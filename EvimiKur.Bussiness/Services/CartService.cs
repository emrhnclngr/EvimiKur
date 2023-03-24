using AutoMapper;
using EvimiKur.Bussiness.CustomExtensions;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Common;
using EvimiKur.Dtos;
using EvimiKur.Dtos.Interfaces;
using EvimiKur.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Services
{
    public class CartService : ICartService
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public CartService(IHttpContextAccessor contextAccessor, IMapper mapper, IProductService productService)
        {
            _contextAccessor = contextAccessor;
            _mapper = mapper;
            _productService = productService;
        }


        public decimal CalculateTotalPrice(decimal unitPrice, int quantity)
        {
            return unitPrice * quantity;
        }



        public void Add(ProductListDto product)
        {
            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet");

            if (productList == null)
            {
                productList = new List<ProductListDto>();
                //product.Quantity = 1;
                productList.Add(product);
            }
            else
            {
                // Eğer sepette aynı ürün varsa, miktarını artır
                var existingProduct = productList.FirstOrDefault(p => p.Id == product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Quantity += product.Quantity;
                    //existingProduct.TotalPrice = CalculateTotalPrice(existingProduct.UnitPrice, existingProduct.Quantity);
                }
                else
                {
                    productList.Add(product);
                }
            }

            _contextAccessor.HttpContext.Response.SetObject("sepet", productList);
        }

        public List<ProductListDto> List()
        {
            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet");

            return productList;
        }

        public void Remove(int productId)
        {
            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet");

            if (productList != null)
            {
                var productToRemove = productList.FirstOrDefault(p => p.Id == productId);
                if (productToRemove != null)
                {
                    var product = new ProductListDto();
                    productList.Remove(productToRemove);
                    _contextAccessor.HttpContext.Response.SetObject("sepet", productList);
                }
            }
        }
        public void IncreaseCartCookie(int id)
        {
            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet");

            if (productList != null)
            {
                var existingProduct = productList.FirstOrDefault(p => p.Id == id);
               
                if (existingProduct != null)
                {
                    
                    existingProduct.Quantity += 1;
                    //existingProduct.TotalPrice = CalculateTotalPrice(existingProduct.UnitPrice, existingProduct.Quantity);
                    
                }
            }

            _contextAccessor.HttpContext.Response.SetObject("sepet", productList);
        }
        public void DecreaseCartCookie(int id)
        {
            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet");

            if (productList != null)
            {
                var existingProduct = productList.FirstOrDefault(p => p.Id == id);

                if (existingProduct != null)
                {
                    if(existingProduct.Quantity > 0)
                    existingProduct.Quantity -= 1;
                    else
                        existingProduct.Quantity = 0;
                    //existingProduct.TotalPrice = CalculateTotalPrice(existingProduct.UnitPrice, existingProduct.Quantity);

                }
            }

            _contextAccessor.HttpContext.Response.SetObject("sepet", productList);
        }
        public void TotalPrice()
        {
            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet");

            if(productList != null)
            {
                decimal totalPrice = 0;
                foreach (var product in productList)
                {
                    decimal productPrice = product.Price;
                    totalPrice = productPrice;
                }
                _contextAccessor.HttpContext.Response.WriteAsync("Toplam Fiyat" + totalPrice);
            }
        }








        //public void IncreaseCartCookie(int id)
        //{
        //    var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet");

        //    if (productList != null)
        //    {
        //        var product = productList.FirstOrDefault(p => p.Id == id);
        //        if (product != null)
        //        {
        //            product.Quantity += 1;
        //            _contextAccessor.HttpContext.Response.SetObject("sepet", productList);
        //        }
        //    }
        //}






        //public void AddToCart(ProductListDto product)
        //{
        //    var productList = _contextAccessor.HttpContext.Session.GetObject<List<ProductListDto>>("sepet");

        //    if(productList == null)
        //    {
        //        productList = new List<ProductListDto>();
        //        productList.Add(product);
        //    }
        //    else
        //    {
        //        productList.Add(product);
        //    }

        //   _contextAccessor.HttpContext.Session.SetObject("sepet", productList);

        //}
        //public void RemoveCart(ProductListDto product)
        //{
        //    var productList = _contextAccessor.HttpContext.Session.GetObject<List<ProductListDto>>("sepet");
        //    productList.Remove(product);
        //    _contextAccessor.HttpContext.Session.SetObject("sepet", productList);
        //}
        //public List<ProductListDto> ProductInTheCart()
        //{
        //    return _contextAccessor.HttpContext.Session.GetObject<List<ProductListDto>>("sepet");
        //}





    }

}

    









   

   

using AutoMapper;
using EvimiKur.Bussiness.CustomExtensions;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Common;
using EvimiKur.Dtos;
using EvimiKur.Dtos.Interfaces;
using EvimiKur.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Services
{
    public class CartService : ICartService
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public CartService(IHttpContextAccessor contextAccessor, IMapper mapper, IProductService productService, IAppUserService appUserService)
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
            var userId = int.Parse((_contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet"+ userId);

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

            _contextAccessor.HttpContext.Response.SetObject("sepet"+userId, productList);
        }

        public List<ProductListDto> List()
        {
            var userId = int.Parse((_contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet" + userId);

            return productList;
        }

        public void Remove(int productId)
        {
            var userId = int.Parse((_contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet" + userId);

            if (productList != null)
            {
                var productToRemove = productList.FirstOrDefault(p => p.Id == productId);
                if (productToRemove != null)
                {
                    var product = new ProductListDto();
                    productList.Remove(productToRemove);
                    _contextAccessor.HttpContext.Response.SetObject("sepet" +userId, productList);
                }
            }
        }
        public void IncreaseCartCookie(int id)
        {
            var userId = int.Parse((_contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet" + userId);

            if (productList != null)
            {
                var existingProduct = productList.FirstOrDefault(p => p.Id == id);
               
                if (existingProduct.Quantity < existingProduct.UnitInStock)
                {
                    
                    existingProduct.Quantity += 1;
                    //existingProduct.TotalPrice = CalculateTotalPrice(existingProduct.UnitPrice, existingProduct.Quantity);
                    
                }
                else
                {
                    existingProduct.Quantity = existingProduct.UnitInStock;
                }
            }

            _contextAccessor.HttpContext.Response.SetObject("sepet" + userId, productList);
        }
        public void DecreaseCartCookie(int id)
        {
            var userId = int.Parse((_contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)).Value);
            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet" + userId);

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

            _contextAccessor.HttpContext.Response.SetObject("sepet" + userId, productList);
        }
       













    }

}

    









   

   

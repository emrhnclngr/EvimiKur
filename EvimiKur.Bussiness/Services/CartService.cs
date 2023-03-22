using AutoMapper;
using EvimiKur.Business.CustomExtensions;
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






        public void AddToCartCookie(ProductListDto product)
        {
            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet");

            if (productList == null)
            {
                productList = new List<ProductListDto>();
                productList.Add(product);
            }
            else
            {
                productList.Add(product);
            }

            _contextAccessor.HttpContext.Response.SetObject("sepet", productList);
        }

        public List<ProductListDto> ProductInTheCart()
        {
            return _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet");
        }

        public async void RemoveCartCookie(int id)
        {
            var productList = _contextAccessor.HttpContext.Request.GetObject<List<ProductListDto>>("sepet");
            var response = await _productService.GetByIdAsync<ProductListDto>(id);
            var product = response.Data;
            productList.Remove(product);
            _contextAccessor.HttpContext.Response.SetObject("sepet", productList);
        }






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

    









   

   

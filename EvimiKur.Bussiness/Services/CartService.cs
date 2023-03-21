using AutoMapper;
using EvimiKur.Business.CustomExtensions;
using EvimiKur.Bussiness.Interfaces;
using EvimiKur.Common;
using EvimiKur.Dtos;
using EvimiKur.Dtos.Interfaces;
using EvimiKur.Entities.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvimiKur.Bussiness.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public CartService(IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }
        public void AddToCart(ProductListDto product)
        {
            var productList = _contextAccessor.HttpContext.Session.GetObject<List<ProductListDto>>("sepet");

            if(productList == null)
            {
                productList = new List<ProductListDto>();
                productList.Add(product);
            }
            else
            {
                productList.Add(product);
            }
            _contextAccessor.HttpContext.Session.SetObject("sepet", productList);
            
            //return new Response<ProductListDto>(ResponseType.Success, "Ürün eklendi.");
        }
        public void RemoveCart(ProductListDto product)
        {
            var productList = _contextAccessor.HttpContext.Session.GetObject<List<ProductListDto>>("sepet");
            productList.Remove(product);
            _contextAccessor.HttpContext.Session.SetObject("sepet", productList);
        }
        public List<ProductListDto> ProductInTheCart()
        {
            return _contextAccessor.HttpContext.Session.GetObject<List<ProductListDto>>("sepet");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Extensions;
using App.Domain.Entities.NoDataBase;
using App.Pages;
using App.Services.Identity.Managers;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class DefaultController : Controller
    {
        private readonly AppUserManager _userManager;
        private readonly AppSignInManager _signInManager;
        private readonly IProductService _productService;
        private readonly IConfigDetailService _configDetailService;
        private readonly IConfigChartService _configChartService;

        public DefaultController(AppUserManager userManager, AppSignInManager signInManager, IProductService productService, IConfigDetailService configDetailService, IConfigChartService configChartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _productService = productService;
            _configDetailService = configDetailService;
            _configChartService = configChartService;
        }

        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                var userArea = await _userManager.FindByNameAsync(User.Identity.Name);

                await _signInManager.SignOutAsync();

                await _userManager.UpdateSecurityStampAsync(userArea);
            }

            return RedirectToPage("/Index");
        }

        [Route("AddToCart/{id}")]
        public async Task<IActionResult> AddToCart(int id)
        {
            if (HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart") == null)
            {
                var cart = new List<CartItem>
                {
                    new CartItem {Product = await _productService.GetProductById(id), Quantity = 1, ProductImage = "imageAddress"}
                };
                HttpContext.Session.SetObjectAsJson("cart", cart);
            }
            else
            {
                var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart");
                var index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartItem { Product = await _productService.GetProductById(id), Quantity = 1 });
                }
                HttpContext.Session.SetObjectAsJson("cart", cart);
            }

            return RedirectToPage("/Cart");
        }

        [Route("removeCart/{id}")]
        public IActionResult Remove(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart");
            var index = IsExist(id);
            cart.RemoveAt(index);
            HttpContext.Session.SetObjectAsJson("cart", cart);
            return RedirectToPage("/Cart");
        }

        private int IsExist(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart");
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }


        [Route("manage/UpdateConfigDetails/")]
        public async Task<JsonResult> UpdateConfigDetails(int id, int productId, int configChartId,int configGroupId, string value)
        {
            var configChartSel = await _configChartService.GetConfigChartById(configChartId);
            var configDetailInDb = await _configDetailService.GetConfigDetailById(id);
            configDetailInDb.ConfigChart = configChartSel;
            configDetailInDb.ConfigChartId = configChartId;
            configDetailInDb.ProductId = productId;
            configDetailInDb.ConfigGroupId = configChartSel.ConfigGroupId;
            configDetailInDb.ProductId = productId;
            configDetailInDb.ConfigGroupId = configGroupId;
            configDetailInDb.Value = value;
            await _configDetailService.SaveChangeAsync();
            System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(1).TotalMilliseconds);
            return Json(true);
        }

    }
}
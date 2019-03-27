using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Convertors;
using App.Core.Extensions;
using App.Domain.Entities.NoDataBase;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Components
{
    public class CartComponent : ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart");
            if (cart != null)
            {
                ViewData["total"] = cart.Sum(item => item.Product.Price * item.Quantity).ToPrice();
            }
            return await Task.FromResult((IViewComponentResult)View("_cartComponent", cart));
        }
    }
}

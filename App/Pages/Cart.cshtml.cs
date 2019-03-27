using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.Convertors;
using App.Core.Extensions;
using App.Domain.Entities.NoDataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class CartModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("cart");
            ViewData["cart"] = cart;
            ViewData["total"] = cart.Sum(item => item.Product.Price * item.Quantity).ToPrice();
            ViewData["SessionId"] = HttpContext.Session.Id;
            return Page();
        }


    }
}
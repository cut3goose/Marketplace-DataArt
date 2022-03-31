using Microsoft.AspNetCore.Mvc;
using OnlineShop.Cart.Domain;
using OnlineShop.Contracts.Cart.CartProductModels;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult DisplayProducts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var cartProductDeleteModel = new CartProductDeleteModel
            {
                ProductId = productId
            };
            _cartService.DeleteCartProduct(cartProductDeleteModel);
            
            return RedirectToAction("DisplayProducts");
        }
    }
}
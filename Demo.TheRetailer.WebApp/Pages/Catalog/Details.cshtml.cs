using Demo.TheRetailer.WebApp.Data;
using Demo.TheRetailer.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Demo.TheRetailer.WebApp.Pages.Catalog
{
    public class DetailsModel : PageModel
    {
        private const int CurrentUserId = 1;

        private readonly TheRetailerDbContext _context;

        public DetailsModel(TheRetailerDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int Quantity { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await AddToBasketAsync();

            return RedirectToPage("/Checkout/Index");
        }

        private async Task AddToBasketAsync()
        {
            var basket = await GetBasket();

            AddItemToBasket(basket);

            await _context.SaveChangesAsync();
        }

        private async Task<Basket> GetBasket()
        {
            var basket = await _context.Baskets
                .Include(x => x.BasketItems)
                .SingleOrDefaultAsync(x => x.UserId == CurrentUserId);

            if (basket != null && basket.ExpiredAt < DateTime.Now)
            {
                _context.Baskets.Remove(basket);
                basket = null;
            }

            if (basket == null)
            {
                basket = CreateBasket();
                _context.Baskets.Add(basket);
            }

            basket.ExpiredAt = DateTime.Now.AddMinutes(10);

            return basket;
        }

        private static Basket CreateBasket()
        {
            return new Basket { UserId = CurrentUserId };
        }

        private void AddItemToBasket(Basket basket)
        {
            const decimal currentPrice = 20;
            const int productId = 20;

            var item = basket.BasketItems.SingleOrDefault(x => x.ProductId == productId);

            if (item == null)
            {
                item = CreateItem(currentPrice, productId);
                basket.BasketItems.Add(item);
            }
        }

        private BasketItem CreateItem(decimal currentPrice, int productId)
        {
            return new BasketItem
            {
                CurrentPrice = currentPrice,
                ProductId = productId,
                Quantity = Quantity
            };
        }
    }
}

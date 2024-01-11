using Demo.TheRetailer.WebApp.Core.Delivery;
using Demo.TheRetailer.WebApp.Data;
using Demo.TheRetailer.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Demo.TheRetailer.WebApp.Pages.Checkout
{
    public class IndexModel : PageModel
    {
        private const int CurrentUserId = 1;

        private readonly TheRetailerDbContext _context;
        private readonly IProvideDeliveryOptions _deliveryOptionsProvider;

        public IndexModel(TheRetailerDbContext context, IProvideDeliveryOptions deliveryOptionsProvider)
        {
            _context = context;
            _deliveryOptionsProvider = deliveryOptionsProvider;
        }

        [BindProperty]
        public int DeliveryOption { get; private set; }
        public IEnumerable<DeliveryOption> DeliveryOptions { get; private set; } = default!;

        [BindProperty]
        public int ShippingAddress { get; private set; }
        public IEnumerable<ShippingAddress> ShippingAddresses { get; private set; } = default!;

        [BindProperty]
        public int PaymentMethod { get; private set; }
        public IEnumerable<PaymentMethod> PaymentMethods { get; private set; } = default!;

        public async Task OnGetAsync()
        {
            ShippingAddresses = await _context.ShippingAddresses.Where(x => x.UserId == CurrentUserId).ToListAsync();
            PaymentMethods = await _context.PaymentMethods.Where(x => x.UserId == CurrentUserId).ToListAsync();
            
            var defaultAddress = ShippingAddresses.Select(x=>x.Postcode).SingleOrDefault();
            if (!string.IsNullOrWhiteSpace(defaultAddress))
            {
                DeliveryOptions = await _deliveryOptionsProvider.GetAsync(defaultAddress);
            }
        }
    }
}

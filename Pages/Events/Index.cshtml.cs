using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VendorEvents_1.Models;

namespace VendorEvents_1.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly VendorEvents_1.Models.EventContext _context;

        public IndexModel(VendorEvents_1.Models.EventContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Event != null)
            {
                Event = await _context.Event.ToListAsync();
            }
        }
    }
}

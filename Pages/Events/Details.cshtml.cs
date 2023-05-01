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
    public class DetailsModel : PageModel
    {
        private readonly VendorEvents_1.Models.EventContext _context;

        public DetailsModel(VendorEvents_1.Models.EventContext context)
        {
            _context = context;
        }

      public Event Event { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

            var event = await _context.Event.FirstOrDefaultAsync(m => m.EventID == id);
            if (event == null)
            {
                return NotFound();
            }
            else 
            {
                Event = event;
            }
            return Page();
        }
    }
}

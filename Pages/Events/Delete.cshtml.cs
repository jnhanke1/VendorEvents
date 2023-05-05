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
    public class DeleteModel : PageModel
    {
        private readonly VendorEvents_1.Models.EventContext _context;

        public DeleteModel(VendorEvents_1.Models.EventContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

            var myevent = await _context.Event.FirstOrDefaultAsync(m => m.EventID == id);

            if (myevent == null)
            {
                return NotFound();
            }
            else 
            {
                Event = myevent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }
            var myevent = await _context.Event.FindAsync(id);

            if (myevent != null)
            {
                Event = myevent;
                _context.Event.Remove(Event);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

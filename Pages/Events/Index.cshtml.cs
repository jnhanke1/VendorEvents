using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VendorEvents_1.Models;
using Microsoft.AspNetCore.Mvc.Rendering; 

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
                Event = await _context.Event.Include(e => e.EventProducts!).ThenInclude(ep => ep.Product).ToListAsync(); //bring in all data for an event. .include --includes event product association table, then product info. 
            }
        }

        //for paging:
        [BindProperty(SupportsGet = true)]
        public int PageNum {get;set;} =1;
        public int PageSize {get; set;} = 10;
        
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}

        public SelectList SortList {get; set;}

        public async Task OnGetSortAsync()
        {
            var query = _context.Event.Select(e => e); 

            switch(CurrentSort)
            {
                case "date_asc":
                    query = query.OrderBy(e => e.EventStartDate); 
                    break;
                case "date_desc":
                    query = query.OrderByDescending(e => e.EventStartDate); 
                    break; 
                case "by_location": 
                    query = query.OrderBy(e => e.EventLocation); 
                    break; 
            }


        }

    }
}

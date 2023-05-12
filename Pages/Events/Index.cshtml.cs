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

        // Paging support
        // PageNum is the current page number we are on
        // PageSize is how many records will be displayed per page. 
        // PageNum needs BindProperty because the user decides which page we are on.
        // The user selects the page number
        // SupportsGet = true allows us to pass the PageNum through the URL with an HTTP Get Parameter 
        // This is necessary, because page numbers are not passed through normal forms

        //for paging:
        [BindProperty(SupportsGet = true)]
        public int PageNum {get;set;} = 1;
        public int PageSize {get; set;} = 10;

        //sorting support:
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;} = string.Empty; 

        //second sorting technique with a SelectList 

        public SelectList SortList {get; set;} = default!; 


        public async Task OnGetAsync() //add in paging to OnGetAsync.   
        {
            if (_context.Event != null)
            {
 
                //Event = await _context.Event.ToListAsync(); 
                //sorting support
                //break up query. Do basic query first, that just selects all events.
                var query = _context.Event.Include(e => e.EventProducts).Select(e => e); 
                List<SelectListItem> sortItems = new List<SelectListItem> {
                    new SelectListItem { Text = "Booked Events", Value = "booked_asc"},
                    new SelectListItem { Text = "Event Date Ascending", Value = "date_asc" }, 
                    new SelectListItem { Text = "Event Date Descending", Value = "date_desc"}, 
                    new SelectListItem { Text = "Event Name", Value = "name_asc"}, 
                    new SelectListItem { Text = "Location", Value = "loc_asc"}
                };
                SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);


                switch (CurrentSort)
                {
                    //if user selected "booked_asc", modify query to sort by booked, then date ascending order:
                    case "booked_asc":
                    query = query.OrderByDescending(e => e.EventBooked).ThenBy(e => e.EventStartDate); 
                    break; 
                    //if user selected "date_asc", modify query to sort by date ascending order
                    case "date_asc":
                    query = query.OrderBy(e => e.EventStartDate); 
                    break; 
                    //if user selected "date_desc", modify query to sort by date descending order: 
                    case "date_desc":
                    query = query.OrderByDescending(e => e.EventStartDate); 
                    break; 
                    //if user selected "name_asc", modify query to sort by event name ascending: 
                    case "name_asc":
                    query = query.OrderBy(e => e.EventName); 
                    break; 
                    //if user selected "loc_asc", modify query to sort by location ascending order: 
                    case "loc_asc":
                    query = query.OrderBy(e => e.EventLocation); 
                    break; 
                    default: 
                    query = query.OrderByDescending(e => e.EventBooked).ThenBy(e => e.EventStartDate); 
                    break; 
                }

                //retrieve just the events for teh page we are on: 
                //use .Skip() and .Take() to select them:
                Event = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();

        
        //calls list of events without sorting or paging:
//            if (_context.Event != null)
 //           {
   //             Event = await _context.Event.Include(e => e.EventProducts!).ThenInclude(ep => ep.Product).ToListAsync(); //bring in all data for an event. .include --includes event product association table, then product info. 
    //        }
            }
        }
    }
}

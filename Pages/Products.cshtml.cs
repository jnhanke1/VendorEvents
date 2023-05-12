using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VendorEvents_1.Models;
using System.ComponentModel.DataAnnotations; 
using Microsoft.AspNetCore.Mvc.Rendering; 
using Microsoft.Extensions.Configuration; 

//intention of this page is to see all products and their details.

namespace VendorEvents_1.Pages
{
    public class ProductModel : PageModel
    {

        private readonly VendorEvents_1.Models.EventContext _context;

        public ProductModel(VendorEvents_1.Models.EventContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

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
            if (_context.Product != null)
            {
                //Product = await _context.Product.ToListAsync(); 
                //sorting support
                //break up query. Do basic query first, that just selects all events.
                var query = _context.Product.Include(e => e.EventProducts).Select(e => e); 
                List<SelectListItem> sortItems = new List<SelectListItem> {
                    new SelectListItem { Text = "Products Ascending", Value = "prod_asc"},
                    new SelectListItem { Text = "Products Descending", Value = "prod_desc"}, 
                };
                SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);


                switch (CurrentSort)
                {
                    //if user selected "prod_asc", modify query to sort by booked, then date ascending order:
                    case "prod_asc":
                    query = query.OrderBy(e => e.ProductName);
                    break; 
                    //if user selected "prod_desc", modify query to sort by date ascending order
                    case "prod_desc":
                    query = query.OrderByDescending(e => e.ProductName); 
                    break; 
                    default: 
                    query = query.OrderBy(e => e.ProductName); 
                    break; 
                }

                //retrieve just the events for the page we are on: 
                //use .Skip() and .Take() to select them:
                Product = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();

        
        //calls list of events without sorting or paging:
//            if (_context.Event != null)
 //           {
   //             Event = await _context.Event.Include(e => e.EventProducts!).ThenInclude(ep => ep.Product).ToListAsync(); //bring in all data for an event. .include --includes event product association table, then product info. 
    //        }
            }
        }
    }
}

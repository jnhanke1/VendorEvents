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

namespace VendorEvents_1.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger; 
        private readonly VendorEvents_1.Models.EventContext _context;

        public DetailsModel(VendorEvents_1.Models.EventContext context, ILogger<DetailsModel> logger) //logging support.
        {
            _context = context;
            _logger = logger; 
        }

        [BindProperty]
        public Event Event { get; set; } = default!; 
        
        [BindProperty]
        public int ProductIDToDelete {get; set;}

        [BindProperty]
        [Display(Name = "Product")]
        public int ProductIDToAdd {get; set;}

        public List<Product> AllProducts {get; set;} = default!; 
        public SelectList ProductsDropDown {get; set;} = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

            var myevent = await _context.Event.Include(e => e.EventProducts!).ThenInclude(ep => ep.Product).FirstOrDefaultAsync(m => m.EventID == id); //add in event info
            AllProducts = await _context.Product.ToListAsync(); 
            ProductsDropDown = new SelectList(AllProducts, "ProductID", "ProductName", "ProductDescription"); 
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

        public async Task<IActionResult> OnPostDeleteProductAsync(int? id) //user selects product to delete. supplies us an ID they want to delete via hidden property on form. bind property for int producttodelete.
        {
            _logger.LogWarning($"OnPost: EventID {id}, DELETE product {ProductIDToDelete}"); 
            if(id == null)
            {
                return NotFound(); 
            }

            var myevent = await _context.Event.Include(e => e.EventProducts!).ThenInclude(ep => ep.Product).FirstOrDefaultAsync(m => m.EventID == id);  //select event info.

            if(Event == null)
            {
                return NotFound(); 
            }
            else
            {
                Event = myevent; 
            }

            EventProduct productToDelete = _context.EventProduct.Find(ProductIDToDelete, id.Value)!; //searches for product id and event id to delete.

            if (productToDelete != null)
            {
                _context.Remove(productToDelete); 
                _context.SaveChanges(); 
            }
            else
            {
                _logger.LogWarning("Product NOT listed for sale at Event."); 
            }
            
            return RedirectToPage(new {id = id}); //reload same details page again for this event. 
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            _logger.LogWarning($"OnPost: EventID {id}, ADD product {ProductIDToAdd}"); //option to add a new product to an event through details screen.
            if(ProductIDToAdd == 0)
            {
                ModelState.AddModelError("ProductIDToAdd", "This is a required field."); //return error if no products chosen.
                return Page(); 
            }
            if(id == null)
            {
                return NotFound(); 
            }
            
            var myevent = await _context.Event.Include(e => e.EventProducts!).ThenInclude(ep => ep.Product).FirstOrDefaultAsync(m => m.EventID == id); 
            AllProducts = await _context.Product.ToListAsync();
            ProductsDropDown = new SelectList(AllProducts, "ProductID", "ProductDescription"); 

            if (Event == null)
            {
                return NotFound(); 
            }
            else
            {
                Event = myevent; 
            }

            if(!_context.EventProduct.Any(ep => ep.ProductID == ProductIDToAdd && ep.EventID == id.Value))
            {
                EventProduct productToAdd = new EventProduct {EventID = id.Value, ProductID = ProductIDToAdd}; //list product for event
                _context.Add(productToAdd); 
                _context.SaveChanges(); 
            }
            else
            {
                _logger.LogWarning("Product already listed to sell for this Event."); //make sure product isn't already listed for this event. 
            }

            return RedirectToPage(new {id = id}); 

        }
    }
}

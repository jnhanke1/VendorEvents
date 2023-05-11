using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; 
using VendorEvents_1.Models;

namespace VendorEvents_1.Pages.Events
{
    public class EditModel : PageModel
    {

        private readonly ILogger<EditModel> _logger;
        private readonly VendorEvents_1.Models.EventContext _context;

        public EditModel(VendorEvents_1.Models.EventContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger; 
        }

        [BindProperty]
        public Event Event { get; set; } = default!; //this is the specific event you are editing. 
        public List<Product> Products {get; set;} = default!; //this is a list of all products tied to this event -- step 1.

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Event == null)
            {
                return NotFound();
            }

            //bring in related data using Include and ThenInclude -- step 2.
            var myevent =  await _context.Event.Include(e => e.EventProducts!).ThenInclude(ep => ep.Product).FirstOrDefaultAsync(m => m.EventID == id);
            //get a list of all products. this list is used to make checkboxes!!!:
            Products = _context.Product.ToList();
            if (myevent == null)
            {
                return NotFound();
            }
            Event = myevent;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        //always add in the logging to catch errors as they occur and identify solutions!
        public async Task<IActionResult> OnPostAsync(int[] selectedProducts)
        {
           // if (!ModelState.IsValid)
           // {

          //  _logger.LogWarning("INVALID STATE"); 
          //  foreach (var modelError in ModelState)
          //  {
          //      string propertyName = modelError.Key;
          //      if(modelError.Value.Errors.Count > 0)
          //      {
          //          _logger.LogWarning($"ERROR: {propertyName} {modelError.Value.Errors[0].ErrorMessage}"); 
           //     }
          //  }
           //     return Page();
           // }

            //_context.Attach(event).State = entitystate.Modified - finds the event you want to update and update all their 'normal properties' 
            _context.Attach(Event).State = EntityState.Modified;
            var eventToUpdate = await _context.Event.Include(e => e.EventProducts!).ThenInclude(ep => ep.Product).FirstOrDefaultAsync(m => m.EventID == Event.EventID); //matches event to EventID
            if (eventToUpdate != null)
            {
                eventToUpdate.EventName = Event.EventName; //have to update event info
                eventToUpdate.EventStartDate = Event.EventStartDate; //updates event info 
                eventToUpdate.EventLocation = Event.EventLocation; 
                eventToUpdate.EventComments = Event.EventComments; 
                eventToUpdate.EventContactName = Event.EventContactName; 
                eventToUpdate.EventPhone = Event.EventPhone; 
                eventToUpdate.EventEmail = Event.EventEmail; 
                eventToUpdate.EventCost = Event.EventCost; 
                eventToUpdate.EventBooked = Event.EventBooked; 
                eventToUpdate.EventPaid = Event.EventPaid; 


                //separate method to update the products -- too complex here. 
                UpdateEventProducts(selectedProducts, eventToUpdate); //new method -- pass in list of selected products and the event to update. 
            }
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(Event.EventID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EventExists(int id)
        {
          return _context.Event.Any(e => e.EventID == id);
        }


        private void UpdateEventProducts(int[] selectedProducts, Event eventToUpdate)
        {
            if (selectedProducts == null)
            {
                eventToUpdate.EventProducts = new List<EventProduct>();
                return; 
            }

            //make two lists -- current products and selected products to compare and determine updates. 
            List<int> currentProducts = eventToUpdate.EventProducts!.Select(p => p.ProductID).ToList();
            List<int> selectedProductsList = selectedProducts.ToList(); 

            foreach (var product in _context.Product) //loop through all products in database.
            {
                if(selectedProductsList.Contains(product.ProductID)) //if selected product is in this list.
                {
                    if (!currentProducts.Contains(product.ProductID)) //and event is not included
                    {
                        //add product here:
                        eventToUpdate.EventProducts!.Add(
                            new EventProduct {EventID = eventToUpdate.EventID, ProductID = product.ProductID}
                        ); //save changes
                        _logger.LogWarning($"Event {eventToUpdate.EventName}, on {eventToUpdate.EventStartDate} ({eventToUpdate.EventID}) - ADD {product.ProductID} - {product.ProductName}"); 
                    }
                }
                else 
                {
                    if (currentProducts.Contains(product.ProductID)) //if current products list includes one product not in selected list - remove product!
                    {
                        //remove product:
                        EventProduct productToRemove = eventToUpdate.EventProducts!.SingleOrDefault(e => e.ProductID == product.ProductID)!; 
                        _context.Remove(productToRemove); //save changes
                        _logger.LogWarning($"Event {eventToUpdate.EventName}, on {eventToUpdate.EventStartDate} ({eventToUpdate.EventID}) - DELETE {product.ProductID} - {product.ProductName}"); 
                    }
                }
            }
        }
    }
}

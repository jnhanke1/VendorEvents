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
        //dependency injection part 2
        private readonly ILogger<ProductModel> _logger; 
        private readonly VendorEvents_1.Models.EventContext _context;

        //property that represents our list of products to display:
        public List<Product> Products {get; set;}
        public ProductModel(EventContext context, ILogger<ProductModel> logger) //logging support.
        {
            _context = context;
            _logger = logger; 
        }

        public IList<Product> Product {get; set; } = default!; 


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

        //search bar support: 
        public string ProductNameSort {get; set; }
        public string DescSort {get; set; }
        public string CurrentFilter {get; set; }

        //sorting support:
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set; } = string.Empty; 

        public async Task OnGetAsync(string sortOrder, string searchString)
        {

            //for search bar:
            ProductNameSort = String.IsNullOrEmpty(sortOrder) ? "prod_asc" : ""; 
            DescSort = string.IsNullOrEmpty(sortOrder) ? "desc_asc" : ""; 

            //bring in all products from the database.
            //_context is our 'db' variable, represents database.
         //   Products = _context.Product.ToList(); 

            //for search bar: 
            CurrentFilter = searchString; 
            IQueryable<Product> productsIQ = from p in _context.Product select p; 

            if (!String.IsNullOrEmpty(searchString))
            {
                productsIQ = productsIQ.Where(p => p.ProductName.Contains(searchString) || p.ProductDescription.Contains(searchString)); 
            }

            //to sort products: 
            switch(sortOrder)
            {
                case "prod_asc": 
                productsIQ = productsIQ.OrderBy(p => p.ProductName); 
                break ; 
                case "desc_asc": 
                productsIQ = productsIQ.OrderBy(p => p.ProductDescription); 
                break; 
                case "prod_desc": 
                productsIQ = productsIQ.OrderByDescending(p => p.ProductName); 
                break; 
                case "desc_desc":
                productsIQ = productsIQ.OrderByDescending(p => p.ProductDescription); 
                break; 
                default: 
                productsIQ = productsIQ.OrderBy(p => p.ProductName); 
                break; 
            }

                //retrieve just the events for teh page we are on: 
                //use .Skip() and .Take() to select them:
                Product = await productsIQ.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }


    }
}
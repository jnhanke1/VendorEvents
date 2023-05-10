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

//intention of this page is to see all products and their details.

namespace VendorEvents_1.Pages
{
    public class ProductModel : PageModel
    {
        //dependency injection part 2
        private readonly ILogger<ProductModel> _logger; 
        private readonly VendorEvents_1.Models.EventContext _context;

        //property that represents our list of professors to display:
        public List<Product> Products {get; set;}
        public ProductModel(EventContext context, ILogger<ProductModel> logger) //logging support.
        {
            _context = context;
            _logger = logger; 
        }

        public void OnGet()
        {
            //bring in all products from the database.
            //_context is our 'db' variable, represents database.
            Products = _context.Product.ToList(); 
        }
    }
}
using System.ComponentModel.DataAnnotations;   //required for Data validation.
using System; 
using System.Collections.Generic; 

namespace VendorEvents_1.Models //namespace.foldername
{
    public class Product
    {
        public int ProductID {get; set; } //Primary Key

        [Display(Name = "Product Name")]
        [Required]
        public string ProductName {get; set;} = string.Empty; 

        [Display(Name = "Product Description")]
        public string ProductDescription {get; set;} = string.Empty; 

        [Required]
        public decimal ProductPrice {get; set;}

        public int ProductQty {get; set;}

        public string ProductSource {get; set;} = string.Empty; 

        public int EventID {get; set;} //Foreign Key linking Product to Event.

        public Event? Event {get; set;} //navigation property

        public List<EventProduct>? EventProducts {get; set;} = default!; //Navigation Property. Products can have MANY EventProducts.


        public override string ToString()
        {
            return $"({ProductID} - {ProductName} /n /t Retail Price: {ProductPrice} | Quantity on Hand: {ProductQty}  /n /t {ProductDescription}, /n /t Vendor Resource: {ProductSource})"; 
        }
    }
}
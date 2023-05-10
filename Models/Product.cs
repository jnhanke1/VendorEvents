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

        [Display(Name = "Price")]
        [Required]
        public decimal ProductPrice {get; set;}

        [Display(Name = "Qty")]
        public int ProductQty {get; set;}

        [Display(Name = "Product Source")]
        public string ProductSource {get; set;} = string.Empty; 
        
        [Display(Name = "ProductSample")]
        public string ProductImage {get; set;} = string.Empty; 

       // public int EventID {get; set;} //Foreign Key linking Product to Event.  - removed per KD

       // public Event? Event {get; set;} //navigation property - removed per KD
       
        public List<EventProduct>? EventProducts {get; set;} = default!; //Navigation Property. Products can have MANY EventProducts.


        //public override string ToString()
        //{
        //    return $"({ProductID} - {ProductName} /n /t Retail Price: {ProductPrice} | Quantity on Hand: {ProductQty}  /n /t {ProductDescription}, /n /t Vendor Resource: {ProductSource})"; 
        //}


    }
}
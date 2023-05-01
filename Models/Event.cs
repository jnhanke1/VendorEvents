using System.ComponentModel.DataAnnotations;   //required for Data validation.
using System; 
using System.Collections.Generic; 

namespace VendorEvents_1.Models //namespace.Folder name
{
    public class Event
    {
        public int EventID {get; set;} //PrimaryKey

        [Display(Name = "Event Name")]
        [Required]
        public string EventName {get; set;} = string.Empty; 

        public string EventLocation {get; set; } = string.Empty; 

        [Display(Name = "Event Start")]
        [Required]
        public DateTime EventStartDate {get; set;}

        public decimal EventCost {get; set;}

        public string EventContactName {get; set;} = string.Empty; 

        [Phone]
        public int EventPhone {get; set;} 

        [EmailAddress]
        public string EventEmail {get; set;} = string.Empty; 

        public string EventComments {get; set;} = string.Empty;

        [StringLength(1)]
        public string EventPaid {get;set;} = string.Empty;
        
        [StringLength(1)]
        public string EventBooked {get; set;} = string.Empty; 

        
        public List<EventProduct>? EventProducts {get; set;} = default!;  //Navigation Property. One event can have many products offered. 

        public override string ToString()
        {
            return $"({EventStartDate.Date} {EventStartDate.TimeOfDay} | {EventName}  /n /t Location: {EventLocation}, Cost: ${EventCost} /n Event Booked: {EventBooked}  |  Event Paid: {EventPaid} /n /t Comments: {EventComments}  /n /t Contact: {EventContactName}, {EventPhone}, {EventEmail})"; 
    
        }
    }

    public class EventProduct
    {
        public int EventID {get; set;} //composite primary key; foreign key 1
        public int ProductID {get; set;} //composite primary key, foreign key 2
        public Event Event {get; set;} = default!; //navigation property. One event per EventProduct.
        public Product Product {get; set;} = default!; //navigation property. one product per EventProduct. 
    }
}


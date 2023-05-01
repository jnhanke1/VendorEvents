using Microsoft.EntityFrameworkCore; 

namespace VendorEvents_1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EventContext(serviceProvider.GetRequiredService<DbContextOptions<EventContext>>()))
            {
                //look for any events. 
                if(context.Event.Any())
                {
                    return; //db has been seeded. 
                }

                List<Event> events = new List<Event> {
                    new Event {EventName = "Fiesta On The Square", EventLocation = "Woflin Square - Amarillo, TX", EventStartDate = DateTime.Parse("5/6/2023 9:00 am"), EventCost = 50M, EventContactName = "McKay Anderson", EventPhone = 000-000-0000, EventEmail = "mckay@maysinvestments.com", EventComments = "**Repeat Event -- outdoors. Bring Tent**", EventPaid = "Y", EventBooked = "Y"},
                    new Event {EventName = "Caprock Roundup & Old Settler's Reunion", EventLocation = "Claude, TX", EventStartDate = DateTime.Parse("7/8/2023"), EventCost = 50M, EventContactName = "Claude Chamber of Commerce", EventPhone = 806-310-9044, EventEmail = "claudetxchamber@gmail.com", EventComments = "Outdoors - Bring Tent", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Memorial Bash 2023", EventLocation = "City Park - Fritch, TX", EventStartDate = DateTime.Parse("5/27/2023"), EventCost = 40M, EventContactName = "Whitney Phillips", EventPhone = 806-676-5269, EventEmail = "phillipswhitney94@gmail.com", EventComments = "Indoor Event. 20x20 booth reserved.", EventPaid = "N", EventBooked = "Y"}
                    }; 
                context.AddRange(events); 

                List<Product> products = new List<Product> {
                    new Product {ProductName = "Wristlet - Rainbow", ProductDescription = "Silicone wristlet with pendant", ProductPrice = 15.00M, ProductQty = 3, ProductSource = "KW Laser Supplies"},
                    new Product {ProductName = "Wristlet - Green Glow in the Dark", ProductDescription = "Silicone wristlet with pendant", ProductPrice = 15.00M, ProductQty = 3, ProductSource = "KW Laser Supplies"},                 
                    new Product {ProductName = "MOM Sign - Black/White", ProductDescription = "18x12 MOM sign - White Background, Black text", ProductPrice = 35M, ProductQty = 1, ProductSource = "Handmade"}                
                };
                    context.AddRange(products); 


            }

        }
    }
}
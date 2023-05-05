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
                    new Event {EventName = "Fiesta On The Square", EventLocation = "Woflin Square - Amarillo, TX", EventStartDate = DateTime.Parse("5/6/2023 9:00 am"), 
                    EventCost = 50M, EventContactName = "McKay Anderson", EventPhone = 000-000-0000, EventEmail = "mckay@maysinvestments.com", 
                    EventComments = "**Repeat Event -- outdoors. Bring Tent**", EventPaid = "Y", EventBooked = "Y"},
                    new Event {EventName = "Caprock Roundup & Old Settler's Reunion", EventLocation = "Claude, TX", EventStartDate = DateTime.Parse("7/8/2023"), 
                    EventCost = 50M, EventContactName = "Susan", EventPhone = 806-310-9044, EventEmail = "claudetxchamber@gmail.com", 
                    EventComments = "Outdoors - Bring Tent", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Memorial Bash 2023", EventLocation = "City Park - Fritch, TX", EventStartDate = DateTime.Parse("5/27/2023"), 
                    EventCost = 40M, EventContactName = "Whitney Phillips", EventPhone = 806-676-5269, EventEmail = "phillipswhitney94@gmail.com", 
                    EventComments = "Indoor Event. 20x20 booth reserved. Benefits Fritch Volunteer Firefighters Association", EventPaid = "N", EventBooked = "Y"},
                    new Event {EventName = "4th of July Bash", EventLocation = "Canadian Courthouse, Canadian, TX", EventStartDate = DateTime.Parse("7/4/23"), 
                    EventCost = 0M, EventContactName = "Jackie McPherson", EventPhone = 000-000-0000, EventEmail = " ", 
                    EventComments = " Outdoor booths only. No electriciy", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Tulia Summer Arts & Crafts Show", EventLocation = "Senior Citizen's Center, Tulia, TX", EventStartDate = DateTime.Parse("6/10/23"), 
                    EventCost = 40M, EventContactName = "Tulia Senior Citizens Center", EventPhone = 806-995-2296, EventEmail = "bbstcreations@yahoo.com", 
                    EventComments = " ", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Summer Kickoff", EventLocation = "Starlight Ranch, Amarillo, TX", EventStartDate = DateTime.Parse("5/27/23"), 
                    EventCost = 75.00M, EventContactName = "Amber White", EventPhone = 000-000-0000, EventEmail = "a.white@familyfunfestivals.org", 
                    EventComments = "Outdoor --  price is 1/2 standard fee", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Wildcat Country Craft Fair", EventLocation = "River Road Middle School, Amarillo, TX", EventStartDate = DateTime.Parse("5/6/23 9:00 AM"), 
                    EventCost = 40M, EventContactName = "Tiffany Lamb", EventPhone = 000-000-0000, EventEmail = "riverroadmsboosters@gmail.com", 
                    EventComments = "Indoor fee - $40. Outdoor booths - $20.", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Contagion Athletics Small Business Fair", EventLocation = "Contagion Athletics, Amarillo, TX", EventStartDate = DateTime.Parse("7/23/23"), 
                    EventCost = 150M, EventContactName = "Kevin", EventPhone = 806-599-4200, EventEmail = " ", 
                    EventComments = "Outdoor, 6' table booth - $35. Indoor booths start at 150 (upstairs)", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "St. Pat5rick's Day Main Street Market", EventLocation = "Shamrock, TX", EventStartDate = DateTime.Parse("3/19/23"), 
                    EventCost = 75M, EventContactName = "Wayne", EventPhone = 806-334-0777, EventEmail = "shamrock.vendors@yahoo.com", 
                    EventComments = "Fee is for both Saturday & Sunday. Indoors. 10 AM - 4 PM both days.", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Sip & Shop", EventLocation = "Craft Cocktail Lounge, 626 S. Polk, Amarillo, TX", EventStartDate = DateTime.Parse("5/20/23 2:00 PM"), 
                    EventCost = 0M, EventContactName = " ", EventPhone = 000-000-0000, EventEmail = "email@email.com", 
                    EventComments = "Indoors, 2-6 PM", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Canadian 4th of July Rodeo", EventLocation = "Canadian, TX", EventStartDate = DateTime.Parse("7/1/23"), 
                    EventCost = 50M, EventContactName = "Cherakee Wilson", EventPhone = 806-255-0034, EventEmail = "email@email.com", 
                    EventComments = "Outdoor at Rodeo, $50 per day. Option to sign up June 29-30 July 1, 4.", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Boomtown Vendor Show", EventLocation = "Borger Aluminum Dome, Borger, TX", EventStartDate = DateTime.Parse("5/6/23"), 
                    EventCost = 0M, EventContactName = "Misty Storm", EventPhone = 806-395-7797, EventEmail = "email@email.com", 
                    EventComments = "xyz", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Straight 8 Tournament", EventLocation = "Cactus Bar, Amarillo, TX", EventStartDate = DateTime.Parse("6/3/23 12:00 PM"), 
                    EventCost = 35M, EventContactName = "LeeOra Avant", EventPhone = 806-316-8243, EventEmail = "l.c.glitter.desgin@gmail.com", 
                    EventComments = "benefit fundraiser", EventPaid = "N", EventBooked = "N"}

                    }; 
                context.AddRange(events); 

                List<Product> products = new List<Product> {
                    new Product {ProductName = "Wristlet - Rainbow", ProductDescription = "Silicone wristlet with pendant", ProductPrice = 15.00M, ProductQty = 3, ProductSource = "KW Laser Supplies"},
                    new Product {ProductName = "Wristlet - Green Glow in the Dark", ProductDescription = "Silicone wristlet with pendant", ProductPrice = 15.00M, ProductQty = 3, ProductSource = "KW Laser Supplies"},                 
                    new Product {ProductName = "Wristlet - Pink Glow in the Dark", ProductDescription = "Silicone wristlet with pendant", ProductPrice = 15.00M, ProductQty = 3, ProductSource = "KW Laser Supplies"},                 
                    new Product {ProductName = "Wristlet - Yellow Glow in the Dark", ProductDescription = "Silicone wristlet with pendant", ProductPrice = 15.00M, ProductQty = 3, ProductSource = "KW Laser Supplies"},                 
                    new Product {ProductName = "MOM Sign - Black/White", ProductDescription = "18x12 MOM sign - White Background, Black text", ProductPrice = 35M, ProductQty = 1, ProductSource = "Handmade"}                
                };
                    context.AddRange(products); 

                List<EventProduct> sell = new List<EventProduct>{
                    new EventProduct {ProductID = 1, EventID = 1},
                    new EventProduct {ProductID = 2, EventID = 1},
                    new EventProduct {ProductID = 2, EventID = 2},
                    new EventProduct {ProductID = 3, EventID = 1}                   
                }; 
                context.AddRange(sell);

                context.SaveChanges();
            }

        }
    }
}
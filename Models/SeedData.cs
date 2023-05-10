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
                    new Event {EventName = "Fiesta On The Square", EventLocation = "Woflin Square - Amarillo, TX", EventStartDate = DateTime.Parse("5/6/2023 9:00:00"), 
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
                    new Event {EventName = "Wildcat Country Craft Fair", EventLocation = "River Road Middle School, Amarillo, TX", EventStartDate = DateTime.Parse("5/6/23 9:00:00"), 
                    EventCost = 40M, EventContactName = "Tiffany Lamb", EventPhone = 000-000-0000, EventEmail = "riverroadmsboosters@gmail.com", 
                    EventComments = "Indoor fee - $40. Outdoor booths - $20.", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Contagion Athletics Small Business Fair", EventLocation = "Contagion Athletics, Amarillo, TX", EventStartDate = DateTime.Parse("7/23/23"), 
                    EventCost = 150M, EventContactName = "Kevin", EventPhone = 806-599-4200, EventEmail = " ", 
                    EventComments = "Outdoor, 6' table booth - $35. Indoor booths start at 150 (upstairs)", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "St. Patrick's Day Main Street Market", EventLocation = "Shamrock, TX", EventStartDate = DateTime.Parse("3/19/23"), 
                    EventCost = 75M, EventContactName = "Wayne", EventPhone = 806-334-0777, EventEmail = "shamrock.vendors@yahoo.com", 
                    EventComments = "Fee is for both Saturday & Sunday. Indoors. 10 AM - 4 PM both days.", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Sip & Shop", EventLocation = "Craft Cocktail Lounge, 626 S. Polk, Amarillo, TX", EventStartDate = DateTime.Parse("5/20/23 2:00:00 PM"), 
                    EventCost = 0M, EventContactName = " ", EventPhone = 000-000-0000, EventEmail = "email@email.com", 
                    EventComments = "Indoors, 2-6 PM", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Canadian 4th of July Rodeo", EventLocation = "Canadian, TX", EventStartDate = DateTime.Parse("7/1/23"), 
                    EventCost = 50M, EventContactName = "Cherakee Wilson", EventPhone = 806-255-0034, EventEmail = "email@email.com", 
                    EventComments = "Outdoor at Rodeo, $50 per day. Option to sign up June 29-30 July 1, 4.", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Boomtown Vendor Show", EventLocation = "Borger Aluminum Dome, Borger, TX", EventStartDate = DateTime.Parse("5/6/23"), 
                    EventCost = 0M, EventContactName = "Misty Storm", EventPhone = 806-395-7797, EventEmail = "email@email.com", 
                    EventComments = "indoor event. Text to reserve.", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Straight 8 Tournament", EventLocation = "Cactus Bar, Amarillo, TX", EventStartDate = DateTime.Parse("6/3/23 12:00:00 PM"), 
                    EventCost = 35M, EventContactName = "LeeOra Avant", EventPhone = 806-316-8243, EventEmail = "l.c.glitter.desgin@gmail.com", 
                    EventComments = "benefit fundraiser", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Special Spaces Amarillo Spring Fling", EventLocation = "AACAL, 1100 N Forest, Amarillo, TX", EventStartDate = DateTime.Parse("5/0/2023"), 
                    EventCost = 60M, EventContactName = "Carol McKinney", EventPhone = 000-000-0000, EventEmail = "email@email.com", 
                    EventComments = "$2 Admissions fee. Indoors. Bringing Donation item", EventPaid = "Y", EventBooked = "Y"},
                    new Event {EventName = "ACAPTO Market", EventLocation = "Amarillo Collegiate Academy, 6000 S. Georgia, Amarillo, TX", EventStartDate = DateTime.Parse("10/14/23"), 
                    EventCost = 40M, EventContactName = "Sarah Burns", EventPhone = 000-000-0000, EventEmail = "acaptomail@gmail.com", 
                    EventComments = "Outdoor", EventPaid = "N", EventBooked = "N"},                    
                    new Event {EventName = "Fritch Howdy Neighbor Day", EventLocation = "Fritch, TX", EventStartDate = DateTime.Parse("9/16/23"), 
                    EventCost = 0M, EventContactName = "Fritch Chamber of Commerce", EventPhone = 000-000-0000, EventEmail = "fritchchamber@gmail.com", 
                    EventComments = "**Event Cancelled**", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Fritch Winter Bazaar", EventLocation = "Fritch, TX", EventStartDate = DateTime.Parse("12/2/23"), 
                    EventCost = 0M, EventContactName = " ", EventPhone = 000-000-0000, EventEmail = "fritchchamber@gmail.com", 
                    EventComments = "**Event Cancelled**", EventPaid = "N", EventBooked = "N"},     
                    new Event {EventName = "Iron Horse Shootout", EventLocation = "Amarillo, TX", EventStartDate = DateTime.Parse("7/19/23"), 
                    EventCost = 0M, EventContactName = "Suzanne / Cody", EventPhone = 000-000-0000, EventEmail = "email@email.com", 
                    EventComments = "Hosted by the 100 Club. Booth onsite to offer event-related items only. Event dates: 7/19/23 - 7/22/23.", EventPaid = "N", EventBooked = "Y"},
                    new Event {EventName = "Old Sorehead Trade Days ", EventLocation = "Snyder, TX", EventStartDate = DateTime.Parse("4/15/23"), 
                    EventCost = 0M, EventContactName = " ", EventPhone = 000-000-0000, EventEmail = "clearwatercreek@outlook.com", 
                    EventComments = "Two-day event: 4/15/23 - 4/16/23.  ", EventPaid = "N", EventBooked = "N"},     
                    new Event {EventName = "Dirt Dreamer Road", EventLocation = "Snyder, TX", EventStartDate = DateTime.Parse("6/16/23"), 
                    EventCost = 0M, EventContactName = " ", EventPhone = 000-000-0000, EventEmail = "clearwatercreek@outlook.com", 
                    EventComments = "6/16/23 - 6/17/23. Indoors, 9 am - Noon, 12-6 PM Saturday. 9-5 Sunday", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "1st Annual Food Truck Spring Festival", EventLocation = "Burns Civic Center, Eden, TX", EventStartDate = DateTime.Parse("4/1/23"), 
                    EventCost = 0M, EventContactName = "Lisa Blaylock", EventPhone = 210-862-2172, EventEmail = "clearwatercreek@outlook.com", 
                    EventComments = "11-6. Indoors. Easter Egg Hunt ", EventPaid = "N", EventBooked = "N"},     
                    new Event {EventName = "Wild, Wild, West Fest", EventLocation = "Andrews, TX", EventStartDate = DateTime.Parse("4/22/23"), 
                    EventCost = 0M, EventContactName = " ", EventPhone = 000-000-0000, EventEmail = "email@email.com", 
                    EventComments = "4/22/23 - 4/23/23. Event NOT RECOMMENDED by other vendors. wildwildwestfest.com", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Thunder over Dalhart Airshow", EventLocation = "Dalhart, TX", EventStartDate = DateTime.Parse("5/20/23"), 
                    EventCost = 0M, EventContactName = "Gingert Cullers Cleavinger", EventPhone = 000-000-0000, EventEmail = "email@email.com", 
                    EventComments = "Outdoor. 2-day event.", EventPaid = "N", EventBooked = "N"},     
                    new Event {EventName = "FamFest", EventLocation = "Sam Houston Park, Amarillo, TX", EventStartDate = DateTime.Parse("5/20/23"), 
                    EventCost = 40M, EventContactName = "Mandy", EventPhone = 000-000-0000, EventEmail = "mandy@missionamarillo.org", 
                    EventComments = "11-4, outdoors.", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "Christmas in July", EventLocation = "Hereford Civic Center, Hereford, TX", EventStartDate = DateTime.Parse("7/23/23"), 
                    EventCost = 45M, EventContactName = "Salena Pinales", EventPhone = 806-344-0786, EventEmail = "email@email.com", 
                    EventComments = "Indoor event. Chairs provided. Apply via messenger.", EventPaid = "N", EventBooked = "N"},     
                    new Event {EventName = "Dumas Block Party Event", EventLocation = " 2414 East 5th St, Dumas, TX", EventStartDate = DateTime.Parse("6/10/23"), 
                    EventCost = 50M, EventContactName = " ", EventPhone = 000-000-0000, EventEmail = "info@MooreOptions.life", 
                    EventComments = "Outdoor, 12-4 PM", EventPaid = "N", EventBooked = "N"},
                    new Event {EventName = "From Ministry to the Marketplace", EventLocation = "Amarillo Civic Center, Amarillo, TX", EventStartDate = DateTime.Parse("6/9/23"), 
                    EventCost = 100M, EventContactName = "Marcie Steward", EventPhone = 678-501-5187, EventEmail = "email@email.com", 
                    EventComments = "Indoor - table only, June 9th 9am - 3 pm and 7-10 pm, June 10th 10am - 2pm. marciestewardministries.org", EventPaid = "N", EventBooked = "N"} ,
                    new Event {EventName = "Gypsy Artisan Market", EventLocation = "Sherman, TX", EventStartDate = DateTime.Parse("6/10/23"), 
                    EventCost = 225M, EventContactName = "Cara Hutson", EventPhone = 0000000, EventEmail = "gypsyartisanmarkettx@gmail.com", 
                    EventComments = "Indoor - 2 day event 6/10/23-6/11/23. ", EventPaid = "N", EventBooked = "N"}    ,         
                    new Event {EventName = "Garden Fest", EventLocation = "Amarillo Botanical Gardens, Amarillo, TX", EventStartDate = DateTime.Parse("4/29/23"), 
                    EventCost =  0M, EventContactName = "Amarillo Botanical Gardens", EventPhone = 0000000, EventEmail = "email@email.com", 
                    EventComments = "Outdoor. Heavy Traffic", EventPaid = "N", EventBooked = "N"}   
                    new Event {EventName = "Annual Bash in July", EventLocation = "Agape Bliss Event Center, Plainview, TX", EventStartDate = DateTime.Parse("7/8/23"), 
                    EventCost = 0M, EventContactName = "Jesse Alaniz", EventPhone = 0000000, EventEmail = "email@gmail.com", 
                    EventComments = "Outside Booth, lunch provided for vendors. ", EventPaid = "N", EventBooked = "N"}                                                                                                                                             
                    }; 
                context.AddRange(events); 

                List<Product> products = new List<Product> {
                    new Product {ProductName = "Wristlet - Rainbow", ProductDescription = "Silicone wristlet with pendant", ProductPrice = 15.00M, ProductQty = 3, ProductSource = "KW Laser Supplies"},
                    new Product {ProductName = "Wristlet - Green Glow in the Dark", ProductDescription = "Silicone wristlet with pendant", ProductPrice = 15.00M, ProductQty = 3, ProductSource = "KW Laser Supplies"},                 
                    new Product {ProductName = "Wristlet - Pink Glow in the Dark", ProductDescription = "Silicone wristlet with pendant", ProductPrice = 15.00M, ProductQty = 3, ProductSource = "KW Laser Supplies"},                 
                    new Product {ProductName = "Wristlet - Yellow Glow in the Dark", ProductDescription = "Silicone wristlet with pendant", ProductPrice = 15.00M, ProductQty = 3, ProductSource = "KW Laser Supplies"},
                    new Product {ProductName = "BJJ Sign - Boy", ProductDescription = "14 inch tall sign, boy with interchangeable belts", ProductPrice = 45M, ProductQty = 1, ProductSource = "Handmade", ProductImage = "Images/bjj_boy_sign.jpg"}, 
                    new Product {ProductName = "BJJ Sign - Girl", ProductDescription = "14 inch tall sign, girl with interchangeable belts", ProductPrice = 45M, ProductQty = 1, ProductSource = "Handmade", ProductImage = "Images/bjj_girl_sign.jpg"}   , 
                    new Product {ProductName = "BJJ Sign - Man", ProductDescription = "14 inch tall sign, male with interchangeable belts", ProductPrice = 45M, ProductQty = 1, ProductSource = "Handmade", ProductImage = "Images/bjj_man_sign.jpg"}   ,
                    new Product {ProductName = "BJJ Sign - Male Round", ProductDescription = "14 inch round sign - female", ProductPrice = 30M, ProductQty = 1, ProductSource = "Handmade", ProductImage = "Images/bjj_male_round_sign.jpg"}   ,
                    new Product {ProductName = "BJJ Sign - Female Round", ProductDescription = "14 inch round sign - female", ProductPrice = 30M, ProductQty = 1, ProductSource = "Handmade", ProductImage = "Images/bjj_female_round_sign.jpg" },
                    new Product {ProductName = "MOM Sign - Black/White", ProductDescription = "18x12 MOM sign - White Background, Black text", ProductPrice = 35M, ProductQty = 1, ProductSource = "Handmade"}                
                };
                    context.AddRange(products); 

                    context.SaveChanges();

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
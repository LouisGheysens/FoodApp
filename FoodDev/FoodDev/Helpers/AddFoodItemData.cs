using Firebase.Database;
using Firebase.Database.Query;
using FoodDev.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodDev.Helpers
{
    public class AddFoodItemData
    {
        FirebaseClient client;
        public List<FoodItem> FoodItems { get; set; }
        public AddFoodItemData()
        {
            client = new FirebaseClient("https://fooddev-fe397-default-rtdb.europe-west1.firebasedatabase.app/");
            FoodItems = new List<FoodItem>()
            {
                new FoodItem()
                {
                    ProductId = 1,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Exotisch fruit 41g",
                    Description = " Exotisch fruit fruit",
                    Weight = "41g"
                },
                new FoodItem()
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Exotisch fruit 150g",
                    Description = " Exotisch fruit fruit",
                    Weight = "150g"
                },
                new FoodItem()
                {
                    ProductId = 3,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Exotisch fruit 245g",
                    Description = " Exotisch fruit fruit",
                    Weight = "245g"
                },
                new FoodItem()
                {
                    ProductId = 4,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Exotisch fruit zonder suiker 41g",
                    Description = " Exotisch fruit zonder suiker fruit",
                    Weight = "41g"
                },
                new FoodItem()
                {
                    ProductId = 5,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Exotisch fruit zonder suiker 150g",
                    Description = " Exotisch fruit zonder suiker fruit",
                    Weight = "150g"
                },
                new FoodItem()
                {
                    ProductId = 6,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Exotisch fruit zonder suiker 245g",
                    Description = " Exotisch fruit zonder suiker fruit",
                    Weight = "245g"
                },
                new FoodItem()
                {
                    ProductId = 7,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Kiwi 41g",
                    Description = "Kiwi fruit",
                    Weight = "41.00",
                },
                new FoodItem()
                {
                    ProductId = 8,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Kiwi 150g",
                    Description = "Kiwi fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 9,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Kiwi 245g",
                    Description = "Kiwi fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 10,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Aardbeien 41g",
                    Description = "Aardbeien fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 11,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Aardbeien 150g",
                    Description = "Kiwi fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 12,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Aardbeien 245g",
                    Description = "Aardbeien fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 13,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Aardbeien zonder suiker 245g",
                    Description = "Aardbeien zonder suiker  fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 14,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Aardbeien zonder suiker  245g",
                    Description = "Aardbeien zonder suiker fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 15,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Aardbeien zonder suiker  245g",
                    Description = "Aardbeien zonder suiker  fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 16,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Aardbeien en rabarber 41g",
                    Description = "Aardbeien en rabarber  fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 17,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Aardbeien en rabarber 150g",
                    Description = "Kiwi fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 18,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Aardbeien en rabarber 245g",
                    Description = "Aardbeien en rabarber  fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 19,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Rode rabarber 41g",
                    Description = "Rode rabarber fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 20,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Rode rabarber 150g",
                    Description = "Rode rabarber fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 21,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Rode rabarber 245g",
                    Description = "Rode rabarber fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 22,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Krieken 41g",
                    Description = "Krieken fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 23,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Krieken 150g",
                    Description = "Krieken fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 24,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Krieken 245g",
                    Description = "Krieken fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 25,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Krieken zonder suiker 41g",
                    Description = "Krieken zonder suiker fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 26,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Krieken zonder suiker 150g",
                    Description = "Krieken zonder suiker fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 27,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Krieken zonder suiker 245g",
                    Description = "Krieken zonder suiker fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 28,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Pruimen 41g",
                    Description = "Pruimen fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 29,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Pruimen 150g",
                    Description = "Pruimen fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 30, 
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Pruimen 245g",
                    Description = "Pruimen fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 31,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Pruimen zonder suiker 41g",
                    Description = "Pruimen zonder suiker fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 32,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Pruimen zonder suiker 150",
                    Description = "Pruimen zonder suiker fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 33,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Pruimen zonder suiker 245g",
                    Description = "Pruimen zonder suiker fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 34,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Perziken 41g",
                    Description = "Perziken fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 35,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Perziken 150g",
                    Description = "Perziken fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 36,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Perziken 245g",
                    Description = "Perziken fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 37,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Appelsienen 41g",
                    Description = "Appelsienen fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 38,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Appelsienen 150g",
                    Description = "Appelsienen fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 39,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Appelsienen 245g",
                    Description = "Appelsienen fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 40,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Appelsienen zonder suiker 41g",
                    Description = "Appelsienen zonder suiker fruit",
                    Weight = "41g"
                },
                new FoodItem()
                {
                    ProductId = 41,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Appelsienen zonder suiker 150g",
                    Description = "Appelsienen zonder suiker fruit",
                    Weight = "150g"
                },
                new FoodItem()
                {
                    ProductId = 42,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Appelsienen zonder suiker 245g",
                    Description = "Appelsienen zonder suiker fruit",
                    Weight = "245g"
                },
                new FoodItem()
                {
                    ProductId = 43,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Abrikozen 41g",
                    Description = "Abrikozen fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 44,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Abrikozen 150g",
                    Description = "Abrikozen fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 45,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Abrikozen 245g",
                    Description = "Abrikozen fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 46,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Abrikozen zonder suiker fruit  41g",
                    Description = "Abrikozen zonder suiker fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 47,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Abrikozen zonder suiker 150g",
                    Description = "Abrikozen zonder suiker fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 48,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Abrikozen zonder suiker  245g",
                    Description = "Abrikozen zonder suiker fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 49,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Woudvruchten 41g",
                    Description = "Woudvruchten fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 50,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Woudvruchten 150g",
                    Description = "Woudvruchten fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 51,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Woudvruchten 245g",
                    Description = "Woudvruchten fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 52,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Frambozen 41g",
                    Description = "Frambozen fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 53,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Frambozen 150g",
                    Description = "Frambozen fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 54,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Frambozen 245g",
                    Description = "Frambozen fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 55,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Frambozen zonder suiker 41g",
                    Description = "Frambozen zonder suiker fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 56,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Frambozen zonder suiker 150g",
                    Description = "Frambozen zonder suiker fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 57,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Frambozen zonder suiker 245g",
                    Description = "Frambozen zonder suiker fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 58,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Rode bessen 41g",
                    Description = "Rode bessen  fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 59,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Rode bessen 150g",
                    Description = "Rode bessen  fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 60,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Rode bessen 245g",
                    Description = "Rode bessen  fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 61,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Rode bessen zonder suiker 41g",
                    Description = "Rode bessen zonder suiker  fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 62,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Rode bessen zonder suiker 150g",
                    Description = "Rode bessen zonder suiker fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 63,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Rode bessen zonder suiker 245g",
                    Description = "Rode bessen zonder suiker  fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 64,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "4 vruchten 41g",
                    Description = " 4 vruchten  fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 65,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "4 vruchten 150g",
                    Description = " 4 vruchten  fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 66,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "4 vruchten 245g",
                    Description = " 4 vruchten  fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 67,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "4 vruchten zonder suiker 41g",
                    Description = " 4 vruchten zonder suiker  fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 68,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "4 vruchten zonder suiker 150g",
                    Description = " 4 vruchten zonder suiker fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 69,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "4 vruchten zonder suiker 245g",
                    Description = " 4 vruchten zonder suiker fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 70,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Veenbessen zonder suiker 41g",
                    Description = " Veenbessen zonder suiker fruit",
                    Weight = "41g",
                },
                new FoodItem()
                {
                    ProductId = 71,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Veenbessen zonder suiker 150g",
                    Description = " Veenbessen zonder suiker fruit",
                    Weight = "150g",
                },
                new FoodItem()
                {
                    ProductId = 72,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Veenbessen zonder suiker 245g",
                    Description = " Veenbessen zonder suiker fruit",
                    Weight = "245g",
                },
                new FoodItem()
                {
                    ProductId = 73,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Blauwe bessen zonder suiker 41g",
                    Description = " Blauwe bessen zonder suiker fruit",
                    Weight = "41g"
                },
                new FoodItem()
                {
                     ProductId = 74,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Blauwe bessen zonder suiker 150g",
                    Description = " Blauwe bessen zonder suiker fruit",
                    Weight = "150g"
                },
                new FoodItem()
                {
                    ProductId = 75,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Blauwe bessen zonder suiker 245g",
                    Description = " Blauwe bessen zonder suiker fruit",
                    Weight = "245g"
                },
                new FoodItem()
                {
                    ProductId = 76,
                    CategoryId = 3,
                    ImageUrl = "MainBurger",
                    Name = "Set confituur 4 x 41g",
                    Description = "Confituur",
                    Weight = "4 x 41g"
                },
                new FoodItem()
                {
                    ProductId = 77,
                    CategoryId = 2,
                    ImageUrl = "MainBurger",
                    Name = "Choco pasta mini 41g",
                    Description = "Choco pasta mini",
                    Weight = "41g"
                },
                new FoodItem()
                {
                    ProductId = 78,
                    CategoryId = 2,
                    ImageUrl = "MainBurger",
                    Name = "Choco pasta met noten 250g",
                    Description = "Choco pasta noten",
                    Weight = "250g"
                },
                new FoodItem()
                {
                    ProductId = 79,
                    CategoryId = 2,
                    ImageUrl = "MainBurger",
                    Name = "Choco light 250g",
                    Description = "Choco light",
                    Weight = "250g"
                },
                new FoodItem()
                {
                    ProductId = 80,
                    CategoryId = 2,
                    ImageUrl = "MainBurger",
                    Name = "Choco light zonder suiker 150g",
                    Description = "Choco light zonder suiker",
                    Weight = "150g"
                },
                new FoodItem()
                {
                    ProductId = 81,
                    CategoryId = 2,
                    ImageUrl = "MainBurger",
                    Name = "Speculaas 200g(12 per doos) zonder suiker",
                    Description = "Speculaas zonder suiker",
                    Weight = "200g"
                },
                new FoodItem()
                {
                    ProductId = 82,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Aardbeien extra light / zonder suiker 230g",
                    Description = "Aarbeienen extra light zonder suiker",
                    Weight = "230g"
                },
                new FoodItem()
                {

                    ProductId = 83,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Krieken  extra light / zonder suiker 230g",
                    Description = "Krieken extra light zonder suiker",
                    Weight = "230g"
                },
                new FoodItem()
                {

                    ProductId = 84,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Frambozen extra light / zonder suiker 230g",
                    Description = "Frambozen extra light zonder suiker",
                    Weight = "230g"
                },
                new FoodItem()
                {

                    ProductId = 85,
                    CategoryId = 2,
                    ImageUrl = "MainBurger",
                    Name = "Abrikozen exrtra light / zonder suiker 230g",
                    Description = "Abrikozen extra light zonder suiker",
                    Weight = "230g"
                },
                new FoodItem()
                {

                    ProductId = 86,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "Appelsienen extra light / zonder suiker 230g",
                    Description = "Appelsienen extra light zonder suiker",
                    Weight = "230g"
                },
                new FoodItem()
                {

                    ProductId = 87,
                    CategoryId = 1,
                    ImageUrl = "MainBurger",
                    Name = "4 vruchten extra light / zonder suiker 230g",
                    Description = "4 vruchten extra light zonder suiker",
                    Weight = "230g"
                },
                new FoodItem()
                {
                    ProductId = 88,
                    CategoryId = 4,
                    ImageUrl = "MainBurger",
                    Name = "Chocoladesiroop 425g",
                    Description = "Siroop / chocolade",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 89,
                    CategoryId = 4,
                    ImageUrl = "MainBurger",
                    Name = "Salted caramel 425g",
                    Description = "Siroop / saltedcaramel",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 90,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "Mayo 425g",
                    Description = "Sauzen / mayo",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 91,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "BBQ steak 425g",
                    Description = "Sauzen / BBQ steak",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 92,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "Ketchup 425g",
                    Description = "Sauzen / ketchup",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 93,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "Curry 425g",
                    Description = "Sauzen / Curry",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 94,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "Snack saus 425g",
                    Description = "Sauzen / snack saus",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 95,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "Sweet hot chili 425g",
                    Description = "Sauzen / sweet hot chili",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 96,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "Curry ketchup 425g",
                    Description = "Sauzen / curry ketchup",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 97,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "Andalouse 425g",
                    Description = "Sauzen / andalouse",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 98,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "Tartare 425g",
                    Description = "Sauzen / tartare",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 99,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "Samurai 425g",
                    Description = "Sauzen / samurai",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 100,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "Teriyaki 425g",
                    Description = "Sauzen / teriyaki",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 101,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "American saus 425g",
                    Description = "Sauzen / american saus",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 102,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "Salad dressing 425g",
                    Description = "Sauzen / salad dressing",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 103,
                    CategoryId = 5,
                    ImageUrl = "MainBurger",
                    Name = "Honing mosterd 425g",
                    Description = "Sauzen / honing mosterd",
                    Weight = "425g"
                },
                new FoodItem()
                {
                    ProductId = 104,
                    CategoryId = 6,
                    ImageUrl = "MainBurger",
                    Name = "Kokosvet 300ml",
                    Description = "Braadvetten / kokosvet",
                    Weight = "300ml"
                },
            };
        }

        public async Task AddFoodItemsAsync()
        {
            try
            {
                foreach(var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem()
                    {
                        ProductId = item.ProductId,
                        CategoryId = item.CategoryId,
                        Name = item.Name,
                        Description = item.Description,
                        Weight = item.Weight,
                        ImageUrl = item.ImageUrl
                    });
                }
            }catch(Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
        }
    }
}

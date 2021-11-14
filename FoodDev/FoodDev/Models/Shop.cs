using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace FoodDev.Models
{
    public class RootObject
    {
        public ObservableCollection<Shop> Data { get; set; }

        public RootObject()
        {
            Data = new ObservableCollection<Shop>();
        }

        public class Shop
        {
            public Shop(string name, string v1, string v2, string v3)
            {
            }

            public int NrKlant { get; set; }

            public string Contact { get; set; }

            public string Onderneming { get; set; }

            public string Adres { get; set; }

            public int Postcode { get; set; }

            public string Stad { get; set; }

            public int NrBtw { get; set; }

            public string Tel { get; set; }

            public string GSM { get; set; }

            public string Email { get; set; }
        }
    }
}

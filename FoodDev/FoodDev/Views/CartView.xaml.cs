using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodDev.Models;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Syncfusion.Pdf;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Graphics;
using System.Collections;
using System.Collections.ObjectModel;

namespace FoodDev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartView : ContentPage
    {
        bool isLoading  
        {
            set
            {
                pageActivityIndicator.IsVisible = true;
                pageActivityIndicator.IsRunning = value;
                PlaceButton.IsVisible = !value;
                this.IsBusy = value;
            }
        }

        public CartView()
        {
            InitializeComponent();
            LabelName.Text = "Welkom! " + Preferences.Get("Username", "Guest");
            RetrieveJsonData();
            configureClientPicker();
            configurePlaceButton();
            pageActivityIndicator.BindingContext = this;
        }

        private void configurePlaceButton()
        {
            PlaceButton.Clicked += PlaceButton_Clicked;
        }

        private void configureClientPicker()
        {
            JsonPicker.SelectedIndexChanged += JsonPicker_SelectedIndexChanged;
        }

        async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
            
        }

        public void RetrieveJsonData()
        {
            string jsonFileName = "csvjson.json";
            RootObject ObjContactList = new RootObject();
            var assembly = typeof(CartView).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                //Converting JSON Array Objects into generic list    
                ObjContactList = JsonConvert.DeserializeObject<RootObject>(jsonString);
            }
            //Binding picker with json string     
            JsonPicker.ItemsSource = ObjContactList.Data;
        }

        private bool ValidateForm()
        {
            if (JsonPicker.SelectedIndex == -1) return false;
            if (string.IsNullOrWhiteSpace(ExtraMessage.Text)) return false;
            return true;
        }

        private async void NavigateToLastPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FinishOrderPage());
        }

        private void JsonPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JsonPicker.SelectedIndex == -1) { return; }
            var selectClient = (RootObject)JsonPicker.SelectedItem;
            ExtraMessage.Text = selectClient.Data.ToString();
        }

        private async void PlaceButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FinishOrderPage());
        }
    }
}
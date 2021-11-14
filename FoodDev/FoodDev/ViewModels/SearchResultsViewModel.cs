using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using FoodDev.Models;
using FoodDev.Services;

namespace FoodDev.ViewModels
{
    public class SearchResultsViewModel: BaseViewModel
    {
        public ObservableCollection<FoodItem> FoodItemsByQuery { get; set; }


        private int _TotalFoodItems;

        public int TotalFoodItems
        {
            set
            {
                _TotalFoodItems = value;
                OnPropertyChanged();
            }
            get
            {
                return _TotalFoodItems;
            }
        }

        public SearchResultsViewModel(string searchText)
        {
            FoodItemsByQuery = new ObservableCollection<FoodItem>();
            GetFoodItemsByQueryAsync(searchText);
        }

        private async void GetFoodItemsByQueryAsync(string searchText)
        {
            var data = await new FoodItemService().GetFoodItemsByQueryAsync(searchText);
            FoodItemsByQuery.Clear();
            foreach(var item in data)
            {
                FoodItemsByQuery.Add(item);
            }
            TotalFoodItems = FoodItemsByQuery.Count;
        }
    }
}

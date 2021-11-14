using FoodDev.Models;
using FoodDev.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FoodDev.ViewModels
{
    public class OrdersHistoryViewModel: BaseViewModel
    {
        public ObservableCollection<OrdersHistory> OrderDetails { get; set; }

        private bool _IsBusy;

        public bool IsBusy
        {
            set
            {
                _IsBusy = value;
                OnPropertyChanged();
            }
            get
            {
                return _IsBusy;
            }
        }

        public OrdersHistoryViewModel()
        {
            OrderDetails = new ObservableCollection<OrdersHistory>();
            LoadUserOrders();
        }

        private async void LoadUserOrders()
        {
            try
            {
                _IsBusy = true;
                OrderDetails.Clear();
                var service = new OrderHistoryService();
                var details = await service.GetOrderDetailsAsync();
                
            }catch(Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            finally
            {
                _IsBusy = false;
            }
        }

    }
}

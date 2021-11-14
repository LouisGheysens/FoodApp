using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using DynamicData;
using System.Collections.Generic;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using DynamicData.Binding;
using FoodDev.Models;
using DynamicData.PLinq;
using static FoodDev.Models.RootObject;

namespace FoodDev.ViewModels
{
    public class MainViewModel : ReactiveObject, IDisposable
    {
        public MainViewModel()
        {
            SortCommand = ReactiveCommand.CreateFromTask(ExecuteSort);


            //Search logic
            Func<Shop, bool> restaurantFilter(string text) => restaurant =>
            {
                return string.IsNullOrEmpty(text) || restaurant.Onderneming.ToLower().Contains(text.ToLower()) || restaurant.Stad.ToLower().Contains(text.ToLower());
            };

            var filterPredicate = this.WhenAnyValue(x => x.SearchText)
                                      .Throttle(TimeSpan.FromMilliseconds(250), RxApp.TaskpoolScheduler)
                                      .DistinctUntilChanged()
                                      .Select(restaurantFilter);

            //Filter logic
            Func<Shop, bool> countryFilter(string country) => restaurant =>
            {
                return country == "All" || country == restaurant.Stad;
            };

            var countryPredicate = this.WhenAnyValue(x => x.SelectedCountryFilter)
                                       .Select(countryFilter);

            //sort
            var sortPredicate = this.WhenAnyValue(x => x.SortBy)
                                    .Select(x => x == "Type" ? SortExpressionComparer<Shop>.Ascending(a => a.Stad) : SortExpressionComparer<Shop>.Ascending(a => a.Onderneming));

            _cleanUp = _sourceCache.Connect()
            .RefCount()
            .Filter(countryPredicate)
            .Filter(filterPredicate)
            .Sort(sortPredicate)
            .Bind(out _restaurants)
            .DisposeMany()
            .Subscribe();

            //Set default values
            SelectedCountryFilter = "All";
            SortBy = "Name";

            AddCommand = ReactiveCommand.CreateFromTask(async () => await ExecuteAdd());
            DeleteCommand = ReactiveCommand.Create<Shop>(ExecuteRemove);
            SortCommand = ReactiveCommand.CreateFromTask(ExecuteSort);
        }

        private void ExecuteRemove(Shop restaurant)
        {
            _sourceCache.Edit((update) =>
            {
                update.Remove(restaurant);
            });
        }

        private async Task ExecuteAdd()
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Insert Name", "");
            _sourceCache.Edit((update) =>
            {
                update.AddOrUpdate(new Shop(name, "Casual", "Fast food", "US"));
            });
        }

        private async Task ExecuteSort()
        {
            var sort = await App.Current.MainPage.DisplayActionSheet("Sort by", "Cancel", null, buttons: new string[] { "Name", "Type" });
            if (sort != "Cancel")
            {
                SortBy = sort;
            }
        }

        public void Dispose()
        {
            _cleanUp.Dispose();
        }

        public ReadOnlyObservableCollection<Shop> Restaurants => _restaurants;

        public string SearchText
        {
            get => _searchText;
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }

        public string SelectedCountryFilter
        {
            get => _selectedCountryFilter;
            set => this.RaiseAndSetIfChanged(ref _selectedCountryFilter, value);
        }

        private string SortBy
        {
            get => _sortBy;
            set => this.RaiseAndSetIfChanged(ref _sortBy, value);
        }

        public ReactiveCommand<Unit, Unit> AddCommand { get; set; }
        public ReactiveCommand<Shop, Unit> DeleteCommand { get; }
        public ReactiveCommand<Unit, Unit> SortCommand { get; }

        private SourceCache<Shop, string> _sourceCache = new SourceCache<Shop, string>(x => x.NrKlant.ToString());
        private readonly ReadOnlyObservableCollection<Shop> _restaurants;
        private string _searchText;
        private string _selectedCountryFilter;
        private string _sortBy;

        private readonly IDisposable _cleanUp;

        }
    }

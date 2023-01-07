using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InfiniteScrollingMaui.Models;
using InfiniteScrollingMaui.Services;
using System.Collections.ObjectModel;

namespace InfiniteScrollingMaui.ViewModels;

public partial class AnimalListViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;

    [ObservableProperty]
    private bool _isLoading;

    private List<EntryDetails> _allAnimalList;
    private int _pageSize = 20;
    public ObservableCollection<EntryDetails> AnimalList { get; set; } = new ObservableCollection<EntryDetails>();
    private readonly AnimalService _animalService;
    public AnimalListViewModel(AnimalService animalService)
    {
        _animalService = animalService;
        GetAnimalList();
    }

    async Task GetAnimalList()
    {
        AnimalList.Clear();
        IsBusy = true;
        //Task.Run(async () =>
        //{
            _allAnimalList = await _animalService.GetAnimalList();

            App.Current.Dispatcher.Dispatch(() =>
            {
                var recordsToBeAdded = _allAnimalList.Take(_pageSize).ToList();
                foreach (var record in recordsToBeAdded)
                {
                    AnimalList.Add(record);
                }
                IsBusy = false;
            });
        //});
    }

    [RelayCommand]
    async Task LoadMoreData()
    {
        if (IsLoading) return;
        if (_allAnimalList?.Count > 0)
        {
            IsLoading = true;
            var recordsToBeAdded = _allAnimalList.Skip(AnimalList.Count).Take(_pageSize).ToList();
            foreach (var record in recordsToBeAdded)
            {
                AnimalList.Add(record);
            }
            IsLoading = false;
        }
    }
}

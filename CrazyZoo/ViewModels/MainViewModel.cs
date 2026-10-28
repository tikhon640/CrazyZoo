using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CrazyZoo.Commands;
using CrazyZoo.Core.Events;
using CrazyZoo.Core.Interfaces;
using CrazyZoo.Core.Models;
using CrazyZoo.Core.Repositories;
namespace CrazyZoo.ViewModels;

using System.Windows.Input;
using CrazyZoo.Commands;

public class MainViewModel : INotifyPropertyChanged
{

    public ObservableCollection<Animal> Animals { get; } = new();

    public ObservableCollection<Animal> FilteredAnimals { get; } = new();

    public ObservableCollection<string> Log { get; } = new();

    public ObservableCollection<string> Statistics { get; } = new();

    private Animal? selectedAnimal;

    public Animal? SelectedAnimal
    {
        get => selectedAnimal;
        set
        {
            selectedAnimal = value;
            OnPropertyChanged(nameof(SelectedAnimal));
        }
    }

    private string searchText = "";

    public string SearchText
    {
        get => searchText;
        set
        {
            searchText = value;
            OnPropertyChanged(nameof(SearchText));
            ApplyFilter();
        }
    }

    public ICommand AddMonkeyCommand { get; }
    public ICommand AddPenguinCommand { get; }
    public ICommand AddLionCommand { get; }
    public ICommand AddTigerCommand { get; }

    public ICommand RemoveAnimalCommand { get; }
    public ICommand NormalActionCommand { get; }
    public ICommand CrazyActionCommand { get; }
    public ICommand SpecialActionCommand { get; }

    public MainViewModel()
    {
        AddMonkeyCommand = new RelayCommand(AddMonkey);
        AddPenguinCommand = new RelayCommand(AddPenguin);
        AddLionCommand = new RelayCommand(AddLion);
        AddTigerCommand = new RelayCommand(AddTiger);
    }

    {
    }

    {
    }

    {
        Log.Add($"{e.SourceAnimal.Name} removed");
    }

    private void CrazyActionPerformed(object? sender, AnimalEventArgs e)
    {
        Log.Add($"{e.SourceAnimal.Name} performed crazy action");
    }

    private void ReactionGenerated(object? sender, AnimalReactionEventArgs e)
    {
        Log.Add(e.Message);
    }

    }

    {


    }

    {


    }

    {


    }
    {
        if (SelectedAnimal == null)
            return;

    }

    {


    }
    {
    }

    {
    }

    {
    }
    {
        {
            {
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}
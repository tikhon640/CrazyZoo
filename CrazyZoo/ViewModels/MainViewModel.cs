using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CrazyZoo.Commands;
using CrazyZoo.Core.Events;
using CrazyZoo.Core.Interfaces;
using CrazyZoo.Core.Models;
using CrazyZoo.Core.Repositories;

namespace CrazyZoo.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly MonkeyRepository monkeyRepository = new();
    private readonly PenguinRepository penguinRepository = new();
    private readonly LionRepository lionRepository = new();
    private readonly TigerRepository tigerRepository = new();

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
        Subscribe(monkeyRepository);
        Subscribe(penguinRepository);
        Subscribe(lionRepository);
        Subscribe(tigerRepository);

        AddMonkeyCommand = new RelayCommand(AddMonkey);
        AddPenguinCommand = new RelayCommand(AddPenguin);
        AddLionCommand = new RelayCommand(AddLion);
        AddTigerCommand = new RelayCommand(AddTiger);

        RemoveAnimalCommand = new RelayCommand(RemoveAnimal);
        NormalActionCommand = new RelayCommand(NormalAction);
        CrazyActionCommand = new RelayCommand(CrazyAction);
        SpecialActionCommand = new RelayCommand(SpecialAction);
    }

    private void Subscribe<T>(AnimalRepositoryBase<T> repository)
        where T : Animal
    {
        repository.AnimalAdded += AnimalAdded;
        repository.AnimalRemoved += AnimalRemoved;
        repository.CrazyActionPerformed += CrazyActionPerformed;
        repository.ReactionGenerated += ReactionGenerated;
    }

    private void AnimalAdded(object? sender, AnimalEventArgs e)
    {
        Log.Add($"{e.SourceAnimal.Name} added");
    }

    private void AnimalRemoved(object? sender, AnimalEventArgs e)
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

    private void AddMonkey()
    {
        var animal = new Monkey("Monkey");

        monkeyRepository.AddAnimal(animal);

        Animals.Add(animal);

        RefreshCollections();
    }

    private void AddPenguin()
    {
        var animal = new Penguin("Penguin");

        penguinRepository.AddAnimal(animal);

        Animals.Add(animal);

        RefreshCollections();
    }

    private void AddLion()
    {
        var animal = new Lion("Lion");

        lionRepository.AddAnimal(animal);

        Animals.Add(animal);

        RefreshCollections();
    }

    private void AddTiger()
    {
        var animal = new Tiger("Tiger");

        tigerRepository.AddAnimal(animal);

        Animals.Add(animal);

        RefreshCollections();
    }

    private void RemoveAnimal()
    {
        if (SelectedAnimal == null)
            return;

        switch (SelectedAnimal)
        {
            case Monkey monkey:
                monkeyRepository.RemoveAnimal(monkey);
                break;

            case Penguin penguin:
                penguinRepository.RemoveAnimal(penguin);
                break;

            case Lion lion:
                lionRepository.RemoveAnimal(lion);
                break;

            case Tiger tiger:
                tigerRepository.RemoveAnimal(tiger);
                break;
        }

        Animals.Remove(SelectedAnimal);

        SelectedAnimal = null;

        RefreshCollections();
    }

    private void NormalAction()
    {
        if (SelectedAnimal == null)
            return;

        Log.Add(SelectedAnimal.NormalAction());

        OnPropertyChanged(nameof(SelectedAnimal));
    }

    private void CrazyAction()
    {
        if (SelectedAnimal == null)
            return;

        switch (SelectedAnimal)
        {
            case Monkey monkey:
                monkeyRepository.PerformCrazyAction(monkey);
                break;

            case Penguin penguin:
                penguinRepository.PerformCrazyAction(penguin);
                break;

            case Lion lion:
                lionRepository.PerformCrazyAction(lion);
                break;

            case Tiger tiger:
                tigerRepository.PerformCrazyAction(tiger);
                break;
        }

        OnPropertyChanged(nameof(SelectedAnimal));
    }

    private void SpecialAction()
    {
        if (SelectedAnimal == null)
            return;

        if (SelectedAnimal is IFly flyer)
        {
            Log.Add(flyer.Fly());
        }
        else if (SelectedAnimal is IClimb climber)
        {
            Log.Add(climber.Climb());
        }
        else if (SelectedAnimal is ISwimmable swimmer)
        {
            Log.Add(swimmer.Swim());
        }

        OnPropertyChanged(nameof(SelectedAnimal));
    }

    private void RefreshCollections()
    {
        ApplyFilter();
        UpdateStatistics();
    }

    private void ApplyFilter()
    {
        FilteredAnimals.Clear();

        var filtered = Animals
            .Where(a => a.Name.Contains(
                SearchText,
                StringComparison.OrdinalIgnoreCase))
            .OrderBy(a => a.Name);

        foreach (var animal in filtered)
        {
            FilteredAnimals.Add(animal);
        }
    }

    private void UpdateStatistics()
    {
        Statistics.Clear();

        var groups = Animals
            .GroupBy(a => a.GetType().Name)
            .OrderBy(g => g.Key);

        foreach (var group in groups)
        {
            Statistics.Add($"{group.Key}: {group.Count()}");
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
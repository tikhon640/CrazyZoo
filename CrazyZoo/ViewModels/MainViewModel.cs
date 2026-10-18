using System.Collections.ObjectModel;
using System.ComponentModel;
using CrazyZoo.Core.Events;
using CrazyZoo.Core.Models;
using CrazyZoo.Core.Repositories;
using System.Linq;
namespace CrazyZoo.ViewModels;

using System.Windows.Input;
using CrazyZoo.Commands;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly ZooRepository repository;

    public ObservableCollection<Animal> Animals { get; } = new();

    public ObservableCollection<string> Log { get; } = new();

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
    public ICommand AddMonkeyCommand { get; }
    public ICommand AddPenguinCommand { get; }
    public ICommand AddLionCommand { get; }
    public ICommand AddTigerCommand { get; }
    public MainViewModel()
    {
        repository = new ZooRepository();
        AddMonkeyCommand = new RelayCommand(AddMonkey);
        AddPenguinCommand = new RelayCommand(AddPenguin);
        AddLionCommand = new RelayCommand(AddLion);
        AddTigerCommand = new RelayCommand(AddTiger);
        repository.AnimalAdded += Repository_AnimalAdded;
        repository.AnimalRemoved += Repository_AnimalRemoved;
        repository.CrazyActionPerformed += Repository_CrazyActionPerformed;
    }

    private void Repository_AnimalAdded(object? sender, AnimalEventArgs e)
    {
        Log.Add($"{e.Animal.Name} added.");
    }

    private void Repository_AnimalRemoved(object? sender, AnimalEventArgs e)
    {
        Log.Add($"{e.Animal.Name} removed.");
    }

    private void Repository_CrazyActionPerformed(
    object? sender,
    CrazyActionEventArgs e)
    {
        Log.Add(e.Message);

        ReactToCrazyAction(e.Animal);
    }

    public void AddMonkey()
    {
        var monkey = new Monkey("Monkey");

        repository.AddAnimal(monkey);

        Animals.Add(monkey);
    }

    public void AddPenguin()
    {
        var penguin = new Penguin("Penguin");

        repository.AddAnimal(penguin);

        Animals.Add(penguin);
    }

    public void AddLion()
    {
        var lion = new Lion("Lion");

        repository.AddAnimal(lion);

        Animals.Add(lion);
    }
    public void PerformCrazyAction()
    {
        if (SelectedAnimal == null)
            return;

        repository.PerformCrazyAction(SelectedAnimal);
    }

    public void AddTiger()
    {
        var tiger = new Tiger("Tiger");

        repository.AddAnimal(tiger);

        Animals.Add(tiger);
    }
    public IEnumerable<Animal> GetHighEnergyAnimals()
    {
        return Animals.Where(a => a.Energy > 50);
    }

    public IEnumerable<Animal> GetAnimalsSortedByName()
    {
        return Animals.OrderBy(a => a.Name);
    }

    public IEnumerable<IGrouping<string, Animal>> GetAnimalsByType()
    {
        return Animals.GroupBy(a => a.GetType().Name);
    }
    private void ReactToCrazyAction(Animal actor)
    {
        foreach (var animal in Animals)
        {
            if (animal != actor)
            {
                Log.Add($"{animal.Name} reacted to {actor.Name}'s crazy action!");
            }
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
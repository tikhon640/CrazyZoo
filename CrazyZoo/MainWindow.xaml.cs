using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using CrazyZoo.Core.Interfaces;
using CrazyZoo.Core.Models;

namespace CrazyZoo;

public partial class MainWindow : Window
{
    public ObservableCollection<Animal> Animals { get; set; }

    private Animal? selectedAnimal;

    public MainWindow()
    {
        InitializeComponent();

        Animals = new ObservableCollection<Animal>();

        AnimalsList.ItemsSource = Animals;
    }

    private void AddMonkeyButton_Click(object sender, RoutedEventArgs e)
    {
        Animals.Add(new Monkey("Monkey"));
    }

    private void AddPenguinButton_Click(object sender, RoutedEventArgs e)
    {
        Animals.Add(new Penguin("Penguin"));
    }

    private void AddLionButton_Click(object sender, RoutedEventArgs e)
    {
        Animals.Add(new Lion("Lion"));
    }

    private void AddTigerButton_Click(object sender, RoutedEventArgs e)
    {
        Animals.Add(new Tiger("Tiger"));
    }

    private void AnimalsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        selectedAnimal = AnimalsList.SelectedItem as Animal;

        if (selectedAnimal == null)
            return;

        NameText.Text = $"Name: {selectedAnimal.Name}";
        EnergyText.Text = $"Energy: {selectedAnimal.Energy}";
    }

    private void NormalAction_Click(object sender, RoutedEventArgs e)
    {
        if (selectedAnimal == null)
            return;

        string result = selectedAnimal.NormalAction();

        LogList.Items.Add(result);

        RefreshInfo();
    }

    private void CrazyAction_Click(object sender, RoutedEventArgs e)
    {
        if (selectedAnimal == null)
            return;

        string result = selectedAnimal.CrazyAction();

        LogList.Items.Add(result);

        RefreshInfo();
    }

    private void SpecialAction_Click(object sender, RoutedEventArgs e)
    {
        if (selectedAnimal == null)
            return;

        if (selectedAnimal is IFly flyer)
        {
            LogList.Items.Add(flyer.Fly());
        }
        else if (selectedAnimal is IClimb climber)
        {
            LogList.Items.Add(climber.Climb());
        }
        else if (selectedAnimal is ISwimmable swimmer)
        {
            LogList.Items.Add(swimmer.Swim());
        }

        RefreshInfo();
    }

    private void RemoveAnimal_Click(object sender, RoutedEventArgs e)
    {
        if (selectedAnimal == null)
            return;

        Animals.Remove(selectedAnimal);

        NameText.Text = "";
        EnergyText.Text = "";

        LogList.Items.Add("Animal removed");
    }

    private void RefreshInfo()
    {
        AnimalsList.Items.Refresh();

        if (selectedAnimal != null)
        {
            NameText.Text = $"Name: {selectedAnimal.Name}";
            EnergyText.Text = $"Energy: {selectedAnimal.Energy}";
        }
    }
}
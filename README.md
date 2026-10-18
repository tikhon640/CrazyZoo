# Crazy Zoo

## Eesmärk

Crazy Zoo on WPF rakendus, mis demonstreerib objektorienteeritud programmeerimist, sündmusi, LINQ päringuid, MVVM mustrit ja GitHub koostööd.

## Projekti struktuur

### CrazyZoo.Core

Sisaldab:

- Animal baasklassi
- loomaklasse
- liideseid
- Repository mustrit
- sündmusi

### CrazyZoo

Sisaldab:

- WPF kasutajaliidest
- MainWindow
- MainViewModel

## Klassihierarhia

Animal

- Monkey
- Penguin
- Lion
- Tiger
- Elephant
- Zebra
- Giraffe

## Liidesed

- IClimb
- IFly
- ISwimmable

## Repository Pattern

Projektis kasutatakse:

- IRepository<T>
- Repository<T>
- ZooRepository

Repository võimaldab loomade lisamist, eemaldamist ja otsimist.

## Sündmused

Projektis kasutatakse järgmisi sündmusi:

- AnimalAdded
- AnimalRemoved
- CrazyActionPerformed

Sündmused teavitavad süsteemi loomade lisamisest, eemaldamisest ja CrazyAction tegevustest.

## LINQ

Projektis kasutatakse LINQ päringuid:

### Filtreerimine

```csharp
Where()
```

### Sorteerimine

```csharp
OrderBy()
```

### Grupeerimine

```csharp
GroupBy()
```

## MVVM

Projektis kasutatakse:

- MainViewModel
- INotifyPropertyChanged
- ICommand
- RelayCommand

ViewModel haldab loomade andmeid ja rakenduse loogikat.

## Loomade tegevused

Igal loomal on:

- NormalAction()
- CrazyAction()

Mõned loomad kasutavad eriliideseid:

- Fly()
- Climb()
- Swim()

## Funktsioonid

- Loomade lisamine
- Loomade eemaldamine
- Normal Action
- Crazy Action
- Special Action
- Loomade kuvamine
- Tegevuste logi

## GitHub koostöö

Projektis kasutati:

- GitHub Repository
- Issue
- Branch
- Pull Request
- Merge

Koostöö käigus lisati projektile uus loomaliik Tiger.

## Uued loomad Vol.2 töö jaoks

Lisatud loomad:

- Tiger
- Elephant
- Zebra
- Giraffe

## AI kasutamine

Kasutasin tehisintellekti õppematerjalide selgitamiseks, dokumentatsiooni koostamiseks ning lahenduse kontrollimiseks. Lõplik lahendus on koostatud, kohandatud ja testitud iseseisvalt.

## Käivitamine

1. Ava lahendus Visual Studios.
2. Määra käivitatavaks projektiks CrazyZoo.
3. Build Solution.
4. Käivita rakendus.
5. Lisa loomi ning kasuta Normal Action, Crazy Action ja Special Action funktsioone.

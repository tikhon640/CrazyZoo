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


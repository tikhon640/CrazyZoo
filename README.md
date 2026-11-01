# Crazy Zoo

Crazy Zoo is a WPF application developed in C# using MVVM, Repository Pattern, Events and LINQ.

## Vol.2 Features

### Animals

- Monkey
- Penguin
- Lion
- Tiger
- Bear
- Wolf
- Fox

### Architecture

- MVVM Pattern
- Repository Pattern
- Event-based communication
- Commands (RelayCommand)

### LINQ Usage

- Where
- OrderBy
- GroupBy

### Additional Functionality

- Animal search
- Animal statistics
- Animal actions
- Special actions based on interfaces
- Event log

---

## Vol.3 Features

### Sequential Processing

Resource-intensive calculations are executed one animal at a time.

### Parallel Processing

Resource-intensive calculations are executed in parallel using:

- Task.Run()
- Task.WhenAll()

### Performance Measurement

Execution time is measured using:

- Stopwatch

### Cancellation

Long-running calculations can be cancelled using:

- CancellationToken
- CancellationTokenSource

### Reports

Calculation report includes:

- Animal name
- Status
- Result
- Duration

Supported statuses:

- Success
- Cancelled
- Failed

### Responsive UI

The user interface remains responsive while calculations are running.

---

## Technologies

- C#
- .NET
- WPF
- MVVM
- LINQ
- GitHub
- Task Parallel Library (TPL)

---

## How to Run

1. Open the solution in Visual Studio.
2. Build the solution.
3. Start the application.
4. Add at least three animals.
5. Enter a workload value.
6. Test Sequential processing.
7. Test Parallel processing.
8. Test Cancellation.
9. View calculation reports.

---

## Git Workflow

### Vol.2

- Feature branch created by a second student
- Pull Request created
- Code Review completed
- Changes merged into master

### Vol.3

- Separate feature branch
- Pull Request created
- Parallel processing implementation merged into master

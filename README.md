

# Chess Game – Software Development Project

## Project Description

This is a chess game built as part of our Software Development course. The goal is to create a functional desktop application in C# using WPF, where two players can play chess locally. We aim to implement the core rules of chess, a basic GUI, and a solid structure for the codebase.



---

## Group Members

| **Name**              | **GitHub Username**    |
|-----------------------|------------------------|
| Abdihakim Mahamed     | `abdihakim43`          |
| Hamed Sarvari         | `Saha23me`             |
| Alexander Johansson   | `Joal22za`             |
 
 
## Declaration

I, Abdihakim Mahamed, declare that I am the sole author of the content I add to this repository.  
I, Hamed Sarvari, declare that I am the sole author of the content I add to this repository.  
I, Alexander Johansson, declare that I am the sole author of the content I add to this repository.  
---

##  What We’re Building

We’re making a desktop-based chess game with these core features:

- 8x8 interactive chessboard
- Correct piece layout
- Click to select a piece, then click to move
- Turn-based play (White and Black)
- Piece capturing
- Check and checkmate detection
- Game reset button

We may also try to add:
- Move highlights
- Pawn promotion
- Restart option
- Optional AI or save/load (if time allows)

---

##  How It Will Work

The game starts with a normal chess setup. Each player takes turns clicking a piece and selecting a valid move. The rules for piece movement and capturing are enforced in the game logic. When a check or checkmate occurs, the game ends or displays a warning.

All logic will be separated into proper classes (e.g., piece, board, GameManager) to allow easier testing and development.

---

## Technologies & Tools

- **Language**: C#
- **Framework**: .NET 8
- **UI**: WPF (XAML)
- **IDE**: Visual Studio 2022
- **Version Control**: Git + GitHub
- **Testing Framework**: xUnit
- **CI**: GitHub Actions

---

##  Build System

We’re using **MSBuild**, via Visual Studio, to build the project. We will also set up a GitHub Actions workflow to automatically build and test the project on push or pull request.

---

## Timeline (Planned)

| Week | Goals |
|------|-------|
| Week 1 | Set up GitHub repo, draw board, layout UI |
| Week 2 | Add piece logic and basic movement |
| Week 3 | Add rules (capturing, check, turn system) |
| Week 4 | UI polish, unit tests, and documentation |

---


##  Project Kanban Board

Track progress and tasks on our [Kanban board](https://github.com/users/abdihakim43/projects/1). 




##  How to Build and Run

1. Open the project in Visual Studio 2022  
2. Make sure .NET 8 is installed  
3. Build the solution (Ctrl + Shift + B)  
4. Run the project (F5 or click Start)  

## How to Run Unit Tests

    Open the Solution: Open the solution in Visual Studio 2022.

    Build the Project: Make sure the project is built by pressing Ctrl + Shift + B.

    Open Test Explorer: Go to Test > Windows > Test Explorer in the Visual Studio menu.

    Run Tests: In the Test Explorer window, click Run All to run all tests. Alternatively, you can right-click individual tests and run them.

## How to Generate Code Coverage

1. **Install Coverage Tools**: Make sure you have the **.NET Code Coverage** tool installed (Visual Studio includes it by default in most editions).  
2. **Enable Code Coverage**:  
   - Go to `Test > Analyze Code Coverage > All Tests`.  
   - Visual Studio will build the project, run tests, and display coverage results.  
3. **View Coverage Report**: After the tests finish running, a report will show up under **Code Coverage Results** with percentages and file breakdowns.  
4. *(Optional)* You can export the results as XML or view it in a graphical format using third-party tools like [ReportGenerator](https://github.com/danielpalme/ReportGenerator).

---

## How to Run a Linter

We recommend using **StyleCop Analyzers** for C# linting:

1. **Install StyleCop**:
   - Open the **NuGet Package Manager** for your main project.
   - Search for `StyleCop.Analyzers` and install it.

2. **Configure Rules (Optional)**:
   - You can configure linting rules using a `stylecop.json` file or via an `.editorconfig` file.

3. **View Warnings**:
   - Linting warnings will appear in the **Error List** and **Warnings** tab in Visual Studio.
   - Use Visual Studio’s quick fixes (`Ctrl + .`) to automatically correct some issues.

---
[![.NET](https://github.com/abdihakim43/chess_game/actions/workflows/dotnet.yml/badge.svg)](https://github.com/abdihakim43/chess_game/actions/workflows/dotnet.yml)
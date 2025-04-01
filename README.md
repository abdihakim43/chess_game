

# Chess Game – Software Development Project

## Project Description

This is a chess game built as part of our Software Development course. The goal is to create a functional desktop application in C# using WPF, where two players can play chess locally. We aim to implement the core rules of chess, a basic GUI, and a solid structure for the codebase.



---

## Group Members

| Name                 | GitHub Handle          |
| Abdihakim Mahamed    | [@abdihakim43](https://github.com
abdihakim43) 
 
 
## Declaration

I, Abdihakim Mahamed, declare that I am the sole author of the content I add to this repository.  
I, Name 2, declare that I am the sole author of the content I add to this repository.  

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

All logic will be separated into proper classes (e.g., `Piece`, `Board`, `GameManager`) to allow easier testing and development.

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

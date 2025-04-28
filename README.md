Journey to the End of the Line

  A console-based adventure game developed in C# (.NET 8.0)

Overview

  Journey to the End of the Line is a text-based puzzle adventure designed to explore themes of   
  exploration, mystery, and self-awareness.
  The project showcases modular programming practices, custom console UI systems, and structured 
  game architecture using C#.

Technology Stack

  Language: C#
  Framework: .NET 8.0 Console Application
  IDE: Visual Studio 2022 Community Edition

Architecture:

  Modularized by Acts, Systems, and Maps
  Separation of gameplay logic, rendering, and UI presentation
  Minimal third-party dependencies
  
Gameplay Instructions

  Use W, A, S, D or Arrow Keys to move.
  Press E to interact with environmental objects.
  Press Q to exit an Act after completing required objectives.

Project Structure

  File/Folder	Description
    Program.cs	Entry point; controls main game loop and flow between Acts.
    Acts/	Contains Act1.cs, Act2.cs, Act3.cs (narrative progression and puzzles).
    Systems/	Inventory, Movement, and UI handling.
    Maps/	Static map layouts for each Act.
    GameState.cs	Manages player inventory, progression flags, and overall state.
    
Major Gameplay Features

  Act 1: The Forest of Tusks
    Solve fire and key puzzles to unlock a hidden gate.
    Introduces the first Beastman encounter.
  Act 2: The Storm at Sea
    Explore a drifting ghost ship.
    Solve a star-based ritual puzzle.
    Optional mini-games: Tarot reading and Tic-Tac-Toe puzzle.
  Act 3: The Celestial Ascent
    Final confrontation with the entity "Aborash."
    Player chooses between accepting the truth or engaging in a symbolic battle.
    Integrated glitch sequences and lore payoff.
  Inventory Management
    Players can collect and use items to solve puzzles and unlock new areas.
  Custom Console UI
    Typewriter effects, glitch text displays, and colored console outputs.
    
Hidden/Developer Features

  Developer skip functionality for Acts has been removed for public release.
  Secret key during the Aborash battle remains (undocumented for players).

Known Limitations

  No save or checkpoint system (playthroughs are intended to be single-session).
  No graphical assets; experience is fully text-based.
  Beep-based audio only (no advanced sound engine integration).

Development Notes

  Designed to demonstrate modular, extensible C# programming skills.
  Engineered for quick demoability, narrative pacing, and thematic consistency.
  Readability, maintenance, and extensibility were prioritized in the project's structure.

Future Improvement Opportunities
  Save/Load functionality for longer play sessions.
  Additional Acts expanding the lore and world.
  Optional side-quests and achievement tracking.
  Procedurally generated map layouts for enhanced replayability.

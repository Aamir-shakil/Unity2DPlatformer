Unity 2D Platformer 
Overview

This project is a Unity-based 2D platformer developed to demonstrate the application of software design patterns and automated testing within a real gameplay environment.

The game includes core mechanics such as player movement (running, jumping, wall sliding, wall jumping), double jumping, collectible items, a health system with UI, enemy interactions, temporary power-ups, and win/lose conditions.

The primary focus of the project is to improve code structure, scalability, and reliability through architectural refactoring and testing.

Project Structure

This repository is organised into two main branches:

Main Branch – Baseline Implementation

The main branch contains the original version of the game.
In this version:

Core functionality is implemented in a direct and monolithic manner
Logic is primarily handled through conditional statements
Scripts are more tightly coupled

This branch represents the initial implementation and serves as a baseline for comparison.

Refactored Branch – Improved Architecture

The refactored branch contains the improved version of the project.

This version introduces:

State Pattern for managing player behaviour
Observer Pattern for event-driven communication between systems
Decorator Pattern for extending gameplay effects such as power-ups

The refactored version demonstrates:

Improved modularity
Reduced coupling between components
Clearer separation of responsibilities
Better support for testing and future extension
Testing

The project includes automated testing using the Unity Test Framework.

Edit Mode tests are used for unit testing, allowing validation of isolated logic such as gameplay effects
Play Mode tests are used for integration testing, validating interactions between systems during runtime

This combination ensures both component-level correctness and system-level reliability.

Requirements
Unity Hub
Unity Editor (recommended: 2021 LTS or 2022 LTS)
Visual Studio or Visual Studio Code (for C# scripting)
Installation and Setup
1. Clone the repository
git clone https://github.com/YOUR-USERNAME/YOUR-REPO-NAME.git
2. Open the project in Unity
Open Unity Hub
Select “Open Project”
Choose the cloned project folder
3. Select the desired branch

Use Git to switch between versions:

git checkout main

For the baseline version

git checkout refactored

For the refactored version

4. Open the main scene

Navigate to:

Assets/Scenes/

Open the main game scene.

5. Run the project

Press Play in the Unity Editor to start the game.

Controls
Move: A / D or Arrow Keys
Jump: Space/ up arrow
Double Jump: Space/up arrow while airborne
Wall Slide: Move towards a wall
Wall Jump: Jump while attached to a wall
Development Approach

The project was developed incrementally, with changes committed and uploaded to GitHub throughout development. 

Notes

The two branches represent different architectural approaches to the same game. The project is intended to demonstrate the application of software engineering practices within game development, rather than serve as a complete commercial product.

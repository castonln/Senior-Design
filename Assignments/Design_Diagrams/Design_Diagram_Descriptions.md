## Conventions
Boxes - Objects, things, abstractions
Arrows - Interaction methods
Nested Boxes - Abstractions within abstractions

At the highest level, the design diagram examines the relationship between users, the game, and its leaderboard. 
This is because, at its core, the purpose of this project is to connect UC students.

At a layer deeper the diagram describes the inner-workings of the game more concretely. It separates its logic from its visuals,
and its visuals are separated into UI and graphical elements that are part of the game.

Finally, at its deepest layer, the diagram defines all UI needed and how the main game loop functions. The loop and UI interact with each other,
but are independent of each other (UI can be accessed regardless of if a wave has started or not).

# CommandPattern
This is a collection of exercises in implementing Command Pattern in C#. I wrote this project to learn this pattern and to get started with C#.
I wanted to experiment with a couple of ideas, so there are two sub-projects.
The point was to achieve a sufficiently flexible architecture thanks to this pattern. Keep in mind that what the code does beyond that is for illustrative purposes only.
These are console applications with a basic CLI and ASCII display. My implementation of an Invoker responds to key inputs that can be parameterized in its constructor.

## CommandPatternExample1
Here we work with an Invoker with a data structure of `AbstractCommand`s, as well as a `CommandHistory` that allows us to undo the last executed command, and to redo the last undone command.

We have `Lamp` Receivers such that:
- A turned OFF `Lamp` can be turned ON
- A turned ON `Lamp` can be turned OFF
- A turned ON `Lamp` can switch color
- A turned ON `Lamp` can increase intensity if it is below its maximum
- A turned ON `Lamp` can decrease intensity if it is above its minimum

Any action that falls outside of this scope cannot be performed. This means that a "Turn ON" command that targets a turned ON Lamp does nothing. Because this command never executes, it cannot be stored in the history.
I tried to solve this by doing the following:
- Each receiver action (turnOn, switchColor, ...) returns a bool to represent a success/failure.
- Each command stores an internal state `_hasExecuted` that updates whenever `Execute()` is called.
- The history stores *copies* of commands instead of references to the commands passed to the Invoker, since each command has its own internal state.

The solution works but looks a little unintuitive and impractical. I could not find a way to implement MacroCommands (group of multiple commands) with this architecture either. 
The main problem is that within a MacroCommand, it is possible that some commands `Execute()` while others do not.
Undoing such a MacroCommand seemed tricky since it would have to keep track of the individual state of each sub-command. 
It gets worse if we think about MacroCommands made of smaller MacroCommands...


## CommandPatternExample2
Here we work with an Invoker with a data structure of `ICommand`s that do not diverge from the default pattern. We still have a `CommandHistory` to Undo and Redo.

We have `Lamp` and `RotatingArm` Receivers (I was short on inspiration ;)) with a bunch of actions, but this time *all actions are reversible*:
- A `Lamp` can be toggled ON/OFF
- A `Lamp` can cycle between colors
- A `Lamp` can cycle intensity between its minimum and maximum
- A `RotatingArm` can rotate by some angle
- A `RotatingArm` can move its hand along its length (at max length, it resets to 0)

This time the history simply stores references to the commands passed to the Invoker, which feels better. A command encapsulates its target receiver, but has no other internal state.
With this simpler setup I was able to define `MacroCommand`s that are also `ICommand`s, thus allowing command composition.

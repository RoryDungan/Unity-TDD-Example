# Unity TDD Example

This repo is a compainion to my talk on test-driven-development in Unity. It 
shows an example of how to do TDD in a Unity game with a very simple breakout
clone.

## Project structure

The project is split up into the Unity project and a separate C# DLL project
found in the `GameDLL` folder that contains the code for the game. This is 
so that we can easily run the unit tests in Visual Studio or from the command 
line outside of Unity.

The GameDLL project has the following structure:

    Game/               - Game code

        BreakoutGame/   - Code for the game itself, covered by Unit tests

        Unity/          - MonoBehaviours that link to classes from BreakoutGame

        UnityWrapper/   - Wrappers around Unity classes that enable us to 
                          replace them with Mocks in the unit tests. All code in
                          BreakoutGame should talk to these interfaces instead
                          of using the Unity API directly.

    GameTests/          - Unit tests.

    Unity/              - Unity DLLs, needed in order to reference Unity APIs 
                          from the Game DLL.

Unit tests use [NUnit](http://nunit.org/), with [Moq](https://github.com/Moq/moq4/wiki/Quickstart)
for mocking.

Integration tests use the [Unity Test Runner](https://docs.unity3d.com/Manual/testing-editortestsrunner.html),
which is also based on NUnit but with some Unity-specific extensions.



## Getting started

The Unity project requires Unity 2018.1, as it is built with the new .NET 4.x 
runtime. To make modifications to the game, you will need to modify the code in 
GameDLL.

### Using Visual Studio

First, you will need to make sure you have the [.NET Core SDK](https://www.microsoft.com/net/learn/get-started)
installed.

Load up `GameDLL/GameDLL.sln` and build it. This should automatically restore 
NUnit, the NUnit test runner and Moq from Nuget but if they are missing, 
right-click on the solution in the solution explorer and chose "Restore Nuget 
packages". 

You should be able to see and run unit tests in the *Test explorer* window. 
When you want to see your changes in Unity, just build the project and 
`GameDLL.dll` will automatically be copied into the Unity project.

### Using the dotnet CLI

Download and install the
[.NET Core SDK](https://www.microsoft.com/net/learn/get-started).

Run `dotnet build` to build the project and copy DLLs to Unity.

Run `dotnet test` to run the unit test suite.
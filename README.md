# Welcome to Toy Robot

### Run the application

- Clone the repository and goto the folder
```console
git clone git@github.com:ShahabJ/toy_robot.git
cd toy_robot
```

- Build the application (Note:You need .NET Core 5 SDK to build the application)
```console
dotnet build
```
- Create a text file which each line has a command (There are sample files in 'ToyRobot.Console_App/SampleInput' folder)

- Run the application by the folloing commnad
```console
cd ToyRobot.Console_App/ 
dotnet run "Location of created txt file."
```

You can use the the below command as a sample
```console
cd ToyRobot.Console_App/ 
dotnet run "./SampleInput/test_case_a.txt"
```



## Scenario

Create a library that can read in commands of the following form:
- PLACE X, Y, DIRECTION
- MOVE
- LEFT
- RIGHT
- REPORT

## Solution Requirements

- The library allows for a simulation of a toy robot moving on a 6 x 6 square tabletop.
- There are no obstructions on the table surface.
- The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. Any movement that would result in this must be prevented, however further valid movement commands must still be allowed.
- PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
(0,0) can be considered as the SOUTH WEST corner and (5,5) as the NORTH EAST corner.
- The first valid command to the robot is a PLACE command. After that, any sequence of commands may be issued, in any order, including another PLACE command. The library should discard all commands in the sequence until a valid PLACE command has been executed.
- The PLACE command should be discarded if it places the robot outside of the table surface.
- Once the robot is on the table, subsequent PLACE commands could leave out the direction and only provide the coordinates. When this happens, the robot moves to the new coordinates without changing the direction.
- MOVE will move the toy robot one unit forward in the direction it is currently facing.
- LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
- REPORT will announce the X,Y and orientation of the robot.
- A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands.

## Requirements

The project requires [.NET Core 5.0](https://dotnet.microsoft.com/download/dotnet/5.0). 
Kindly note that this project may not work with older versions of .NET.

## Compatible IDEs

Tested on:
- Visual Studio Code for Mac  (with C# OmniSharp extension)

## Useful commands

### Build the project

```console
dotnet build
```

### Run the tests

```console
dotnet test ToyRobot.Test/
```

### Run the application
```console
cd ToyRobot.Console_App/ 
dotnet run "./SampleInput/test_case_a.txt"
```

### Sample Output 
```console
======Start =====
Detected commands: PLACE 0,0,NORTH
Detected commands: MOVE
Detected commands: REPORT
0,1,NORTH
======End=====
```
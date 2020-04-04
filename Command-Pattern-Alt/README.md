# Command Design Pattern (alternative question)

This question is designed to replace the one from "Worksheet Eight" which required some understanding of processes.

## Question

The task is to write an *undo‐redo* mechanism for a simple system; this example is a Square Manipulation System (SMS).

### Input

The program reads its data as successive lines from standard input. 
A line has one of the following forms, where `i`, `j`, and `k`, are non‐negative integers:

```
Cij 
Mijk 
Sij
U
R 
P
```

Your program may assume that the input follows this syntax; error handling is not required.

### Details

Note that no graphical display is needed. 

+ All information about squares will be output textually (see the `P` command).
+ The `C` command (Create) creates square number `i` with side length `j`, centred at the origin. 
It replaces any previous square with number `i`.
+ The `M` command (Move) moves square number `i` by `j` pixels to the right and `k` pixels upwards. 
If there is no square numbered `i`, the command has no effect.
+ The `S` command (Scale) scales square numbered `i` by a factor of `j`. 
If there is no square numbered `i`, the command has no effect.
+ The `U` command (Undo) cancels the last not‐yet‐undone `C`, `M` or `S` command. 
If none remains to be undone, `U` has no effect.
+ The `R` command (Redo) is applicable only if the last executed command was `U` or `R`, otherwise it does nothing. 
It re‐executes the most recent `C`, `M` or `S` command undone and not yet redone.
+ The `P` command (Print) prints on standard output details of all squares in the system. 
Squares are printed in ascending order with respect to number, one per line, where each line has the format:

	```
ijkl
```

	where `i` is the square number, `j` its horizontal coordinate, `k` its vertical coordinate, and `l` its side length. The values should be separated by single spaces.

### Suggestions

The standard solution for *undo‐redo*, which you are encouraged to use, is documented in  Gamma et al. (“Command pattern”). 

The central abstraction in this solution is the *undoable* command. 
There is a type `Command` whose instances represent "undoable" commands (here one other than `U`, `R` or `P`); 
for each command kind, a descendant of `Command` is created, for example, `Move`, with attributes containing just enough information to do and undo one execution of the command. 
For example, in a text editor, a class for “delete a line” would have attributes storing the contents of a line and its position in the file. 
The program contains a history list — a list of `Command` objects that can be traversed back and forth to process a sequence of `U` and `R` commands. 
Note that there is no fixed limit on the number of undo‐redo levels.


### Credits

Thanks to Bertrand Meyer @ ETH for the basis of this exercise.
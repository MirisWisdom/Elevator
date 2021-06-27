<html>
    <h1 align='center'>
        Elevator
    </h1>
    <p align='center'>
        A nimble and spiffy program for invoking executables with elevated privileges.
    <p>
</html>

## Introduction

A tiny program for invoking a given executable with elevated privileges. Any parameters passed to Elevator will be passed onto the intended executable.

```sh
~/elevator.exe --executable '~/program.exe' --argument "hello" /a "world" --arg=3
#              |--------------------------| |-----------------------------------|
#              |                            |
#              |                            +- arguments for ~/program.exe
#              +------------------------------ invoke ~/program.exe
```

The most practical use of Elevator is to allow an unprivileged program to raise its own privileges when necessary. The program in question can invoke itself through Elevator and thus acquire elevated privileges.

## Features

Hopefully these will bring some sweet value to the table:

- Invoke any excutable with UAC and pass any parameters to it through `elevator.exe`;
- Targets .NET v4.5.2 for significant compatibility with operating systems going back a tenth of a century;
- Minimal and unobtrusive: it's the simplest CLI, meaning you can bundle it with your program or even repository;
- STDOUT/STDERR redirection from the invoked executable, to the Elevator's console;
- The exit code of Elevator is always the one of the invoked executable.

## Requirements

The bare minimum required .NET version is v4.5.2 on any Windows OS that is supported by said version.
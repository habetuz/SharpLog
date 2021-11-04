---
title: Home
---

# Welcome to SharpLog
A small logger for big projects.

[Installation](Getting started/#installation) and [usage](Getting started/#usage) under [Getting started](Getting started/).

Full documentation under [Reference](/Reference/Logger/).

???+ warning "Version"
    This documentation is up to date with version `2.4.*`

## Features
- [x] Easy to use
- [x] Asynchronous logging
- [x] File and console outputs integrated
- [x] Easy to implement custom outputs
- [x] Easy toggling of log levels

## Example
Example log from [GameSense](https://github.com/habetuz/GameSense).
```
[10-07-2021 | 12:19:42.472] [Info] [Main]: Program started. Welcome.
[10-07-2021 | 12:19:42.489] [Info] [GameSense/Controller]: Background set.
[10-07-2021 | 12:19:42.504] [Info] [GameSense/Controller]: Mouse animation set.
[10-07-2021 | 12:19:42.584] [Info] [GameSense/InputManager]: Starting...
[10-07-2021 | 12:19:42.596] [Info] [GameSense/InputManager]: Ready!
[10-07-2021 | 12:19:42.596] [Info] [GameSense/Controller]: Name set: KALE
[10-07-2021 | 12:19:42.596] [Info] [GameSense/Controller]: Display name set: KaLE
[10-07-2021 | 12:19:42.596] [Info] [GameSense/Controller]: Developer set: Marvin Fuchs
[10-07-2021 | 12:19:42.596] [Info] [GameSense/Controller]: Starting...
[10-07-2021 | 12:19:42.596] [Info] [GameSense/Controller]: Registering game...
[10-07-2021 | 12:19:42.820] [Info] [GameSense/Transmitter]: Starting...
[10-07-2021 | 12:19:43.119] [Info] [GameSense/Transmitter]: GameSense server is running on 127.0.0.1:49748
[10-07-2021 | 12:19:43.119] [Info] [GameSense/Transmitter]: Ready!
[10-07-2021 | 12:19:43.424] [Info] [GameSense/Controller]: Heartbeat started.
[10-07-2021 | 12:19:43.424] [Info] [GameSense/Controller]: Binding events...
[10-07-2021 | 12:19:43.449] [Info] [GameSense/Controller]: Keyboard event binned!
[10-07-2021 | 12:19:43.483] [Info] [GameSense/Controller]: Mouse events binned!
[10-07-2021 | 12:19:43.484] [Info] [GameSense/Controller]: UpdateTimer ready.
[10-07-2021 | 12:19:43.485] [Info] [GameSense/Controller]: Ready!
[10-07-2021 | 12:24:42.590] [Info] [GameSense/InputManager]: Inputs
| 16x Left
|  3x Space
|  1x Return

[10-07-2021 | 12:24:42.734] [Info] [GameSense/Transmitter]: Transitions
|    1x /game_metadata
|    1x /bind_game_event
|    8x /register_game_event
| 4692x /multiple_game_events
|   29x /game_heartbeat
```
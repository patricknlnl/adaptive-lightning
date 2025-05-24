# Piano Trainer

This is a simple Windows WPF application that listens to an attached MIDI keyboard and displays the notes that you play. It uses the [NAudio](https://github.com/naudio/NAudio) library for MIDI input.

## Features

- Connects to the first available MIDI input device
- Displays incoming note events in a list

## Building

Install the [.NET SDK](https://dotnet.microsoft.com/download) for Windows and run:

```bash
cd PianoTrainer
 dotnet restore
 dotnet build
```

Run the application with `dotnet run`.

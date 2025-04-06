# AudioMetaReader

A console application for analyzing audio file metadata. The application supports various audio file formats and provides information about their characteristics.

## Features

- Support for WAV and MP3 file formats
- Metadata extraction including:
  - File name
  - Format
  - Bitrate
  - Sample rate
  - Number of channels
  - Duration
- Support for both single file and directory processing
- Extensible architecture for adding new formats

## Requirements

- .NET 6.0 or later
- Windows OS

## Installation

1. Clone the repository
2. Build the solution using Visual Studio or .NET CLI:
   ```bash
   dotnet build
   ```

## Usage

Run the application from the command line:

```bash
AudioMetaReader <path to file or directory>
```

## Architecture

The application follows SOLID principles and uses:
- Factory pattern for creating audio file objects
- Strategy pattern for reading metadata
- Dependency Injection for flexibility and testability

## Roadmap

### Phase 1: Basic Functionality (MVP)
- [x] Project structure creation
- [ ] Implementation of base classes and interfaces
- [ ] WAV file support
- [ ] MP3 file support
- [ ] Console interface implementation
- [ ] Basic output formatting

### Phase 2: Improvements and Optimization
- [ ] Support for additional formats (FLAC, OGG, AAC)
- [ ] Error handling improvements
- [ ] Performance optimization
- [ ] Logging implementation
- [ ] Unit tests creation

### Phase 3: Extended Functionality
- [ ] Batch processing support
- [ ] Export to various formats (CSV, JSON)
- [ ] GUI implementation
- [ ] Network sources support
- [ ] Cloud storage integration

### Phase 4: Additional Features
- [ ] Audio characteristics analysis (spectrogram, volume)
- [ ] Metadata editing support
- [ ] Database integration
- [ ] API for integration with other applications
- [ ] Plugin support

## License

This project is licensed under the [MIT](LICENSE) License. 
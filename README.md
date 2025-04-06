# AudioMetaReader

A console application for analyzing audio file metadata. The application supports various audio file formats and provides information about their characteristics.

## Features

- Support for multiple audio formats:
  - WAV
  - MP3
  - FLAC
  - OGG
  - AAC
- Metadata extraction including:
  - File name
  - Format
  - Bitrate
  - Sample rate
  - Number of channels
  - Duration
- Support for both single file and directory processing
- Formatted console output in table format
- Export to CSV and JSON formats
- Comprehensive logging
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

### Basic Usage
```bash
AudioMetaReader <path to file or directory>
```

### Export Options
```bash
# Export to CSV
AudioMetaReader <path> --export-csv <output.csv>

# Export to JSON
AudioMetaReader <path> --export-json <output.json>

# Export to both formats
AudioMetaReader <path> --export-csv <output.csv> --export-json <output.json>
```

## Logging

The application logs all operations to both console and file. Log files are stored in the `logs` directory with daily rotation.

## Architecture

The application follows SOLID principles and uses:
- Factory pattern for creating audio file objects
- Strategy pattern for reading metadata
- Dependency Injection for flexibility and testability
- Serilog for logging
- Newtonsoft.Json for JSON export

## Roadmap

### Phase 1: Basic Functionality (MVP)
- [x] Project structure creation
- [x] Implementation of base classes and interfaces
- [x] WAV file support
- [x] MP3 file support
- [x] Console interface implementation
- [x] Basic output formatting
- [x] Additional format support (FLAC, OGG, AAC)
- [x] Error handling improvements
- [x] Logging implementation
- [x] Export to CSV and JSON

### Phase 2: Improvements and Optimization
- [ ] Performance optimization
- [ ] Unit tests creation
- [ ] Additional metadata fields
- [ ] Parallel processing support

### Phase 3: Extended Functionality
- [ ] GUI implementation
- [ ] Network sources support
- [ ] Cloud storage integration
- [ ] Batch processing improvements

### Phase 4: Additional Features
- [ ] Audio characteristics analysis (spectrogram, volume)
- [ ] Metadata editing support
- [ ] Database integration
- [ ] API for integration with other applications
- [ ] Plugin support

## License

This project is licensed under the [MIT](LICENSE) License. 
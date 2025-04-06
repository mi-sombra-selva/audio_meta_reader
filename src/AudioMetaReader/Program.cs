using AudioMetaReader.Core;
using AudioMetaReader.Export;
using AudioMetaReader.Utils;
using AudioMetaReader.Metadata;

namespace AudioMetaReader
{
    class Program
    {
        private static List<AudioMetadata> _metadataList = new List<AudioMetadata>();

        static void Main(string[] args)
        {
            try
            {
                Logger.Info("Application started");

                if (args.Length == 0)
                {
                    Console.WriteLine("Usage: AudioMetaReader <path to file or directory> [--export-csv <path>] [--export-json <path>]");
                    return;
                }

                var path = args[0];
                var exportCsvPath = GetArgumentValue(args, "--export-csv");
                var exportJsonPath = GetArgumentValue(args, "--export-json");
                
                if (File.Exists(path))
                {
                    ProcessFile(path);
                }
                else if (Directory.Exists(path))
                {
                    ProcessDirectory(path);
                }
                else
                {
                    Logger.Error($"Path {path} does not exist");
                    Console.WriteLine($"Path {path} does not exist");
                    return;
                }

                if (_metadataList.Any())
                {
                    ConsoleTable.PrintTable(_metadataList);

                    if (!string.IsNullOrEmpty(exportCsvPath))
                    {
                        ExportService.ExportToCsv(_metadataList, exportCsvPath);
                    }

                    if (!string.IsNullOrEmpty(exportJsonPath))
                    {
                        ExportService.ExportToJson(_metadataList, exportJsonPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("An error occurred during execution", ex);
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                Logger.Info("Application finished");
            }
        }

        static void ProcessFile(string filePath)
        {
            try
            {
                Logger.Debug($"Processing file: {filePath}");
                var audioFile = AudioFileFactory.CreateAudioFile(filePath);
                audioFile.ReadMetadata();
                _metadataList.Add(audioFile.Metadata);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error processing file {filePath}", ex);
                Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
            }
        }

        static void ProcessDirectory(string directoryPath)
        {
            try
            {
                Logger.Debug($"Processing directory: {directoryPath}");
                var audioFiles = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                    .Where(f => f.EndsWith(".wav", StringComparison.OrdinalIgnoreCase) || 
                               f.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase) ||
                               f.EndsWith(".flac", StringComparison.OrdinalIgnoreCase) ||
                               f.EndsWith(".ogg", StringComparison.OrdinalIgnoreCase) ||
                               f.EndsWith(".aac", StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (!audioFiles.Any())
                {
                    Logger.Info("No audio files found in the specified directory");
                    Console.WriteLine("No audio files found in the specified directory");
                    return;
                }

                Logger.Info($"Found {audioFiles.Count} audio files");
                Console.WriteLine($"Found {audioFiles.Count} audio files:");

                foreach (var file in audioFiles)
                {
                    ProcessFile(file);
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Error processing directory {directoryPath}", ex);
                Console.WriteLine($"Error processing directory {directoryPath}: {ex.Message}");
            }
        }

        private static string GetArgumentValue(string[] args, string argumentName)
        {
            var index = Array.IndexOf(args, argumentName);
            if (index >= 0 && index + 1 < args.Length)
            {
                return args[index + 1];
            }
            return null;
        }
    }
}

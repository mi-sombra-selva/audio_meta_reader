using AudioMetaReader.Core;

namespace AudioMetaReader
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: AudioMetaReader <path to file or directory>");
                return;
            }

            var path = args[0];
            
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
                Console.WriteLine($"Path {path} does not exist");
            }
        }

        static void ProcessFile(string filePath)
        {
            try
            {
                var audioFile = AudioFileFactory.CreateAudioFile(filePath);
                audioFile.ReadMetadata();
                
                Console.WriteLine("Audio file metadata:");
                Console.WriteLine(audioFile.Metadata);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
            }
        }

        static void ProcessDirectory(string directoryPath)
        {
            var audioFiles = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                .Where(f => f.EndsWith(".wav", StringComparison.OrdinalIgnoreCase) || 
                           f.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!audioFiles.Any())
            {
                Console.WriteLine("No audio files found in the specified directory");
                return;
            }

            Console.WriteLine($"Found {audioFiles.Count} audio files:");
            Console.WriteLine();

            foreach (var file in audioFiles)
            {
                ProcessFile(file);
                Console.WriteLine();
            }
        }
    }
}

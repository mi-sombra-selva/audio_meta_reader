using AudioMetaReader.Metadata;

namespace AudioMetaReader.Core
{
    public static class AudioFileFactory
    {
        public static AudioFile CreateAudioFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            var extension = Path.GetExtension(filePath).ToLowerInvariant();

            return extension switch
            {
                ".wav" => new WavFile(filePath, new WavMetadataReader()),
                ".mp3" => new Mp3File(filePath, new Mp3MetadataReader()),
                _ => throw new NotSupportedException($"File format {extension} is not supported")
            };
        }
    }
} 
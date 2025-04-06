namespace AudioMetaReader.Metadata
{
    public class OggMetadataReader : IMetadataReader
    {
        public AudioMetadata ReadMetadata(string filePath)
        {
            using (var file = TagLib.File.Create(filePath))
            {
                var properties = file.Properties;
                
                return new AudioMetadata
                {
                    FileName = Path.GetFileName(filePath),
                    Format = "OGG",
                    Bitrate = (int)(properties.AudioBitrate / 1000), // Convert to kbps
                    SampleRate = properties.AudioSampleRate,
                    Channels = properties.AudioChannels,
                    Duration = properties.Duration.TotalSeconds
                };
            }
        }
    }
}

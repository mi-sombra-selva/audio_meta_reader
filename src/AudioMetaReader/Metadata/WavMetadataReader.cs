namespace AudioMetaReader.Metadata
{
    public class WavMetadataReader : IMetadataReader
    {
        public AudioMetadata ReadMetadata(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fileStream))
            {
                // Reading WAV file header
                var riff = reader.ReadChars(4);
                var fileSize = reader.ReadInt32();
                var wave = reader.ReadChars(4);
                var fmt = reader.ReadChars(4);
                var fmtSize = reader.ReadInt32();
                var audioFormat = reader.ReadInt16();
                var numChannels = reader.ReadInt16();
                var sampleRate = reader.ReadInt32();
                var byteRate = reader.ReadInt32();
                var blockAlign = reader.ReadInt16();
                var bitsPerSample = reader.ReadInt16();

                // Skip the rest of the fmt block
                reader.ReadBytes(fmtSize - 16);

                // Looking for data block
                while (true)
                {
                    var blockId = new string(reader.ReadChars(4));
                    var blockSize = reader.ReadInt32();
                    
                    if (blockId == "data")
                    {
                        var dataSize = blockSize;
                        var duration = (double)dataSize / (sampleRate * numChannels * (bitsPerSample / 8));

                        return new AudioMetadata
                        {
                            FileName = Path.GetFileName(filePath),
                            Format = "WAV",
                            Bitrate = (int)(byteRate * 8 / 1000), // Convert to kbps
                            SampleRate = sampleRate,
                            Channels = numChannels,
                            Duration = duration
                        };
                    }
                    
                    reader.ReadBytes(blockSize);
                }
            }
        }
    }
}

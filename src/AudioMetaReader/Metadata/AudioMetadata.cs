namespace AudioMetaReader.Metadata
{
    public class AudioMetadata
    {
        public string FileName { get; set; }
        public string Format { get; set; }
        public int Bitrate { get; set; }
        public int SampleRate { get; set; }
        public int Channels { get; set; }
        public double Duration { get; set; }

        public override string ToString()
        {
            return $"File: {FileName}\n" +
                   $"Format: {Format}\n" +
                   $"Bitrate: {Bitrate} kbps\n" +
                   $"Sample rate: {SampleRate} Hz\n" +
                   $"Channels: {Channels}\n" +
                   $"Duration: {Duration:F2} sec";
        }
    }
} 
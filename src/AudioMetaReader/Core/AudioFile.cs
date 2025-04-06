using AudioMetaReader.Metadata;

namespace AudioMetaReader.Core
{
    public abstract class AudioFile
    {
        public string FilePath { get; }
        public AudioMetadata Metadata { get; protected set; }

        protected AudioFile(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public abstract void ReadMetadata();
    }
}

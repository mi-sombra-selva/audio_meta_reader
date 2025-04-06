using AudioMetaReader.Metadata;

namespace AudioMetaReader.Core
{
    public class Mp3File : AudioFile
    {
        private readonly IMetadataReader _metadataReader;

        public Mp3File(string filePath, IMetadataReader metadataReader) : base(filePath)
        {
            _metadataReader = metadataReader;
        }

        public override void ReadMetadata()
        {
            Metadata = _metadataReader.ReadMetadata(FilePath);
        }
    }
} 
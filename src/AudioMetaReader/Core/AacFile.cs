using AudioMetaReader.Metadata;

namespace AudioMetaReader.Core
{
    public class AacFile : AudioFile
    {
        private readonly IMetadataReader _metadataReader;

        public AacFile(string filePath, IMetadataReader metadataReader) : base(filePath)
        {
            _metadataReader = metadataReader;
        }

        public override void ReadMetadata()
        {
            Metadata = _metadataReader.ReadMetadata(FilePath);
        }
    }
}

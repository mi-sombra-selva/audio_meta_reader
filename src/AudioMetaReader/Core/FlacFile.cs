using AudioMetaReader.Metadata;

namespace AudioMetaReader.Core
{
    public class FlacFile : AudioFile
    {
        private readonly IMetadataReader _metadataReader;

        public FlacFile(string filePath, IMetadataReader metadataReader) : base(filePath)
        {
            _metadataReader = metadataReader;
        }

        public override void ReadMetadata()
        {
            Metadata = _metadataReader.ReadMetadata(FilePath);
        }
    }
}

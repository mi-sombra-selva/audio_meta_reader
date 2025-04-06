namespace AudioMetaReader.Metadata
{
    public interface IMetadataReader
    {
        AudioMetadata ReadMetadata(string filePath);
    }
}

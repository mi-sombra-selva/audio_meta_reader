using AudioMetaReader.Metadata;
using AudioMetaReader.Utils;
using Newtonsoft.Json;

namespace AudioMetaReader.Export
{
    public static class ExportService
    {
        public static void ExportToCsv(List<AudioMetadata> metadataList, string outputPath)
        {
            try
            {
                var lines = new List<string>
                {
                    "FileName,Format,Bitrate,SampleRate,Channels,Duration"
                };

                lines.AddRange(metadataList.Select(m => 
                    $"{m.FileName},{m.Format},{m.Bitrate},{m.SampleRate},{m.Channels},{m.Duration:F2}"));

                File.WriteAllLines(outputPath, lines);
                Logger.Info($"Successfully exported data to CSV file: {outputPath}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Error exporting to CSV: {ex.Message}", ex);
                throw;
            }
        }

        public static void ExportToJson(List<AudioMetadata> metadataList, string outputPath)
        {
            try
            {
                var json = JsonConvert.SerializeObject(metadataList, Formatting.Indented);
                File.WriteAllText(outputPath, json);
                Logger.Info($"Successfully exported data to JSON file: {outputPath}");
            }
            catch (Exception ex)
            {
                Logger.Error($"Error exporting to JSON: {ex.Message}", ex);
                throw;
            }
        }
    }
}

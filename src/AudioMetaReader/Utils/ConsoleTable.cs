using System.Text;

namespace AudioMetaReader.Utils
{
    public static class ConsoleTable
    {
        public static void PrintTable(List<AudioMetaReader.Metadata.AudioMetadata> metadataList)
        {
            if (metadataList == null || !metadataList.Any())
                return;

            var headers = new[] { "File Name", "Format", "Bitrate (kbps)", "Sample Rate (Hz)", "Channels", "Duration (sec)" };
            var rows = metadataList.Select(m => new[]
            {
                m.FileName,
                m.Format,
                m.Bitrate.ToString(),
                m.SampleRate.ToString(),
                m.Channels.ToString(),
                m.Duration.ToString("F2")
            }).ToList();

            var columnWidths = CalculateColumnWidths(headers, rows);
            var separator = new string('-', columnWidths.Sum() + headers.Length * 3 + 1);

            Console.WriteLine(separator);
            PrintRow(headers, columnWidths);
            Console.WriteLine(separator);

            foreach (var row in rows)
            {
                PrintRow(row, columnWidths);
            }

            Console.WriteLine(separator);
        }

        private static int[] CalculateColumnWidths(string[] headers, List<string[]> rows)
        {
            var widths = new int[headers.Length];
            
            for (int i = 0; i < headers.Length; i++)
            {
                widths[i] = Math.Max(headers[i].Length, rows.Max(r => r[i].Length));
            }

            return widths;
        }

        private static void PrintRow(string[] values, int[] widths)
        {
            var sb = new StringBuilder();
            sb.Append('|');

            for (int i = 0; i < values.Length; i++)
            {
                sb.Append($" {values[i].PadRight(widths[i])} |");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}

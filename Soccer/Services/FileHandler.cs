using System.Collections.Generic;
using System.IO;

namespace Soccer.Services
{
    public class FileHandler
    {
        private Stream stream;

        public FileHandler(Stream fileStream)
        {
            stream = fileStream;
        }

        public IList<string> ParseContent()
        {
            if (stream == null || stream.CanRead == false || stream.Length <= 0) {
                return new List<string>();
            }

            var streamReader = new StreamReader(stream);
            var lines = new List<string>();
            
            // The first lines contains the header
            streamReader.ReadLine();
            while (streamReader.Peek() >= 0) {
                lines.Add(streamReader.ReadLine());
            }
            return lines;
        }
    }
}
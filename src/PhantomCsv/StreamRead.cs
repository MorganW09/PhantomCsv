using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhantomCsv
{
    public class StreamRead
    {

        internal List<string> SplitLine(string line)
        {
            var list = new List<string>();
            var lineSpan = line.AsSpan();
            var startIndex = 0;
            for(int i = 0; i < lineSpan.Length; i++)
            {
                var item = lineSpan[i];
                if (item == ',')
                {
                    list.Add(lineSpan.Slice(startIndex, i - startIndex).ToString());
                    startIndex = i + 1;
                }
            }
            list.Add(lineSpan.Slice(startIndex).ToString());
            return list;
        }

        internal IEnumerable<string> ReadLinesFromString(string path)
        {
            using (var stream = File.OpenRead(path))
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    yield return reader.ReadLine();
                }
            }
        }
    }
}

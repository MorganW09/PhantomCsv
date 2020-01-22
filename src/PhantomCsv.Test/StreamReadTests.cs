using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace PhantomCsv.Test
{
    public class StreamReadTests
    {
        private string getSmallPath()
        {
            return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString(), @"Files\smallString.csv");
        }

        [Fact]
        public void Can_Read_From_File()
        {
            var smallPath = getSmallPath();
            var streamRead = new StreamRead();
            var lines = streamRead.ReadLinesFromString(smallPath);
            lines.Should().HaveCount(50);
        }

        [Fact]
        public void Can_Split_Line_Of_Two_Delimeters()
        {
            var smallPath = getSmallPath();
            var streamRead = new StreamRead();

            var values = streamRead.SplitLine("H,W");
            values.Count.Should().Be(2);
            values.First().Should().Be("H");
            values.Skip(1).First().Should().Be("W");
        }

        [Fact]
        public void Can_Split_Line_Of_Ten_Delimeters()
        {
            var smallPath = getSmallPath();
            var streamRead = new StreamRead();

            var values = streamRead.SplitLine("H,e,l,l,o,W,o,r,l,d");
            values.Count.Should().Be(10);
            values.First().Should().Be("H");
            values[0].Should().Be("H");
            values[1].Should().Be("e");
            values[2].Should().Be("l");
            values[3].Should().Be("l");
            values[4].Should().Be("o");
            values[5].Should().Be("W");
            values[6].Should().Be("o");
            values[7].Should().Be("r");
            values[8].Should().Be("l");
            values[9].Should().Be("d");
        }
    }
}

using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PhantomCsv.Test
{
    public class TypeParserTests
    {
        [Fact]
        public void Can_Identify_SampleTypes()
        {
            var typeParser = new TypeParser<SampleType>();
            var types = typeParser.GetTypes();
            types.Length.Should().Be(4);
            types.First().Item1.Should().Be(typeof(string));
            types.First().Item2.Should().Be("StringType");
            types.Skip(1).First().Item1.Should().Be(typeof(int));
            types.Skip(1).First().Item2.Should().Be("IntType");
            types.Skip(2).First().Item1.Should().Be(typeof(long));
            types.Skip(2).First().Item2.Should().Be("LongType");
            types.Skip(3).First().Item1.Should().Be(typeof(bool));
            types.Skip(3).First().Item2.Should().Be("BoolType");
        }
    }

    public class SampleType
    {
        public string StringType { get; set; }
        public int IntType { get; set; }
        public long LongType { get; set; }
        public bool BoolType { get; set; }
    }
}

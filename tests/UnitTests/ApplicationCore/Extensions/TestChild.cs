using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ApplicationCore.Extensions
{
    public class TestChild : IEquatable<TestChild>
    {
        public Guid Id { get; set; } = new Guid();
        public DateTime Date { get; set; } = DateTime.UtcNow;


        public bool Equals([AllowNull] TestChild other) =>
             other?.Date == Date && other?.Id == Id;
    }
}

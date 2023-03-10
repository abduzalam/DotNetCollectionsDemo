using System.Collections;

namespace IEnumerableTestNUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Cast_Test()
        {
            var primes = new ArrayList
        {
            5,
            3,
            2,
            7
        };

            var primeQuery = primes.Cast<int>().OrderBy(prime => prime).Select(prime => prime);

            var expected = new List<int> { 2, 3, 5, 7 };

            Assert.That(primeQuery, Is.EqualTo(expected));
        }
        [Test]
        public void OfType_Test()
        {
            var cities = new ArrayList
            {
                "London",
                "Paris",
                "Mandrid",
                "Berlin",
                7,
                "Lisbon"
            };

            var cityQuery = cities.OfType<string>();

            var expected = new List<string> {"London","Paris","Mandrid","Berlin","Lisbon" };

            Assert.That(cityQuery, Is.EqualTo(expected));
        }
    }
}
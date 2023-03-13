using System.Collections;
/// This is an NUnit Test project
namespace IEnumerableTestNUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// This Example illustrates the Cast<T> from non-generic collection
        /// </summary>
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
        /// <summary>
        /// This Example illustrates the OfType<T> method from non-generic collection
        /// </summary>
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

        [Test]
        public void OfType_Get_EvenNums()
        {
            var cities = new ArrayList
            {
                "London",
                "Paris",
                "Mandrid",
                "Berlin",
                7,
                "Lisbon",
                2,
                10,
                9
            };

            var evens = cities.OfType<int>().Where(num => num % 2 == 0).Select(num=>num);

            var expected = new List<int> { 2, 10, 8 };

            Assert.That(evens, Is.EqualTo(expected));
        }

        //AsParallel Method
        [Test]
        public void AsParallel_Method()
        {

            var numbers = Enumerable.Range(0, 100);

            var oddCounts = numbers.AsParallel().Count(x => x % 2 != 0);

            var expected = 50;
            Assert.That(oddCounts, Is.EqualTo(expected));
           
        }
    }
}
using System.Collections;

internal class Program
{
    private static void Main(string[] args)
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

        // Assert.Equal(expected, primeQuery);
    }
}
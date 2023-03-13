using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");

        Stopwatch stparallel = new Stopwatch();
        stparallel.Start();
        Console.WriteLine("Calling UsingAsParallel_Method");
        UsingAsParallel_Method();
        Console.WriteLine("Completed UsingAsParallel_Method");
        stparallel.Stop();
        Console.WriteLine($"Time for completion of UsingAsParallel_Method = {stparallel.Elapsed.TotalMilliseconds}");


        Stopwatch stnonparallel = new Stopwatch();
        stnonparallel.Start();
        Console.WriteLine("Calling NotUsingAsParallel_Method");
        NotUsingAsParallel_Method();
        Console.WriteLine("Completed NotUsingAsParallel_Method");
        stnonparallel.Stop();
        Console.WriteLine($"Time for completion of NotUsingAsParallel_Method = {stnonparallel.Elapsed.TotalMilliseconds}");

        Console.ReadLine();

    }
    /// <summary>
    /// In order for parallel computation to happen you have to have multiple processors or cores, otherwise you are just queueing up tasks in the threadpool waiting for the CPU.
    /// I.e. AsParallel on a single core machine is sequential plus the overhead of threadpool and thread context switch. Even on a two core machine, you may not get both cores,
    /// since lots of other things are running on the same machine.
    //  Really.AsParallel() only becomes useful if you have long running tasks with blocking operations(I/O) where the OS can suspend the blocking thread and let another one run.
    //  AsParallel is actually best if you are CPU bound, not IO bound (assuming you have multiple cores). If you are IO bound, it is better to use an async strategy.
    //  You should use async for not blocking workers, i.e. creating Task chains for each,
    //  but you'd still want to use AsParallel to fan out the workers, so they can get threads from the pool to start the chains

    //In this Method, AsParallel method takes more time due to the above reason
    /// </summary>

    public static void UsingAsParallel_Method()
    {

        var numbers = Enumerable.Range(0, 100);

        var oddCounts = numbers.AsParallel().Count(x => x % 2 != 0);

        var expected = 50;

        if (oddCounts != expected)
            Console.WriteLine("Counts Are Not Equal");
        else
            Console.WriteLine("Counts Are Equal");

    }

    public static void NotUsingAsParallel_Method()
    {

        var numbers = Enumerable.Range(0, 100);

        var oddCounts = numbers.Count(x => x % 2 != 0);

        var expected = 50;

        if (oddCounts != expected)
            Console.WriteLine("Counts Are Not Equal");
        else
            Console.WriteLine("Counts Are Equal");

    }
}
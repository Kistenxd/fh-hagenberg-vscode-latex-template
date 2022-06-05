using System;
using System.Threading;

public class APM_Main {
private static int CurrentThread() => Thread.CurrentThread.ManagedThreadId;

public class Calculator {
    // declare delegate for method to call asynchronously
    private delegate int AddHandler(int a, int b);
    private AddHandler _addHandler = Add;

    public static int Add(int a, int b) {          // synchronous Add
        Console.WriteLine("Adding on thread " + CurrentThread());
        Thread.Sleep(1000); // simulate workload
        return a + b;
    }

    public IAsyncResult BeginAdd(int a, int b) { // asynchronous Add
        Console.WriteLine("Calling Add from thread " + CurrentThread());
        // use delegate to run Add on different thread
        return _addHandler.BeginInvoke(a, b, null, null);
    }

    public int EndAdd(IAsyncResult result) {
        Console.WriteLine("Waiting for Add on thread " + CurrentThread());
        // use the delegate to block until result is available
        return _addHandler.EndInvoke(result);
    }
}

static void Main() {
    Calculator calc = new Calculator();
    IAsyncResult result = calc.BeginAdd(5, 5); // Start async call
    Console.WriteLine("Main thread " + CurrentThread() + " is not blocked.");
    int calcValue = calc.EndAdd(result); // Call EndAdd to retrieve the result
    Console.WriteLine("Main thread is blocked");
    Console.WriteLine("Calculation returned " + calcValue);
    /* output:          Calling Add from thread 1
                        Main thread 1 is not blocked.
                        Waiting for Add on thread 1
                        Adding on thread 3
                        Main thread is blocked
                        Calculation returned 10 */
}
}
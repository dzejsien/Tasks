using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;


namespace Tasks.ConsoleApp
{

    class Program
    {
        // ex 1 - simple task - UI is responsive but not work when change UI (one task)
        //static void Main(string[] args)
        //{
        //    WriteLine("Hello World!");

        //    var cnt = 1;
        //    var toChange = 1;

        //    var t = new Task(() =>
        //    {
        //        while (cnt < 5)
        //        {
        //            Write("..." + cnt);
        //            Thread.Sleep(2000);
        //            cnt++;

        //            if (cnt == 3)
        //            {
        //                // works (if u change UI u must change it in diff way)
        //                toChange = 2;
        //            }
        //        }

        //        WriteLine("Tochange: " + toChange);

        //    });

        //    t.Start();

        //    WriteLine(Environment.NewLine);
        //    WriteLine("Task ends " + toChange);
        //    ReadLine();
        //}

        // ex2 - make ui responsive (two tasks)
        //static void Main(string[] args)
        //{
        //    // must do this, in case of console app - if wpf u have UI Thread Context
        //    SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

        //    WriteLine("Hello World!");

        //    var cnt = 1;
        //    var toChange = 1;

        //    var t = new Task(() =>
        //    {
        //        while (cnt < 5)
        //        {
        //            Write("..." + cnt);
        //            Thread.Sleep(2000);
        //            cnt++;
        //        }

        //        toChange = cnt;
        //    });

        //    // antecedent - is the previous task
        //    var t2 = t.ContinueWith((antecedent) =>
        //    {
        //        WriteLine("Tochange: " + toChange);
        //        // here attach to UI Thread to be responsive and refresh UI
        //    }, TaskScheduler.FromCurrentSynchronizationContext());

        //    // to change sth in UI, must call it in context of UI Thread
        //    // but it not enough, this lock the UI also - task will be run in UI Thread
        //    // musst split tasks to two, one which compute, second which update UI
        //    t.Start(/* wrong: TaskScheduler.FromCurrentSynchronizationContext()*/);

        //    WriteLine(Environment.NewLine);
        //    WriteLine("Task ends " + toChange);
        //    ReadLine();
        //}

        // more efficient way to create tasks - by factory
        //static void Main(string[] args)
        //{
        //    // must do this, in case of console app - if wpf u have UI Thread Context
        //    SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

        //    WriteLine("Hello World!");

        //    var cnt = 1;
        //    var toChange = 1;

        //    // more efficient
        //    var t = Task.Factory.StartNew(() =>
        //    {
        //        while (cnt < 5)
        //        {
        //            Write("..." + cnt);
        //            Thread.Sleep(2000);
        //            cnt++;
        //        }

        //        toChange = cnt;
        //    });

        //    var t2 = t.ContinueWith((antecedent) =>
        //    {
        //        WriteLine("Tochange: " + toChange);
        //    }, TaskScheduler.FromCurrentSynchronizationContext());

        //    // it's not necessery - there will be an error
        //    //t.Start();

        //    WriteLine(Environment.NewLine);
        //    WriteLine("Task ends " + toChange);
        //    ReadLine();
        //}

        //static int toChange2 = 1;
        // it's shared - not thread safe!
        //static int cntr = 0;

        // ex - 4 more tasks in parallel
        //static void Main(string[] args)
        //{
        //    // must do this, in case of console app - if wpf u have UI Thread Context
        //    SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

        //    Compute();
        //    Compute();
        //    Compute();

        //    WriteLine(Environment.NewLine);
        //    WriteLine("MAIN THREAD ENDED!");
        //    ReadLine();
        //}

        //static void Compute()
        //{
        //    var taskId = new Random().Next(1, 100);
        //    WriteLine($"Before starting task [{taskId}]");

        //    var t = Task.Factory.StartNew(() =>
        //    {
        //        cntr++;
        //        WriteLine($"RUNNING TASKS NR: {cntr}");
        //        var cnt = 1;
        //        var end = new Random().Next(1, 5);
        //        while (cnt <= end)
        //        {
        //            WriteLine($"Task [{taskId}] with iteration {cnt}/{end}");
        //            Thread.Sleep(1000);
        //            cnt++;
        //        }

        //        toChange2 = cnt;
        //    });

        //    var t2 = t.ContinueWith((antecedent) =>
        //    {
        //        cntr--;
        //        WriteLine($"Ending task [{taskId}] with result: {toChange2}");

        //        if (cntr == 0)
        //        {
        //            WriteLine("ALL TASKS ENDED!!!");
        //        }
        //    }, TaskScheduler.FromCurrentSynchronizationContext());
        //}

        // labda expression = custom class + delegate - if you have () => { ... } it creates class with 
        // void method and create delegate in context of this new class pointing to this new method

        // closure = code + supporting data env - it is the same, but statements in body of method are based on external variables
        // think: variable are passed by ref - so creates poitner to external variable always (shared variables! - race condition! thread unsafe!)
        // compiler: create class with field, and every delegate are called calling to that field

        // TASK - object representing an ongoing computaion

        // ABOVE CODE TASKS

        // FACADES !!!!!!!!!!!!!!!!! - task over existsing operations
        // TaskCompletionSource<> and get from that Task - there is !!no CODE!!, SetResult - complition


        #region BEGING OF NEW EXERCIES - NOT IN TASK
        //static void Main(string[] args)
        //{
        //    // must do this, in case of console app - if wpf u have UI Thread Context
        //    SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

        //    Compute();

        //    WriteLine(Environment.NewLine);
        //    WriteLine("MAIN THREAD ENDED!");
        //    ReadLine();
        //}

        //static void Compute()
        //{
        //    var result = GetData();

        //    var min = result.Min();
        //    var max = result.Max();
        //    var avg = result.Average();

        //    WriteLine("Min: " + min);
        //    WriteLine("Max: " + max);
        //    WriteLine("Avg: " + avg);
        //}

        //static IList<int> GetData()
        //{
        //    var result = new List<int>();

        //    result.Add(GetDataFromNet());
        //    result.Add(GetDataFromNet());
        //    result.Add(GetDataFromNet());

        //    return result;
        //}

        //static int GetDataFromNet()
        //{
        //    var cnt = 1;
        //    var end = new Random().Next(1, 10);
        //    while (cnt <= end)
        //    {
        //        Thread.Sleep(100);
        //        cnt++;
        //    }

        //    var result = new Random().Next(1, 9999);
        //    return result;
        //}
        #endregion

        #region EX 1 - task sources - sth wrong ...
        //static void Main(string[] args)
        //{
        //    // must do this, in case of console app - if wpf u have UI Thread Context
        //    SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

        //    Compute();

        //    WriteLine(Environment.NewLine);
        //    WriteLine("MAIN THREAD ENDED!");
        //    ReadLine();
        //}

        //static void Compute()
        //{
        //    var result = GetData();

        //    int min = 0, max = 0;
        //    double avg = 0;

        //    var t_min = Task.Factory.StartNew(() =>
        //    {
        //        min = result.Min();
        //    });

        //    var t_max = Task.Factory.StartNew(() =>
        //    {
        //        max = result.Max();
        //    });

        //    var t_avg = Task.Factory.StartNew(() =>
        //    {
        //        avg = result.Average();
        //    });


        //    t_min.Wait();
        //    WriteLine("Min: " + min);
        //    t_max.Wait();
        //    WriteLine("Max: " + max);
        //    t_avg.Wait();
        //    WriteLine("Avg: " + avg);
        //}

        //static IList<int> GetData()
        //{
        //    var result = new List<int>();

        //    Task t_1 = GetDataFromNet();
        //    Task t_2 = GetDataFromNet();
        //    Task t_3 = GetDataFromNet();

        //    Task.WaitAny(new[] { t_1, t_2, t_3 });

        //    return result;
        //}

        //static Task GetDataFromNet()
        //{
        //    var cnt = 1;
        //    var end = new Random().Next(1, 10);
        //    while (cnt <= end)
        //    {
        //        Thread.Sleep(100);
        //        cnt++;
        //    }

        //    var result = new Random().Next(1, 9999);
        //    //return result;
        //    // facade task!
        //    var tc = new TaskCompletionSource<int>(result);
        //    return tc.Task;
        //}
        #endregion

        #region EX 1 - wait
        //static void Main(string[] args)
        //{
        //    // must do this, in case of console app - if wpf u have UI Thread Context
        //    SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

        //    Compute();

        //    WriteLine(Environment.NewLine);
        //    WriteLine("MAIN THREAD ENDED!");
        //    ReadLine();
        //}

        //static void Compute()
        //{
        //    var result = GetData();

        //    int min = 0, max = 0;
        //    double avg = 0, sumAll = 0;

        //    var t_min = Task.Factory.StartNew(() =>
        //    {
        //        min = result.Min();
        //    });

        //    var t_max = Task.Factory.StartNew(() =>
        //    {
        //        max = result.Max();
        //    });

        //    var t_avg = Task.Factory.StartNew(() =>
        //    {
        //        avg = result.Average();
        //    });

        //    var t_sumAll = Task.Factory.StartNew(() =>
        //    {
        //        // must wait for tasks, otherwise will have 0
        //        Task.WaitAll(t_min, t_max, t_avg);
        //        sumAll = avg + min + max;
        //    });

        //    t_min.Wait();
        //    WriteLine("Min: " + min);
        //    t_max.Wait();
        //    WriteLine("Max: " + max);
        //    t_avg.Wait();
        //    WriteLine("Avg: " + avg);
        //    t_sumAll.Wait();
        //    WriteLine("Sum all: " + sumAll);
        //}

        //static IList<int> GetData()
        //{
        //    var result = new List<int>();

        //    var t_1 = GetDataFromNet();
        //    var t_2 = GetDataFromNet();
        //    var t_3 = GetDataFromNet();

        //    result.AddRange(new[] { t_1, t_2, t_3 });

        //    return result;
        //}

        //static int GetDataFromNet()
        //{
        //    var cnt = 1;
        //    var end = new Random().Next(1, 10);
        //    while (cnt <= end)
        //    {
        //        Thread.Sleep(100);
        //        cnt++;
        //    }

        //    var result = new Random().Next(1, 9999);
        //    return result;
        //}
        #endregion

        #region EX 1 - harvesting data (using task like functions and task.Result
        //static void Main(string[] args)
        //{
        //    // must do this, in case of console app - if wpf u have UI Thread Context
        //    SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

        //    Compute();

        //    WriteLine(Environment.NewLine);
        //    WriteLine("MAIN THREAD ENDED!");
        //    ReadLine();
        //}

        //static void Compute()
        //{
        //    var result = GetData();

        //    //int min = 0, max = 0;
        //    //double avg = 0;
        //    //double sumAll = 0;

        //    Task<int> t_min = Task.Factory.StartNew(() =>
        //    {
        //        var min = result.Min();
        //        return min;
        //    });

        //    Task<int> t_max = Task.Factory.StartNew(() =>
        //    {
        //        var max = result.Max();
        //        return max;
        //    });

        //    Task<double> t_avg = Task.Factory.StartNew(() =>
        //    {
        //        var avg = result.Average();
        //        return avg;
        //    });

        //    var t_sumAll = Task.Factory.StartNew(() =>
        //    {
        //        // must wait for tasks, otherwise will have 0
        //        var sumAll = t_avg.Result + t_min.Result + t_max.Result;
        //        return sumAll;

        //    });

        //    // don't has to use Wait(), .Result do this implicit

        //    WriteLine("Min: " + t_min.Result);
        //    WriteLine("Max: " + t_max.Result);
        //    WriteLine("Avg: " + t_avg.Result);
        //    WriteLine("Sum all: " + t_sumAll.Result);
        //}

        //static IList<int> GetData()
        //{
        //    var result = new List<int>();

        //    var t_1 = GetDataFromNet();
        //    var t_2 = GetDataFromNet();
        //    var t_3 = GetDataFromNet();

        //    result.AddRange(new[] { t_1, t_2, t_3 });

        //    return result;
        //}

        //static int GetDataFromNet()
        //{
        //    var cnt = 1;
        //    var end = new Random().Next(1, 10);
        //    while (cnt <= end)
        //    {
        //        Thread.Sleep(100);
        //        cnt++;
        //    }

        //    var result = new Random().Next(1, 9999);
        //    return result;
        //}
        #endregion

        //#region EX 2 - waiting on multiple tasks WaitAll/WaitAny
        //// waitany returns index to task
        //static void Main(string[] args)
        //{
        //    // must do this, in case of console app - if wpf u have UI Thread Context
        //    SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

        //    Compute();

        //    WriteLine(Environment.NewLine);
        //    WriteLine("MAIN THREAD ENDED!");
        //    ReadLine();
        //}

        //static void Compute()
        //{
        //    var result = GetData();

        //    //int min = 0, max = 0;
        //    //double avg = 0;
        //    //double sumAll = 0;

        //    Task<int> t_min = Task.Factory.StartNew(() =>
        //    {
        //        var min = result.Min();
        //        return min;
        //    });

        //    Task<int> t_max = Task.Factory.StartNew(() =>
        //    {
        //        var max = result.Max();
        //        return max;
        //    });

        //    Task<double> t_avg = Task.Factory.StartNew(() =>
        //    {
        //        var avg = result.Average();
        //        return avg;
        //    });

        //    var t_sumAll = Task.Factory.StartNew(() =>
        //    {
        //        // must wait for tasks, otherwise will have 0
        //        var sumAll = t_avg.Result + t_min.Result + t_max.Result;
        //        return sumAll;

        //    });

        //    // don't has to use Wait(), .Result do this implicit

        //    WriteLine("Min: " + t_min.Result);
        //    WriteLine("Max: " + t_max.Result);
        //    WriteLine("Avg: " + t_avg.Result);
        //    WriteLine("Sum all: " + t_sumAll.Result);
        //}

        //static IList<int> GetData()
        //{
        //    var result = new List<int>();

        //    var t_1 = GetDataFromNet();
        //    var t_2 = GetDataFromNet();
        //    var t_3 = GetDataFromNet();

        //    result.AddRange(new[] { t_1, t_2, t_3 });

        //    return result;
        //}

        //static int GetDataFromNet()
        //{
        //    var cnt = 1;
        //    var end = new Random().Next(1, 10);
        //    while (cnt <= end)
        //    {
        //        Thread.Sleep(100);
        //        cnt++;
        //    }

        //    var result = new Random().Next(1, 9999);
        //    return result;
        //}
        //#endregion

        #region EX 3 - waiting on multiple tasks WaitAll
        // waitany returns index to task
        static void Main(string[] args)
        {
            // must do this, in case of console app - if wpf u have UI Thread Context
            //SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

            Compute();
            Compute2().Wait();
            Compute3().Wait();

            WriteLine(Environment.NewLine);
            WriteLine("MAIN THREAD ENDED!");
            ReadLine();
        }

        static void Compute()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var tasks = new List<Task>();
            (int, int, int) container = (0,0,0);


            tasks.Add(new Task(() => {
                container.Item1 = GetDataFromDb();
                Thread.Sleep(3000);
                Console.WriteLine("First task");
            }));

            tasks.Add(new Task(() => {
                container.Item2 = GetDataFromDb();
                Thread.Sleep(2000);
                Console.WriteLine("Second task");
            }));

            tasks.Add(new Task(() => {
                container.Item3 = GetDataFromDb();
                Thread.Sleep(1000);
                Console.WriteLine("Third task");
            }));
            tasks.ForEach(t => t.Start());
            Task.WaitAll(tasks.ToArray());

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        static async Task Compute3()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var tasks = new List<Task>();
            (int, int, int) container = (0, 0, 0);


            tasks.Add(Task.Run(() => {
                container.Item1 = GetDataFromDb();
                Thread.Sleep(3000);
                Console.WriteLine("First task");
            }));

            tasks.Add(Task.Run(() => {
                container.Item2 = GetDataFromDb();
                Thread.Sleep(2000);
                Console.WriteLine("Second task");
            }));

            tasks.Add(Task.Run(() => {
                container.Item3 = GetDataFromDb();
                Thread.Sleep(1000);
                Console.WriteLine("Third task");
            }));

            // better than Task.WaitAll https://msdn.microsoft.com/en-us/magazine/jj991977.aspx Figure 5
            await Task.WhenAll(tasks.ToArray());

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        static async Task Compute2()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var tasks = new List<Func<Task>>();
            (int, int, int) container = (0, 0, 0);


            tasks.Add(async () => {
                container.Item1 = GetDataFromDb();
                Thread.Sleep(3000);
                Console.WriteLine("First task");
            });

            tasks.Add(async () => {
                container.Item2 = GetDataFromDb();
                Thread.Sleep(2000);
                Console.WriteLine("Second task");
            });

            tasks.Add(async () => {
                container.Item3 = GetDataFromDb();
                Thread.Sleep(1000);
                Console.WriteLine("Third task");
            });

            foreach (var t in tasks)
            {
                await t();
            }
           

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        static int GetDataFromDb()
        {
            var cnt = 1;
            var end = new Random().Next(1, 10);
            while (cnt <= end)
            {
                Thread.Sleep(100);
                cnt++;
            }

            var result = new Random().Next(1, 9999);
            return result;
        }
        #endregion
    }
}

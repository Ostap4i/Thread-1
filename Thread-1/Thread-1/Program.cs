using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Task 1
        //Thread numberThread = new Thread(PrintNumbers);
        //numberThread.Start();


        // Task 2
        //Console.Write("Enter the start diapason: ");
        //int start = int.Parse(Console.ReadLine());

        //Console.Write("Enter the diapason end: ");
        //int end = int.Parse(Console.ReadLine());

        //// Використання класу Thread
        //Thread thread = new Thread(() => PrintNumbersThread(start, end));
        //thread.Start();

        //// Використання класу Task
        //Task.Run(() => PrintNumbersTask(start, end));

        //// Використання асинхронного методу
        //PrintNumbersAsync(start, end).Wait();

        //Console.ReadLine(); // Щоб програма не завершилася до закінчення роботи потоку


        //Task 3
        //Console.Write("Введіть початок діапазону: ");
        //int start = int.Parse(Console.ReadLine());

        //Console.Write("Введіть кінець діапазону: ");
        //int end = int.Parse(Console.ReadLine());

        //// Використання класу Thread
        //Thread thread = new Thread(() => PrintNumbersThread(start, end));
        //thread.Start();

        //// Використання класу Task
        //Task.Run(() => PrintNumbersTask(start, end));

        //// Використання асинхронного методу
        //PrintNumbersAsync(start, end).Wait();

        //Console.ReadLine();


        //Task 4


        // Генеруємо набір з 10 000 випадкових чисел
        //Random rand = new Random();
        //int[] numbers = new int[10000];
        //for (int i = 0; i < numbers.Length; i++)
        //{
        //    numbers[i] = rand.Next(1, 10001);
        //}

        //int max = 0;
        //int min = 0;
        //double average = 0.0;

        //Thread maxThread = new Thread(() => max = FindMax(numbers));
        //Thread minThread = new Thread(() => min = FindMin(numbers));
        //Thread averageThread = new Thread(() => average = FindAverage(numbers));

        //maxThread.Start();
        //minThread.Start();
        //averageThread.Start();

        //maxThread.Join();
        //minThread.Join();
        //averageThread.Join();

        //Console.WriteLine($"Max: {max}");
        //Console.WriteLine($"Min: {min}");
        //Console.WriteLine($"Average: {average}");


        //Task 5

        // Генеруємо набір з 10 000 випадкових чисел
        Random rand = new Random();
        int[] numbers = new int[10000];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = rand.Next(1, 10001);
        }

        // Ініціалізуємо змінні для зберігання результатів
        int max = 0;
        int min = 0;
        double average = 0.0;

        // Створюємо потоки для обчислення максимуму, мінімуму та середнього арифметичного
        Thread maxThread = new Thread(() => max = FindMax(numbers));
        Thread minThread = new Thread(() => min = FindMin(numbers));
        Thread averageThread = new Thread(() => average = FindAverage(numbers));

        // Запускаємо потоки
        maxThread.Start();
        minThread.Start();
        averageThread.Start();

        // Чекаємо завершення роботи потоків
        maxThread.Join();
        minThread.Join();
        averageThread.Join();

        // Виводимо результати
        Console.WriteLine($"Максимум: {max}");
        Console.WriteLine($"Мінімум: {min}");
        Console.WriteLine($"Середнє арифметичне: {average}");

        // Створюємо потік для запису у файл
        Thread fileThread = new Thread(() => WriteToFile(numbers, max, min, average));
        fileThread.Start();
        fileThread.Join(); // Чекаємо завершення запису у файл



    }

    //Task 1
    //static void PrintNumbers()
    //{
    //    for (int i = 0; i <= 50; i++)
    //    {
    //        Console.WriteLine(i);
    //        Thread.Sleep(100); 
    //    }
    //}


    //static void PrintNumbers()
    //{
    //    for (int i = 0; i <= 50; i++)
    //    {
    //        Console.WriteLine(i);
    //        Thread.Sleep(100); 
    //    }
    //}



    //
    //static void PrintNumbersThread(int start, int end)
    //{
    //    for (int i = start; i <= end; i++)
    //    {
    //        Console.WriteLine($"Thread: {i}");
    //        Thread.Sleep(100); 
    //    }
    //}

    //static void PrintNumbersTask(int start, int end)
    //{
    //    for (int i = start; i <= end; i++)
    //    {
    //        Console.WriteLine($"Task: {i}");
    //        Task.Delay(100).Wait();
    //    }
    //}

    //static async Task PrintNumbersAsync(int start, int end)
    //{
    //    for (int i = start; i <= end; i++)
    //    {
    //        Console.WriteLine($"Async: {i}");
    //        await Task.Delay(100); 
    //    }
    //}


    //Task 3
    //static void PrintNumbersThread(int start, int end)
    //{
    //    for (int i = start; i <= end; i++)
    //    {
    //        Console.WriteLine($"Thread: {i}");
    //        Thread.Sleep(100); // Затримка для зручності перегляду
    //    }
    //}

    //static void PrintNumbersTask(int start, int end)
    //{
    //    for (int i = start; i <= end; i++)
    //    {
    //        Console.WriteLine($"Task: {i}");
    //        Task.Delay(100).Wait(); // Затримка для зручності перегляду
    //    }
    //}

    //static async Task PrintNumbersAsync(int start, int end)
    //{
    //    for (int i = start; i <= end; i++)
    //    {
    //        Console.WriteLine($"Async: {i}");
    //        await Task.Delay(100); // Затримка для зручності перегляду
    //    }
    //}


    //Task 4

    //static int FindMax(int[] numbers)
    //{
    //    return numbers.Max();
    //}

    //static int FindMin(int[] numbers)
    //{
    //    return numbers.Min();
    //}

    //static double FindAverage(int[] numbers)
    //{
    //    return numbers.Average();
    //}


    //Task 5

    static int FindMax(int[] numbers)
    {
        return numbers.Max();
    }

    static int FindMin(int[] numbers)
    {
        return numbers.Min();
    }

    static double FindAverage(int[] numbers)
    {
        return numbers.Average();
    }

    static void WriteToFile(int[] numbers, int max, int min, double average)
    {
        using (StreamWriter writer = new StreamWriter("results.txt"))
        {
            writer.WriteLine("Набір чисел:");
            foreach (int number in numbers)
            {
                writer.WriteLine(number);
            }
            writer.WriteLine();
            writer.WriteLine($"Min: {max}");
            writer.WriteLine($"Max: {min}");
            writer.WriteLine($"Average: {average}");
        }
    }
}






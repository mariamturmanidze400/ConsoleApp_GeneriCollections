class Program
{
    static void Main()
    {

        BookStore();
        CallCenter();
        PalindromeCheck();
        RemoveEvenNumbers();
    }

    static void BookStore()
    {
        Console.WriteLine("=== წიგნის მაღაზია ===");

        Dictionary<string, double> books = new Dictionary<string, double>
        {
            { "ვეფხისტყაოსანი", 25.50 },
            { "პატარა პრინცი", 18.00 },
            { "დათა თუთაშხია", 22.90 }
        };

        books["ანა ფრანკის დღიური"] = 20.00;

        books["ტრიუმფალური თაღი"] = 19.50;

        string search = "დათა თუთაშხია";
        if (books.TryGetValue(search, out double price))
            Console.WriteLine($"ვიპოვე: {search} - {price} ლარი");
        else
            Console.WriteLine("წიგნი ვერ ვიპოვე");

        books.Remove("ტრიუმფალური თაღი");

        foreach (KeyValuePair<string, double> book in books)
            Console.WriteLine($"{book.Key}: {book.Value} ლარი");

        Console.WriteLine($"ფასი: {books.Values.Sum()} ლარი");
        Console.WriteLine();
    }

    static void CallCenter()
    {
        Console.WriteLine("=== სატელეფონო ცენტრი ===");

        Queue<string> waiting = new Queue<string>();

        waiting.Enqueue("მარიამი");
        waiting.Enqueue("გიორგი");
        waiting.Enqueue("ნინო");
        waiting.Enqueue("დავითი");

        Console.WriteLine($"მოლოდინში: {waiting.Count} კლიენტი");

        while (waiting.Count > 0)
        {
            string client = waiting.Dequeue();
            Console.WriteLine($"მომსახურება: {client} (დარჩა: {waiting.Count})");
        }

        Console.WriteLine();
    }

    static void PalindromeCheck()
    {
        Console.WriteLine("=== პალინდრომი ===");

        string[] words = { "mom", "dad", "noon", "book", "house", "ანა", "აბა", "დედა", "მამა", "წიგნი" };


        foreach (string word in words)
        {
            Console.WriteLine($"{word} - {(IsPalindrome(word) ? "პალინდრომია" : "არ არის პალინდრომი")}");
        }

        Console.WriteLine();
    }

    static bool IsPalindrome(string word)
    {
        string text = word.ToLower();
        Stack<char> stack = new Stack<char>();

        foreach (char c in text)
            stack.Push(c);

        foreach (char c in text)
        {
            if (stack.Pop() != c)
                return false;
        }

        return true;
    }

    static void RemoveEvenNumbers()
    {
        Console.WriteLine("=== ლუწი რიცხვების წაშლა ===");

        Random random = new Random();
        List<int> numbers = new List<int>();

        for (int i = 0; i < 10; i++)
            numbers.Add(random.Next(1, 101));

        Console.WriteLine("თავიდან: " + string.Join(", ", numbers));

        numbers.RemoveAll(n => n % 2 == 0);

        Console.WriteLine("ლუწების გარეშე: " + string.Join(", ", numbers));
    }
}
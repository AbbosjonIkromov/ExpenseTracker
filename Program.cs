using System.Text.RegularExpressions;


string path = @"C:\Users\Lenovo 5i Pro\ExpenceTracker";
string fullPath = Path.Combine(path, "expenses.txt");

IsFileExists(fullPath);

var expenseList = GetExpenseDetails(); // Tuple
    
WriteFile(expenseList, fullPath);




static List<(string Expence, decimal Amount, TimeOnly Date)> GetExpenseDetails()
{
    var expenseList = new List<(string Expence, decimal Amount, TimeOnly Date)>();
    do
    {
        Console.Write("Expence: ");
        string expence = Console.ReadLine();   
        Console.Write("Amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());
        Console.Write("Date: ");
        TimeOnly date = TimeOnly.Parse(Console.ReadLine());

        expenseList.Add((expence, amount, date));

    }while(HitEnter());

        return expenseList;
    
}

static void WriteFile(List<(string Expence, decimal Amount, TimeOnly Date)> expenseList, string path)
{
    using(StreamWriter streamWriter = new StreamWriter(path))
    {
        streamWriter.WriteLine(" ----------------------------------------------- ");
        streamWriter.WriteLine($"| {"Expence",-10}    | {"Amount",-10}    | {"Date",-10}    |");
        streamWriter.WriteLine(" ----------------------------------------------- ");

        foreach(var expence in expenseList)
        {
            streamWriter.WriteLine($"| {expence.Expence,-10}    | {expence.Amount,-10}    | {expence.Date,-10}    |");
            streamWriter.WriteLine(" ----------------------------------------------- ");
        }
    }
    Console.WriteLine("\nMalumotlar file ga muvaffaqiyatli yozildi.\n");
}


static void IsFileExists(string path)
{
    if(!File.Exists(path))
        File.Create(path);
}

static bool HitEnter()
{
    Console.Write("\nHit enter to add expense...");
    string str = Console.ReadLine();
    Console.WriteLine('\n');
    return (string.IsNullOrEmpty(str)) ? true : (Regex.IsMatch(str, "stop", RegexOptions.IgnoreCase)) ? false : false;


    // if(string.IsNullOrEmpty(str))
    //     return true;
    
    // if(Regex.IsMatch(str, "stop", RegexOptions.IgnoreCase))
    //     return false;
}


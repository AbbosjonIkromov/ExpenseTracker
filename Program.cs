using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32.SafeHandles;


string path = @"C:\Users\Lenovo 5i Pro\ExpenceTracker";
string fullPath = Path.Combine(path, "expenses.txt");

StringBuilder stringBuilder = new StringBuilder();
string line = " ----------------------------------------------- \n";
stringBuilder.Append(line);
stringBuilder.AppendFormat($"| {"Expence",-10}    | {"Amount",-10}    | {"Date",-10}    |\n");
stringBuilder.Append(line);

string expence;
decimal amount;
TimeOnly date;
bool check = true;
do
{
    Console.Write("Expence: ");
    expence = Console.ReadLine();
    Console.Write("Amount: ");
    amount = decimal.Parse(Console.ReadLine());
    Console.Write("Date: ");
    date = TimeOnly.Parse(Console.ReadLine());
    stringBuilder.AppendFormat("| {0,-10}    | {1,-10}    | {2,-10}    |\n", expence, amount, date);
    stringBuilder.Append(line);

    Console.Write("\nHit enter to add expense...");
    string str = Console.ReadLine();

    if (string.IsNullOrEmpty(str))
        check = true;
    else if (Regex.IsMatch(str, "stop", RegexOptions.IgnoreCase))
        break;
    else
        check = false;

} while (check);


if (check)
{
    try
    {

        WriteFile(stringBuilder, fullPath);
        System.Console.WriteLine(stringBuilder);
        Console.WriteLine("\nMalumotlar file ga muvaffaqiyatli yozildi.\n");

    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine("Exception: ", ex.Message);
    }
}
else
    Console.WriteLine("\nDastur Yakunlandi!");


static void WriteFile(StringBuilder stringBuilder, string path)
{
    using (StreamWriter streamWriter = new StreamWriter(path))
    {
        streamWriter.WriteLine(stringBuilder);
    }
}



Console.Write("Entfernung: ");
int meter = int.Parse(Console.ReadLine());

Console.Write("Stunde: ");
int std = int.Parse(Console.ReadLine());

Console.Write("Minute: ");
int min = int.Parse(Console.ReadLine());

Console.Write("Sekunde: ");
int sek = int.Parse(Console.ReadLine());

double gesamt = std * 3600 + min * 60 + sek;

Console.WriteLine($"Meter/Sekunde: \t\t{Math.Round(meter/gesamt, 2)}");
Console.WriteLine($"Kilometer/Stunde: \t{Math.Round(meter / gesamt * 3.6, 2)}");
Console.WriteLine($"Meilen/Stunde: \t\t{Math.Round(meter / gesamt * 3.6 * 0.621, 2)}");
//Console.Write("Entfernung: ");
//int meter = int.Parse(Console.ReadLine());

//Console.Write("Stunde: ");
//int std = int.Parse(Console.ReadLine());

//Console.Write("Minute: ");
//int min = int.Parse(Console.ReadLine());

//Console.Write("Sekunde: ");
//int sek = int.Parse(Console.ReadLine());

//double gesamt = std * 3600 + min * 60 + sek;

//Console.WriteLine($"Meter/Sekunde: \t\t{Math.Round(meter/gesamt, 2)}");
//Console.WriteLine($"Kilometer/Stunde: \t{Math.Round(meter / gesamt * 3.6, 2)}");
//Console.WriteLine($"Meilen/Stunde: \t\t{Math.Round(meter / gesamt * 3.6 * 0.621, 2)}");

//int[] zahlen = [16, 44, 38, 92, 77];
//Console.Write("Gib einen Tipp ab: ");
//int tipp = int.Parse(Console.ReadLine());
//if (tipp >= 0 && tipp <= 100)
//{
//	if (zahlen.Contains(tipp))
//		Console.WriteLine("Glückwunsch!");
//	else
//		Console.WriteLine("Leider kein Gewinn.");
//}

int jahr = 1800;
bool schaltjahr = false;
if (jahr % 4 == 0)
	schaltjahr = true;
if (jahr % 100 == 0)
	schaltjahr = false;
if (jahr % 400 == 0)
	schaltjahr = true;
Console.WriteLine(schaltjahr ? $"{jahr} ist ein Schaltjahr" : $"{jahr} ist kein Schaltjahr");

DateTime.IsLeapYear(jahr);
https://teams.microsoft.com/l/meetup-join/19%3ameeting_YjZmN2E3ZmUtNzBjZC00ZmU4LWE4MjAtZmRjMzhjYmUwNDA2%40thread.v2/0?context=%7b%22Tid%22%3a%22d044494e-fc77-4ae0-8c6b-8b4520666035%22%2c%22Oid%22%3a%223ffe4726-5471-4d4b-bf80-37b42ecd2116%22%7d
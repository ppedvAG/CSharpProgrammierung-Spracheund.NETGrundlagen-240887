while (true)
{
	double z1 = ZahlEingabe("Gib eine Zahl ein: ");
	double z2 = ZahlEingabe("Gib eine weitere Zahl ein: ");
	Rechenarten op = RechenartEingabe();
	double ergebnis = Berechne(z1, z2, op);

	Console.WriteLine("Enter zum Wiederholen");
	if (Console.ReadKey(true).Key != ConsoleKey.Enter)
		break;
	Console.Clear();
}

double Berechne(double z1, double z2, Rechenarten art)
{
	switch (art)
	{
		case Rechenarten.Add:
            Console.WriteLine($"{z1} + {z2} = {z1 + z2}");
			return z1 + z2;
		case Rechenarten.Sub:
			Console.WriteLine($"{z1} - {z2} = {z1 - z2}");
			return z1 - z2;
		case Rechenarten.Mult:
			Console.WriteLine($"{z1} * {z2} = {z1 * z2}");
			return z1 * z2;
		case Rechenarten.Div:
			if (z2 == 0)
			{
				Console.WriteLine("Zahl 2 darf nicht 0 sein (Division durch 0 nicht möglich)");
				return double.NaN;
			}
			else
			{
				Console.WriteLine($"{z1} / {z2} = {z1 / z2}");
				return z1 / z2;
			}
		default:
			return double.NaN;
	}
}

double ZahlEingabe(string text)
{
	while (true)
	{
		Console.Write(text);
		double zahl;
		bool funktioniert = double.TryParse(Console.ReadLine(), out zahl);
		if (funktioniert)
			return zahl;
		else
            Console.WriteLine("Die Eingabe ist keine Zahl");
    }
}

Rechenarten RechenartEingabe()
{
	while (true)
	{
		//Console.WriteLine("Gib eine Rechenart ein: ");
		//foreach (Rechenarten r in Enum.GetValues<Rechenarten>())
		//	Console.WriteLine($"{(int) r}: {r}");
		//double zahl = ZahlEingabe("");

		string ausgabe = "Gib eine Rechenart ein: \n";
		foreach (Rechenarten r in Enum.GetValues<Rechenarten>())
			ausgabe += $"{(int) r}: {r}\n";
		double zahl = ZahlEingabe(ausgabe);

		Rechenarten art = (Rechenarten) zahl;

		//if (zahl >= 1 && zahl <= 4)
		//{
		//	return art;
		//}

		if (Enum.IsDefined(art))
		{
			return art;
		}
	}
}


enum Rechenarten
{
	Add = 1, Sub, Mult, Div
}
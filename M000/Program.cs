while (true)
{
	Console.Write("Gib eine Zahl ein: ");
	int z1 = int.Parse(Console.ReadLine());

	Console.Write("Gib eine weitere Zahl ein: ");
	int z2 = int.Parse(Console.ReadLine());

	Console.WriteLine("Gib eine Rechenart ein: ");
	foreach (Rechenarten r in Enum.GetValues<Rechenarten>())
		Console.WriteLine($"{(int) r}: {r}");
	Rechenarten op = Enum.Parse<Rechenarten>(Console.ReadLine());

	switch (op)
	{
		case Rechenarten.Add:
			Console.WriteLine($"Ergebnis: {z1 + z2}");
			break;
		case Rechenarten.Sub:
			Console.WriteLine($"Ergebnis: {z1 - z2}");
			break;
		case Rechenarten.Mult:
			Console.WriteLine($"Ergebnis: {z1 * z2}");
			break;
		case Rechenarten.Div:
			if (z2 == 0)
				Console.WriteLine("Zahl 2 darf nicht 0 sein (Division durch 0 nicht möglich)");
			else
				Console.WriteLine($"Ergebnis: {(double) z1 / z2}");
			break;
	}

	Console.WriteLine("Enter zum Wiederholen");
	if (Console.ReadKey(true).Key != ConsoleKey.Enter)
		break;
	Console.Clear();
}


enum Rechenarten
{
	Add = 1, Sub, Mult, Div
}
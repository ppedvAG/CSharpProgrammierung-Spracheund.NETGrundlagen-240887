namespace M005;

internal class Program
{
	/// <summary>
	/// Die Main Methode
	/// Einstiegspunkt jedes Programms
	/// Jedes Programm benötigt eine Main Methode
	/// </summary>
	static void Main(string[] args)
	{
		PrintAddiere(3, 6);
		double summe = Addieren(4, 6);
        Console.WriteLine($"Die Summe ist: {summe}");

		Addieren(2, 3); //Int Methode auswählen mit 2x int Parameter
		Addieren(2.0, 3); //Double Methode auswählen mit mind. 1x double Parameter

        Console.WriteLine(); //18 Overloads

		Summiere(1, 2, 3); //3 Parameter
		Summiere(1, 2, 3, 5, 6, 9); //6 Parameter
		Summiere(1, 2, 3, 5, 6, 9, 2, 5, 1, 8, 3); //11 Parameter
		Summiere(2); //1 Parameter
		Summiere(); //0 Parameter

		AddiereOderSubtrahiere(4, 8);
		AddiereOderSubtrahiere(5, 1);
		AddiereOderSubtrahiere(2, 3);
		AddiereOderSubtrahiere(9, 7);
		AddiereOderSubtrahiere(9, 7, false);

		//out-Parameter
		//Der out-Parameter ermöglicht mehrere Rückgabewerte
		//Normalerweise wird über den Rückgabewert einer Funktion genau ein Wert zurückgegeben
		//Mittels out können weitere benannte Werte zurückgegeben werden
		//z.B.: TryParse

		int r; //Leere Variable deklarieren, die den Wert des Out-Parameters einfängt
		bool funktioniert = int.TryParse("123", out r); //Mittels out r wird hier der Parameter mit der Variable darüber "verbunden"
		if (funktioniert)
		{
			Console.WriteLine($"Zahl: {r}");
		}
		else
		{
            Console.WriteLine("Parsen hat nicht funktioniert");
        }

		//Eigene out Methode
		int sub;
		int add = AddiereUndSubtrahiere(4, 9, out sub);
        Console.WriteLine($"Summe: {add}, Differenz: {sub}");

		//Benannte Werte aus dem Tupel entnehmen
		var t = AddiereUndSubtrahiere(8, 5);
		Console.WriteLine(t.Summe);
		Console.WriteLine(t.Differenz);
    }

	/// <summary>
	/// Funktionsaufbau
	/// 1. Modifier: u. a. static, Access Modifier, ref, async, extern, unsafe, ...
	/// 2. Rückgabetyp: Jede Funktion kann ein Ergebnis haben, muss aber nicht (void für kein Ergebnis)
	/// - Rückgabewerte können beim Abschluss der Funktion in einer Variable empfangen werden (z.B. Console.ReadLine, Math.Round, int.Parse, ...)
	/// - Dieses Ergebnis kann in Folge weiterverwendet werden
	/// 3. Namen der Funktion: Über den Namen kann die Funktion verwendet werden
	/// 4. Parameter: Daten, welche der Funktion mitgegeben werden müssen
	/// - Diese Werte können dann von der Funktion verarbeitet werden
	/// 5. Body: Innerhalb von { } wird der Code definiert, welcher von der Funktion ausgeführt werden soll
	/// </summary>
	static void PrintAddiere(int x, int y)
	{
        Console.WriteLine($"{x} + {y} = {x + y}");
    }

	/// <summary>
	/// Funktion mit Rückgabewert
	/// 
	/// Jetzt ist der Rückgabetyp nicht mehr void, dadurch muss die Funktion ein return Statement haben
	/// Über return wird das Ergebnis aus der Funktion ausgegeben, und kann in weiterer Folge in einer Variable gespeichert werden
	/// </summary>
	static double Addieren(double x, double y)
	{
		return x + y;
	}

	/// <summary>
	/// Überladung von Methoden
	/// Das Anlegen von gleichnamigen Methoden, welche sich über die Parameter unterscheiden
	/// </summary>
	static int Addieren(int x, int y)
	{
		return x + y;
	}

	/// <summary>
	/// params: Beliebig viele Parameter übergeben
	/// </summary>
	static void Summiere(params int[] zahlen)
	{
		string gesamt = "";
		foreach (int i in zahlen)
		{
			gesamt += i + " + ";
		}
		gesamt = gesamt.TrimEnd('+', ' ');
		gesamt += " = " + zahlen.Sum();
        Console.WriteLine(gesamt);
    }

	/// <summary>
	/// Optionale Parameter: Parameter mit einem Standardwert, kann bei Aufruf der Funktion überschrieben werden
	/// </summary>
	static void AddiereOderSubtrahiere(int x, int y, bool add = true)
	{
		if (add)
            Console.WriteLine(x + y);
		else
            Console.WriteLine(x - y);
    }

	/// <summary>
	/// Mittels out kann ein weiterer Rückgabewert ermöglicht werden
	/// </summary>
	static int AddiereUndSubtrahiere(int x, int y, out int sub)
	{
		sub = x - y;
		return x + y;
	}

	/// <summary>
	/// Tupel: Mehrere benannte Werte in einer Variable speichern
	/// </summary>
	static (int Summe, int Differenz) AddiereUndSubtrahiere(int x, int y)
	{
		return (x + y, x - y);
	}
}

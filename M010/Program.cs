namespace M010;

/// <summary>
/// Interfaces
/// 
/// Geben nur eine Struktur vor (wie abstract), aber eine Klasse kann mehrere Interfaces haben
/// - Methoden ohne Body
/// - interface Keyword
/// - Kann nicht instanziert werden (wie abstract class)
/// 
/// Klasse ist eine strenge Vererbung -> Nur genau eine Oberklasse, gibt ALLES vor
/// Interfaces sind eine sanfte Vererbung -> Beliebig viele Interfaces, geben kleine Teile vor die am Ende eine gesamte Klasse ergeben
/// 
/// Ziel: Polymorphismus
/// </summary>
internal class Program
{
	static void Main(string[] args)
	{
		Smartphone s = new Smartphone();
		Wertkarte w = new Wertkarte();

		//Polymorphismus
		IAufladbar a = s;
		a = w;

		IComparable c = 10;
		c = 10.5;

		//Prüfen, ob ein Interface auf einer Klasse ist
		//Mit dem is Operator
		if (s is IAufladbar)
		{
			//Hat das Objekt hinter der Variable das Interface?
		}

		//Nachdem das Interface diese Methode erzwingt, kann diese auf a immer ausgeführt werden
		a.Aufladen(100);

		IAufladbar[] x = new IAufladbar[3];
		x[0] = new Smartphone();
		x[1] = new Wertkarte();
		x[2] = new Wertkarte();
		foreach (IAufladbar l  in x)
		{
			l.Aufladen(100);
            l.PrintZustand();
            Console.WriteLine(l.LadestandProzent());
		}
	}
}

/// <summary>
/// IAufladbar stellt eine gemeinsame Basis für die beiden Unterklassen dar, die sonst keinerlei Zusammenhang haben
/// </summary>
public interface IAufladbar
{
	int Ladezustand { get; set; }

	int Maximum { get; }

	void Aufladen(int anzahl);

	double LadestandProzent();

	void PrintZustand();
}

public class Smartphone : IAufladbar
{
	public int Ladezustand { get; set; }

	public int Maximum { get; } = 100;

	public void Aufladen(int anzahl)
	{
		if (anzahl + Ladezustand > Maximum)
		{
			Ladezustand = Maximum;
		}
		else
		{
			Ladezustand += anzahl;
		}
	}

	public double LadestandProzent()
	{
		return (double) Ladezustand / Maximum * 100.0;
	}

	public void PrintZustand()
	{
        Console.WriteLine($"Das Smartphone ist jetzt mit {Ladezustand}% von {Maximum}% geladen.");
    }
}

public class Wertkarte : IAufladbar
{
	public int Ladezustand { get; set; }

	public int Maximum { get; } = 500;

	public void Aufladen(int anzahl)
	{
		if (anzahl + Ladezustand > Maximum)
		{
            Console.WriteLine("Maximum wurde überschritten");
        }
		else
		{
			Ladezustand += anzahl;
		}
	}

	public double LadestandProzent()
	{
		return (double) Ladezustand / Maximum * 100.0;
	}

	public void PrintZustand()
	{
        Console.WriteLine($"Die Wertkarte hat {Ladezustand}€ Guthaben.");
    }
}
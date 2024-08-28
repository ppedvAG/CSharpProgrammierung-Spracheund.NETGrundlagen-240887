namespace M008;

/// <summary>
/// Vererbung
/// 
/// Oberklassen geben Strukturen für Unterklassen vor, Unterklassen übernehmen diese Strukturen
/// Felder/Propeties/Methoden werden vererbt (von der Oberklasse an die Unterklasse weitergegeben)
/// 
/// WICHTIG: Keine Mehrfachvererbung
/// </summary>
internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch(20, "Max");
		m.Alter = 20; //Alter und Bewegen wurden nicht in Mensch definiert -> Vererbt
		m.Bewegen(10);

		Katze k = new Katze(3);
		k.Alter = 3;
		k.Bewegen(20);

		m.Bewegen2(10); //Max bewegt sich um 10m
		k.Bewegen2(10); //Lebewesen bewegt sich um 10m
	}
}

/// <summary>
/// Oberklasse Lebewesen, gibt Eigenschaften für die Unterklassen vor, die allgemein gültig sind
/// 
/// Eigenschaften: Alter, Körpergröße, Name, ...
/// Funktionen: Bewegen, ...
/// </summary>
public class Lebewesen
{
	public int Alter { get; set; }

	/// <summary>
	/// Wenn ein Konstruktor in einer Oberklasse definiert wird, muss in den Unterklassen eine Verkettung stattfinden
	/// </summary>
	/// <param name="alter"></param>
	public Lebewesen(int alter)
	{
		Alter = alter;
	}

	public void Bewegen(int distanz)
	{
		Console.WriteLine($"Lebewesen bewegt sich um {distanz}m");
	}

	/// <summary>
	/// virtual
	/// 
	/// Funktion, welche überschrieben werden kann von den Unterklassen
	/// Hier kann eine Basisimplementation existieren, in den Unterklassen kann diese überschrieben werden
	/// </summary>
	public virtual void Bewegen2(int distanz)
	{
		Console.WriteLine($"Lebewesen bewegt sich um {distanz}m");
	}
}

/// <summary>
/// Mit : [Klassenname] kann eine Vererbung hergestellt werden
/// 
/// Strg + .: Generate Constructor
/// </summary>
public class Mensch : Lebewesen
{
	/// <summary>
	/// Neue Felder können im Konstruktor einfach hinzugefügt werden
	/// </summary>
	public string Name { get; set; }

	public Mensch(int alter, string name) : base(alter) //Hier werden Verkettungen mit base(...) gemacht
	{
		Name = name;
	}

	/// <summary>
	/// Override + Abstand -> Vorschläge
	/// Akzeptieren mit Enter
	/// </summary>
	public override void Bewegen2(int distanz)
	{
		//base.: Methode aus der Oberklasse benutzen
		//Vorallem nützlich bei Überschreibungen, gibt Zugriff auf die Basisimplementation
		//base.Bewegen2(distanz);

		Console.WriteLine($"{Name} bewegt sich um {distanz}m");
	}
}

public class Katze : Lebewesen
{
	public Katze(int alter) : base(alter) { }
}
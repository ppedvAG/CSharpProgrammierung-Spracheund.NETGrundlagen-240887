namespace M009;

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

	public void Sprechen(string text)
	{
        Console.WriteLine(text);
    }

	public override void WasBinIch()
	{
        Console.WriteLine("Ich bin ein Mensch");
    }
}

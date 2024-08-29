namespace M000;

public class Schiff : Fahrzeug, IBeladbar
{
	public string Treibstoff { get; set; }

	public Fahrzeug GeladenesFahrzeug { get; set; }

	public Schiff(string name, double preis, int maxV, string treibstoff) : base(name, preis, maxV)
	{
		Treibstoff = treibstoff;
	}

	public override string Info()
	{
		return base.Info() + $" Es fährt mit {Treibstoff}";
	}

	public override void Hupen()
	{
        Console.WriteLine("");
    }

	public void Belade(Fahrzeug f)
	{
		if (GeladenesFahrzeug == null)
			GeladenesFahrzeug = f;
	}

	public Fahrzeug Entlade()
	{
		//GeladenesFahrzeug = null;
		//return GeladenesFahrzeug; //Hier ist die Variable schon leer

		Fahrzeug zwischenspeicher = GeladenesFahrzeug; //Hier wird ein Zeiger auf das Objekt unter GeladenesFahrzeug gelegt
		GeladenesFahrzeug = null;
		return zwischenspeicher;
	}
}
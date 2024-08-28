namespace M000;

public class PKW : Fahrzeug
{
	public int AnzSitze { get; set; }

	public PKW(string name, double preis, int maxV, int anzSitze) : base(name, preis, maxV)
	{
		AnzSitze = anzSitze;
	}

	public override string Info()
	{
		return base.Info() + $" Es hat {AnzSitze} Sitzplätze.";
	}
}
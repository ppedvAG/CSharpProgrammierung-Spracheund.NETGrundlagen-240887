namespace M000;

public class Schiff : Fahrzeug
{
	public string Treibstoff { get; set; }

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
}
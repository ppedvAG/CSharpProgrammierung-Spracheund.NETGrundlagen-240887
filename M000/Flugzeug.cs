namespace M000;

public class Flugzeug : Fahrzeug
{
	public int MaxFlughoehe { get; set; }

	public Flugzeug(string name, double preis, int maxV, int maxFlughoehe) : base(name, preis, maxV)
	{
		MaxFlughoehe = maxFlughoehe;
	}

	public override string Info()
	{
		return base.Info() + $" Es kann auf maximal {MaxFlughoehe} aufsteigen.";
	}
}
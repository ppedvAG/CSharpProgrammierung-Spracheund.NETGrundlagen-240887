namespace M000;

public abstract class Fahrzeug
{
	public string Name { get; set; }

	public double Preis { get; set; }

	public int AktV { get; set; }

	public int MaxV { get; set; }

	public bool MotorLaeuft { get; set; }

	public Fahrzeug(string name, double preis, int maxV)
	{
		Name = name;
		Preis = preis;
		MaxV = maxV;
	}

	public void StarteMotor()
	{
		if (!MotorLaeuft)
		{
			MotorLaeuft = true;
		}
		else
		{
            Console.WriteLine("Motor läuft bereits");
        }
	}

	public void StoppeMotor()
	{
		if (MotorLaeuft && AktV <= 0)
		{
			MotorLaeuft = false;
		}
		else
		{
			Console.WriteLine("Motor läuft nicht oder Fahrzeug ist noch in Bewegung");
		}
	}

	public virtual string Info()
	{
		return $"{Name} kostet {Preis}€ und {(MotorLaeuft 
			? $"fährt momentan mit {AktV}km/h von {MaxV}km/h."
			: $"könnte maximal {MaxV}km/h fahren.")}";
	}

	public void Beschleunige(int a)
	{
		if (!MotorLaeuft)
		{
			Console.WriteLine("Motor läuft nicht");
			return;
		}

		if (AktV + a > MaxV)
		{
            Console.WriteLine("Neue Geschwindigkeit ist zu hoch");
			return;
        }

		if (AktV + a < 0)
		{
            Console.WriteLine($"{Name} kann nicht unter 0km/h bremsen");
			return;
        }

		AktV += a;
        Console.WriteLine($"{Name} fährt jetzt {AktV}km/h.");
    }

	public abstract void Hupen();

	public override string ToString()
	{
		return $"{Name} {GetType().Name}";
	}

	public static Fahrzeug GeneriereFahrzeug(string name)
	{
		Random r = new Random();
		int x = r.Next(0, 3);
		switch (x)
		{
			case 0: return new PKW("PKW" + name, 20000, 250, 5);
			case 1: return new Schiff("Schiff" + name, 20000, 250, "Dampf");
			default: return new Flugzeug("Flugzeug" + name, 20000, 250, 10000);
			//default: return null;
		}
	}
}

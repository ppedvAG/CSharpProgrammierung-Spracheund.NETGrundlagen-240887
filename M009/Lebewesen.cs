namespace M009;

/// <summary>
/// Oberklasse Lebewesen, gibt Eigenschaften für die Unterklassen vor, die allgemein gültig sind
/// 
/// Eigenschaften: Alter, Körpergröße, Name, ...
/// Funktionen: Bewegen, ...
/// </summary>
public abstract class Lebewesen
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

	/// <summary>
	/// Diese Methode stellt die Definition bereit
	/// Diese Methode hat in der Oberklasse keinen Body
	/// Jede Unterklasse MUSS diese implementieren
	/// </summary>
	public abstract void WasBinIch();
}

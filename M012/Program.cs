using System.Diagnostics;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		List<int> zahlen = Enumerable.Range(1, 20).ToList();
		zahlen.Where(e => e % 2 == 0); //Linq Funktionen benötigen immer eine Lambda-Expression (e => ...)

		//Äquivalent zu Where (oben)
		foreach (int e in zahlen)
			if (e % 2 == 0)
				Console.WriteLine(e);

		//IEnumerable ist nur eine Anleitung (keine Resourcen, keine Zeit)
		Enumerable.Range(1, 1_000_000_000); //Anleitung: 1ms
		///Enumerable.Range(1, 1_000_000_000).ToList(); //Mit ToList, ToArray, foreach, ToDictionary, ... wird die Anleitung ausgeführt

		Console.WriteLine(zahlen.Average());
		Console.WriteLine(zahlen.Min());
		Console.WriteLine(zahlen.Max());
		Console.WriteLine(zahlen.Sum());

		//Wenn bei First/Last kein Element gefunden wird, stürzt das Programm ab
		//2 Möglichkeiten
		//- Wenn die Liste leer ist
		//- Wenn eine Bedingung gegeben ist, und hier kein Element zurück kommt
		Console.WriteLine(zahlen.First());
		Console.WriteLine(zahlen.Last());

		//Wenn bei FirstOrDefault/LastOrDefault kein Element gefunden wird, kommt der Standardwert des Typens zurück (hier 0)
		Console.WriteLine(zahlen.FirstOrDefault());
		Console.WriteLine(zahlen.LastOrDefault());

		//Finde das erste Element, welches durch 50 teilbar ist
		//Console.WriteLine(zahlen.First(e => e % 50 == 0)); //System.InvalidOperationException: 'Sequence contains no matching element'
		Console.WriteLine(zahlen.FirstOrDefault(e => e % 50 == 0)); //0
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Linq mit Objektliste
		//Alle Fahrzeuge mit mind. 250km/h Höchstgeschwindigkeit
		fahrzeuge.Where(e => e.MaxV >= 250);

		//Alle VWs mit mind. 250km/h Höchstgeschwindigkeit
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW && e.MaxV >= 250);
		fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.VW)
			.Where(e => e.MaxV >= 250);

		//Nach Marke sortieren
		fahrzeuge.OrderBy(e => e.Marke); //WICHTIG: Originale Liste wird nicht sortiert, neue Liste ist sortiert

		//Nach Marke -> MaxV sortieren
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);

		//Absteigende Sortierungen
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		//All & Any
		//All: Prüft, ob alle Elemente einer Bedingung entsprechen
		//Any: Prüft, ob mindestens ein Element einer Bedingung entspricht

		//Häufig in if's verwendet
		if (fahrzeuge.All(e => e.MaxV >= 250))
		{
			//Fahren alle unsere Fahrzeuge mind. 250km/h?
		}

		if (fahrzeuge.Any(e => e.MaxV >= 250))
		{
			//Fährt mind. einstes unserer Fahrzeuge mind. 250km/h?
		}

		fahrzeuge.Any(); //Ist in der Liste ein Element enthalten? (Gut mit Where kombinierbar)

		//Count: Zählt Elemente anhand einer Bedingung

		//Wieviele BMWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.BMW); //4
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).Count(); //4

		//Avg, Min, Max, Sum, MinBy, MaxBy bei einer Objektliste

		//Wie schnell fahren unsere Fahrzeuge im Durchschnitt?
		fahrzeuge.Average(e => e.MaxV); //208.41666

		fahrzeuge.Min(e => e.MaxV); //Ergebnis: int (die Zahl)
		fahrzeuge.MinBy(e => e.MaxV); //Ergebnis: Fahrzeug (Objekt mit dem kleinsten Wert)

		//Was ist die Durchschnittsgeschwindigkeit aller Audis?
		fahrzeuge
			.Where(e => e.Marke == FahrzeugMarke.Audi)
			.Average(e => e.MaxV); //Filterung -> Durchschnitt

		//Skip & Take
		//Überspringe X Elemente, nimm X Elemente

		//Beispiel 1: Webshop
		int seite = 0;
		fahrzeuge
			.Skip(seite * 10)
			.Take(10); //Überspringe Seite * 10 Elemente (10, 20, 30, 40, ...) und zeige die nächsten 10 Elemente an

		//Beispiel 2: Topliste
		//Was sind die schnellsten 3 Fahrzeuge?
		fahrzeuge
			.OrderByDescending(e => e.MaxV)
			.Take(3);

		//Select
		//Transformiert eine Liste
		//Eine Liste in eine beliebige andere Form umwandeln

		//Zwei Anwendungsfälle
		//- Entnehmen eines einzelnen Feldes (80%)
		fahrzeuge
			.Select(e => e.Marke) //Welche Marken haben wir?
			.Distinct();

		fahrzeuge.Select(e => e.MaxV); //Liste mit nur den Geschwindigkeiten

		//- Umformen der Liste (20%)
		//Schöne Outputs anhand der Liste erzeugen
		//"Das Fahrzeug hat die Marke [Marke] und kann maximal [MaxV] fahren."
		fahrzeuge.Select(e => $"Das Fahrzeug hat die Marke {e.Marke} und kann maximal {e.MaxV} fahren.");

		//Liste von Ints zu einer Double Liste konvertieren, wobei jedes Element halbiert sein soll
		Enumerable.Range(1, 20).Select(e => e / 2.0);

		//Boolean Liste, welche abwechselnd true und false ist
		Enumerable.Range(1, 20).Select(e => e % 2 == 0);

		//Gesamte Liste casten
		Enumerable.Range(1, 20).Select(e => (double) e);
		#endregion

		#region Erweiterungsmethoden
		int x = 238957;
		x.Quersumme();

		Console.WriteLine(932578.Quersumme());
		#endregion
	}
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV;

	public FahrzeugMarke Marke;

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}
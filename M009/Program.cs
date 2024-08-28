namespace M009;

/// <summary>
/// Polymorphismus
/// = Typkompabilität
/// 
/// Welche Typen passen mit welchen anderen Typen zusammen?
/// - Typen die gemeinsam in einer Vererbungshierarchie sind
/// - Typen welche sich implizit/explizit ineinander konvertieren lassen (per extra Code)
/// 
/// Typen
/// Was ist ein Typ?
/// Jedes Objekt hat einen Typen
/// Der Typ jedes Objekts ist seine Klasse
/// Über [Objekt].GetType() kann der Typ hinter einem Objekt herausgefunden werden (Type-Objekt)
/// </summary>
internal class Program
{
	static void Main(string[] args)
	{
		#region Polymorphismus
		Lebewesen lw = new Mensch(20, "Max");
		lw = new Katze(3);
		//lw = new Lebewesen(10);

		//Die object Klasse
		//Ist die Oberklasse von allen Klassen in C#
		//Gibt 4 Methoden vor (per Vererbung weitergegeben)
		//- Equals(other)
		//- GetHashCode()
		//- ToString()
		//- GetType()

		//Kompatibel mit object oder einer Unterklasse von object
		object o = new object();
		o = 123;
		o = lw;
		o = "Hallo";
		o = false; //Alles kompatibel, da Oberklasse von allem
		#endregion

		#region Genauer Typvergleich
		Lebewesen l = new Mensch(20, "Max");
		Type lebewesenType = l.GetType(); //GetType(): Gibt den Typen von einem Objekt zurück
		Type typeofType = typeof(Lebewesen); //typeof: Gibt den Typen über einen Klassennamen zurück

		//Prüft, ob das Objekt hinter der Variable genau den gegebenen Typen hat
		if (l.GetType() == typeof(Lebewesen))
		{
			//false
		}

		if (l.GetType() == typeof(Mensch))
		{
			//true
		}
		#endregion

		#region is-Typvergleich
		//Prüft, ob ein Typ in einer Vererbungshierarchie mit einem anderen Typen ist
		if (l is Lebewesen)
		{
			//true
		}

		if (l is Mensch)
		{
			//true
		}

		if (l is object)
		{
			//immer true
		}
		#endregion

		#region Abstract
		//Abstract: Definiert, das eine Klasse nur eine Struktur darstellt

		//Effekte
		//- Klasse kann nicht mehr instanziert werden (kein new mehr möglich)
		//- Muss für Vererbung verwendet werden
		//- Kann abstrakte Methoden/Propeties definieren

		//Lebewesen
		//- Es gibt in der Realität kein Lebewesen, welches nur als Lebewesen bezeichnet wird
		//- Jedes Lebewesen hat eine spezifische Bezeichnung (z.B. Hund, Katze, Mensch, ...)
		//- Jedes Lebewesen, dass keine Bezeichnung hat, bekommt eine Bezeichnung (meistens lateinisch)

		Mensch m = new Mensch(20, "Max");
		m.WasBinIch();
		#endregion

		//Beispiel Polymorphismus
		Lebewesen[] zoo = new Lebewesen[3];
		zoo[0] = new Katze(2);
		zoo[1] = new Mensch(20, "Max");
		zoo[2] = new Katze(5);
		foreach (Lebewesen leb in zoo)
		{
			leb.WasBinIch();

			if (leb is Mensch)
			{
				Mensch mensch = (Mensch) leb;
				mensch.Sprechen("Hallo");
			}
		}
	}
}

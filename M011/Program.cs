using System.Globalization;

namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		//Generisches Typargument (Generic)
		//Typargument, welches in < > gesetzt wird bei Klassen/Funktionen
		//Platzhalter für einen Typen, überall wo dieser Platzhalter verwendet wird, wird der gegebene Typ eingesetzt

		//Beispiel für Klasse mit Generic: List
		//List: Funktioniert wie Array, ist aber dynamisch groß
		List<int> ints = new List<int>(); //T wird durch int ersetzt
		ints.Add(1);
		ints.Add(2);
		ints.Add(3);

		List<string> strings = new List<string>();
		strings.Add("A");
		strings.Add("B");
		strings.Add("C");

		//Zugriff wie bei Array
		ints[0] = 10;
		Console.WriteLine(ints[0]);

		//Schleifen wie bei Array
		foreach (int x in ints)
		{
            Console.WriteLine(x);
        }

		/////////////////////////////////////////////////
		
		//Dictionary: Liste von Schlüssel-Wert Paaren
		//Wird oftmals auch als Map bezeichnet
		//Schlüssel und Werte aneinander hängen, über Schlüssel auf die Werte zugreifen

		//Dictionary<string, int> einwohnerzahlen = new Dictionary<string, int>();
		//Dictionary<string, int> einwohnerzahlen = new(); //Kurzform der Objektinitialisierung (C# 10, .NET 6)
		Dictionary<string, int> einwohnerzahlen = []; //Noch kürzere Form für Listen (C# 12, .NET 8)
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);
		//einwohnerzahlen.Add("Paris", 2_160_000); //System.ArgumentException: 'An item with the same key has already been added. Key: Paris'

		if (!einwohnerzahlen.ContainsKey("Paris")) //Prüfen, ob der Key bereits existiert
			einwohnerzahlen.Add("Paris", 2_160_000);

        //Zugriff wie bei Array/Liste []
        Console.WriteLine(einwohnerzahlen["Wien"]);
		einwohnerzahlen["Wien"] = 2_100_000;

		//Schleife wie bei Array/Liste
		foreach (KeyValuePair<string, int> kv in einwohnerzahlen)
		{
            Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner.");
        }

		//var: Typ automatisch ergänzen, ähnlich wie new()
		foreach (var kv in einwohnerzahlen)
		{
			Console.WriteLine($"Die Stadt {kv.Key} hat {kv.Value} Einwohner.");
		}
	}
}

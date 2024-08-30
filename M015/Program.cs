using Newtonsoft.Json;
using System.Diagnostics;
using System.Xml.Serialization;

namespace M015;

internal class Program
{
	static void Main(string[] args)
	{
		//Wichtigste Klassen: Path, File, Directory

		//Aufgabe: Datei in einem Ordner erstellen
		string fileName = "Test.txt";
		string folderPath = "Output";
		string fullPath = Path.Combine(folderPath, fileName);

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		File.WriteAllText(fullPath, "Inhalt");

		/////////////////////////////////////////////////////////
		
		StreamWriter sw = new StreamWriter(fullPath);
		sw.WriteLine("Zeile1"); //Schreibt den String in den Buffer
		sw.WriteLine("Zeile2"); //Schreibt den String in den Buffer
		sw.WriteLine("Zeile3"); //Schreibt den String in den Buffer
		sw.Flush(); //Schreibt den Buffer in die unterliegende Resource (File)
		sw.Close();

		//Using-Block
		//Führt Close() am Ende des Blocks automatisch durch
		//Sollte bei allen Klassen verwendet werden, welche auf externe Resourcen zugreifen (DB, File, API, ...)
		using (StreamReader sr = new StreamReader(fullPath))
		{
			//string str = sr.ReadToEnd(); //Liest das gesamte File auf einmal

			List<string> lines = [];
			while (!sr.EndOfStream)
			{
				lines.Add(sr.ReadLine());
			}
		} //.Close()

		//Using-Statement
		//Selbige Funktion wie using-Block, aber benötigt keine Klammern
		//Wird am Ende der Methode geschlossen
		using StreamWriter sw2 = new StreamWriter("Test.txt");

		//Schnelle Methoden
		File.WriteAllText(fullPath, "Inhalt");
		File.WriteAllLines(fullPath, ["Hallo", "Welt", "!"]);

		string readFile = File.ReadAllText(fullPath);
		string[] readLines = File.ReadAllLines(fullPath);

		/////////////////////////////////////////////////////////
	
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

		//Json & XML

		//System.Text.Json
		//SystemJson();

		//Newtonsoft.Json
		//NuGet-Packages
		//Externe Pakete, welche zu unserem Projekt hinzuinstalliert werden können
		//Tools -> NuGet-Package Manager -> Manage Packages
		//NewtonsoftJson();

		//XML
		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		using (StreamWriter xmlWriter = new StreamWriter(fullPath))
		{
			xml.Serialize(xmlWriter, fahrzeuge);
		}

		using (StreamReader xmlReader = new StreamReader(fullPath))
		{
			List<Fahrzeug> readFzg = (List<Fahrzeug>) xml.Deserialize(xmlReader);
		}
	}

	static void SystemJson()
	{
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

		string fileName = "Test.txt";
		string folderPath = "Output";
		string fullPath = Path.Combine(folderPath, fileName);

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//string json = JsonSerializer.Serialize(fahrzeuge);
		//File.WriteAllText(fullPath, json);

		//string readJson = File.ReadAllText(fullPath);
		//List<Fahrzeug> readFzg = JsonSerializer.Deserialize<List<Fahrzeug>>(readJson);
	}

	static void NewtonsoftJson()
	{
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

		string fileName = "Test.txt";
		string folderPath = "Output";
		string fullPath = Path.Combine(folderPath, fileName);

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string json = JsonConvert.SerializeObject(fahrzeuge);
		File.WriteAllText(fullPath, json);

		string readJson = File.ReadAllText(fullPath);
		List<Fahrzeug> readFzg = JsonConvert.DeserializeObject<List<Fahrzeug>>(readJson);
	}
}


[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}

    public Fahrzeug()
    {
        
    }
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}
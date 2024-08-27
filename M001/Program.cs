#region Variablen, Typen
//Zwei Slashes: Einzeiliger Kommentar

/*
	Mehrzeiliger
	Kommentar
 */

//Variable: Behälter für Werte
//Besteht immer aus <Typ> <Name>;

int x;
x = 10; //Zuweisung
Console.WriteLine(x); //cw + Tab + Tab

//Datentypen

//Ganze Zahlen: int, byte, short, long

//Kommazahlen: double, float, decimal
double d = 218947.20948;
float f = 218947.20948f; //double und float sind an sich nicht kompatibel, mit f am Ende konvertieren
decimal m = 218947.20948m; //double und decimal sind an sich nicht kompatibel, mit m am Ende konvertieren

//Texttypen: string, char
string s = "Hallo"; //In C# müssen für Strings doppelte Hochkomma verwendet werden
char c = 'A'; //Für einen Char müssen einzelne Hochkomma verwendet werden

//Wahr-/Falsch Wert: bool
bool b = true;
b = false;
#endregion

#region Strings
//Strings verbinden
string hallo = "Hallo";
string welt = "Welt";
Console.WriteLine(hallo + " " + welt + "!");

//String Interpolation ($-String): Code in einen String einbauen
Console.WriteLine($"{hallo} {welt}!");

//Escape-Sequenzen: Undruckbare Zeichen in einen String einzubauen
//https://learn.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
string str = "Hallo \n Welt";
Console.WriteLine(str);

Console.WriteLine("Tabulator \t Tabulator");

//Verbatim-String (@-String): String, welcher Escape Sequenzen ignoriert
string v = @"\n\t\\";
Console.WriteLine(v);

//Besonders nützlich für Pfade
Console.WriteLine(@"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.1\System.Threading.Overlapped.dll");
Console.WriteLine("C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.1\\System.Threading.Overlapped.dll");
#endregion

#region Eingabe
//Wartet hier auf eine Eingabe und Bestätigung mittels Enter
//string eingabe = Console.ReadLine();
//Console.WriteLine($"Du hast {eingabe} eingegeben"); //Eingabe des Users wird wieder ausgegeben

////Warte auf genau eine Eingabe des Users (ohne Enter)
//ConsoleKeyInfo info = Console.ReadKey(true); //true in der Klammer: Zeichen des Users nicht mitausgeben
//Console.WriteLine($"Du hast {info.Key} gedrückt"); //In info hineingreifen

////Aufgabenstellung: Bestätigung ausgeben (J/N) und Eingabe vom Benutzer abfragen
//Console.Write("Bestätigen (J/N): "); //Write: Selbiges wie WriteLine, aber kein Zeilenumbruch am Ende
//ConsoleKeyInfo input = Console.ReadKey(true);
//Console.WriteLine($"Du hast {input.Key} gedrückt");
#endregion

#region Konvertierungen
//3 Richtungen
//Zahl -> String
//String -> Zahl
//Zahl -> Zahl

//Zahl -> String
int i = 12894;
Console.WriteLine(i.ToString());
Console.WriteLine(i + "");

//String -> Zahl
//Parse-Funktionen: Strings zu beliebigen anderen Typen konvertieren
string parse = "123";
//Console.WriteLine(parse * 2); //Nicht möglich, weil parse keine Zahl ist
int konvertiert = int.Parse(parse);
Console.WriteLine(konvertiert * 2);

string kommazahl = "123,456";
//int komma = int.Parse(kommazahl); //Nicht möglich, da int nur ganze Zahlen halten kann
double komma = double.Parse(kommazahl);
Console.WriteLine(komma);

//Zahl <-> Zahl
int y = 0;
double z = 12.34;
//Passt nicht implizit
y = (int) z; //Konvertierung erzwingen mittels Typecast (Cast)
Console.WriteLine(y);

z = y; //Hier muss keine Konvertierung erzwungen werden (Implizit)
Console.WriteLine(z); //Alle ints passen immer in double hinein
#endregion

#region Arithmetik
int zahl1 = 7;
int zahl2 = 4;

Console.WriteLine(zahl1 + zahl2); //Bilde eine Summe, und gib diese aus
Console.WriteLine(zahl1 += zahl2); //Bilde eine Summe, und zahl1 bekommt diese Summe
//+= verändert Werte, + alleine verändert keine Werte

//Modulo (%): Gibt den Rest einer Division zurück
Console.WriteLine(10 % 4); //2
Console.WriteLine(19 % 2 == 0); //Prüfen ob eine Zahl gerade ist
Console.WriteLine(100 % 8); //Prüfen, wieviele 8-große Segmente in die Ausgangszahl passt

//++, --: Erhöhe/Verringere die Zahl um 1
zahl1++; //zahl1 = zahl1 + 1; zahl1 += 1;

Math.Ceiling(8.5); //9
Math.Floor(8.5); //8
Math.Round(8.6); //9
Math.Round(8.4); //8
Math.Round(8.5); //.5 wird zur nächsten geraden Zahl gerundet -> 8
Math.Round(9.5); //.5 wird zur nächsten geraden Zahl gerundet -> 10
double gerundet = Math.Round(214.129048120948, 2);
Console.WriteLine(gerundet);

//Divisionen
Console.WriteLine(8 / 5); //1 (bei zwei Ints wird einer Int-Division durchgeführt)
Console.WriteLine(8 / 5.0); //1.6
Console.WriteLine(8d / 5); //1.6
Console.WriteLine(8 / 5f); //1.6
Console.WriteLine(8m / 5m); //1.6
zahl1++;
Console.WriteLine(zahl1 / zahl2);
Console.WriteLine((double) zahl1 / zahl2);
Console.WriteLine(zahl1 / (float) zahl2);
#endregion
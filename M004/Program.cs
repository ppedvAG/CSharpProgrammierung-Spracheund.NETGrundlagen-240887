#region Schleifen
//Schleifen
//Code mehrmals ausführen (ohne Copy-Paste)

//while-Schleife
//Wird solange ausgeführt, wie die Bedingung innerhalb der Klammern true ist

int a = 0;
int b = 10;
while (a < b)
{
    Console.WriteLine($"while: {a}");
	a++;
}
Console.WriteLine("Nach While-Schleife");

//do-while-Schleife
//Funktioniert wie die while-Schleife, aber wird immer mindestens einmal ausgeführt
a = 0;
do
{
    Console.WriteLine($"do-while: {a}");
	a++;
}
while (a < b);
Console.WriteLine("Nach Do-While-Schleife");

//break und continue
//Schleifenfluss steuern
//break: Beende die Schleife
//continue: Überspringe den Code nach dem Keyword, und bewege dich zum Anfang der Schleife zurück

int c = 0;
while (c < 10)
{
	c++;
	if (c == 5)
		continue; //Wenn c == 5, überspringe den Rest der Schleife
    Console.WriteLine(c); //0-4, 6-9
}

//Endlosschleife
//while (true) //Innerhalb der Klammern muss einen boolescher Ausdruck herauskommen (true oder false)
//{
//	Console.WriteLine("Endlos");
//	if (DateTime.Now.Second % 10 == 0)
//		break; //Wenn die Sekunde 0, 10, 20, 30, 40, 50 ist, beende die Schleife
//}

//do-while mit while (true) und break
a = 0;
do
{
	Console.WriteLine($"do-while: {a}");
	a++;
}
while (a < b);

a = 0;
while (true)
{
	Console.WriteLine($"while-true: {a}");
	a++;

	if (a >= b)
		break;
}

//////////////////////////////////////////////////////////////////////////////////

//for-Schleife
//Code wiederholen (wie while), aber mit einem integriertem Zähler
for (int i = 0; i < 10; i++) //Drei Teile (getrennt mit Semikolon): Zählervariable, Bedingung, Inkrement
{
    Console.WriteLine($"for: {i}");
}

for (int i = 9; i >= 0; i--) //Rückwärtsschleife (forr + Tab)
{
	Console.WriteLine($"forr: {i}");
}

//Array durchgehen
int[] zahlen = [8, 3, 1, 9, 6]; //Länge 5, Index 0-4
for (int i = 0; i < 5; i++) //Zählervariable (i) passt genau mit den Indizes des Arrays zusammen
{
	//Console.WriteLine(zahlen[i + 1]); //Problem: Index kann daneben greifen -> Programmabsturz
										//System.IndexOutOfRangeException: 'Index was outside the bounds of the array.'
	Console.WriteLine($"for-array: {zahlen[i]}");
}

//foreach-Schleife
//Schleife mit einem Zeiger, welche immer auf ein Element zeigt und sich pro Schleifendurchlauf um ein Element bewegt
//Sollte generell der for-Schleife bevorzugt werden
foreach (int i in zahlen)
{
	//i ist die Zahl selbst (8, 3, 1, 9 oder 6)
    Console.WriteLine($"foreach: {i}");
}
#endregion

#region Enums
//Enum
//Liste von Konstanten/fixen Zuständen
//Beispiel: Wochentage, Kontinente, Planeten im Sonnensystem, Geschlechter, ...

//Verwendung: Nur bestimmte Zustände in Variablen/ifs/Parametern bei Methoden/... erlauben
Wochentag heute = Wochentag.Di;
if (heute == Wochentag.Fr)
{
    Console.WriteLine("Endlich Wochenende");
}

//Problem mit Strings: Strings können alles enthalten (z.B. fehlerhafte Zustände)
string heuteStr = "Di";
if (heuteStr == "Fr")
{
	Console.WriteLine("Endlich Wochenende");
}

//Jeder Enumwert hat immer eine Zahl dahinter
//z.B.: Mo = 0, Di = 1, So = 6
//Konvertierungen sind dadurch möglich zw. Zahlen und Enumwerten
Console.WriteLine((int) heute); //Holt die Zahl hinter dem Enumwert
Console.WriteLine((Wochentag) 1); //Den Enumwert zu der entsprechenden Zahl holen

//Enumwerten können selbst Werte zugewiesen werden

//Enums müssen in der Datei ganz unten definiert werden

//Die Enum Klasse
//Enum.Parse("Mo"); //Diese Methode hat keine Ahnung, welcher Enum hier herauskommen soll
Wochentag parsedTag = Enum.Parse<Wochentag>("Mo"); //Per <...> kann der Typ angegeben werden, welcher als Ergebnis herauskommen soll
Wochentag[] alleTage = Enum.GetValues<Wochentag>(); //Alle Werte aus einem Enum hinausholen
bool x = Enum.IsDefined((Wochentag) 20); //Ist der Wert 20 hinter einem der Werte innerhalb des Enums?
#endregion

#region Switch
//Switch
//Prüft, ob ein gegebener Wert, mit bestimmten Werten übereinstimmt, und führt entsprechenden Code aus
int zahl = 3;
switch (zahl)
{
	case 0: //if (zahl == 0)
        Console.WriteLine("Null");
		break; //break beendet das case
	case 1:
		Console.WriteLine("Eins");
		break;
	case 2:
		Console.WriteLine("Zwei");
		break;
	case 3:
		Console.WriteLine("Drei");
		break;
	default: //else (alles andere)
		Console.WriteLine("Andere Zahl");
		break;
}

//Ohne Switch
if (zahl == 0)
    Console.WriteLine("Null");
if (zahl == 1)
	Console.WriteLine("Eins");
if (zahl == 2)
	Console.WriteLine("Zwei");
if (zahl == 3)
	Console.WriteLine("Drei");
else
    Console.WriteLine("Andere Zahl");

//Switch mit Enum
switch (heute)
{
	case Wochentag.Mo:
        Console.WriteLine("Wochenanfang");
        break;
	case Wochentag.Di:
	case Wochentag.Mi:
	case Wochentag.Do:
	case Wochentag.Fr:
        //Di - Fr sind jetzt kombiniert
        Console.WriteLine("Wochenmitte");
        break;
	case Wochentag.Sa:
	case Wochentag.So:
        Console.WriteLine("Wochenende");
        break;
	default:
        Console.WriteLine("Fehler");
        break;
}

if (heute == Wochentag.Mo)
    Console.WriteLine("Wochenanfang");
else if (heute == Wochentag.Di || heute == Wochentag.Mi || heute == Wochentag.Do || heute == Wochentag.Fr)
    Console.WriteLine("Wochenmitte");
else if (heute == Wochentag.Sa || heute == Wochentag.So)
    Console.WriteLine("Wochenende");
else
    Console.WriteLine("Fehler");

//Switch mit boolescher Logik
switch (heute)
{
	case >= Wochentag.Mo and <= Wochentag.Fr:
        Console.WriteLine("Wochenmitte");
		break;
	case Wochentag.Sa or Wochentag.So:
        Console.WriteLine("Wochenende");
		break;
}
#endregion

enum Wochentag
{
	Mo = 1, Di, Mi, Do, Fr, Sa, So
}
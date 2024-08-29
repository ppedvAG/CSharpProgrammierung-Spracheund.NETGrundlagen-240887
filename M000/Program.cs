using M000;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

//Fahrzeug fzg = new Fahrzeug("VW", 20000, 250);
//fzg.StarteMotor();
//Console.WriteLine(fzg.Info());

//fzg.Beschleunige(50);
//Console.WriteLine(fzg.Info());

//fzg.Beschleunige(100);
//Console.WriteLine(fzg.Info());

//fzg.Beschleunige(200);
//Console.WriteLine(fzg.Info());

//fzg.StoppeMotor();
//Console.WriteLine(fzg.Info());

//fzg.Beschleunige(-150);
//Console.WriteLine(fzg.Info());

//fzg.StoppeMotor();
//Console.WriteLine(fzg.Info());

///////////////////////////////////////////////

//PKW p = new PKW("VW", 20000, 250, 5);
//Schiff s = new Schiff("Titanic", 10_000_000, 50, "Dampf");
//Flugzeug f = new Flugzeug("Boeing", 5_000_000, 1000, 10000);

//Console.WriteLine(p.Info());
//Console.WriteLine(s.Info());
//Console.WriteLine(f.Info());

///////////////////////////////////////////////

Fahrzeug[] fzg = new Fahrzeug[10];
for (int i = 0; i < 10; i++)
{
	fzg[i] = Fahrzeug.GeneriereFahrzeug(i.ToString());
    Console.WriteLine(fzg[i].ToString());
}

int anzPKW = 0, anzSchiffe = 0, anzFlugzeuge = 0;
foreach (Fahrzeug f in fzg)
{
	if (f is PKW)
		anzPKW++;
	if (f is Schiff)
		anzSchiffe++;
	if (f is Flugzeug)
		anzFlugzeuge++;
}
Console.WriteLine($"PKWs: {anzPKW}, Schiffe: {anzSchiffe}, Flugzeuge: {anzFlugzeuge}");

fzg[2].Hupen();

TesteBelade(new Container(), Fahrzeug.GeneriereFahrzeug(""));

///////////////////////////////////////////////

void TesteBelade(object o1, object o2)
{
	if (o1 is IBeladbar && o2 is Fahrzeug)
	{
		IBeladbar b = (IBeladbar)o1;
		Fahrzeug f = (Fahrzeug) o2;
		b.Belade(f);
	}
	else if (o2 is IBeladbar beladbar && o1 is Fahrzeug fzg) //Bei is kann ein Variablenname angegeben werden, um eine automatische Umwandlung zu machen
	{
		//IBeladbar beladbar = (IBeladbar) o2;
		//Fahrzeug fzg = (Fahrzeug) o1;
		beladbar.Belade(fzg);
	}
	else
        Console.WriteLine("Keine Beladung möglich");
}
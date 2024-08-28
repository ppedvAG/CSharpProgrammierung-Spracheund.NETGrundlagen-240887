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

PKW p = new PKW("VW", 20000, 250, 5);
Schiff s = new Schiff("Titanic", 10_000_000, 50, "Dampf");
Flugzeug f = new Flugzeug("Boeing", 5_000_000, 1000, 10000);

Console.WriteLine(p.Info());
Console.WriteLine(s.Info());
Console.WriteLine(f.Info());
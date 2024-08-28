using M000;

Fahrzeug fzg = new Fahrzeug("VW", 20000, 250);
fzg.StarteMotor();
Console.WriteLine(fzg.Info());

fzg.Beschleunige(50);
Console.WriteLine(fzg.Info());

fzg.Beschleunige(100);
Console.WriteLine(fzg.Info());

fzg.Beschleunige(200);
Console.WriteLine(fzg.Info());

fzg.StoppeMotor();
Console.WriteLine(fzg.Info());

fzg.Beschleunige(-150);
Console.WriteLine(fzg.Info());

fzg.StoppeMotor();
Console.WriteLine(fzg.Info());
using System;
using Zadatak1.Pool;

class Program
{
    static void Main()
    {
        Pool pool = new Pool();
        PoolMonitoring poolMonitoring = new PoolMonitoring(pool);
        
        Console.WriteLine("Pocinje simulacija promene nivoa vode u bazenu...");

        double inRate = 0.5;
        double outRate = 0.3;

        poolMonitoring.LevelChangeSimulation(inRate, outRate);

        Console.WriteLine("Simulacija zavrsena.");
    }
}

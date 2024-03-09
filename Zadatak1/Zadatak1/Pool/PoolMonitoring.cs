using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak1.Pool
{
    public class PoolMonitoring
    {
        private Pool pool;

        public PoolMonitoring(Pool pool)
        {
            this.pool = pool;
            this.pool.OnLevelChange += OnPoolLevelChanged;
            this.pool.OnStatusChange += OnPoolStatusChanged;
            this.pool.OnLevelChange += OnPoolLevelChangedLogger;
        }

        public void LevelChangeSimulation(double inRate, double outRate)
        {
            while (pool.Level > pool.MinLevel)
            {
                pool.Level -= outRate;
                Thread.Sleep(1000);
            }
            while (pool.Level < pool.MaxLevel)
            {
                pool.Level += inRate;
                Thread.Sleep(1500);
            }
        }

        private void OnPoolLevelChanged(double level)
        {
            Console.WriteLine($"Nivo vode u bazenu je sada {level:F4} metara - zabeleženo {DateTime.Now}");
        }

        private void OnPoolStatusChanged(Status status)
        {
            Console.WriteLine($"Status bazena je promenjen na: {status} - zabeleženo {DateTime.Now}");
        }

        private void OnPoolLevelChangedLogger(double level)
        {
            string filePath = "bazenLog.txt";
            string logMessage = $"Nivo vode: {level:F4} metara - zabeleženo {DateTime.Now}";

            using StreamWriter writer = File.AppendText(filePath);
            writer.WriteLine(logMessage);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1.Pool
{
    public delegate void PoolLevelHandler(double newLevel);
    public delegate void PoolStatusHandler(Status newStatus);

    public class Pool
    {
        private double level;
        private readonly double minLevel;
        private readonly double maxLevel;
        private Status poolStatus;

        public double Level
        {
            get { return level; }
            set
            {
                var newValue = value;
                if (newValue < MinLevel) newValue = MinLevel;
                else if (newValue > MaxLevel) newValue = MaxLevel;

                if (level != newValue)
                {
                    level = newValue;
                    OnLevelChange?.Invoke(level);
                    UpdatePoolStatus();
                }
            }
        }

        public double MinLevel => minLevel;

        public double MaxLevel => maxLevel;

        public Status PoolStatus => poolStatus;

        public event PoolLevelHandler? OnLevelChange;
        public event PoolStatusHandler? OnStatusChange;

        public Pool()
        {
            level = 2.5;
            minLevel = 0.0;
            maxLevel = 5.0;
            poolStatus = Status.Half;
        }

        public Pool(double level, double minLevel, double maxLevel)
        {
            if (minLevel >= maxLevel)
            {
                throw new ArgumentException("Minimamaln nivo mora biti manji od maksimalnog nivoa.");
            }

            this.minLevel = minLevel;
            this.maxLevel = maxLevel;
            this.level = Math.Max(minLevel, Math.Min(level, maxLevel));
            UpdatePoolStatus();
        }

        private void UpdatePoolStatus()
        {
            var newStatus = level <= minLevel ? Status.Empty : level >= maxLevel ? Status.Full : Status.Half;
            if (poolStatus != newStatus)
            {
                poolStatus = newStatus;
                if(poolStatus != Status.Half)
                OnStatusChange?.Invoke(poolStatus);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public enum ECacheSize
    {
        L1 = 1,
        L2 = 2,
        L3 = 3
    }
    public enum EArchitecture
    {
        x86 = 1,
        x64 = 2
    }
    public class Proccesor
    {
        public string Producer;
        public string Model;
        public uint Cores;
        public double Hz;
        public double MaxHz;
        
        public EArchitecture Architecture;
        public ECacheSize CacheSize;
        public Proccesor(string producer, string model, uint cores, double hz, double maxHz,uint size,uint arc)
        {
            Producer = producer;
            Model = model;
            Cores = cores;
            Hz = hz;
        }
    }
}

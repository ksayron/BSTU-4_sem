using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    [Serializable]
    public enum ECacheSize
    {
        none = 0,
        L1 = 1,
        L2 = 2,
        L3 = 3
    }
    [Serializable]
    public enum EArchitecture
    {
        none = 0,
        x86 = 1,
        x64 = 2
    }
    [Serializable]
    public enum EProducer
    {
        none = 0,
        AMD = 1,
        Intel = 2
    }
    [Serializable]
    public enum ESeries
    {
        none = 0,
        Pentium = 1,
        Core = 2,
        FX = 3,
        Ryzen = 4
    }
    [Serializable]
    public enum EModel
    {
        none = 0,
        M3100 = 1,
        M3300 = 2,
        M5500 = 3,
        M5700 = 4,
        M5900 = 5
    }
    [Serializable]
    public class Proccesor
    {
        public EProducer Producer;
        public EModel Model;
        public ESeries Series;
        public uint Cores;
        public float Hz;
        public float MaxHz;
        
        public EArchitecture Architecture;
        public ECacheSize CacheSize;
        public Proccesor(EProducer producer, EModel model,ESeries series, uint cores, float hz, float maxHz, ECacheSize size, EArchitecture arc)
        {
            Producer = producer;
            Model = model;
            Series = series;
            Cores = cores;
            Hz = hz;
            MaxHz = maxHz;
            Architecture = arc;
            CacheSize = size;
        }
        public Proccesor()
        {

        }
        public string Stats()
        {
            string message = $"Производитель: {Producer}\n" +
                $"Модель: {Model}\n" +
                $"Серия: {Series}\n" +
                $"Кол-во ядер: {Cores}\n" +
                $"Частота: {Hz}\n" +
                $"Макс. частота: {MaxHz}\n" +
                $"Architecture: {Architecture}\n" +
                $"CacheSize: {CacheSize}";
            return message;
        }
        public void DisplayProperties()
        {
            

            MessageBox.Show(Stats(), "Processor Properties", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public enum EComType
    {
        none,
        PC,
        Laptop,
        Server
    }
    public enum ERAMType
    {
        none,
        DDR1,
        DDR2,
        DDR3,
        DDR4,
        DDR5
    }
    public enum EDriveType
    {
        none,
        HDD,
        SSD
    }
    public struct Drive
    {
        public EDriveType type;
        public uint size;
    }
    public struct Ram
    {
        public ERAMType type;
        public uint size;
    }
    public class Computer
    {
        public string Name;
        public EComType Type;
        public Drive drives;
        public Ram ram;
        public DateTime PurchaseDate;
        public Proccesor Proccesor;
        public DateTime date;
        public uint Price;

        public Computer()
        {
            Name = string.Empty;
            Type = EComType.none;
            drives = new Drive();
            drives.size = 0;
            drives.type = EDriveType.none;
            ram = new Ram();
            ram.size = 0;
            ram.type = ERAMType.none;
            date = new DateTime();
            Proccesor = new Proccesor();
        }
    }
}

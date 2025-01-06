using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public enum EComType
    {
        PC,
        Laptop,
        Server
    }
    public enum ERAMType
    {
        DDR1,
        DDR2,
        DDR3,
        DDR4,
        DDR5
    }
    public enum EDriveType
    {
        HDD,
        SSD
    }
    public struct Drive
    {
        EDriveType type;
        uint size;
    }
    public struct Ram
    {
        ERAMType type;
        uint size;
    }
    public class Computer
    {
        public string Name;
        public EComType Type;
        public Drive drives;
        public Ram ram;
        public DateTime PurchaseDate;

    }
}

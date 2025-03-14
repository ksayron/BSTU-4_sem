using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    [Serializable]
    public enum EComType
    {
        none,
        PC,
        Laptop,
        Server
    }
    [Serializable]
    public enum ERAMType
    {
        none,
        DDR1,
        DDR2,
        DDR3,
        DDR4,
        DDR5
    }
    [Serializable]
    public enum EDriveType
    {
        none,
        HDD,
        SSD
    }
    [Serializable]
    public struct Drive
    {
        public EDriveType type;
        public uint size;
    }
    [Serializable]
    public struct Ram
    {
        public ERAMType type;
        public uint size;
    }

    public class ValidDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value!= null)
            {
               if (!DateTime.TryParse(value.ToString(), out DateTime validateDate))
               {
                    this.ErrorMessage = "Неккоректная дата";
                    return false;
               }
               if(validateDate < new DateTime(2000, 1, 1))
               {
                    this.ErrorMessage = "Слишком старый компьютер";
                    return false;
               }
                if (validateDate > DateTime.Now)
                {
                    this.ErrorMessage = "Вы не из будущего!";
                    return false;
                }
                return true;
            }
            this.ErrorMessage = "Отсутствует дата";
            return false;
        }
    }
    [Serializable]
    public class Computer
    {
        [Required(ErrorMessage = "Устройство должно обладать именем")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public EComType Type { get; set; }
        [Required]
        public Drive drives;
        [Required]
        public Ram ram;
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public Proccesor Proccesor { get; set; }
        [ValidDate]
        public DateTime date {  get; set; }
        [Required]
        [Range(0,2000)]
        public double Price;

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
            Price = 0;
        }

        public void CalculatePrice()
        {
            double DiskPrice = 0;
            double RamPrice = 0;
            double ProcPrice = 0;
            try{ 
            switch (drives.type)
            {
                case EDriveType.none :
                    {
                        throw new Exception("нет диска");
                        break;
                    }
                case EDriveType.HDD:
                    {
                        DiskPrice = 1;
                        break;
                    }
                case EDriveType.SSD:
                    {
                        DiskPrice = 2;
                        break;
                    }
                default :
                    {
                        throw new Exception("хз как"); 
                    }
            }
            DiskPrice *= 0.03*drives.size;
            switch (ram.type)
            {
                case ERAMType.none:
                    {
                        throw new Exception("нет оперативки");
                        break;
                    }
                case ERAMType.DDR1:
                    {
                        RamPrice = 1;
                        break;
                    }
                case ERAMType.DDR2:
                    {
                        RamPrice = 2;
                        break;
                    }
                case ERAMType.DDR3:
                    {
                        RamPrice = 3;
                        break;
                    }
                case ERAMType.DDR4:
                    {
                        RamPrice = 4;
                        break;
                    }
                case ERAMType.DDR5:
                    {
                        RamPrice = 6;
                        break;
                    }
                default:
                    {
                        throw new Exception("хз как");
                    }
            }
            RamPrice *= ram.size;
            switch (Proccesor.Series)
            {
                case ESeries.none:
                    {
                        throw new Exception("нет оперативки");
                        break;
                    }
                case ESeries.Pentium:
                    {
                        ProcPrice = 1;
                        break;
                    }
                case ESeries.FX:
                    {
                        ProcPrice = 1;
                        break;
                    }
                case ESeries.Core:
                    {
                        ProcPrice = 2;
                        break;
                    }
                case ESeries.Ryzen:
                    {
                        ProcPrice = 2;
                        break;
                    }
                default:
                    {
                        throw new Exception("хз как");
                    }

            }
            switch (Proccesor.Model)
            {
                case EModel.none:
                    {
                        throw new Exception("нет оперативки");
                        break;
                    }
                case EModel.M3100:
                    {
                        ProcPrice *= 10;
                        break;
                    }
                case EModel.M3300:
                    {
                        ProcPrice *= 30;
                        break;
                    }
                case EModel.M5500:
                    {
                        ProcPrice *= 50;
                        break;
                    }
                case EModel.M5700:
                    {
                        ProcPrice *= 70;
                        break;
                    }
                case EModel.M5900:
                    {
                        ProcPrice *= 90;
                        break;
                    }
                default:
                    {
                        throw new Exception("хз как");
                    }
            }
                switch (Proccesor.CacheSize)
                {
                    case ECacheSize.none:
                        {
                            throw new Exception("нет процессора");
                            break;
                        }
                    case ECacheSize.L1:
                        {
                            ProcPrice *= 1.2;
                            break;
                        }
                    case ECacheSize.L2:
                        {
                            ProcPrice *= 2;
                            break;
                        }
                    case ECacheSize.L3:
                        {
                            ProcPrice *= 2.5;
                            break;
                        }
                    default:
                        {
                            throw new Exception("хз как");
                        }
                }
                if (Proccesor.Architecture == EArchitecture.none)
                {
                    throw new Exception("no architecture");
                }
            }
            catch{
                return;
            }
            if(Proccesor.Architecture == EArchitecture.x64)
            {
                ProcPrice *= 1.5;
            }
            ProcPrice += Proccesor.Cores * (Proccesor.Hz / 2 + Proccesor.MaxHz / 2);
            Price = ProcPrice+RamPrice+DiskPrice;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_MSSQL_LIB
{
    public class LifeEvent
    {
        public LifeEvent() { this.Description = string.Empty; }
        public int Id { get; set; }
        public int CelebrityId { get; set; }
        public DateTime? Date { get; set; }
        public string Description {  get; set; }
        public string? ReqPhotoPath { get; set; }
        public virtual bool Update(LifeEvent lifeEvent) => false;
    }
}

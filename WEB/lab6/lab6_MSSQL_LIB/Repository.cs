
using lab6_LIB;

namespace lab6_MSSQL_LIB
{
    public interface IRepository : lab6_LIB.IRepository<Celebrity,LifeEvent> { }

    public class Repository :   IRepository
    {
        Context context;
        public Repository()
        {
            this.context = new Context();
        }
        public Repository(string connString)
        {
            this.context = new Context(connString);
        }
        public static IRepository Create()
        {
            return new Repository();
        }
        public static IRepository Create(string connString)
        {
            return new Repository(connString);
        }
        public bool AddCelebrity(Celebrity celebrity)
        {
            if (this.context.Celebrities.Add(celebrity) is not null) { this.context.SaveChanges(); return true; }
            else return false;
        }

        public bool AddEvent(LifeEvent LifeEvent)
        {

            if (this.context.Events.Add(LifeEvent) is not null) { this.context.SaveChanges(); return true; }
            else return false;
        }

        public bool DelCelebrity(int id)
        {
            Celebrity? celeb = this.context.Celebrities.FirstOrDefault(ce => ce.Id == id);
            if (celeb == null) return false;
            this.context.Celebrities.Remove(celeb);
            this.context.SaveChanges();
            return true;
        }

        public bool DelEvent(int id)
        {
            LifeEvent? even = this.context.Events.FirstOrDefault(e => e.Id == id);
            if (even == null) return false;
            this.context.Events.Remove(even);
            this.context.SaveChanges();
            return true;
        }


        public List<Celebrity> GetAllCelebrity()
        {
            return this.context.Celebrities.ToList();
        }

        public List<LifeEvent> GetAllEvents()
        {
            return this.context.Events.ToList();
        }

        public Celebrity? GetCelebById(int id)
        {
            return this.context.Celebrities.FirstOrDefault(p=>p.Id==id);
        }

        public Celebrity? GetCelebByEventId(int Eventid)
        {
            var Eventt = this.context.Events.FirstOrDefault(p => p.Id == Eventid);
            return GetCelebById(Eventt.CelebrityId);
        }

        public List<LifeEvent> GetEventsByCelebId(int CelebID)
        {
            return this.context.Events.Where(p=>p.CelebrityId == CelebID).ToList();
        }

        public LifeEvent? GetEventById(int id)
        {
            return this.context.Events.FirstOrDefault(p => p.Id == id);
        }

        public int GetCelebdByName(string name)
        {
            return this.context.Celebrities.First(p => p.FullName == name).Id;
        }

        public bool UpdCelebrity(int id, Celebrity celebrity)
        {
            Celebrity? celeb = this.context.Celebrities.FirstOrDefault(ce => ce.Id == id);
            if (celeb == null) return false;
            celeb.FullName = celebrity.FullName;
            celeb.Nationality = celebrity.Nationality;
            celeb.ReqPhotoPath = celebrity.ReqPhotoPath;
            this.context.Celebrities.Update(celeb);
            this.context.SaveChanges();
            return true;
        }

        public bool UpdEvent(int id, LifeEvent LifeEvent)
        {
            LifeEvent? even = this.context.Events.FirstOrDefault(e => e.Id == id);
            if (even == null) return false;
            even.Date = LifeEvent.Date;
            even.Description = LifeEvent.Description;
            even.ReqPhotoPath = LifeEvent.ReqPhotoPath;
            even.CelebrityId = LifeEvent.CelebrityId;
            this.context.Events.Update(even);
            this.context.SaveChanges();
            return true;
        }

        public void Dispose() { }
    }

}

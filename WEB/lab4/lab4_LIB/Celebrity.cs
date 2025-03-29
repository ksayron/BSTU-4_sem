namespace lab4_LIB
{
    public class Celebrity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string PhotoPath { get; set; }
        public Celebrity() { }
        public Celebrity (int id,string name,string surename,string photo)
        {
            Id = id;
            Firstname = name;
            Surname = surename;
            PhotoPath = photo;
        }
    }
}

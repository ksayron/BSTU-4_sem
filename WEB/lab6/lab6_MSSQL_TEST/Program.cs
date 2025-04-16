﻿using lab6_MSSQL_LIB;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace lab6_MSSQL_TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string CS = "Server=(LocalDb)\\MSSQLLocalDB; Database = Lab6_DB; TrustServerCertificate=True; Trusted_Connection=true";
            

            Init init =new Init(CS);
            Init.Execute(create: true, delete: true);

            Func<Celebrity, string> PrintC = (Celebrity cel) =>  $"Id = {cel.Id}, FullName = {cel.FullName}, Nationality = {cel.Nationality}, ReqPhotoPath = {cel.ReqPhotoPath}";
            Func<LifeEvent, string> PrintLE = (LifeEvent le) =>  $"Id = {le.Id}, CelebrityId = {le.CelebrityId}, Date = {le.Date},Description = {le.Description}, ReqPhotoPath = {le.ReqPhotoPath}";
            Func<string, string> puri = (f) => $"{f}";
            using (IRepository repo = Repository.Create(CS))
            {
                {
                    Console.WriteLine("------GetAllCelebrity()------");
                    repo.GetAllCelebrity().ForEach(celeb => Console.WriteLine(PrintC(celeb)));
                }
                {
                    Console.WriteLine("------GetAllLifeEvents()------");
                    repo.GetAllEvents().ForEach(even => Console.WriteLine(PrintLE(even)));
                }
                {
                    Console.WriteLine("------AddCelebrity()------");
                    Celebrity c = new Celebrity() { FullName = "Albert Einstien", Nationality = "DE", ReqPhotoPath = puri("Einstein.jpg") };
                    if (repo.AddCelebrity(c)) Console.WriteLine($"OK: AddCelebrity{ PrintC(c)}");
                    else Console.WriteLine($"ERROR: AddCelebrity{PrintC(c)}");
                    
                }
                {
                    Console.WriteLine("------AddCelebrity()------");
                    Celebrity c = new Celebrity() { FullName = "Samuel Huntington", Nationality = "US", ReqPhotoPath = puri("Huntington.jpg") };
                    if (repo.AddCelebrity(c)) Console.WriteLine($"OK: AddCelebrity {PrintC(c)}");
                    else Console.WriteLine($"ERROR: AddCelebrity{PrintC(c)}");
                }
                {
                    Console.WriteLine("------DelCelebrity()------");
                    int id = 0;
                    id = repo.GetCelebdByName("Albert Einstien");
                    if (id>0) { repo.DelCelebrity(id); Console.WriteLine($"OK: DelCelebrity {id}"); }
                    else Console.WriteLine($"ERROR: GetCelebIdByNam ");
                }
                {
                    Console.WriteLine("------UpdCelebrity()------");
                    int id = 0;
                    id = repo.GetCelebdByName("Samuel Huntington");
                    if (id > 0) 
                    {
                        Celebrity? c = repo.GetCelebById(id);
                        if (c is not null)
                        {
                            c.FullName += " Updated";
                            repo.UpdCelebrity(id,c);
                            Console.WriteLine($"OK: UpdCelebrity{PrintC(c)}"); 
                        }
                        else Console.WriteLine($"ERROR: GetCelebById ");
                    }

                    else Console.WriteLine($"ERROR: GetCelebIdByNam ");
                }
                {
                    Console.WriteLine("------AddLifeEvent()------");
                    
                    int id = 0;
                    id = repo.GetCelebdByName("Samuel Huntington Updated");
                    if (id > 0)
                    {
                        LifeEvent le = new LifeEvent() { CelebrityId = id, Date = new DateTime(1991,1,1),Description="Novi God", ReqPhotoPath = null };
                        LifeEvent le2 = new LifeEvent() { CelebrityId = id, Date = new DateTime(1991, 6, 1), Description = "leto :)", ReqPhotoPath = null };
                        LifeEvent le3= new LifeEvent() { CelebrityId = id, Date = new DateTime(1991, 9, 1), Description = "snova ucheba :(", ReqPhotoPath = null };
                        Celebrity? c = repo.GetCelebById(id);
                        if (c is not null)
                        {
                            if(repo.AddEvent(le)) Console.WriteLine($"OK: AddLifeEvent {PrintLE(le)}");
                            else Console.WriteLine($"ERROR: AddLifeEvent {PrintLE(le)}");
                            if (repo.AddEvent(le2)) Console.WriteLine($"OK: AddLifeEvent {PrintLE(le2)}");
                            else Console.WriteLine($"ERROR: AddLifeEvent {PrintLE(le2)}");
                            if (repo.AddEvent(le3)) Console.WriteLine($"OK: AddLifeEvent {PrintLE(le3)}");
                            else Console.WriteLine($"ERROR: AddLifeEvent {PrintLE(le3)}");
                        }
                        else Console.WriteLine($"ERROR: GetCelebById ");
                    }

                    else Console.WriteLine($"ERROR: GetCelebIdByNam ");
                }
                {
                    Console.WriteLine("------DelLifeEvent()------");
                    int id = 22;
                    if (repo.DelEvent(id)) { Console.WriteLine($"OK: DelEvent {id} "); }
                    else Console.WriteLine($"ERROR: DelEvent {id} ");
                }
                {
                    Console.WriteLine("------UpdLifeEvent()------");
                    int id = 21;
                    LifeEvent? l1 = repo.GetEventById(id);
                    if( l1 is not null)
                    {
                        l1.Description += " ochen kruto!!!";
                        if (repo.UpdEvent(id, l1)) Console.WriteLine($"OK: UpdEvent {id},{PrintLE(l1)} ");
                        else Console.WriteLine($"ERROR: UpdEvent {id},{PrintLE(l1)} ");
                    }
                }
                {
                    Console.WriteLine("------GetLifeEventsByCelebrityId()------");
                    int id = 0;
                    id = repo.GetCelebdByName("Samuel Huntington Updated");
                    if (id > 0)
                    {
                        Celebrity? c = repo.GetCelebById(id);
                        if (c is not null)
                        {
                            repo.GetEventsByCelebId(c.Id).ForEach(le => Console.WriteLine($"OK: GetEventsByCelebrityId, {id} {PrintLE(le)} "));
                        }
                        else Console.WriteLine($"ERROR: GetEventsByCelebrityId {id} ");
                    }

                    else Console.WriteLine($"ERROR: GetCelebIdByName ");
                }
                {
                    Console.WriteLine("------GetCelebrityByLifeEventId()------");
                    int id = 23;
                    Celebrity? c = repo.GetCelebByEventId(id);
                    if (c is not null)
                    {
                        Console.WriteLine($"OK: GetCelebrityByLifeEventId {id},{PrintC(c)} ");
                        
                    }
                    else Console.WriteLine($"ERROR: GetCelebrityByLifeEventId {id}");
                }
            }
            Console.WriteLine("--------->");Console.ReadKey();
        }
    }
}

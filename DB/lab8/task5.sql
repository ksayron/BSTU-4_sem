create view Predmeti(id,name,pulpitId)
 as select TOP 200 s.SUBJECT,s.SUBJECT_NAME,s.PULPIT from SUBJECT s order by s.SUBJECT_NAME asc;
 select * from Predmeti
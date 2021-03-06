--
-- PRACTICE CREATION COUNT PER WEEK (NOT COUNTING THE CANCELED ACCOUNTS)
--
declare @Interval int = 7;
declare @WeekOffset int = 0;
WITH cSequence AS
(
    SELECT DATEADD(DAY, @WeekOffset, '2013-03-24') AS StartRange, DATEADD(DAY, @Interval + @WeekOffset, '2013-03-24') AS EndRange
    UNION ALL
    SELECT EndRange, DATEADD(DAY, @Interval, EndRange)
    FROM cSequence 
    WHERE DATEADD(DAY, @Interval, EndRange) < DATEADD(DAY, @Interval, GETDATE())
)
SELECT
  CONVERT(char(10), StartRange,126) as StartRange,
  CONVERT(char(10), EndRange,126) as EndRange,
  (select count(*) from practice PR
    join [user] U on PR.OwnerId = U.Id
    join Person PER on U.PersonId = PER.Id
    where PR.AccountDisabled <> 1 and
    UrlIdentifier not like 'consultorioplus%' and UrlIdentifier <> 'consultoriodrhouse' and
    U.UserName <> 'andrerpena' and
    PR.CreatedOn >= I.StartRange and PR.CreatedOn < I.EndRange) as [Count]
FROM cSequence I;

--
-- PRACTICE USAGE
-- depends on view PatientMedicalRecords (select * from PatientMedicalRecords)
--
select
    PR.Id as PracticeId,
    PR.UrlIdentifier,
    LastActiveOn,
    U.UserName,
    PR.CreatedOn,
    DATEDIFF(day, LastActiveOn, GETDATE()) as InactiveDays,
    (select top 1 CAST(Id as varchar(max))+'-'+Value from GLB_Token where Name = 'Practice='+PR.UrlIdentifier+'&UserName='+U.UserName) as ActivationToken,
    (select count(*) from Patient as PAT where PR.Id = PAT.PracticeId) as PatientCount,
    DATEDIFF(day, PR.CreatedOn, GETDATE()) as ElapsedTime,
    (select count(*) from PatientMedicalRecords as PMR where PR.Id = PMR.PracticeId) as MedicalRecordsCount,
    PER.Email,
    PR.PhoneMain
  from practice PR
  join [user] U on PR.OwnerId = U.Id
  join Person PER on U.PersonId = PER.Id
  where
    PR.AccountDisabled <> 1 and
    UrlIdentifier not like 'consultorioplus%' and UrlIdentifier <> 'consultoriodrhouse' and
    U.UserName <> 'andrerpena'
    --and UrlIdentifier like '%clin%'
    --and PER.Email = 'cristianormoraes@gmail.com'
  --order by LastActiveOn desc
  order by PR.CreatedOn desc

--
-- PATIENTS STATS FOR A PRACTICE
-- depends on view PatientMedicalRecords (select * from PatientMedicalRecords)
--
select
    PS.*,
    PR.UrlIdentifier,
    DATEDIFF(day, LastActiveOn, GETDATE()) as InactiveDays,
    CASE PS.ElapsedTime WHEN 0 THEN 0.0 ELSE PS.PatientCount * 1.0 / PS.ElapsedTime END as PatientsPerDay,
    PER.email
  from (
      select
          PR.Id,
          (select count(*) from Patient as PAT where PR.Id = PAT.PracticeId) as PatientCount,
          DATEDIFF(day, PR.CreatedOn, GETDATE()) as ElapsedTime,
          (select count(*) from PatientMedicalRecords as PMR where PR.Id = PMR.PracticeId) as MedicalRecordsCount
        from Practice PR
    ) PS
    join Practice PR on PS.Id = PR.Id
    join [user] U on PR.OwnerId = U.Id
    join Person PER on U.PersonId = PER.Id
  where PR.AccountDisabled <> 1 and
    PR.UrlIdentifier not like 'consultorioplus%' and PR.UrlIdentifier <> 'consultoriodrhouse' and
    U.UserName <> 'andrerpena'
  order by PatientsPerDay desc, PS.ElapsedTime

--insert into glb_token (Value, ExpirationDate, [Type], Name) values ('5a740aca6e1046b7904b4df6d5fa6826', '2013-05-10', 'VerifyPracticeAndEmail', 'Practice=evandrofontesdeoliveira&UserName=evafoli')

-- All tokens
select * from glb_token

-- Info about an user
select U.Id, U.UserName, U.SYS_PasswordAlt, PR.UrlIdentifier, PR.Id from [user] U join Practice PR on PR.OwnerId = U.Id
  where UserName = 'deiapas'

select * from [File]

--update [user] set SYS_PasswordAlt = 'Masb@1567' where Id = 29

--delete from glb_token where Id = 21

select * from Person
  join [user] U on U.PersonId = Person.Id
  where U.PracticeId = 41

select * from Person
  where Id = 213

select OwnerId, SYS_PasswordAlt, UserName, [Password]
  from practice PR
  join [user] U on PR.OwnerId = U.Id

--update [user] set SYS_PasswordAlt = 'Masb@1567' where Id = 1

select UserName from [user]







-- check datetime columns of medical record items
select CreatedOn, MedicalRecordDate from dbo.Anamnese                       --where PracticeId = 14
select CreatedOn, MedicalRecordDate from dbo.Diagnosis                      --where PracticeId = 14
select CreatedOn, MedicalRecordDate from dbo.DiagnosticHypothesis           --where PracticeId = 14
select CreatedOn, RequestDate from dbo.ExaminationRequest                   --where PracticeId = 14
select CreatedOn, ExaminationDate, ReceiveDate from dbo.ExaminationResult   --where PracticeId = 14
select CreatedOn, IssuanceDate from dbo.MedicalCertificate                  --where PracticeId = 14
select FileDate, ReceiveDate from dbo.PatientFile                           --where PracticeId = 14
select CreatedOn, MedicalRecordDate from dbo.PhysicalExamination            --where PracticeId = 14
select CreatedOn, IssuanceDate from dbo.Receipt                             --where PracticeId = 14



select * from PatientFile as PF
  join Practice as PR on PR.Id = PF.PracticeId

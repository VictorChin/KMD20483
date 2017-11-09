Create Table SampleTable
(id int primary key,
 name varchar(30),
 phone varchar(10),
 dob datetime);
 insert into SampleTable
 values (1,'Victor','2125551212','19750721');
 insert into SampleTable
 values (2,'Bob','2125551213','19730721');
insert into SampleTable
 values (3,'Jon','2125551214','19790721');


select name,phone from SampleTable where dob > '19750101';
select min(dob),max(dob) from SampleTable;


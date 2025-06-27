DROP TABLE IF EXISTS Employee;
CREATE TABLE Employee(
ID INT PRIMARY KEY,
FIRSTName VARCHAR (100),
Department varchar(100),
salary DECIMAL (10,2));

INSERT INTO Employee(ID,FIRSTName,Department,salary) VALUES 
( 1, 'NICOLE','HR',500000),
( 2, 'RAYAN','HR',600000),
( 3, 'AMBER','TECH',300000),
( 4, 'LUMINE','TECH',300000),
( 5, 'FURINA','IT',200000),
( 6, 'KOJIMA','IT',170000)
;

SELECT * FROM (SELECT FIRSTName,Department,salary, 
ROW_NUMBER() OVER (PARTITION BY Department ORDER BY salary DESC)
AS ROWNUM FROM Employee )
AS Ranked WHERE ROWNUM <=3;

SELECT * FROM (SELECT FIRSTName,Department,salary, 
RANK() OVER (PARTITION BY Department ORDER BY salary DESC)
AS RANKNUM FROM Employee )
AS Ranked WHERE RANKNUM <=3;


SELECT * FROM (SELECT FIRSTName,Department,salary, 
DENSE_RANK() OVER (PARTITION BY Department ORDER BY salary DESC)
AS DENSERANKNUM FROM Employee )
AS Ranked WHERE DENSERANKNUM <=3;


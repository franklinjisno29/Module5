use UST

--Emp
IF OBJECT_ID('EMP', 'U') IS NOT NULL
    DROP TABLE EMP;
CREATE TABLE EMP (
    EMPNO INT NOT NULL,
    ENAME VARCHAR(10),
    JOB VARCHAR(9),
    MGR INT,
    HIREDATE DATE,
    SAL DECIMAL(7, 2),
    COMM DECIMAL(7, 2),
    DEPTNO INT
);

INSERT INTO EMP VALUES
    (7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
    (7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
    (7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
    (7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
    (7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
    (7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
    (7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
    (7788, 'SCOTT', 'ANALYST', 7566, '1982-12-09', 3000, NULL, 20),
    (7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
    (7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
    (7876, 'ADAMS', 'CLERK', 7788, '1983-01-12', 1100, NULL, 20),
    (7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
    (7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
    (7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);

--Designation Masters
IF OBJECT_ID('DESIGNATION_MASTERS', 'U') IS NOT NULL
    DROP TABLE DESIGNATION_MASTERS;
CREATE TABLE DESIGNATION_MASTERS (
    Design_Code INT PRIMARY KEY,
    Design_Name VARCHAR(50) UNIQUE
);
INSERT INTO DESIGNATION_MASTERS VALUES
    (101, 'HOD'),
    (102, 'Professor'),
    (103, 'Reader'),
    (104, 'Sr.Lecturer'),
    (105, 'Lecturer'),
    (106, 'Director');

--Department Masters
IF OBJECT_ID('DEPARTMENT_MASTERS', 'U') IS NOT NULL
    DROP TABLE DEPARTMENT_MASTERS;
CREATE TABLE DEPARTMENT_MASTERS (
    Dept_code INT PRIMARY KEY,
    Dept_Name VARCHAR(50) UNIQUE
);
INSERT INTO DEPARTMENT_MASTERS VALUES
    (10, 'Computer Science'),
    (20, 'Electricals'),
    (30, 'Electronics'),
    (40, 'Mechanics'),
    (50, 'Robotics');

--Student Masters
IF OBJECT_ID('STUDENT_MASTERS', 'U') IS NOT NULL
    DROP TABLE STUDENT_MASTERS;
CREATE TABLE STUDENT_MASTERS (
    Student_Code INT PRIMARY KEY,
    Student_Name VARCHAR(50) NOT NULL,
    Dept_Code INT REFERENCES DEPARTMENT_MASTERS(dept_code),
    Student_Dob DATE,
    Student_Address VARCHAR(240)
);

INSERT INTO STUDENT_MASTERS VALUES
    (1001, 'Amit', 10, '1980-01-11', 'chennai'),
    (1002, 'Ravi', 10, '1981-11-01', 'New Delhi'),
    (1003, 'Ajay', 20, '1982-01-13', null),
    (1004, 'Raj', 30, '1979-01-14', 'Mumbai'),
    (1005, 'Arvind', 40, '1983-01-15', 'Bangalore'),
    (1006, 'Rahul', 50, '1981-01-16', 'Delhi'),
    (1007, 'Mehul', 20, '1982-01-17', 'Chennai'),
    (1008, 'Dev', 10, '1981-03-11', 'Bangalore'),
    (1009, 'Vijay', 30, '1980-01-19', 'Bangalore'),
    (1010, 'Rajat', 40, '1980-01-20', 'Bangalore'),
    (1011, 'Sunder', 50, '1980-01-21', 'Chennai'),
    (1012, 'Rajesh', 30, '1980-01-22', null),
    (1013, 'Anil', 20, '1980-01-23', 'Chennai'),
    (1014, 'Sunil', 10, '1985-02-15', null),
    (1015, 'Kapil', 40, '1981-03-18', 'Mumbai'),
    (1016, 'Ashok', 40, '1980-11-26', null),
    (1017, 'Ramesh', 30, '1980-12-27', null),
    (1018, 'Amit Raj', 50, '1980-09-28', 'New Delhi'),
    (1019, 'Ravi Raj', 50, '1981-05-29', 'New Delhi'),
    (1020, 'Amrit', 10, '1980-11-11', null),
    (1021, 'Sumit', 20, '1980-01-01', 'Chennai');

--Student Marks
IF OBJECT_ID('STUDENT_MARKS', 'U') IS NOT NULL
    DROP TABLE STUDENT_MARKS;
CREATE TABLE STUDENT_MARKS (
    Student_Code INT REFERENCES STUDENT_MASTERS(Student_Code),
    Student_Year INT NOT NULL,
    Subject1 INT,
    Subject2 INT,
    Subject3 INT
);

INSERT INTO STUDENT_MARKS VALUES
    (1001, 2010, 55, 45, 78),
    (1002, 2010, 66, 74, 88),
    (1003, 2010, 87, 54, 65),
    (1004, 2010, 65, 64, 90),
    (1005, 2010, 78, 88, 65),
    (1006, 2010, 65, 86, 54),
    (1007, 2010, 67, 79, 49),
    (1008, 2010, 72, 55, 55),
    (1009, 2010, 71, 59, 58),
    (1010, 2010, 68, 44, 92),
    (1011, 2010, 89, 96, 78),
    (1012, 2010, 78, 56, 55),
    (1013, 2010, 75, 58, 65),
    (1014, 2010, 73, 74, 65),
    (1015, 2010, 66, 45, 74),
    (1016, 2010, 68, 78, 74),
    (1017, 2010, 69, 44, 52),
    (1018, 2010, 65, 78, 56),
    (1019, 2010, 78, 58, 74),
    (1020, 2010, 45, 55, 65),
    (1021, 2010, 78, 79, 78),
    (1001, 2011, 68, 44, 92),
    (1002, 2011, 89, 96, 78),
    (1003, 2011, 78, 56, 55),
    (1004, 2011, 75, 58, 65),
    (1005, 2011, 73, 74, 65),
    (1006, 2011, 66, 45, 74),
    (1007, 2011, 68, 78, 74),
    (1008, 2011, 69, 44, 52),
    (1009, 2011, 65, 78, 56),
    (1010, 2011, 78, 58, 74),
    (1011, 2011, 45, 55, 65),
    (1012, 2011, 78, 79, 78),
    (1013, 2011, 66, 74, 88),
    (1014, 2011, 65, 64, 90),
    (1015, 2011, 78, 88, 65),
    (1016, 2011, 65, 86, 54),
    (1017, 2011, 67, 79, 49),
    (1018, 2011, 72, 55, 55),
    (1019, 2011, 71, 59, 58),
    (1020, 2011, 55, 45, 78),
    (1021, 2011, 87, 54, 65);

--Staff Masters
IF OBJECT_ID('STAFF_MASTERS', 'U') IS NOT NULL
    DROP TABLE STAFF_MASTERS;
CREATE TABLE STAFF_MASTERS (
    Staff_Code INT PRIMARY KEY,
    Staff_Name VARCHAR(50) NOT NULL,
    Design_Code INT REFERENCES DESIGNATION_MASTERS(Design_Code),
    Dept_Code INT REFERENCES DEPARTMENT_MASTERS(Dept_code),
    Staff_Dob DATE,
    Hiredate DATE,
    Mgr_code INT,
    Staff_Sal DECIMAL(10, 2),
    Staff_Address VARCHAR(240)
);

INSERT INTO STAFF_MASTERS VALUES
    (100001, 'Arvind', 102, 30, '1980-01-15', '2003-01-15', 100006, 17000, 'Bangalore'),
    (100002, 'Shyam', 102, 20, '1980-02-18', '2002-02-17', 100007, 20000, 'Chennai'),
    (100003, 'Mohan', 102, 10, '1980-03-23', '2002-01-19', 100006, 24000, 'Mumbai'),
    (100004, 'Anil', 102, 20, '1977-04-22', '2001-03-11', 100006, 20000, 'Hyderabad'),
    (100005, 'John', 106, 10, '1976-05-22', '2001-01-21', 100007, 32000, 'Bangalore'),
    (100006, 'Allen', 103, 30, '1980-01-22', '2001-04-23', 100005, 42000, 'Chennai'),
    (100007, 'Smith', 103, 20, '1973-07-19', '2002-03-12', 100005, 62000, 'Mumbai'),
    (100008, 'Raviraj', 102, 40, '1980-06-17', '2003-01-11', 100006, 18000, 'Bangalore'),
    (100009, 'Rahul', 102, 20, '1978-01-16', '2003-12-11', 100006, 22000, 'Hyderabad'),
    (100010, 'Ram', 103, 30, '1979-01-17', '2002-01-17', 100007, 32000, 'Bangalore');

--Book Masters
IF OBJECT_ID('BOOK_MASTERS', 'U') IS NOT NULL
    DROP TABLE BOOK_MASTERS;
CREATE TABLE BOOK_MASTERS (
    Book_code INT PRIMARY KEY,
    Book_name VARCHAR(50) NOT NULL,
    Book_pub_year INT,
    Book_pub_author VARCHAR(50) NOT NULL
);

INSERT INTO BOOK_MASTERS VALUES
    (10000001, 'Let Us C++', 2000, 'Yashavant Kanetkar'),
    (10000002, 'Mastersing VC++', 2005, 'P.J Allen'),
    (10000003, 'JAVA Complete Reference', 2004, 'H.Schild'),
    (10000004, 'J2EE Complete Reference', 2000, 'H. Schild'),
    (10000005, 'Relational DBMS', 2000, 'B.C. Desai'),
    (10000006, 'Let Us C', 2000, 'Yashavant Kanetkar'),
    (10000007, 'Intoduction To Algorithams', 2001, 'Cormen'),
    (10000008, 'Computer Networks', 2000, 'Tanenbaum'),
    (10000009, 'Introduction to O/S', 2001, 'Millan');

--Book Transactions
IF OBJECT_ID('BOOK_TRANSACTIONS', 'U') IS NOT NULL
    DROP TABLE BOOK_TRANSACTIONS;
CREATE TABLE BOOK_TRANSACTIONS (
    Book_code INT REFERENCES BOOK_MASTERS(Book_code),
    Student_code INT REFERENCES STUDENT_MASTERS(Student_Code),
    Staff_code INT REFERENCES STAFF_MASTERS(Staff_Code),
    Book_issue_Date DATE NOT NULL,
    Book_expected_return_date DATE NOT NULL,
    Book_actual_return_date DATE
);

INSERT INTO BOOK_TRANSACTIONS VALUES
    (10000006, 1012, NULL, '2011-02-02', '2011-02-09', NULL),
    (10000008, NULL, 100006, '2011-03-10', '2011-03-17', '2011-03-15'),
    (10000009, NULL, 100010, '2011-04-01', '2011-04-08', '2011-04-10'),
    (10000004, 1015, NULL, '2011-02-12', '2011-02-19', NULL),
    (10000005, NULL, 100007, '2011-03-14', '2011-03-21', '2011-03-21'),
    (10000007, NULL, 100007, '2010-04-01', '2010-04-07', '2010-04-06'),
    (10000007, NULL, 100006, '2010-04-01', '2010-04-07', '2010-04-06'),
    (10000005, 1009, NULL, '2011-05-31', '2011-06-08', '2011-06-08');

-- 1. Retrieve the details (Name, Salary and dept code) of the staff who are working in department code 20, 30 and 40.
SELECT Staff_Name AS Name, Staff_Sal AS Salary, Dept_Code
FROM STAFF_MASTERS
WHERE Dept_Code IN (20, 30, 40);

-- 2. Display the code and total marks for every student. Total Marks will be calculated as subject1+subject2+subject3 .(Refer Student_marks table )
SELECT Student_Code AS Code, Subject1 + Subject2 + Subject3 AS Total_Marks
FROM STUDENT_MARKS;

-- 3. List the Name and Designation code of the staff who have joined before Jan 2003 and whose salary range is between 12000 and 25000. Display the columns with user defined Column headers. Hint: Use As clause along with other operators
SELECT Staff_Name AS Name, Design_Code AS Designation_Code
FROM STAFF_MASTERS
WHERE Hiredate < '2003-01-01' AND Staff_Sal BETWEEN 12000 AND 25000;

-- 4. List the code, name, and department number of the staff who have experience of 18 or more years and sort them based on their experience.  
SELECT Staff_Code AS Code, Staff_Name AS Name, Dept_Code
FROM STAFF_MASTERS
WHERE DATEDIFF(YEAR, Hiredate, GETDATE()) >= 18
ORDER BY DATEDIFF(YEAR, Hiredate, GETDATE());

-- 5. List the name, designation code, and salary for 10 years of the staff who are working in departments 10 and 30.  
SELECT Staff_Name AS Name, Design_Code AS Designation_Code, Staff_Sal AS Salary
FROM STAFF_MASTERS
WHERE Dept_Code IN (10, 30) AND DATEDIFF(YEAR, Hiredate, GETDATE()) >= 10;

-- 6. Display name concatenated with dept code separated by comma and space. Name the column as ‘Student Info’.
SELECT CONCAT(Staff_Name, ', ', Dept_Code) AS 'Student Info'
FROM STAFF_MASTERS;

-- 7. Display the staff details who do not have manager. Hint: Use is null  
SELECT *
FROM STAFF_MASTERS
WHERE Mgr_code IS NULL;

-- 8. Write a query which will display name, department code and date of birth of all students who were born between January 1, 1981 and March 31, 1983. Sort it based on date of birth (ascending).Hint: Use between operator
SELECT Student_Name AS Name, Dept_Code, Student_Dob AS Date_of_Birth
FROM STUDENT_MASTERS
WHERE Student_Dob BETWEEN '1981-01-01' AND '1983-03-31'
ORDER BY Student_Dob ASC;

-- 9. Display the Book details that were published during the period of 2001 to 2004. Also display book details with Book name having the character ‘&’ anywhere.
SELECT *
FROM BOOK_MASTERS
WHERE (Book_pub_year BETWEEN 2001 AND 2004) OR (Book_name LIKE '%&%');

-- 10. Display the Book details where the records have the word “COMP” anywhere in the Book name.
SELECT *
FROM BOOK_MASTERS
WHERE Book_name LIKE '%COMP%';

-- 11. List the details of the staff, whose names start with ‘A’ and end with ‘S’ or whose names contains N as the second or third character, and ending with either ‘N’ or ‘S’.
SELECT *
FROM STAFF_MASTERS
WHERE (Staff_Name LIKE 'A%S' OR Staff_Name LIKE '_N%' OR Staff_Name LIKE '__N%' OR Staff_Name LIKE '%N' OR Staff_Name LIKE '%N%');

-- 12. List the names of the staff having ‘_’ character in their name.
SELECT Staff_Name
FROM STAFF_MASTERS
WHERE Staff_Name LIKE '%_%';

--JOINS
-- 1. Write a query which displays Staff Name, Department Code, Department Name, and Salary for all staff who earns more than 20000.
SELECT sm.Staff_Name, sm.Dept_Code, dm.Dept_Name, sm.Staff_Sal
FROM STAFF_MASTERS sm
JOIN DEPARTMENT_MASTERS dm ON sm.Dept_Code = dm.Dept_code
WHERE sm.Staff_Sal > 20000;

-- 2. Display Staff Code, Staff Name, Department Name, and his manager’s number and name. Label the columns Staff#, Staff, Mgr#, Manager.  
SELECT sm1.Staff_Code AS 'Staff#', sm1.Staff_Name AS 'Staff', dm.Dept_Name AS 'Department Name', 
       sm2.Staff_Code AS 'Mgr#', sm2.Staff_Name AS 'Manager'
FROM STAFF_MASTERS sm1
JOIN DEPARTMENT_MASTERS dm ON sm1.Dept_Code = dm.Dept_code
LEFT JOIN STAFF_MASTERS sm2 ON sm1.Mgr_code = sm2.Staff_Code;

-- 3. Create a query that will display Student Code, Student Name, Department Name, Subject1, Subject2, and Subject3 for all students who are getting 60 and above in each subject from department 10 and 20.
SELECT sm.Student_Code, sm.Student_Name, dm.Dept_Name, 
       smk.Subject1, smk.Subject2, smk.Subject3
FROM STUDENT_MASTERS sm
JOIN DEPARTMENT_MASTERS dm ON sm.Dept_Code = dm.Dept_code
JOIN STUDENT_MARKS smk ON sm.Student_Code = smk.Student_Code
WHERE dm.Dept_Code IN (10, 20)
AND smk.Subject1 >= 60 AND smk.Subject2 >= 60 AND smk.Subject3 >= 60;

-- 4. Create a query that will display Student Code, Student Name, Book Code, and Book Name for all students whose expected book return date is today.
SELECT bt.Student_code, sm.Student_Name, bt.Book_code, bm.Book_name
FROM BOOK_TRANSACTIONS bt
JOIN STUDENT_MASTERS sm ON bt.Student_code = sm.Student_Code
JOIN BOOK_MASTERS bm ON bt.Book_code = bm.Book_code


-- 5. Create a query that will display Staff Code, Staff Name, Department Name, Designation name, Book Code, Book Name, and Issue Date. For only those staff who have taken any book in last 30 days.
SELECT sm.Staff_Code, sm.Staff_Name, dm.Dept_Name, dm.Dept_code,
       bt.Book_code, bm.Book_name, bt.Book_issue_Date
FROM STAFF_MASTERS sm
JOIN DEPARTMENT_MASTERS dm ON sm.Dept_Code = dm.Dept_code
JOIN BOOK_TRANSACTIONS bt ON sm.Staff_Code = bt.Staff_code
JOIN BOOK_MASTERS bm ON bt.Book_code = bm.Book_code


-- 1. Create the Customer table with the following columns.
CREATE TABLE Customer (
    CustomerId INT,
    CustomerName VARCHAR(20),
    Address1 VARCHAR(30),
    Address2 VARCHAR(30)
);

-- 2. Modify the Customer table CustomerName column of datatype with Varchar2(30), rename the column to CustomerName and it should not accept Nulls.
ALTER TABLE Customer
ALTER COLUMN CustomerName VARCHAR(30) NOT NULL;

-- 3. a) Add the following Columns to the Customer table.
ALTER TABLE Customer
ADD 
    Gender NVARCHAR(10),
    Age INT,
    PhoneNo BIGINT
;

-- 3. b) Rename the Customer table to Cust_Table
EXEC sp_rename 'Customer', 'Cust_Table';

-- Insert rows with the following data into the Customer table.
INSERT INTO Cust_Table (CustomerId, CustomerName, Address1, Address2, Gender, Age, PhoneNo)
VALUES (1000, 'Allen', '#115 Chicago', '#115 Chicago', 'M', 25, 7878776);

INSERT INTO Cust_Table (CustomerId, CustomerName, Address1, Address2, Gender, Age, PhoneNo)
VALUES (1001, 'George', '#116 France', '#116 France', 'M', 25, 434524);

INSERT INTO Cust_Table (CustomerId, CustomerName, Address1, Address2, Gender, Age, PhoneNo)
VALUES (1002, 'Becker', '#114 New York', '#114 New York', 'M', 45, 431525);

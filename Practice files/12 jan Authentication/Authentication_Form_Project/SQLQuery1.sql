create database Authentication_MVC;

-- Employee table
create table Employee
(
Id int primary key identity(1,1),
Name varchar(50),
Desiganation varchar(50),
Salary int
);

-- user table
create table Users
(
U_ID int primary key identity(1,1),
UserName varchar(50),
Userpassword varchar(50)
);

--Role master
create table RoleMaster
(
RID int primary key identity(1,1),
RoleName varchar(50)
);

--map users to roles

create table UserRoleMapping
(
URM int primary key,
UserID int references Users(U_ID),
RoleID int references RoleMaster(RID)
);

select * from employee;
select * from users;
select * from RoleMaster;
select * from UserRoleMapping;

insert into Employee values('pooja','Tester',34000),
('Komal','HR',25000),
('Shobha','Manager',45000),
('pooja','Software',56000);

insert into RoleMaster values('Admin'),('User'),('Customer');

insert into UserRoleMapping values
(100,1,2),
(101,1,3),
(102,2,1),
(103,2,2),
(104,2,3),
(105,3,3)
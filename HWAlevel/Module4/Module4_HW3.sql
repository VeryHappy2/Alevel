use AdventureWorks2019;

select * from Sales.Customer;

select * from Sales.Store 
	order by [name], rowguid, ModifiedDate;

 select * from HumanResources.Employee
	where BirthDate > '1989-09-28';

select JobTitle, LoginID, NationalIDNumber from HumanResources.Employee
	where LoginID like '%0'
	order by JobTitle, NationalIDNumber;

select ModifiedDate, MiddleName, Title from Person.Person
	where year(ModifiedDate) = 2008
	and ModifiedDate is not null
	and Title is null;

select distinct humdep.Name as DepartmentName
	from HumanResources.EmployeeDepartmentHistory HumanEdh
	join HumanResources.Department humdep on HumanEdh.DepartmentID = humdep.DepartmentID;

select TerritoryID, CommissionPct, SalesYTD, Bonus, SalesQuota, ModifiedDate, rowguid, SalesLastYear  from Sales.SalesPerson
	where CommissionPct > 0
	order by TerritoryID, SalesYTD, Bonus, SalesQuota, ModifiedDate, rowguid, SalesLastYear;

select MAX(VacationHours) from HumanResources.Employee HumEmp

select * from HumanResources.Employee HumE
	where JobTitle = 'Sales Representative' 
		or JobTitle =  'Network Administrator'
		or JobTitle =  'Network Manager'


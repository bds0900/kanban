USE [Kanban]
GO


--vRandNumber view and RandNumber are needed for user defined function
CREATE VIEW vRandNumber
AS
SELECT RAND() as RandNumber
go
CREATE FUNCTION RandNumber()
RETURNS float
AS
  BEGIN
  RETURN (SELECT RandNumber FROM vRandNumber)
  END
go


create procedure CheckDefect
@defectRate int,
@testTrayID int
as
begin
declare @remainder float
declare @i int
set @i=1;
while(@i<61)
begin
	set @remainder =floor(dbo.RandNumber()*(@defectRate-1+1))+1
	if(1=@remainder)
	update Trays set TestStatus=0 where UnitNumber=@i and TestTrayID=@testTrayID
	else
	update Trays set TestStatus=1 where UnitNumber=@i and TestTrayID=@testTrayID
	set @i=@i+1
end
end
Go


--this function return work speed
create function WorkSpeeds (@StationID  int)
returns float
as
begin
--random number
declare @ran_num float
set @ran_num=(floor(dbo.RandNumber()*(10-1+1))+1)/100
-- determine + or -
declare @plus_minus int
set @plus_minus=(floor(dbo.RandNumber()*(2-1+1))+1)
-- result
declare @result float

if(@plus_minus=1)
	set @result=(select Speed+Speed*@ran_num from EmployeeSkill inner join Employee on EmployeeSkill.Type=Employee.Type
	inner join Station on Station.EmployeeID=Employee.EmployeeID where Station.StationID=@StationID)

else 
	set @result=(select Speed-Speed*@ran_num from EmployeeSkill inner join Employee on EmployeeSkill.Type=Employee.Type
	inner join Station on Station.EmployeeID=Employee.EmployeeID where Station.StationID=@StationID)
	return @result
end
go


-- Add a worker to the list
create procedure Hire
@type  varchar(10)
as
begin
declare @employeeID int
insert into Employee(Type,Active) values(@type,0)
set @employeeID=(select top 1 EmployeeID from Employee order by EmployeeID desc)
return @employeeID
end
go


create procedure SetStation
as
begin
declare @stationID int
declare @binID int
declare @testTrayID int
insert into Station (TotalLamp,LampCount,Active) values (0,0,0)
--get stationID
set @stationID=(select top 1 StationID from Station order by StationID desc)
--fill the bins with parts
insert into Bin (PartID,Quantities) select PartID,Capacity from Parts;
--assign the bins to station
insert into StationBin (StationID,BinID) select top 6 @stationID,BinID from Bin order by BinID desc
--get test tray
insert into TestTray (TestUnitNumber) values (0)
set @testTrayID=(select top 1 TestTrayID from TestTray order by TestTrayID desc)
--assign the test tray to station
insert into StationTestTray (StationID,TestTrayID) values(@stationID,@testTrayID)
end
go


create procedure WorkStation
@stationID int,
@employeeID int
as
begin
declare @speed int
declare @delay datetime
declare @lampCount int
declare @xxxxxx varchar(6)
declare @yy varchar(2)
declare @unitNum varchar(10)
declare @testTrayID int
declare @defectRate int
declare @unitNumber int
set @delay=dateadd(second,@speed,0)
--if there is a bin is empty, stop working..
	if(0=(select distinct Quantities from CommonTray where StationID=@stationID and Quantities=0))
	goto error_label
Begin tran
	-- consume one parts 
	update Bin set Quantities= Quantities-1 from Bin inner join StationBin on Bin.BinID=StationBin.BinID inner join Station on Station.StationID=StationBin.StationID where Station.StationID=@stationID
	if @@error<>0
	begin
		rollback tran
		goto error_label
	end
	-- use stationID look up assigned test tray ID
	set @xxxxxx= (select TestTray.TestTrayID from TestTray inner join StationTestTray on StationTestTray.TestTrayID=TestTray.TestTrayID inner join Station on Station.StationID=StationTestTray.StationID where Station.StationID=@stationID)
	set @yy = (select TestTray.TestUnitNumber+1 from TestTray inner join StationTestTray on StationTestTray.TestTrayID=TestTray.TestTrayID inner join Station on Station.StationID=StationTestTray.StationID where Station.StationID=@stationID)
	set @unitNum='LX'+right('000000' + convert(varchar(6),@xxxxxx), 6) + right('00' + convert(varchar(2),@yy), 2)
	select @unitNumber=TestUnitNumber+1 from TestTray inner join StationTestTray on StationTestTray.TestTrayID=TestTray.TestTrayID  inner join Station on Station.StationID=StationTestTray.StationID where Station.StationID=@stationID
	-- produce a product, put it in a tray
	insert into Trays (TestTrayID,TrayID,UnitNumber) values (@xxxxxx,@unitNum,@unitNumber)
	-- update the unit number in test tray
	update TestTray set TestUnitNumber=@unitNumber from TestTray inner join StationTestTray on StationTestTray.TestTrayID=TestTray.TestTrayID  inner join Station on Station.StationID=StationTestTray.StationID where Station.StationID=@stationID
		if @@error<>0
		begin
			rollback tran
			goto error_label
		end
	-- update total lamp number
	update Station set TotalLamp=TotalLamp+1 where StationID=@stationID
		if @@error<>0
		begin
			rollback tran
			goto error_label
		end
	update Station set LampCount+=1 where StationID=@stationID
		if @@error<>0
		begin
			rollback tran
			goto error_label
		end
	set @lampCount=(select LampCount from Station where StationID=@stationID)
	--select ConfigValue from Configuration where CpmfigID=
	if(@lampCount=60)
	begin
	--check defect rate
	select @defectRate=EmployeeSkill.DefectRate from EmployeeSkill inner join Employee on Employee.Type=EmployeeSkill.Type where Employee.EmployeeID=@employeeID
	set @testTrayID=(select TestTrayID from StationTestTray where StationID=@stationID)
	exec CheckDefect @defectRate, @testTrayID
	update Station set LampCount=0 where StationID=@stationID
		if @@error<>0
		begin
			rollback tran
			goto error_label
		end
	-- if test tray is full, assign a new test tray on station
	if(60=(select TestTray.TestUnitNumber from TestTray inner join StationTestTray on StationTestTray.TestTrayID=TestTray.TestTrayID inner join Station on Station.StationID=StationTestTray.StationID where Station.StationID=@stationID))
	begin
		--get test tray
		insert into TestTray (TestUnitNumber) values (0)
		set @testTrayID=(select top 1 TestTrayID from TestTray order by TestTrayID desc)
		--assign the test tray to station
		update StationTestTray set TestTrayID=@testTrayID where StationID=@stationID
		if @@error<>0
		begin
			rollback tran
			goto error_label
		end
	end
	end
commit tran
error_label:
	--update Station set Active=0 from Station where StationID=@stationID
	--update Employee set Active=0 from Employee inner join Station on Station.EmployeeID=Employee.EmployeeID where StationID=@stationID
end
Go


create procedure Configure
as
begin
declare @loopCount int
declare @i int
set @loopCount=(select ConfigValue from Configuration where ConfigID='Stations')
set @i=0
while(@i<@loopCount)
	begin
	exec SetStation 
	set @i+=1
	end
end
go


create procedure AddBin
as
begin
declare @howMany int
declare @stationID int
declare @count int 
declare @i int
set @i=0;
set @count=(select count(distinct StationID) from Cart )
while(@i<@count)
	begin
	set @stationID=(select distinct top 1 StationID from Cart)
	set @howMany=(select count(StationID) from Cart where StationID=@stationID )
	-- add new bins and and add items that left in the cart
	insert into Bin(PartID,Quantities) select Cart.PartID, Capacity+Cart.Quantities from Cart inner join Parts on Parts.PartID=Cart.PartID where StationID=@stationID
	-- clear the old bins
	update Bin set Quantities=0 from Bin inner join Cart on Cart.BinID=Bin.BinID where StationID=@stationID
	-- assign new bins to station
	insert into StationBin (StationID,BinID) select top (@howMany) @stationID,BinID from Bin order by BinID desc
	-- take out the old bins
	delete StationBin from StationBin inner join Bin on Bin.BinID=StationBin.BinID inner join Cart on Cart.BinID=Bin.BinID where Cart.StationID=@stationID
	-- cleart the cart
	delete from Cart where StationID=@stationID
	set @i+=1
	end
end
go



create procedure Runner
as
begin
--pick the kanban card from the common tray
insert into Cart select * from CommonTray
--fill the bins with parts
exec AddBin
end
go



create procedure ChangeEmployee
@employeeID int,
@stationID int
as
begin
declare @isActive bit
set @isActive=(select Active from Station where StationID=@stationID)
begin tran
--check the station is activated or deactivated
if(1=(select Active from Station where StationID=@stationID))
	begin
	--stop the station
	update Station set Active=0 from Station where StationID=@stationID
	if @@error<>0
	begin
		rollback tran
		goto error_label
	end
	end
--replace
update Station set EmployeeID=@employeeID where StationID=@stationID
	if @@error<>0
	begin
		rollback tran
		goto error_label
	end
commit tran
error_label:
end
go


create procedure Deactivate
@stationID int
as
begin
begin tran
update Station set Active=0 from Station where StationID=@stationID
	if @@error<>0
	begin
		rollback tran
		goto error_label
	end
update Employee set Employee.Active=0 from Employee inner join Station on Station.EmployeeID=Employee.EmployeeID where StationID=@stationID
	if @@error<>0
	begin
		rollback tran
		goto error_label
	end
commit tran
error_label:
end
go



create procedure Activate
@stationID int,
@employeeID int
as
begin
begin tran
update Station set EmployeeID=@employeeID from Station where StationID=@stationID
	if @@error<>0
	begin
		rollback tran
		goto error_label
	end
update Employee set Employee.Active=1 from Employee inner join Station on Station.EmployeeID=Employee.EmployeeID where StationID=@stationID
	if @@error<>0
	begin
		rollback tran
		goto error_label
	end
update Station set Active=1 from Station where StationID=@stationID
	if @@error<>0
	begin
		rollback tran
		goto error_label
	end
commit tran
error_label:
end
go

/*1 ������ � ������ ������ Date, NULL ����������, ����������� ������. ����������� ������������ 
�������� � ����������� ������� � ����������� �� ���������� �������������� �������� ���������� �������. 
�������� � ����������� ������� ������ ������������ �������. 

1.1 ������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (������� ShippedDate) 
������������ � ������� ���������� � ShipVia >= 2. ������ �������� ���� ������ ���� ������ ��� 
����� ������������ ����������, �������� ����������� ������ �Writing International Transact-SQL Statements� 
� Books Online ������ �Accessing and Changing Relational Data Overview�. ���� ����� ������������ ����� ��� 
���� �������. ������ ������ ����������� ������ ������� OrderID, ShippedDate � ShipVia.  
�������� ������ ���� �� ������ ������ � NULL-�� � ������� ShippedDate. */
SELECT  OrderID, ShippedDate, ShipVia 
  FROM Northwind.Orders
  WHERE ShippedDate >= {d'1998-05-06'} 
    AND ShipVia >= 2;

/*1.2 �������� ������, ������� ������� ������ �������������� ������ �� ������� Orders.
 � ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL 
 ������ �Not Shipped� � ������������ ��������� ������� CAS�. 
 ������ ������ ����������� ������ ������� OrderID � ShippedDate. */

 SELECT OrderID, ShippedDate = CASE
	   WHEN ShippedDate IS  NULL THEN 'Not Shipped'
   END
   FROM Northwind.Orders
   WHERE ShippedDate IS NULL

 /*1.3 ������� � ������� Orders ������, ������� ���� ���������� ����� 6 ��� 1998 ���� (ShippedDate)
  �� ������� ��� ���� ��� ������� ��� �� ����������. � ������� ������ ������������� ������ ������� 
  OrderID (������������� � Order Number) � ShippedDate (������������� � Shipped Date). 
  � ����������� ������� ����������� ��� ������� ShippedDate ������ �������� NULL ������ �Not Shipped�,
   ��� ��������� �������� ����������� ���� � ������� �� ���������. */

   SELECT OrderID as 'Order Number', 'Shipped Date' = CASE
	   WHEN ShippedDate IS  NULL THEN 'Not Shipped'
	   ELSE CONVERT(nvarchar(30), ShippedDate, 102)
   END 
   FROM Northwind.Orders
   WHERE ShippedDate > {d'1998-03-06'} OR ShippedDate IS NULL ;



   /*2 ������������� ���������� IN, DISTINCT, ORDER BY, NOT 

   2.1 ������� �� ������� Customers 
   ���� ����������, ����������� � USA � Canada. ������ ������� � ������ ������� ��������� IN. 
   ����������� ������� � ������ ������������ � ��������� ������ � ����������� �������. 
   ����������� ���������� ������� �� ����� ���������� � �� ����� ����������. */
   SELECT ContactName, Country
   FROM Northwind.Customers
   WHERE Country IN ('USA','Canada')
   ORDER BY ContactName,Address;

   /*2.2 ������� �� ������� Customers ���� ����������, �� ����������� � USA � Canada. 
   ������ ������� � ������� ��������� IN. ����������� ������� � ������ ������������ � ��������� 
   ������ � ����������� �������. ����������� ���������� ������� �� ����� ����������.*/

   SELECT ContactName, Country
   FROM Northwind.Customers
   WHERE Country NOT IN ('USA','Canada')
   ORDER BY ContactName;
   

   /*2.3 ������� �� ������� Customers ��� ������, � ������� ��������� ���������. 
   ������ ������ ���� ��������� ������ ���� ��� � ������ ������������ �� ��������. 
   �� ������������ ����������� GROUP BY. ����������� ������ ���� ������� � ����������� �������. */

   SELECT DISTINCT Country
   FROM Northwind.Customers
   ORDER BY Country DESC;


   /*3 ������������� ��������� BETWEEN, DISTINCT 

   3.1 ������� ��� ������ (OrderID) �� ������� Order Details (������ �� ������ �����������),
    ��� ����������� �������� � ����������� �� 3 �� 10 ������������ � ��� ������� Quantity � �������
	 Order Details. ������������ �������� BETWEEN. ������ ������ ����������� ������ ������� OrderID. */

	 SELECT DISTINCT OrderID
	 FROM Northwind.[Order Details] 
	 WHERE Quantity BETWEEN 3 AND 10;

	/*3.2 ������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� ��
	 ����� �� ��������� b � g. ������������ �������� BETWEEN. 
	 ���������, ��� � ���������� ������� �������� Germany. 
	 ������ ������ ����������� ������ ������� CustomerID � Country � ������������ �� Country. */

	 SELECT CustomerID, Country
	 FROM Northwind.Customers
	 WHERE Country BETWEEN 'b%' AND 'h%'
	 ORDER BY Country;

	 /*3.3 ������� ���� ���������� �� ������� Customers, � ������� �������� ������ ���������� �� �����
	  �� ��������� b � g, �� ��������� �������� BETWEEN. � ������� ����� �Execution Plan� ���������� 
	  ����� ������ ���������������� 3.2 ��� 3.3 � ��� ����� ���� ������ � ������ ���������� ���������� 
	  Execution Plan-a ��� ���� ���� ��������, ���������� ���������� Execution Plan ���� ������ � ������ � 
	  ���� ����������� � �� �� ����������� ���� ����� �� ������ � �� ������ ��������� ���� ��������� 
	  ���������. ������ ������ ����������� ������ ������� CustomerID � Country � ������������ �� Country.*/

	  SELECT CustomerID, Country
	  FROM Northwind.Customers
	  WHERE Country > 'b%' AND Country < 'h%'
	  ORDER BY Country;

	  /* 
	  ���� ���������� 3.2

	  <QueryPlan DegreeOfParallelism="0" NonParallelPlanReason="NoParallelPlansInDesktopOrExpressEdition" MemoryGrant="1024" CachedPlanSize="16" CompileTime="1" CompileCPU="1" CompileMemory="152">
      <MemoryGrantInfo SerialRequiredMemory="512" SerialDesiredMemory="544" RequiredMemory="512" DesiredMemory="544" RequestedMemory="1024" GrantWaitTime="0" GrantedMemory="1024" MaxUsedMemory="16" />
      <OptimizerHardwareDependentProperties EstimatedAvailableMemoryGrant="206217" EstimatedPagesCached="51554" EstimatedAvailableDegreeOfParallelism="2" />
      <RelOp AvgRowSize="32" EstimateCPU="0.00043212" EstimateIO="0.0112613" EstimateRebinds="0" EstimateRewinds="0" EstimatedExecutionMode="Row" EstimateRows="40" LogicalOp="Sort" NodeId="0" Parallel="false" PhysicalOp="Sort" EstimatedTotalSubtreeCost="0.016637">
	  <RelOp AvgRowSize="32" EstimateCPU="0.0002571" EstimateIO="0.00460648" EstimateRebinds="0" EstimateRewinds="0" EstimatedExecutionMode="Row" EstimateRows="40" LogicalOp="Clustered Index Scan" NodeId="1" Parallel="false" PhysicalOp="Clustered Index Scan" EstimatedTotalSubtreeCost="0.00486358" TableCardinality="91">


	  ���� ���������� 3.3
	  <QueryPlan DegreeOfParallelism="0" NonParallelPlanReason="NoParallelPlansInDesktopOrExpressEdition" MemoryGrant="1024" CachedPlanSize="16" CompileTime="1" CompileCPU="1" CompileMemory="152">
	 <MemoryGrantInfo SerialRequiredMemory="512" SerialDesiredMemory="544" RequiredMemory="512" DesiredMemory="544" RequestedMemory="1024" GrantWaitTime="0" GrantedMemory="1024" MaxUsedMemory="16" />
	 <OptimizerHardwareDependentProperties EstimatedAvailableMemoryGrant="206217" EstimatedPagesCached="51554" EstimatedAvailableDegreeOfParallelism="2" />
	 <RelOp AvgRowSize="32" EstimateCPU="0.00043212" EstimateIO="0.0112613" EstimateRebinds="0" EstimateRewinds="0" EstimatedExecutionMode="Row" EstimateRows="40" LogicalOp="Sort" NodeId="0" Parallel="false" PhysicalOp="Sort" EstimatedTotalSubtreeCost="0.016637">
	 <RelOp AvgRowSize="32" EstimateCPU="0.0002571" EstimateIO="0.00460648" EstimateRebinds="0" EstimateRewinds="0" EstimatedExecutionMode="Row" EstimateRows="40" LogicalOp="Clustered Index Scan" NodeId="1" Parallel="false" PhysicalOp="Clustered Index Scan" EstimatedTotalSubtreeCost="0.00486358" TableCardinality="91">


	 ������ ��������� �� ���� ����������
	  */

	  /*.4 ������������� ��������� LIKE

4.1 � ������� Products ����� ��� �������� (������� ProductName), ��� ����������� ��������� 'chocolade'. 
��������, ��� � ��������� 'chocolade' ����� ���� �������� ���� ����� 'c' � �������� - ����� ��� ��������,
 ������� ������������� ����� �������. ���������: ���������� ������� ������ ����������� 2 ������.*/

 SELECT ProductName 
 FROM Northwind.Products
 WHERE ProductName LIKE 'cho_olade' ;


 /*5 ������������� ���������� ������� (SUM, COUNT)

5.1 ����� ����� ����� ���� ������� �� ������� Order Details � ������ ���������� ����������� ������� � 
������ �� ���. ��������� ��������� �� ����� � ��������� � ����� 1 ��� ���� ������ money.
 ������ (������� Discount) ���������� ������� �� ��������� ��� ������� ������. 
 ��� ����������� �������������� ���� �� ��������� ������� ���� ������� ������ �� ��������� � ������� 
 UnitPrice ����. ����������� ������� ������ ���� ���� ������ � ����� �������� � ��������� ������� 'Totals'.*/

 SELECT CONVERT(MONEY,(SUM((UnitPrice  - Discount) * Quantity)),1) AS 'Totals'
 FROM Northwind.[Order Details];


 /*5.2 �� ������� Orders ����� ���������� �������, ������� ��� �� ���� ���������� 
 (�.�. � ������� ShippedDate ��� �������� ���� ��������). ������������ ��� ���� ������� ������ 
 �������� COUNT. �� ������������ ����������� WHERE � GROUP.*/

 SELECT COUNT(*) - COUNT(ShippedDate) AS 'The number of orders'
  FROM Northwind.Orders;

  /*5.3 �� ������� Orders ����� ���������� ��������� ����������� (CustomerID), 
  ��������� ������. ������������ ������� COUNT � �� ������������ ����������� WHERE � GROUP.*/

  SELECT COUNT(DISTINCT CustomerID) AS 'The number of Customers'
  FROM Northwind.Orders;


  /*6 ����� ���������� ������, ��������������, ������������� ���������� ������� � 
  ����������� GROUP BY � HAVING

	6.1 �� ������� Orders ����� ���������� ������� � ������������ �� �����. 
	� ����������� ������� ���� ����������� ��� ������� c ���������� Year � Total. 
	�������� ����������� ������, ������� ��������� ���������� ���� �������.*/

	SELECT DATEPART(yyyy,OrderDate) AS 'Year', COUNT( DATEPART(yyyy,OrderDate)) AS 'Total'
	FROM Northwind.Orders
	GROUP BY DATEPART(yyyy,OrderDate);

	SELECT COUNT(OrderID)
	FROM Northwind.Orders;
	--830


	/*6.2 �� ������� Orders ����� ���������� �������, c�������� ������ ���������. 
	����� ��� ���������� �������� � ��� ����� ������ � ������� Orders, ��� � ������� 
	EmployeeID ������ �������� ��� ������� ��������. � ����������� ������� ���� ����������� 
	������� � ������ �������� (������ ������������� ��� ���������� ������������� LastName & FirstName. 
	��� ������ LastName & FirstName ������ ���� �������� ��������� �������� � ������� ��������� �������. 
	����� �������� ������ ������ ������������ ����������� �� EmployeeID.) � ��������� ������� �Seller� 
	� ������� c ����������� ������� ����������� � ��������� 'Amount'. ���������� ������� ������ ���� 
	����������� �� �������� ���������� �������.*/

	SELECT (SELECT LastName + FirstName
	  FROM Northwind.Employees
	  WHERE Employees.EmployeeID = Orders.EmployeeID) AS 'Seller',
	  COUNT(CustomerID) AS  'Amount'
	FROM Northwind.Orders
	GROUP BY EmployeeID
	ORDER BY 'Amount' DESC;

	/*6.3 �� ������� Orders ����� ���������� �������, c�������� ������ ��������� � ��� ������� 
	����������. ���������� ���������� ��� ������ ��� ������� ��������� � 1998 ����. 
	� ����������� ������� ���� ����������� ������� � ������ �������� (�������� ������� �Seller�), 
	������� � ������ ���������� (�������� ������� �Customer�) � ������� c ����������� ������� 
	����������� � ��������� 'Amount'. � ������� ���������� ������������ ����������� �������� ����� 
	T-SQL ��� ������ � ���������� GROUP (���� �� �������� ������� �������� ������ �ALL� � �����������
	 �������). ����������� ������ ���� ������� �� ID �������� � ����������. ���������� ������� ������ 
	 ���� ����������� �� ��������, ���������� � �� �������� ���������� ������. � ����������� ������ 
	 ���� ������� ���������� �� ��������. �.�. � ������������� ������ ������ �������������� 
	 ������������� � ���������� � �������� �������� ��� ������� ���������� ��������� �������:*/

	 SELECT CASE
	      WHEN GROUPING(CustomerID) = 1 THEN N'ALL'
		  ELSE (
                   SELECT ContactName
		           FROM Northwind.Customers as C 
		           WHERE O.CustomerID = C.CustomerID
		        )
		END AS Customer, 
		CASE 
		   WHEN GROUPING(EmployeeID) = 1 THEN N'ALL'
		   ELSE (
		           SELECT FirstName+' '+LastName
		           FROM Northwind.Employees as E 
		           WHERE O.EmployeeID = E.EmployeeID
		         ) 
		  END AS Seller, 
		  COUNT(*) AS Amount
	FROM Northwind.Orders AS O
	WHERE YEAR(OrderDate) = 1998
	GROUP BY CUBE(CustomerID, EmployeeID)
	ORDER BY Seller, Customer, Amount DESC;


 /*6.4 ����� ����������� � ���������, ������� ����� � ����� ������. 
 ���� � ������ ����� ������ ���� ��� ��������� ��������� ��� ������ ���� ��� ��������� �����������,
  �� ���������� � ����� ���������� � ��������� �� ������ �������� � �������������� �����. 
  �� ������������ ����������� JOIN. � ����������� ������� ���������� ������� ��������� ��������� 
  ��� ����������� �������: �Person�, �Type� (����� ���� �������� ������ �Customer� ��� �Seller� 
  � ��������� �� ���� ������), �City�. ������������� ���������� ������� �� ������� �City� � �� �Person�.*/

	 (SELECT Customers.ContactName AS Person, 'Customer' AS Type,Customers.City AS City
	FROM Northwind.Customers
	WHERE EXISTS 
		(SELECT Employees.City 
		 FROM Northwind.Employees
		 WHERE Employees.City=Customers.City)
	)
	UNION ALL
	(SELECT FirstName+' '+LastName AS Person, 'Seller' AS Type,City AS City
	FROM Northwind.Employees 
	WHERE EXISTS 
		(SELECT City 
		 FROM Northwind.Customers 
		 WHERE Employees.City=Customers.City)
	)             
	Order by City,Person


	/*6.5 ����� ���� �����������, ������� ����� � ����� ������. � ������� ������������ ���������� 
	������� Customers c ����� - ��������������. ��������� ������� CustomerID � City. 
	������ �� ������ ����������� ����������� ������. ��� �������� �������� ������, ������� ����������� 
	������, ������� ����������� ����� ������ ���� � ������� Customers. ��� �������� ��������� ������������ 
	�������.*/

	SELECT DISTINCT C1.CustomerID, C2.City
	FROM Northwind.Customers C1 JOIN Northwind.Customers C2 
		ON C1.CustomerID != C2.CustomerID
	WHERE (C1.City = C2.City) and (C1.CustomerID <> C2.CustomerID);

	Select COUNT(*) as 'QUANTITY', City
	From Northwind.Customers
	Group by City
	Having COUNT(*) > 1

	/*6.6 �� ������� Employees ����� ��� ������� �������� ��� ������������, 
	�.�. ���� �� ������ �������. ��������� ������� � ������� 'User Name' (LastName) � 'Boss'. 
	� �������� ������ ���� ��������� ����� �� ������� LastName. 
	��������� �� ��� �������� � ���� �������? */

	SELECT E1.LastName AS 'User Name', E2.LastName AS 'Boss'
	FROM Northwind.Employees E1 join Northwind.Employees E2
	ON E1.ReportsTo = E2.EmployeeID;

	--��������, ������� � ������� ReportsTo ����� �������� NULL, �.�. ���� �������� �������, �� ������ � ������

	/*7 ������������� Inner JOIN
	7.1 ���������� ���������, ������� ����������� ������ 'Western' (������� Region).
	 ���������� ������� ������ ����������� ��� ����: 'LastName' �������� � �������� 
	 ������������� ���������� ('TerritoryDescription' �� ������� Territories). 
	 ������ ������ ������������ JOIN � ����������� FROM. ��� ����������� ������ ����� ��������� 
	 Employees � Territories ���� ������������ ����������� ��������� ��� ���� Northwind.*/

	 SELECT Employees.LastName, Territories.TerritoryDescription 
	 FROM (Northwind.Territories 
	 JOIN Northwind.EmployeeTerritories 
		ON (Territories.TerritoryID = EmployeeTerritories.TerritoryID)) 
	 JOIN Northwind.Employees
		ON (EmployeeTerritories.EmployeeID = Employees.EmployeeID)
	 JOIN Northwind.Region 
		ON Territories.RegionID  = Region.RegionID
	 WHERE RegionDescription = 'Western';
	 

	 /*8 ������������� Outer JOIN
	 8.1 ��������� � ����������� ������� ����� ���� ���������� �� ������� Customers � ��������� 
	 ���������� �� ������� �� ������� Orders. ������� �� ��������, ��� � ��������� ���������� ��� 
	 �������, �� ��� ����� ������ ���� �������� � ����������� �������. ����������� ���������� ������� 
	 �� ����������� ���������� �������.*/

	 SELECT Customers.ContactName, COUNT(Orders.CustomerID)  AS 'QUNTITY'
	 FROM Northwind.Customers LEFT JOIN Northwind.Orders
	 ON Customers.CustomerID = Orders.CustomerID
	 GROUP BY Customers.ContactName
	 ORDER BY QUNTITY;

	 /*9 ������������� �����������
	  9.1 ��������� ���� ����������� ������� CompanyName � ������� Suppliers, � ������� ��� ����
	   �� ������ �������� �� ������ (UnitsInStock � ������� Products ����� 0). ������������ ��������� 
	   SELECT ��� ����� ������� � �������������� ��������� IN. ����� �� ������������ ������ 
	   ��������� IN �������� '=' ? */
     
	 --������ ������������ =, �.�. = ���������� ������ � ������������ ���������, � �� � �������
	          
	 SELECT CompanyName,SupplierID
	 FROM Northwind.Suppliers
	 WHERE Suppliers.SupplierID IN 
			(SELECT SupplierID 
			 FROM Northwind.Products
			 WHERE UnitsInStock = 0);

	


	/*10 ��������������� ������
	 10.1 ��������� ���� ���������, ������� ����� ����� 150 �������. ������������ ��������� 
	 ��������������� SELECT.*/

	 SELECT EmployeeID, FirstName, LastName
	 FROM Northwind.Employees
	 WHERE (SELECT Count(EmployeeID)
			FROM Northwind.Orders
			WHERE Employees.EmployeeID = Orders.EmployeeID
			GROUP BY EmployeeID) > 150;


	/*11 ������������� EXISTS
	11.1 ��������� ���� ���������� (������� Customers), ������� �� ����� �� ������ ������ 
	(��������� �� ������� Orders). ������������ ��������������� SELECT � �������� EXISTS.*/

	SELECT CustomerID,ContactName
	FROM Northwind.Customers
	WHERE NOT EXISTS(SELECT CustomerID 
					 FROM Northwind.Orders
					 WHERE Customers.CustomerID = Orders.CustomerID);

	/*12 ������������� ��������� �������
	12.1 ��� ������������ ����������� ��������� Employees ��������� �� ������� Employees ������ 
	������ ��� ���� ��������, � ������� ���������� ������� Employees (������� LastName ) �� ����.
	���������� ������ ������ ���� ������������ �� �����������.*/

	 Select DISTINCT (Left (LastName,1)) as 'POINTERS'
	 From Northwind.Employees
	 Order by POINTERS

	 /*13 ���������� ������� � ��������
	13.1 �������� ���������, ������� ���������� ����� ������� ����� ��� ������� �� ��������� �� 
	������������ ���. � ����������� �� ����� ���� ��������� ������� ������ ��������, ������ ���� 
	������ ���� � ����� �������. � ����������� ������� ������ ���� �������� ��������� �������: ������� 
	� ������ � �������� �������� (FirstName � LastName � ������: Nancy Davolio), ����� ������ � ��� 
	���������. � ������� ���� ��������� Discount ��� ������� �������. ��������� ���������� ���, �� 
	������� ���� ������� �����, � ���������� ������������ �������. ���������� ������� ������ ���� 
	����������� �� �������� ����� ������. ��������� ������ ���� ����������� � �������������� ��������� 
	SELECT � ��� ������������� ��������. �������� ������� �������������� GreatestOrders. ���������� 
	������������������ ������������� ���� ��������. ����� ������ ������������ ������� �������� � 
	������� Query.sql ���� �������� ��������� �������������� ����������� ������ ��� ������������ 
	������������ ������ ��������� GreatestOrders. ����������� ������ ������ �������� � ������� ��� 
	��������� � ������������ ������ �������� ���� ��� ������������� �������� ��� ���� ��� ������� �� 
	������������ ��������� ��� � ����������� ��������� �������: ��� ��������, ����� ������, ����� 
	������. ����������� ������ �� ������ ��������� ������, ���������� � ���������, - �� ������ ���������
	������ ��, ��� ������� � ����������� �� ����. ��� ������� �� ������ �������� ������ ���� �������� 
	� ����� Query.sql � ��. ��������� ���� � ������� ����������� � �����������. */

	EXEC Northwind.GreatestOrders @Year = 1996, @countRecords = 10


	
	SELECT TOP(1)  employees.FirstName + ' ' + employees.LastName AS Name
			,orderDetails.OrderID AS OrderID
			,(orderDetails.UnitPrice * (1 - orderDetails.Discount) * orderDetails.Quantity) AS Price
	FROM Northwind.Employees employees
	JOIN Northwind.Orders orders
	  ON  orders.EmployeeID = employees.EmployeeID
		  AND YEAR('1996') = YEAR(orders.OrderDate)
	JOIN Northwind.[Order Details] orderDetails
	  ON orderDetails.OrderID = orders.OrderID
	WHERE  employees.EmployeeID = 4
	ORDER BY  Price DESC

	/*13.2 �������� ���������, ������� ���������� ������ � ������� Orders, �������� ���������� ����� �������� � 
	���� (������� ����� OrderDate � ShippedDate). � ����������� ������ ���� ���������� ������, ���� ������� 
	��������� ���������� �������� ��� ��� �������������� ������. �������� �� ��������� ��� ������������� ����� 
	35 ����. �������� ��������� ShippedOrdersDiff. ��������� ������ ����������� ��������� �������: OrderID,
	 OrderDate, ShippedDate, ShippedDelay (�������� � ���� ����� ShippedDate � OrderDate), SpecifiedDelay 
	 (���������� � ��������� ��������).*/

	 EXEC Northwind.ShippedOrdersDiff @SpecifiedDelay = 15;

	 /*13.3 �������� ���������, ������� ����������� ���� ����������� ��������� ��������, ��� ����������������, ��� � 
	����������� ��� �����������. � �������� �������� ��������� ������� ������������ EmployeeID. ���������� 
	����������� ����� ����������� � ��������� �� � ������ (������������ �������� PRINT) �������� �������� 
	����������. ��������, ��� �������� ���� ����� ����������� ����� ������ ���� ��������. �������� ��������� 
	SubordinationInfo. � �������� ��������� ��� ������� ���� ������ ���� ������������ ������, ����������� � Books
	Online � ��������������� Microsoft ��� ������� ��������� ���� �����. ������������������ ������������� ���������.*/

	EXEC Northwind.SubordinationInfo @EmployeeID = 4;

	/*13.4 �������� �������, ������� ����������, ���� �� � �������� �����������. ���������� ��� ������ BIT. � 
	�������� �������� ��������� ������� ������������ EmployeeID. �������� ������� IsBoss. ������������������ 
	������������� ������� ��� ���� ��������� �� ������� Employees.*/

	SELECT  employees.EmployeeID,employees.ReportsTo,Northwind.IsBoss(employees.EmployeeID) AS IsBoss
	FROM Northwind.Employees AS employees;
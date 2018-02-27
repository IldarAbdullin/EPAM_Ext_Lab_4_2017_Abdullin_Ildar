/*1 Работа с типами данных Date, NULL значениями, трехзначная логика. Возвращение определенных 
значений в результатах запроса в зависимости от полученных первоначальных значений результата запроса. 
Высветка в результатах запроса только определенных колонок. 

1.1 Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (колонка ShippedDate) 
включительно и которые доставлены с ShipVia >= 2. Формат указания даты должен быть верным при 
любых региональных настройках, согласно требованиям статьи “Writing International Transact-SQL Statements” 
в Books Online раздел “Accessing and Changing Relational Data Overview”. Этот метод использовать далее для 
всех заданий. Запрос должен высвечивать только колонки OrderID, ShippedDate и ShipVia.  
Пояснить почему сюда не попали заказы с NULL-ом в колонке ShippedDate. */
SELECT  OrderID, ShippedDate, ShipVia 
  FROM Northwind.Orders
  WHERE ShippedDate >= {d'1998-05-06'} 
    AND ShipVia >= 2;

/*1.2 Написать запрос, который выводит только недоставленные заказы из таблицы Orders.
 В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL 
 строку ‘Not Shipped’ – использовать системную функцию CASЕ. 
 Запрос должен высвечивать только колонки OrderID и ShippedDate. */

 SELECT OrderID, ShippedDate = CASE
	   WHEN ShippedDate IS  NULL THEN 'Not Shipped'
   END
   FROM Northwind.Orders
   WHERE ShippedDate IS NULL

 /*1.3 Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (ShippedDate)
  не включая эту дату или которые еще не доставлены. В запросе должны высвечиваться только колонки 
  OrderID (переименовать в Order Number) и ShippedDate (переименовать в Shipped Date). 
  В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’,
   для остальных значений высвечивать дату в формате по умолчанию. */

   SELECT OrderID as 'Order Number', 'Shipped Date' = CASE
	   WHEN ShippedDate IS  NULL THEN 'Not Shipped'
	   ELSE CONVERT(nvarchar(30), ShippedDate, 102)
   END 
   FROM Northwind.Orders
   WHERE ShippedDate > {d'1998-03-06'} OR ShippedDate IS NULL ;



   /*2 Использование операторов IN, DISTINCT, ORDER BY, NOT 

   2.1 Выбрать из таблицы Customers 
   всех заказчиков, проживающих в USA и Canada. Запрос сделать с только помощью оператора IN. 
   Высвечивать колонки с именем пользователя и названием страны в результатах запроса. 
   Упорядочить результаты запроса по имени заказчиков и по месту проживания. */
   SELECT ContactName, Country
   FROM Northwind.Customers
   WHERE Country IN ('USA','Canada')
   ORDER BY ContactName,Address;

   /*2.2 Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada. 
   Запрос сделать с помощью оператора IN. Высвечивать колонки с именем пользователя и названием 
   страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков.*/

   SELECT ContactName, Country
   FROM Northwind.Customers
   WHERE Country NOT IN ('USA','Canada')
   ORDER BY ContactName;
   

   /*2.3 Выбрать из таблицы Customers все страны, в которых проживают заказчики. 
   Страна должна быть упомянута только один раз и список отсортирован по убыванию. 
   Не использовать предложение GROUP BY. Высвечивать только одну колонку в результатах запроса. */

   SELECT DISTINCT Country
   FROM Northwind.Customers
   ORDER BY Country DESC;


   /*3 Использование оператора BETWEEN, DISTINCT 

   3.1 Выбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повторяться),
    где встречаются продукты с количеством от 3 до 10 включительно – это колонка Quantity в таблице
	 Order Details. Использовать оператор BETWEEN. Запрос должен высвечивать только колонку OrderID. */

	 SELECT DISTINCT OrderID
	 FROM Northwind.[Order Details] 
	 WHERE Quantity BETWEEN 3 AND 10;

	/*3.2 Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на
	 буквы из диапазона b и g. Использовать оператор BETWEEN. 
	 Проверить, что в результаты запроса попадает Germany. 
	 Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country. */

	 SELECT CustomerID, Country
	 FROM Northwind.Customers
	 WHERE Country BETWEEN 'b%' AND 'h%'
	 ORDER BY Country;

	 /*3.3 Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы
	  из диапазона b и g, не используя оператор BETWEEN. С помощью опции “Execution Plan” определить 
	  какой запрос предпочтительнее 3.2 или 3.3 – для этого надо ввести в скрипт выполнение текстового 
	  Execution Plan-a для двух этих запросов, результаты выполнения Execution Plan надо ввести в скрипт в 
	  виде комментария и по их результатам дать ответ на вопрос – по какому параметру было проведено 
	  сравнение. Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.*/

	  SELECT CustomerID, Country
	  FROM Northwind.Customers
	  WHERE Country > 'b%' AND Country < 'h%'
	  ORDER BY Country;

	  /* 
	  План выполнения 3.2

	  <QueryPlan DegreeOfParallelism="0" NonParallelPlanReason="NoParallelPlansInDesktopOrExpressEdition" MemoryGrant="1024" CachedPlanSize="16" CompileTime="1" CompileCPU="1" CompileMemory="152">
      <MemoryGrantInfo SerialRequiredMemory="512" SerialDesiredMemory="544" RequiredMemory="512" DesiredMemory="544" RequestedMemory="1024" GrantWaitTime="0" GrantedMemory="1024" MaxUsedMemory="16" />
      <OptimizerHardwareDependentProperties EstimatedAvailableMemoryGrant="206217" EstimatedPagesCached="51554" EstimatedAvailableDegreeOfParallelism="2" />
      <RelOp AvgRowSize="32" EstimateCPU="0.00043212" EstimateIO="0.0112613" EstimateRebinds="0" EstimateRewinds="0" EstimatedExecutionMode="Row" EstimateRows="40" LogicalOp="Sort" NodeId="0" Parallel="false" PhysicalOp="Sort" EstimatedTotalSubtreeCost="0.016637">
	  <RelOp AvgRowSize="32" EstimateCPU="0.0002571" EstimateIO="0.00460648" EstimateRebinds="0" EstimateRewinds="0" EstimatedExecutionMode="Row" EstimateRows="40" LogicalOp="Clustered Index Scan" NodeId="1" Parallel="false" PhysicalOp="Clustered Index Scan" EstimatedTotalSubtreeCost="0.00486358" TableCardinality="91">


	  План выполнения 3.3
	  <QueryPlan DegreeOfParallelism="0" NonParallelPlanReason="NoParallelPlansInDesktopOrExpressEdition" MemoryGrant="1024" CachedPlanSize="16" CompileTime="1" CompileCPU="1" CompileMemory="152">
	 <MemoryGrantInfo SerialRequiredMemory="512" SerialDesiredMemory="544" RequiredMemory="512" DesiredMemory="544" RequestedMemory="1024" GrantWaitTime="0" GrantedMemory="1024" MaxUsedMemory="16" />
	 <OptimizerHardwareDependentProperties EstimatedAvailableMemoryGrant="206217" EstimatedPagesCached="51554" EstimatedAvailableDegreeOfParallelism="2" />
	 <RelOp AvgRowSize="32" EstimateCPU="0.00043212" EstimateIO="0.0112613" EstimateRebinds="0" EstimateRewinds="0" EstimatedExecutionMode="Row" EstimateRows="40" LogicalOp="Sort" NodeId="0" Parallel="false" PhysicalOp="Sort" EstimatedTotalSubtreeCost="0.016637">
	 <RelOp AvgRowSize="32" EstimateCPU="0.0002571" EstimateIO="0.00460648" EstimateRebinds="0" EstimateRewinds="0" EstimatedExecutionMode="Row" EstimateRows="40" LogicalOp="Clustered Index Scan" NodeId="1" Parallel="false" PhysicalOp="Clustered Index Scan" EstimatedTotalSubtreeCost="0.00486358" TableCardinality="91">


	 Запрос идентичны по всем параметрам
	  */

	  /*.4 Использование оператора LIKE

4.1 В таблице Products найти все продукты (колонка ProductName), где встречается подстрока 'chocolade'. 
Известно, что в подстроке 'chocolade' может быть изменена одна буква 'c' в середине - найти все продукты,
 которые удовлетворяют этому условию. Подсказка: результаты запроса должны высвечивать 2 строки.*/

 SELECT ProductName 
 FROM Northwind.Products
 WHERE ProductName LIKE 'cho_olade' ;


 /*5 Использование агрегатных функций (SUM, COUNT)

5.1 Найти общую сумму всех заказов из таблицы Order Details с учетом количества закупленных товаров и 
скидок по ним. Результат округлить до сотых и высветить в стиле 1 для типа данных money.
 Скидка (колонка Discount) составляет процент из стоимости для данного товара. 
 Для определения действительной цены на проданный продукт надо вычесть скидку из указанной в колонке 
 UnitPrice цены. Результатом запроса должна быть одна запись с одной колонкой с названием колонки 'Totals'.*/

 SELECT CONVERT(MONEY,(SUM((UnitPrice  - Discount) * Quantity)),1) AS 'Totals'
 FROM Northwind.[Order Details];


 /*5.2 По таблице Orders найти количество заказов, которые еще не были доставлены 
 (т.е. в колонке ShippedDate нет значения даты доставки). Использовать при этом запросе только 
 оператор COUNT. Не использовать предложения WHERE и GROUP.*/

 SELECT COUNT(*) - COUNT(ShippedDate) AS 'The number of orders'
  FROM Northwind.Orders;

  /*5.3 По таблице Orders найти количество различных покупателей (CustomerID), 
  сделавших заказы. Использовать функцию COUNT и не использовать предложения WHERE и GROUP.*/

  SELECT COUNT(DISTINCT CustomerID) AS 'The number of Customers'
  FROM Northwind.Orders;


  /*6 Явное соединение таблиц, самосоединения, использование агрегатных функций и 
  предложений GROUP BY и HAVING

	6.1 По таблице Orders найти количество заказов с группировкой по годам. 
	В результатах запроса надо высвечивать две колонки c названиями Year и Total. 
	Написать проверочный запрос, который вычисляет количество всех заказов.*/

	SELECT DATEPART(yyyy,OrderDate) AS 'Year', COUNT( DATEPART(yyyy,OrderDate)) AS 'Total'
	FROM Northwind.Orders
	GROUP BY DATEPART(yyyy,OrderDate);

	SELECT COUNT(OrderID)
	FROM Northwind.Orders;
	--830


	/*6.2 По таблице Orders найти количество заказов, cделанных каждым продавцом. 
	Заказ для указанного продавца – это любая запись в таблице Orders, где в колонке 
	EmployeeID задано значение для данного продавца. В результатах запроса надо высвечивать 
	колонку с именем продавца (Должно высвечиваться имя полученное конкатенацией LastName & FirstName. 
	Эта строка LastName & FirstName должна быть получена отдельным запросом в колонке основного запроса. 
	Также основной запрос должен использовать группировку по EmployeeID.) с названием колонки ‘Seller’ 
	и колонку c количеством заказов высвечивать с названием 'Amount'. Результаты запроса должны быть 
	упорядочены по убыванию количества заказов.*/

	SELECT (SELECT LastName + FirstName
	  FROM Northwind.Employees
	  WHERE Employees.EmployeeID = Orders.EmployeeID) AS 'Seller',
	  COUNT(CustomerID) AS  'Amount'
	FROM Northwind.Orders
	GROUP BY EmployeeID
	ORDER BY 'Amount' DESC;

	/*6.3 По таблице Orders найти количество заказов, cделанных каждым продавцом и для каждого 
	покупателя. Необходимо определить это только для заказов сделанных в 1998 году. 
	В результатах запроса надо высвечивать колонку с именем продавца (название колонки ‘Seller’), 
	колонку с именем покупателя (название колонки ‘Customer’) и колонку c количеством заказов 
	высвечивать с названием 'Amount'. В запросе необходимо использовать специальный оператор языка 
	T-SQL для работы с выражением GROUP (Этот же оператор поможет выводить строку “ALL” в результатах
	 запроса). Группировки должны быть сделаны по ID продавца и покупателя. Результаты запроса должны 
	 быть упорядочены по продавцу, покупателю и по убыванию количества продаж. В результатах должна 
	 быть сводная информация по продажам. Т.е. в резульирующем наборе должны присутствовать 
	 дополнительно к информации о продажах продавца для каждого покупателя следующие строчки:*/

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


 /*6.4 Найти покупателей и продавцов, которые живут в одном городе. 
 Если в городе живут только один или несколько продавцов или только один или несколько покупателей,
  то информация о таких покупателя и продавцах не должна попадать в результирующий набор. 
  Не использовать конструкцию JOIN. В результатах запроса необходимо вывести следующие заголовки 
  для результатов запроса: ‘Person’, ‘Type’ (здесь надо выводить строку ‘Customer’ или ‘Seller’ 
  в завимости от типа записи), ‘City’. Отсортировать результаты запроса по колонке ‘City’ и по ‘Person’.*/

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


	/*6.5 Найти всех покупателей, которые живут в одном городе. В запросе использовать соединение 
	таблицы Customers c собой - самосоединение. Высветить колонки CustomerID и City. 
	Запрос не должен высвечивать дублируемые записи. Для проверки написать запрос, который высвечивает 
	города, которые встречаются более одного раза в таблице Customers. Это позволит проверить правильность 
	запроса.*/

	SELECT DISTINCT C1.CustomerID, C2.City
	FROM Northwind.Customers C1 JOIN Northwind.Customers C2 
		ON C1.CustomerID != C2.CustomerID
	WHERE (C1.City = C2.City) and (C1.CustomerID <> C2.CustomerID);

	Select COUNT(*) as 'QUANTITY', City
	From Northwind.Customers
	Group by City
	Having COUNT(*) > 1

	/*6.6 По таблице Employees найти для каждого продавца его руководителя, 
	т.е. кому он делает репорты. Высветить колонки с именами 'User Name' (LastName) и 'Boss'. 
	В колонках должны быть высвечены имена из колонки LastName. 
	Высвечены ли все продавцы в этом запросе? */

	SELECT E1.LastName AS 'User Name', E2.LastName AS 'Boss'
	FROM Northwind.Employees E1 join Northwind.Employees E2
	ON E1.ReportsTo = E2.EmployeeID;

	--Продовцы, которые в столбце ReportsTo имеют значение NULL, т.е. сами являются боссами, не попали в выбрку

	/*7 Использование Inner JOIN
	7.1 Определить продавцов, которые обслуживают регион 'Western' (таблица Region).
	 Результаты запроса должны высвечивать два поля: 'LastName' продавца и название 
	 обслуживаемой территории ('TerritoryDescription' из таблицы Territories). 
	 Запрос должен использовать JOIN в предложении FROM. Для определения связей между таблицами 
	 Employees и Territories надо использовать графические диаграммы для базы Northwind.*/

	 SELECT Employees.LastName, Territories.TerritoryDescription 
	 FROM (Northwind.Territories 
	 JOIN Northwind.EmployeeTerritories 
		ON (Territories.TerritoryID = EmployeeTerritories.TerritoryID)) 
	 JOIN Northwind.Employees
		ON (EmployeeTerritories.EmployeeID = Employees.EmployeeID)
	 JOIN Northwind.Region 
		ON Territories.RegionID  = Region.RegionID
	 WHERE RegionDescription = 'Western';
	 

	 /*8 Использование Outer JOIN
	 8.1 Высветить в результатах запроса имена всех заказчиков из таблицы Customers и суммарное 
	 количество их заказов из таблицы Orders. Принять во внимание, что у некоторых заказчиков нет 
	 заказов, но они также должны быть выведены в результатах запроса. Упорядочить результаты запроса 
	 по возрастанию количества заказов.*/

	 SELECT Customers.ContactName, COUNT(Orders.CustomerID)  AS 'QUNTITY'
	 FROM Northwind.Customers LEFT JOIN Northwind.Orders
	 ON Customers.CustomerID = Orders.CustomerID
	 GROUP BY Customers.ContactName
	 ORDER BY QUNTITY;

	 /*9 Использование подзапросов
	  9.1 Высветить всех поставщиков колонка CompanyName в таблице Suppliers, у которых нет хотя
	   бы одного продукта на складе (UnitsInStock в таблице Products равно 0). Использовать вложенный 
	   SELECT для этого запроса с использованием оператора IN. Можно ли использовать вместо 
	   оператора IN оператор '=' ? */
     
	 --Нельяз использовать =, т.к. = сравнивает только с единтсвенным значением, а не с набором
	          
	 SELECT CompanyName,SupplierID
	 FROM Northwind.Suppliers
	 WHERE Suppliers.SupplierID IN 
			(SELECT SupplierID 
			 FROM Northwind.Products
			 WHERE UnitsInStock = 0);

	


	/*10 Коррелированный запрос
	 10.1 Высветить всех продавцов, которые имеют более 150 заказов. Использовать вложенный 
	 коррелированный SELECT.*/

	 SELECT EmployeeID, FirstName, LastName
	 FROM Northwind.Employees
	 WHERE (SELECT Count(EmployeeID)
			FROM Northwind.Orders
			WHERE Employees.EmployeeID = Orders.EmployeeID
			GROUP BY EmployeeID) > 150;


	/*11 Использование EXISTS
	11.1 Высветить всех заказчиков (таблица Customers), которые не имеют ни одного заказа 
	(подзапрос по таблице Orders). Использовать коррелированный SELECT и оператор EXISTS.*/

	SELECT CustomerID,ContactName
	FROM Northwind.Customers
	WHERE NOT EXISTS(SELECT CustomerID 
					 FROM Northwind.Orders
					 WHERE Customers.CustomerID = Orders.CustomerID);

	/*12 Использование строковых функций
	12.1 Для формирования алфавитного указателя Employees высветить из таблицы Employees список 
	только тех букв алфавита, с которых начинаются фамилии Employees (колонка LastName ) из этой.
	Алфавитный список должен быть отсортирован по возрастанию.*/

	 Select DISTINCT (Left (LastName,1)) as 'POINTERS'
	 From Northwind.Employees
	 Order by POINTERS

	 /*13 Разработка функций и процедур
	13.1 Написать процедуру, которая возвращает самый крупный заказ для каждого из продавцов за 
	определенный год. В результатах не может быть несколько заказов одного продавца, должен быть 
	только один и самый крупный. В результатах запроса должны быть выведены следующие колонки: колонка 
	с именем и фамилией продавца (FirstName и LastName – пример: Nancy Davolio), номер заказа и его 
	стоимость. В запросе надо учитывать Discount при продаже товаров. Процедуре передается год, за 
	который надо сделать отчет, и количество возвращаемых записей. Результаты запроса должны быть 
	упорядочены по убыванию суммы заказа. Процедура должна быть реализована с использованием оператора 
	SELECT и БЕЗ ИСПОЛЬЗОВАНИЯ КУРСОРОВ. Название функции соответственно GreatestOrders. Необходимо 
	продемонстрировать использование этих процедур. Также помимо демонстрации вызовов процедур в 
	скрипте Query.sql надо написать отдельный ДОПОЛНИТЕЛЬНЫЙ проверочный запрос для тестирования 
	правильности работы процедуры GreatestOrders. Проверочный запрос должен выводить в удобном для 
	сравнения с результатами работы процедур виде для определенного продавца для всех его заказов за 
	определенный указанный год в результатах следующие колонки: имя продавца, номер заказа, сумму 
	заказа. Проверочный запрос не должен повторять запрос, написанный в процедуре, - он должен выполнять
	только то, что описано в требованиях по нему. ВСЕ ЗАПРОСЫ ПО ВЫЗОВУ ПРОЦЕДУР ДОЛЖНЫ БЫТЬ НАПИСАНЫ 
	В ФАЙЛЕ Query.sql – см. пояснение ниже в разделе «Требования к оформлению». */

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

	/*13.2 Написать процедуру, которая возвращает заказы в таблице Orders, согласно указанному сроку доставки в 
	днях (разница между OrderDate и ShippedDate). В результатах должны быть возвращены заказы, срок которых 
	превышает переданное значение или еще недоставленные заказы. Значению по умолчанию для передаваемого срока 
	35 дней. Название процедуры ShippedOrdersDiff. Процедура должна высвечивать следующие колонки: OrderID,
	 OrderDate, ShippedDate, ShippedDelay (разность в днях между ShippedDate и OrderDate), SpecifiedDelay 
	 (переданное в процедуру значение).*/

	 EXEC Northwind.ShippedOrdersDiff @SpecifiedDelay = 15;

	 /*13.3 Написать процедуру, которая высвечивает всех подчиненных заданного продавца, как непосредственных, так и 
	подчиненных его подчиненных. В качестве входного параметра функции используется EmployeeID. Необходимо 
	распечатать имена подчиненных и выровнять их в тексте (использовать оператор PRINT) согласно иерархии 
	подчинения. Продавец, для которого надо найти подчиненных также должен быть высвечен. Название процедуры 
	SubordinationInfo. В качестве алгоритма для решения этой задачи надо использовать пример, приведенный в Books
	Online и рекомендованный Microsoft для решения подобного типа задач. Продемонстрировать использование процедуры.*/

	EXEC Northwind.SubordinationInfo @EmployeeID = 4;

	/*13.4 Написать функцию, которая определяет, есть ли у продавца подчиненные. Возвращает тип данных BIT. В 
	качестве входного параметра функции используется EmployeeID. Название функции IsBoss. Продемонстрировать 
	использование функции для всех продавцов из таблицы Employees.*/

	SELECT  employees.EmployeeID,employees.ReportsTo,Northwind.IsBoss(employees.EmployeeID) AS IsBoss
	FROM Northwind.Employees AS employees;
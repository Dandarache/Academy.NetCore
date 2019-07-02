-- 1.16 Select the name of each manufacturer along 
--      with the name and price of its most expensive product.


; 
WITH MostExpensiveProduct_CTE
AS
(
	SELECT p.Code AS ProductId,
	       p.Name AS ProductName,
		   p.Price,
		   m.Name AS Manufacturer,
		   ROW_NUMBER() OVER (PARTITION BY m.Code ORDER BY p.Price DESC) AS Row
	  FROM [dbo].[Products] p
	 INNER JOIN [dbo].[Manufacturers] m
		ON p.Manufacturer = m.Code 
)
SELECT * 
  FROM MostExpensiveProduct_CTE
 WHERE Row = 1






--select a.Name, max(a.price), b.Name
--from Manufacturers b 
--join Products a 
--on a.Manufacturer = b.code
--group by a.Name, b.name;


--SELECT Products.Name, MAX(Price), Manufacturers.Name
-- FROM Products 
--INNER JOIN Manufacturers
--   ON Products.Manufacturer = Manufacturers.Code
-- WHERE Manufacturer = Manufacturers.Code
-- GROUP BY Manufacturers.Name;

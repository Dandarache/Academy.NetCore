------------------------------------------------
-- 101) Lista alla låtar (Track) av Frank Zappa 
--      längre än 240000 ms 
------------------------------------------------
SELECT [Name], Milliseconds  
  FROM Track
 WHERE Composer LIKE '%Zappa%' 
   AND Milliseconds >= 240000

------------------------------------------------
-- 102) Lista förnamn, efternamn och land för alla
--      kunder (Customer) som finns i Brazil  
--      och Argentina.
------------------------------------------------
SELECT FirstName, LastName, Country
  FROM Customer
 WHERE Country IN ('Brazil', 'Argentina') 

------------------------------------------------
-- 103) Lista namn, millisekunder för alla låtar som 
--      är mellan 30000 och 60000 ms (Track)
------------------------------------------------
SELECT [Name], Milliseconds
  FROM Track
 WHERE Milliseconds BETWEEN 30000 AND 60000

------------------------------------------------
-- 104) Lista hela namnet, dvs för- och  
--        efternamn på alla anställda i en 
--        kolumn (Employee) 
--
-- Tips:  Använd CONCAT
------------------------------------------------
SELECT CONCAT(FirstName, ' ', LastName) 
  FROM Employee

------------------------------------------------
-- 105) Lista efternamnet på alla anställda i 
--        med stora bokstäver (Employee) 
--
-- Tips:  Använd UPPER
------------------------------------------------
SELECT UPPER(LastName) 
  FROM Employee

------------------------------------------------
-- 106) Lista efternamnet på alla anställda i 
--        med små bokstäver (Employee) 
--
-- Tips:  Använd LOWER
------------------------------------------------
SELECT LOWER(LastName) 
  FROM Employee

------------------------------------------------
-- 107) Lista första bokstaven i förnamnet och
--        efternamnet på alla anställda enligt 
--        följande format: 
--        D. Jansson
--
-- Tips:  Använd CONCAT, SUBSTRING
------------------------------------------------
SELECT SUBSTRING(FirstName, 1, 1) + '. ' + LastName
  FROM Employee

------------------------------------------------
-- 108) Lista för- och efternamnet, födelsedatum
--        samt ålder i antal år på alla anställda. 
--
-- Tips:  Använd DATEDIFF, GETDATE, YEAR
------------------------------------------------
SELECT FirstName, 
       LastName,
	   BirthDate,
	   DATEDIFF(YEAR, BirthDate, GETDATE())
  FROM Employee

------------------------------------------------
-- 109) Lista för- och efternamnet, anställningsdatum
--        samt antal dagar som anställda har arbetat. 
--
-- Tips:  Använd DATEDIFF, GETDATE, DAY
------------------------------------------------
SELECT FirstName, 
       LastName,
	   HireDate,
	   DATEDIFF(DAY, HireDate, GETDATE())
  FROM Employee

------------------------------------------------
-- 110) Räkna ut hur gammal varje anställd var
--        när de anställdes. 
--
-- Tips:  Använd DATEDIFF, GETDATE, YEAR
------------------------------------------------
SELECT FirstName, 
       LastName,
	   HireDate,
	   DATEDIFF(YEAR, BirthDate, HireDate)
  FROM Employee

------------------------------------------------
-- 111) Ta reda på vilken månad varje anställd 
--        är född. 
--
-- Tips:  Använd DATENAME, MONTH
------------------------------------------------
SELECT FirstName, 
       LastName,
	   HireDate,
	   DATENAME(MONTH, BirthDate) AS BirthMonth
  FROM Employee

------------------------------------------------
-- 112) Lägg till 15 år på anställningsdatum 
--        för varje anställd.
--
-- Tips:  Använd DATEADD, YEAR
------------------------------------------------
SELECT FirstName, 
       LastName,
	   HireDate,
	   DATEADD(YEAR, 15, HireDate) AS ModifiedHireDate
  FROM Employee

------------------------------------------------
-- 113) Lista alla anställda (Employee) som 
--         inte har någon chef. (ReportsTo)
------------------------------------------------
SELECT FirstName, LastName 
  FROM Employee
 WHERE ReportsTo IS NULL

------------------------------------------------
-- 114) Lista för- och efternamn på alla 
--         anställda baklänges.
-- Tips:   CONCAT, REVERSE
------------------------------------------------
SELECT REVERSE(CONCAT(FirstName, ' ', LastName)) 
  FROM Employee

------------------------------------------------
-- 115) Lista alla anställda som har kunder i USA 
--      Välj anställnings id, för- och efternamn
--      samt antal amerikanska kunder per anställd.
------------------------------------------------
SELECT Employee.FirstName,
       Employee.LastName,
	   Employee.EmployeeId,
	   COUNT(Customer.CustomerId) AS NumberOfCustomers
  FROM Employee
 INNER JOIN Customer 
    ON Customer.SupportRepId = employee.employeeid
 WHERE Customer.Country='USA' 
 GROUP By Employee.FirstName, Employee.LastName, Employee.EmployeeId

------------------------------------------------
-- 116) Gör en self join med tabellen Employee.
--      Syftet är att lista data över anställda 
--      tillsammans med en kolumn med chefens namn.
--      Använd en LEFT OUTER JOIN.
------------------------------------------------
SELECT emp.EmployeeId, 
       emp.FirstName + ' ' + emp.LastName AS Employee, 
       mgr.EmployeeId AS ManagerId,
	   mgr.FirstName + ' ' + mgr.LastName AS Manager
  FROM Employee emp 
  LEFT OUTER JOIN Employee mgr 
    ON emp.ReportsTo = mgr.EmployeeId

------------------------------------------------
-- 117) Lista genre, antal låtar per genre,
--      kortaste låten, längsta låten samt 
--      snittlängden för en låt.
--
-- Tips: GROUP BY, MIN, MAX, AVG, COUNT   
------------------------------------------------
SELECT Genre.[Name] AS Genre, 
       COUNT(*) AS NumberOfTracks, 
	   MIN(Milliseconds) AS ShortestTrack,
       MAX(Milliseconds) AS LongestTrack, 
	   AVG(Milliseconds) AS AverageTrackLength
  FROM Track 
 INNER JOIN Genre 
    ON Genre.GenreId = Track.GenreId
 GROUP BY Genre.[Name]

------------------------------------------------
-- 118) Lista genre, antal låtar per genre,
--      kortaste låten, längsta låten samt 
--      snittlängden för en låt för alla genrer
--      som har fler än 100 låtar. 
--      Sortera listan fallande med den genre 
--      som har flest låtar överst.
--
-- Tips: GROUP BY, HAVING, MIN, MAX, AVG, COUNT   
------------------------------------------------
SELECT Genre.[Name] AS Genre, 
       COUNT(*) AS NumberOfTracks, 
	   MIN(Milliseconds) AS ShortestTrack,
       MAX(Milliseconds) AS LongestTrack, 
	   AVG(Milliseconds) AS AverageTrackLength
  FROM Track 
 INNER JOIN Genre 
    on Genre.GenreId = Track.GenreId
 GROUP BY Genre.[Name]
 HAVING COUNT(*) > 100
 ORDER BY NumberOfTracks DESC
 
------------------------------------------------
-- 119) Gör en CROSS JOIN mellan Genre och 
--      MediaType. Studera resultatet och försök
--      att förklara varför det blir som det blir.
------------------------------------------------
SELECT * 
FROM Genre
  CROSS JOIN MediaType

------------------------------------------------
-- 120) Lista alla låtar som sålts enligt 
--      faktura med ID = 89
--      
-- Tips: Använd en s.k. subquery och IN
------------------------------------------------
SELECT * 
  FROM Track 
 WHERE TrackId IN (
	SELECT TrackId 
	  FROM InvoiceLine 
	 WHERE InvoiceId = 89
)

------------------------------------------------
-- 121) Lägg till en låt för albumet som heter
--      "Nevermind" av Nirvana.
--      Använd samma värden som för de andra låtarna
--      för alla kolumner utom namn och id.
--      Ange inget värde för id.
--      Ange en ny titel för namn.
--      
-- Tips: INSERT
------------------------------------------------
INSERT Track 
	([Name], AlbumId, MediaTypeId, GenreId, Composer, Milliseconds, Bytes, UnitPrice, TrackNumber) 
VALUES 
	('My Foo Song', 164, 1, 1, 'Nirvana', 100, 100, 1.99, 2)

------------------------------------------------
-- 122) Välj för- och efternamn på alla anställda och
--      kombinera dem med för- och efternamn på alla kunder
--      i en gemensam lista. 
--      
-- Tips: UNION
------------------------------------------------
SELECT FirstName + ' ' + LastName
  FROM Employee
 UNION 
SELECT FirstName + ' ' + LastName
  FROM Customer

------------------------------------------------
-- 123) Lista alla låtar av Iron Maiden genom 
--      att använda en subquery inom ett IN
--      statement.
--      
-- Tips: SELECT ... WHERE ... IN (SELECT ...)
------------------------------------------------
SELECT * FROM Track
 WHERE AlbumId IN (
	SELECT AlbumId FROM Album WHERE ArtistId = 90
) 

------------------------------------------------
-- 124) Lista alla låtar med titel, namn på genre, 
--      namn på mediatyp samt en siffra på antal 
--      spellistor som som har låten.
--      Sortera i fallande ordning med den låt som 
--      tillhör flest spellistor överst.
--      
-- Tips: INNER JOIN, LEFT JOIN, GROUP BY, COUNT
------------------------------------------------
SELECT Track.[Name] AS Title, 
       Genre.[Name] AS Genre, 
	   MediaType.[Name] AS MediaType, 
	   COUNT(*) AS NumberOfPlayLists
  FROM Track
 INNER JOIN Genre 
    ON Genre.GenreId = Track.GenreId
 INNER JOIN MediaType
    ON MediaType.MediaTypeId = Track.MediaTypeId
  LEFT OUTER JOIN PlaylistTrack
    ON PlaylistTrack.TrackId = Track.TrackId
 GROUP BY Track.[Name], Genre.[Name], MediaType.[Name]
 ORDER BY NumberOfPlayLists DESC

------------------------------------------------
-- 125) Skapa en ny tabell med resultatet från 
--      föregående övning. Använd samma SQL-sats
--      men komplettera SQL-koden så att tabellen
--      skapas.
--      
-- Tips: INSERT INTO
------------------------------------------------
SELECT Track.[Name] AS Title, 
       Genre.[Name] AS Genre, 
	   MediaType.[Name] AS MediaType, 
	   COUNT(*) AS NumberOfPlayLists
  INTO MyPlaylistReport
  FROM Track
 INNER JOIN Genre 
    ON Genre.GenreId = Track.GenreId
 INNER JOIN MediaType
    ON MediaType.MediaTypeId = Track.MediaTypeId
  LEFT OUTER JOIN PlaylistTrack
    ON PlaylistTrack.TrackId = Track.TrackId
 GROUP BY Track.[Name], Genre.[Name], MediaType.[Name]
 ORDER BY NumberOfPlayLists DESC

SELECT * 
  FROM MyPlaylistReport
 ORDER BY NumberOfPlayLists DESC

------------------------------------------------
-- 126) Ta bort tabellen du skapade i förra övningen
--      
-- Tips: DROP TABLE ...
------------------------------------------------
DROP TABLE MyPlaylistReport
GO

------------------------------------------------
-- 127) Skapa en ny TEMPORÄR tabell på samma sätt
--      som i övning 125. Använd samma SQL-sats
--      men komplettera SQL-koden så att tabellen
--      skapas.
--      
--      Fundera på vad som är skillnaden mellan
--      tabellen i denna övning och den du skapade
--      i övning 125.
--      
-- Tips: #MinTabell
------------------------------------------------

------------------------------------------------
-- 128) Uppdatera låten du skapade i övning 121
--      med ett nytt namn.
--
-- Tips: UPDATE ... SET ... WHERE
------------------------------------------------
UPDATE Track 
SET Track.[Name] = 'My updated Foo Song' 
WHERE TrackId = 99999999999999999999


------------------------------------------------
-- 129) Ta bort den låt du skapade i övning 121
--      
-- Tips: DELETE ... WHERE ...
------------------------------------------------
DELETE Track WHERE TrackId = 99999999999999999999

------------------------------------------------
-- 130) Skriv en SQL-fråga som räknar 525 upphöjt
--      till 2
--      
-- Tips: POWER
------------------------------------------------
SELECT POWER(525, 2) AS [Upphöjt till]

------------------------------------------------
-- 131) Skriv en SQL-fråga som räknar ut roten
--      ur 275625
--      
-- Tips: SQRT
------------------------------------------------
SELECT SQRT(275625) AS [Roten ur]

------------------------------------------------
-- 132) Skriv en SQL-fråga som räknar ut roten
--      ur 275625
--      
-- Tips: SQRT
------------------------------------------------
SELECT SQRT(275625) AS [Roten ur]

------------------------------------------------
-- 133) Skriv en SQL-fråga som räknar ut 
--      97838 modulus 3
--      
-- Tips: %
------------------------------------------------
SELECT (97838 % 3) AS [Modulus]

------------------------------------------------
-- 134) Skriv en SQL-fråga som räknar ut 
--      logaritmen av 97
--      
-- Tips: LN
------------------------------------------------
SELECT LOG(97) AS [Logaritmen]

------------------------------------------------
-- 134) Skriv en SQL-fråga som räknar ut 
--      exponenten av 3
--      
-- Tips: EXP
------------------------------------------------
SELECT EXP(3) AS [Exponenten]

------------------------------------------------
-- 135) Skriv en SQL-fråga som returnerar 
--      det absoluta talet av -123.45678
--      
-- Tips: ABS
------------------------------------------------
SELECT ABS(-123.4567) AS [Absoluta talet]

------------------------------------------------
-- 136) Skriv en SQL-fråga som avrundar talet 
--      123.45678 nedåt.
--      
-- Tips: FLOOR
------------------------------------------------
SELECT FLOOR(123.4567) AS [Avrundningen]

------------------------------------------------
-- 137) Skriv en SQL-fråga som avrundar talet
--      123.45678 uppåt
--      
-- Tips: CEILING
------------------------------------------------
SELECT CEILING(123.4567) AS [Avrundningen]

------------------------------------------------
-- 138) Skriv en SQL-fråga som tar bort whitespace
--      på följande text:
--      '   Det är vacker väder idag     '
--      
-- Tips: TRIM
------------------------------------------------
SELECT TRIM('   Det är vackert väder idag.     ') AS [Trimmad text]

------------------------------------------------
-- 139) Konvertera texten '2019-06-28 11:35' till 
--      ett datum med typen DATETIME.
--      
-- Tips: CONVERT
------------------------------------------------
SELECT CONVERT(DATETIME, '2019-06-28 11:35') AS [Datumet]

------------------------------------------------
-- 140) Skapa en variabel av typen DATETIME.
--      Konvertera texten '2019-06-28 11:35' till
--      ett datum och sätt variabeln till detta datum.
--      Visa datumet med en select-sats
--      
-- Tips: CONVERT(..., ..., 1)
------------------------------------------------
DECLARE @myDate DATETIME
SET @myDate = CONVERT(DATETIME, '2019-06-28 11:35') 
SELECT @myDate

------------------------------------------------
-- 141) Konvertera datumet nedan till en text
--      som visar datumet enligt US standard.
--      
-- Tips: CONVERT(..., ..., 1)
------------------------------------------------
DECLARE @myDate2 DATETIME
SET @myDate2 = CONVERT(DATETIME, '2019-06-28 11:35') 
SELECT CONVERT(NVARCHAR(50), @myDate2, 1) AS [USA Datumet]

------------------------------------------------
-- 142) Konvertera texten '2019-06-28 11:35' till 
--      ett datum med typen DATETIME med funktionen CAST.
--      
-- Tips: CAST
------------------------------------------------
SELECT CAST('2019-06-28 11:35' AS DATETIME) AS [Datumet]





--CTE
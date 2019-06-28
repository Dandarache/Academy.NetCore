------------------------------------------------
-- 101) Lista alla l�tar (Track) av Frank Zappa 
--      l�ngre �n 240000 ms 
------------------------------------------------
SELECT [Name], Milliseconds  
  FROM Track
 WHERE Composer LIKE '%Zappa%' 
   AND Milliseconds >= 240000

------------------------------------------------
-- 102) Lista f�rnamn, efternamn och land f�r alla
--      kunder (Customer) som finns i Brazil  
--      och Argentina.
------------------------------------------------
SELECT FirstName, LastName, Country
  FROM Customer
 WHERE Country IN ('Brazil', 'Argentina') 

------------------------------------------------
-- 103) Lista namn, millisekunder f�r alla l�tar som 
--      �r mellan 30000 och 60000 ms (Track)
------------------------------------------------
SELECT [Name], Milliseconds
  FROM Track
 WHERE Milliseconds BETWEEN 30000 AND 60000

------------------------------------------------
-- 104) Lista hela namnet, dvs f�r- och  
--        efternamn p� alla anst�llda i en 
--        kolumn (Employee) 
--
-- Tips:  Anv�nd CONCAT
------------------------------------------------
SELECT CONCAT(FirstName, ' ', LastName) 
  FROM Employee

------------------------------------------------
-- 105) Lista efternamnet p� alla anst�llda i 
--        med stora bokst�ver (Employee) 
--
-- Tips:  Anv�nd UPPER
------------------------------------------------
SELECT UPPER(LastName) 
  FROM Employee

------------------------------------------------
-- 106) Lista efternamnet p� alla anst�llda i 
--        med sm� bokst�ver (Employee) 
--
-- Tips:  Anv�nd LOWER
------------------------------------------------
SELECT LOWER(LastName) 
  FROM Employee

------------------------------------------------
-- 107) Lista f�rsta bokstaven i f�rnamnet och
--        efternamnet p� alla anst�llda enligt 
--        f�ljande format: 
--        D. Jansson
--
-- Tips:  Anv�nd CONCAT, SUBSTRING
------------------------------------------------
SELECT SUBSTRING(FirstName, 1, 1) + '. ' + LastName
  FROM Employee

------------------------------------------------
-- 108) Lista f�r- och efternamnet, f�delsedatum
--        samt �lder i antal �r p� alla anst�llda. 
--
-- Tips:  Anv�nd DATEDIFF, GETDATE, YEAR
------------------------------------------------
SELECT FirstName, 
       LastName,
	   BirthDate,
	   DATEDIFF(YEAR, BirthDate, GETDATE())
  FROM Employee

------------------------------------------------
-- 109) Lista f�r- och efternamnet, anst�llningsdatum
--        samt antal dagar som anst�llda har arbetat. 
--
-- Tips:  Anv�nd DATEDIFF, GETDATE, DAY
------------------------------------------------
SELECT FirstName, 
       LastName,
	   HireDate,
	   DATEDIFF(DAY, HireDate, GETDATE())
  FROM Employee

------------------------------------------------
-- 110) R�kna ut hur gammal varje anst�lld var
--        n�r de anst�lldes. 
--
-- Tips:  Anv�nd DATEDIFF, GETDATE, YEAR
------------------------------------------------
SELECT FirstName, 
       LastName,
	   HireDate,
	   DATEDIFF(YEAR, BirthDate, HireDate)
  FROM Employee

------------------------------------------------
-- 111) Ta reda p� vilken m�nad varje anst�lld 
--        �r f�dd. 
--
-- Tips:  Anv�nd DATENAME, MONTH
------------------------------------------------
SELECT FirstName, 
       LastName,
	   HireDate,
	   DATENAME(MONTH, BirthDate) AS BirthMonth
  FROM Employee

------------------------------------------------
-- 112) L�gg till 15 �r p� anst�llningsdatum 
--        f�r varje anst�lld.
--
-- Tips:  Anv�nd DATEADD, YEAR
------------------------------------------------
SELECT FirstName, 
       LastName,
	   HireDate,
	   DATEADD(YEAR, 15, HireDate) AS ModifiedHireDate
  FROM Employee

------------------------------------------------
-- 113) Lista alla anst�llda (Employee) som 
--         inte har n�gon chef. (ReportsTo)
------------------------------------------------
SELECT FirstName, LastName 
  FROM Employee
 WHERE ReportsTo IS NULL

------------------------------------------------
-- 114) Lista f�r- och efternamn p� alla 
--         anst�llda bakl�nges.
-- Tips:   CONCAT, REVERSE
------------------------------------------------
SELECT REVERSE(CONCAT(FirstName, ' ', LastName)) 
  FROM Employee

------------------------------------------------
-- 115) Lista alla anst�llda som har kunder i USA 
--      V�lj anst�llnings id, f�r- och efternamn
--      samt antal amerikanska kunder per anst�lld.
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
-- 116) G�r en self join med tabellen Employee.
--      Syftet �r att lista data �ver anst�llda 
--      tillsammans med en kolumn med chefens namn.
--      Anv�nd en LEFT OUTER JOIN.
------------------------------------------------
SELECT emp.EmployeeId, 
       emp.FirstName + ' ' + emp.LastName AS Employee, 
       mgr.EmployeeId AS ManagerId,
	   mgr.FirstName + ' ' + mgr.LastName AS Manager
  FROM Employee emp 
  LEFT OUTER JOIN Employee mgr 
    ON emp.ReportsTo = mgr.EmployeeId

------------------------------------------------
-- 117) Lista genre, antal l�tar per genre,
--      kortaste l�ten, l�ngsta l�ten samt 
--      snittl�ngden f�r en l�t.
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
-- 118) Lista genre, antal l�tar per genre,
--      kortaste l�ten, l�ngsta l�ten samt 
--      snittl�ngden f�r en l�t f�r alla genrer
--      som har fler �n 100 l�tar. 
--      Sortera listan fallande med den genre 
--      som har flest l�tar �verst.
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
-- 119) G�r en CROSS JOIN mellan Genre och 
--      MediaType. Studera resultatet och f�rs�k
--      att f�rklara varf�r det blir som det blir.
------------------------------------------------
SELECT * 
FROM Genre
  CROSS JOIN MediaType

------------------------------------------------
-- 120) Lista alla l�tar som s�lts enligt 
--      faktura med ID = 89
--      
-- Tips: Anv�nd en s.k. subquery och IN
------------------------------------------------
SELECT * 
  FROM Track 
 WHERE TrackId IN (
	SELECT TrackId 
	  FROM InvoiceLine 
	 WHERE InvoiceId = 89
)

------------------------------------------------
-- 121) L�gg till en l�t f�r albumet som heter
--      "Nevermind" av Nirvana.
--      Anv�nd samma v�rden som f�r de andra l�tarna
--      f�r alla kolumner utom namn och id.
--      Ange inget v�rde f�r id.
--      Ange en ny titel f�r namn.
--      
-- Tips: INSERT
------------------------------------------------
INSERT Track 
	([Name], AlbumId, MediaTypeId, GenreId, Composer, Milliseconds, Bytes, UnitPrice, TrackNumber) 
VALUES 
	('My Foo Song', 164, 1, 1, 'Nirvana', 100, 100, 1.99, 2)

------------------------------------------------
-- 122) V�lj f�r- och efternamn p� alla anst�llda och
--      kombinera dem med f�r- och efternamn p� alla kunder
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
-- 123) Lista alla l�tar av Iron Maiden genom 
--      att anv�nda en subquery inom ett IN
--      statement.
--      
-- Tips: SELECT ... WHERE ... IN (SELECT ...)
------------------------------------------------
SELECT * FROM Track
 WHERE AlbumId IN (
	SELECT AlbumId FROM Album WHERE ArtistId = 90
) 

------------------------------------------------
-- 124) Lista alla l�tar med titel, namn p� genre, 
--      namn p� mediatyp samt en siffra p� antal 
--      spellistor som som har l�ten.
--      Sortera i fallande ordning med den l�t som 
--      tillh�r flest spellistor �verst.
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
-- 125) Skapa en ny tabell med resultatet fr�n 
--      f�reg�ende �vning. Anv�nd samma SQL-sats
--      men komplettera SQL-koden s� att tabellen
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
-- 126) Ta bort tabellen du skapade i f�rra �vningen
--      
-- Tips: DROP TABLE ...
------------------------------------------------
DROP TABLE MyPlaylistReport
GO

------------------------------------------------
-- 127) Skapa en ny TEMPOR�R tabell p� samma s�tt
--      som i �vning 125. Anv�nd samma SQL-sats
--      men komplettera SQL-koden s� att tabellen
--      skapas.
--      
--      Fundera p� vad som �r skillnaden mellan
--      tabellen i denna �vning och den du skapade
--      i �vning 125.
--      
-- Tips: #MinTabell
------------------------------------------------

------------------------------------------------
-- 128) Uppdatera l�ten du skapade i �vning 121
--      med ett nytt namn.
--
-- Tips: UPDATE ... SET ... WHERE
------------------------------------------------
UPDATE Track 
SET Track.[Name] = 'My updated Foo Song' 
WHERE TrackId = 99999999999999999999


------------------------------------------------
-- 129) Ta bort den l�t du skapade i �vning 121
--      
-- Tips: DELETE ... WHERE ...
------------------------------------------------
DELETE Track WHERE TrackId = 99999999999999999999

------------------------------------------------
-- 130) Skriv en SQL-fr�ga som r�knar 525 upph�jt
--      till 2
--      
-- Tips: POWER
------------------------------------------------
SELECT POWER(525, 2) AS [Upph�jt till]

------------------------------------------------
-- 131) Skriv en SQL-fr�ga som r�knar ut roten
--      ur 275625
--      
-- Tips: SQRT
------------------------------------------------
SELECT SQRT(275625) AS [Roten ur]

------------------------------------------------
-- 132) Skriv en SQL-fr�ga som r�knar ut roten
--      ur 275625
--      
-- Tips: SQRT
------------------------------------------------
SELECT SQRT(275625) AS [Roten ur]

------------------------------------------------
-- 133) Skriv en SQL-fr�ga som r�knar ut 
--      97838 modulus 3
--      
-- Tips: %
------------------------------------------------
SELECT (97838 % 3) AS [Modulus]

------------------------------------------------
-- 134) Skriv en SQL-fr�ga som r�knar ut 
--      logaritmen av 97
--      
-- Tips: LN
------------------------------------------------
SELECT LOG(97) AS [Logaritmen]

------------------------------------------------
-- 134) Skriv en SQL-fr�ga som r�knar ut 
--      exponenten av 3
--      
-- Tips: EXP
------------------------------------------------
SELECT EXP(3) AS [Exponenten]

------------------------------------------------
-- 135) Skriv en SQL-fr�ga som returnerar 
--      det absoluta talet av -123.45678
--      
-- Tips: ABS
------------------------------------------------
SELECT ABS(-123.4567) AS [Absoluta talet]

------------------------------------------------
-- 136) Skriv en SQL-fr�ga som avrundar talet 
--      123.45678 ned�t.
--      
-- Tips: FLOOR
------------------------------------------------
SELECT FLOOR(123.4567) AS [Avrundningen]

------------------------------------------------
-- 137) Skriv en SQL-fr�ga som avrundar talet
--      123.45678 upp�t
--      
-- Tips: CEILING
------------------------------------------------
SELECT CEILING(123.4567) AS [Avrundningen]

------------------------------------------------
-- 138) Skriv en SQL-fr�ga som tar bort whitespace
--      p� f�ljande text:
--      '   Det �r vacker v�der idag     '
--      
-- Tips: TRIM
------------------------------------------------
SELECT TRIM('   Det �r vackert v�der idag.     ') AS [Trimmad text]

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
--      ett datum och s�tt variabeln till detta datum.
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
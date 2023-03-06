# HealthEquity Test

## Excercise 1

### Use Visual Studio 22 & .NET 6.0

- Razor Pages Proyect- CrudSite

- API Rest proyect - VehicleApi

## Excercise 2

### Resolution SQL Query
``` sql
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName, c.Age, o.OrderID, o.DateCreated, MethodPurchase AS Purchase Method, od.ProductNumber, od.ProductOrigin
FROM Customers c
INNER JOIN Orders o ON c.PersonID = o.PersonID
INNER JOIN OrderDetails od ON o.OrderID = od.OrderID
WHERE od.ProductNumber = '1112222333'


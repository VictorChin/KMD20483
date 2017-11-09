

Select SubString(Name,1,1), Sum(ListPrice),Count(ListPrice),Stdev(ListPrice) From SalesLT.Product
Group By SubString(Name,1,1)

# Genii

The DALMAPPER solution is made up of 2 main features.
1. DALX - This is a Data Access Layer with a ORM(Object Rational Mapper) that can be easily used in any application. The goal was to make it plug and play. No need to create a repository pattern and add contect class like EF.

2. GenX - This is a code generator that can be connected to a SQL Server Database to select tables that you want to generate code for. The application lets you generate multiple templates on one table that can be edited and re generated anytime.

# DALX
The DALX library can be implmented on any model/entity of a sql table manually or use the GENX application to generate the table entity with the DALX inherited.

The BaseEntity<T> Class can be used to inherit from DALX. 
  
Constructors
public BaseEntity(){}

public BaseEntity(DBHelper dbHelper){}

public BaseEntity(object id, DBHelper dBHelper = null){} 

Methods
CREATE METHODS
public virtual bool Create();

READ METHODS
public virtual List<T> Read(int SelectTop = 0)
public virtual List<T> Read(List<QueryFilter> filters, int SelectTop = 0)
public virtual List<T> Read(QuerySorter sorter, int SelectTop = 0)
public virtual List<T> Read(List<QueryFilter> filters, SorterCollection sorters, int SelectTop = 0)
public virtual List<T> Read(List<QueryFilter> filters, QuerySorter sorter, int SelectTop = 0)

Update();
public bool Update(DBParameterCollection parameters = null, QueryFilterCollection filters = null)
public bool Update(string column, string value)

Delete();
 public bool Delete()
 public bool DeleteAll()
  
HELPER METHODS
public int Count()
public List<T> Distinct(string identifier)
public bool Exist(string column, string value)

# SETUP

Add the connection string in the app.config file of your Visual Studio C# application to use the DALX library to read and write from the database

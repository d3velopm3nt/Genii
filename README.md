# Genii

The DALMAPPER solution is made up of 2 main features.
1. DALX - This is a Data Access Layer with a ORM(Object Rational Mapper) that can be easily used in any application. The goal was to make it plug and play. No need to create a repository pattern and add contect class like EF.

2. GenX - This is a code generator that can be connected to a SQL Server Database to select tables that you want to generate code for. The application lets you generate multiple templates on one table that can be edited and re generated anytime.

Temlates - This can be any type of text file that you want to generate for selected tables in the database. You can add different keywords in the template file to replace with the correct information.
keywords
[Entity] = The table name selected to generate
[Project] = The current project name to replace in the file
[DateGenerated] = Replaced with the current date and time to show when the file was generated.
[Properties::SnippetFile::SnippetId] = This will loop through all columns of table and replace each column with the snippet specified.


Snippets - This is a piece of code or text that can be injected into a template using the keywords and format.
The snippets can be used to replace properties and extensions in files.
You can add the snippetfile name after the template keyword to identify which snippetfile to use. If there are more than one snippet in the file then you will have to specify the snippnet Id (name) with the snippet format.
To idenitfy the start of the snippet code you need to put -->  and to end <--

There are build in snippet Identifiers for properties and linked properies( tables relationships)
Use snippetId "Property-->" to replace property with snippet
Use snippetId "LinkedProperty-->" to replace relationship property with snippet.


Extensions - This can be used to add snippet code to existing file.
You can add extensions in existing files using adding the extension identifer in brackets, example: [Extensions]

There is an extenions file where all the extensions are listed and path of existing file.
 format: ExtensionID::snippetname:SnippeId (Optional)

# DALX
The DALX library can be implmented on any model/entity of a sql table manually or use the GENX application to generate the table entity with the DALX inherited.

The BaseEntity<T> Class can be used to inherit from DALX. 
  
Constructors
public BaseEntity(){}

public BaseEntity(DBHelper dbHelper){}

public BaseEntity(object id, DBHelper dBHelper = null){} 

Methods

public virtual bool Create();

public virtual List<T> Read(int SelectTop = 0)
  
public virtual List<T> Read(List<QueryFilter> filters, int SelectTop = 0)
  
public virtual List<T> Read(QuerySorter sorter, int SelectTop = 0)
  
public virtual List<T> Read(List<QueryFilter> filters, SorterCollection sorters, int SelectTop = 0)
  
public virtual List<T> Read(List<QueryFilter> filters, QuerySorter sorter, int SelectTop = 0)

public bool Update(DBParameterCollection parameters = null, QueryFilterCollection filters = null)

public bool Update(string column, string value)

 public bool Delete()
 
 public bool DeleteAll()
  
HELPER METHODS

public int Count()

public List<T> Distinct(string identifier)
  
public bool Exist(string column, string value)

# SETUP

Add the connection string in the app.config file of your Visual Studio C# application to use the DALX library to read and write from the database

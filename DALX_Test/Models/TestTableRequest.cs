//Date Createad: 2020/01/07 10:41:05
public class TestTableRequest
{
	public Guid Id {get;set;}
public string Name {get;set;}
public string Description {get;set;}
public string Email {get;set;}
public string Password {get;set;}

	
	public TestTableRequest(TestTable model )
	{
		this.Id = model.Id;
this.Name = model.Name;
this.Description = model.Description;
this.Email = model.Email;
this.Password = model.Password;

	}

}


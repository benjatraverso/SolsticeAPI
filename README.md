# SolsticeAPI
Solstice Exam API - Resolution

This Resolution implements a WebAPI REST in .Net C# that exposes the following Endpoints:
CreateContact - PostMethod: [api/values/RegisterContact]
With a body json like:
{
"Name":"Benjamin Traverso",
"Image":"",
"Email":"benjatraverso@gmail.com",
"BirthDate":"23/08/1986",
"PhoneNumber": "1564387863",
"Address": {
	"Country":"Argentina",
	"CountryCode":23,
	"State":"buenosAires",
	"StateCode":54,
	"City":"BuenosAiresCty",
	"CityCode":19,
	"Street":"FelixDeAmador",
	"AppartmentNumber":2659,
	"AdditionalInfo":"ImmaTeaCup"
	}
}

Retrieve contact record - GetMethod: 
[api/values/5] by id
[api/values/GetUserByEmail/{email}] by email (string)
[api/values/GetUserByPhone/{phone}] by phone number (string)
[api/values] gets all contacts list

Update contact record - PutMethod:
Similar to Post, sends contact information from body and updates information getting the record by id and replacing the data.
[api/values/{id:int}]

Delete a contact record - DeleteMethod:
[api/values/{id:int}] - deletes a record by id

Retrieve all contacts from state or city - GetMethod
[api/values/GetAllFromState/{StateCode:int}] 
[api/values/GetAllFromCity/{CityCode:int}]

The contact Model [Models/Cotnact.cs] is:
public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Company { get; set; }
    public string Image { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public Address Address { get; set; }
}

public class Address
{
    public string Country { get; set; }
    public int CountryCode { get; set; }
    public string State { get; set; }
    public int StateCode { get; set; }
    public string City { get; set; }
    public int CityCode { get; set; }
    public string Street { get; set; }
    public string AppartmentNumber { get; set; }
    public string AdditionalInfo { get; set; }
}

Tested by sending the json through PostMan.com against the API running in localHost (package ready to run at http://localhost:5000/)

The API stores data in Memory for simplicity. I understand this is rarely good enought for a REST API, as the data will be lost in case of an API reset. The most common use is to refactor the "Storage.cs" class to replace the storage in memory for a DataBase access so the information si safely and securely managed.

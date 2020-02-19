namespace Solstice.Controllers
{
    using Newtonsoft.Json;
    using Solstice.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Helper;

    public class ValuesController : ApiController
    {
        // GET api/values/GetAllFromState/{StateCode}
        [HttpGet]
        [AcceptVerbs("Get")]
        [Route("api/values/GetAllFromState/{StateCode}")]
        public string GetAllFromState(int StateCode)
        {
            return JsonConvert.SerializeObject(Storage.GetAllFromState(StateCode));
        }

        // GET api/values/GetAllFromCity/{StateCode}
        [HttpGet]
        [AcceptVerbs("Get")]
        [Route("api/values/GetAllFromCity/{CityCode}")]
        public string GetAllFromCity(int CityCode)
        {
            return JsonConvert.SerializeObject(Storage.GetAllFromCity(CityCode));
        }
        
        // GET api/values
        public string Get()
        {
            return JsonConvert.SerializeObject(Storage.GetAllContacts());
        }

        // GET api/values/GetUserByEmail/{benjatraverso@gmail.com}
        [HttpGet]
        [AcceptVerbs("Get")]
        [Route("api/values/GetUserByEmail/{email}")]
        public string GetUserByEmail(string email)
        {
            return JsonConvert.SerializeObject(Storage.GetContactByEmail(email));
        }

        // GET api/values/GetUserByPhone/{1564387863}
        [HttpGet]
        [AcceptVerbs("Get")]
        [Route("api/values/GetUserByPhone/{phone}")]
        public string GetUserByPhone(string phone)
        {
            return JsonConvert.SerializeObject(Storage.GetContactByPhone(phone));
        }

        // GET api/values/5
        public string Get(int id)
        {
            return JsonConvert.SerializeObject(Storage.GetContactById(id));
        }

        // POST api/values
        [HttpPost]
        [AcceptVerbs("Post")]
        [Route("api/values/RegisterContact")]
        public void RegisterContact([FromBody] Dictionary<string,object> contact)
        {
            var contactInfo = new Contact
            {
                Name = Helper.GetValueForKey(contact, "Name"),
                PhoneNumber = Helper.GetValueForKey(contact, "PhoneNumber"),
                Image = Helper.GetValueForKey(contact, "Image"),
                Email = Helper.GetValueForKey(contact, "Email"),
                Company = Helper.GetValueForKey(contact, "Company"),
                BirthDate = Convert.ToDateTime(Helper.GetValueForKey(contact, "BirthDate"))
            };
            Dictionary<string,Object> address = Helper.GetObjectForId(contact, "Address");
            contactInfo.Address = new Address
            {
                Country = Helper.GetValueForKey(address, "Country"),
                CountryCode = Convert.ToInt32(Helper.GetValueForKey(address, "CountryCode")),
                City = Helper.GetValueForKey(address, "City"),
                CityCode = Convert.ToInt32(Helper.GetValueForKey(address, "CityCode")),
                AppartmentNumber = Helper.GetValueForKey(address, "AppartmentNumber"),
                State = Helper.GetValueForKey(address, "State"),
                StateCode = Convert.ToInt32(Helper.GetValueForKey(address, "StateCode")),
                Street = Helper.GetValueForKey(address, "Street"),
                AdditionalInfo = Helper.GetValueForKey(address, "AdditionalInfo")
            };

            Storage.StoreContact(contactInfo);
        }

        // PUT api/values/5
        public string Put([FromBody]Dictionary<string,object> contact)
        {
            var contactInfo = new Contact
            {
                Id = Convert.ToInt32(Helper.GetValueForKey(contact, "Id")),
                Name = Helper.GetValueForKey(contact, "Name"),
                PhoneNumber = Helper.GetValueForKey(contact, "PhoneNumber"),
                Image = Helper.GetValueForKey(contact, "Image"),
                Email = Helper.GetValueForKey(contact, "Email"),
                Company = Helper.GetValueForKey(contact, "Company"),
                BirthDate = Convert.ToDateTime(Helper.GetValueForKey(contact, "BirthDate"))
            };
            Dictionary<string, Object> address = Helper.GetObjectForId(contact, "Address");
            contactInfo.Address = new Address
            {
                Country = Helper.GetValueForKey(address, "Country"),
                CountryCode = Convert.ToInt32(Helper.GetValueForKey(address, "CountryCode")),
                City = Helper.GetValueForKey(address, "City"),
                CityCode = Convert.ToInt32(Helper.GetValueForKey(address, "CityCode")),
                AppartmentNumber = Helper.GetValueForKey(address, "AppartmentNumber"),
                State = Helper.GetValueForKey(address, "State"),
                StateCode = Convert.ToInt32(Helper.GetValueForKey(address, "StateCode")),
                Street = Helper.GetValueForKey(address, "Street"),
                AdditionalInfo = Helper.GetValueForKey(address, "AdditionalInfo")
            };

            if (Storage.UpdateContact(contactInfo))
            {
                return "OK";
            }
            else
            {
                return "Error";
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            var contact = Storage.GetContactById(id);
            Storage.DeleteContact(contact);
        }
    }
}

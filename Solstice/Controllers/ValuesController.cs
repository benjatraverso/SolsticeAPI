namespace Solstice.Controllers
{
    using Solstice.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class ValuesController : ApiController
    {
        // GET api/values
        public dynamic Get()
        {
            return Storage.GetAllContacts();
        }

        // GET api/values/Benjamin
        public dynamic Get(string name)
        {
            return Storage.GetContactByName(name);
        }

        // GET api/values/5
        public dynamic Get(int id)
        {
            return Storage.GetContactById(id);
        }

        // POST api/values
        [HttpPost]
        [Route("api/values/RegisterContact")]
        public void RegisterContact([FromBody] string contact)
        {
            Console.WriteLine("RegisterContact");
            //Console.WriteLine(contact);
            //https://localhost:44302/api/values/Post/{contact}
            // podría necesitar recibirlos "Frombody" en forma de string (serializado)
            // armar los disccionarios necesarios (por venir de un json, probablemente) para parsear la data del serializado recibido en el body
            // completar el nuevo objeto "contact" con la data que tenga (gran parte de la data podría ser optativa
            // y llamar a StoreContact(value) con el objeto construído
            // por simplicidad asumo que el objeto se recibe con el modelo esperado completo de forma que se obtiene el matching deseado
            //Storage.StoreContact(value);
        }

        // PUT api/values/5
        public void Put([FromBody]Contact value)
        {
            // mismas notas que "post"
            Storage.UpdateContact(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            var contact = Storage.GetContactById(id);
            Storage.DeleteContact(contact);
        }
    }
}

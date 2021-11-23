using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_rest_001.Controllers
{
    [Authorize]
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetId(int id)
        {
            var customerFake = "customer-fake";
            return Ok(customerFake);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var customersFake = new string[] { "customer-1", "customer-2", "customer-3333" };
            return Ok(customersFake);
        }
        [HttpPost]
        
        public IHttpActionResult repitepalabra(string palabra, string buscar)
        {
           string mensaje;

            string frase = palabra; //Cadena
            string[] misplits = frase.Split(new char[] { ' ' }); //Convierte la cadena en array
            int CountItems1 = (from Itempalabra in misplits
                                              where (Itempalabra.ToLower() == buscar)
                                              select Itempalabra).ToList().Count;

            var encontradas =  (from Itempalabra in misplits
                               where (Itempalabra.ToLower() == buscar)
                               select new { 
                                   palabras = Itempalabra, 
                                   contar = Itempalabra.Count()  } ).ToList();

            

            

            if (CountItems1 > 0) 
            {
                string vercadena = "";
                foreach (var x in encontradas)
                {
                    vercadena += x.palabras.ToString() + " - ";                
                }
                mensaje = vercadena + " encontradas " + encontradas.ToList().Count().ToString();
            }
            else
            {
                mensaje = "No se encontro palabras";
            }
           
            
            return Ok(mensaje);
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using api_rest_001.Controllers;


namespace api_rest_001
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services
            //var cors = new EnableCorsAttribute("*", "*", "*", "*");
            //config.EnableCors(cors);
            // Web API routes

            // Configuración y servicios de API web
            
            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);            
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.MessageHandlers.Add(new TokenValidationHandler());
            // HABILITAMOS EL SERIALIZADOR DE XML
            //config.Formatters.XmlFormatter.UseXmlSerializer = true;
            // ELIMINAMOS EL FORMATEADOR DE RESPUESTAS XML
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            // HABILITAMOS EL FORMATEADOR DE RESPUESTAS JSON
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

using ReservBigBird.APIModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ReservBigBird.Controllers
{
    public class ConsumeController : Controller
    {
        // GET: Consume
        public ActionResult Index()
        {
            String response = "";
            var credentials = new NetworkCredential("ac", "123");
            var handler = new HttpClientHandler { Credentials = credentials }; // for validation
                                                                               //    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };// allow domain checker
            using (var client = new HttpClient(handler))
            {
                // Make your request...
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    //HttpResponseMessage message = client.GetAsync("http://retailbiensi.azurewebsites.net/api/Article?customerCode=" + cust_id_Store).Result;
                    //HttpResponseMessage message = client.GetAsync("http://mpos.biensicore.co.id/api/Article?customerCode=" + cust_id_Store).Result;
                    HttpResponseMessage message = client.GetAsync("http://localhost:55637/api/LoginNewTbls").Result;

                   

                    if (message.IsSuccessStatusCode)
                    {
                        var serializer = new DataContractJsonSerializer(typeof(List<Login>));
                        var result = message.Content.ReadAsStringAsync().Result;
                        byte[] byteArray = Encoding.UTF8.GetBytes(result);
                        MemoryStream stream = new MemoryStream(byteArray);
                        List<Login> resultData = serializer.ReadObject(stream) as List<Login>;
                        var aa = resultData.ToList();
                        for(int i = 0; i < resultData.Count; i++)
                        {
                            var bb = resultData[i].username;

                            ViewBag.hasil = "Sukses mendapatkan data";

                            return View();
                        }

                        return View();
                        //====================================================================================

                    }
                    else
                    {
                        return View();
                    }
                    //if(message.)
                    

                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                    return View();
                }
            }


            
        }
    }
}
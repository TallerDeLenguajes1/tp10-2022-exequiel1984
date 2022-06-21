using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using tp10_2022_exequiel1984;
GetListadoCivilizaciones();

static void GetListadoCivilizaciones()
        {
            var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            ListCivilizaciones Civilizaciones;
                            Civilizaciones = JsonSerializer.Deserialize<ListCivilizaciones>(responseBody);
                        
                            foreach ( Civilization Civilizacion in Civilizaciones.Civilizations)
                            {
                              Console.WriteLine("Nombre: " + Civilizacion.Name);    
                            }
                            

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
            }
        }



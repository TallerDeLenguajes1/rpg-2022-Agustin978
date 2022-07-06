using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using JuegoRol.Personaje_modelo;

namespace JuegoRol.funciones_personaje
{
    class Funciones
    {
        public static void SerializeObjectJson(List<Personaje> personajes,string path,string formato)
        {
            string personajesJson = JsonConvert.SerializeObject(personajes.ToArray(), Formatting.Indented); //Identado para el archivo json
            FileStream archivoJson = new FileStream(path+formato, FileMode.OpenOrCreate); //Apertura o creacion del archivo

            using(StreamWriter strWriter = new StreamWriter(archivoJson))
            {
                strWriter.WriteLine(personajesJson);
            }
        }

        public static string GetObjectJsonFromFile(string path, string formato)
        {
            string ObjectJson;
            FileStream archivoJson = new FileStream(path + formato, FileMode.Open);
            using(StreamReader strReader = new StreamReader(archivoJson))
            {
                ObjectJson = strReader.ReadToEnd();
            }
            return ObjectJson;
        }
    }
}

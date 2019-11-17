using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MadMaths
{
    interface IStufe
    {
        List<string> AufgabenListe { get; set; }
       string aufgabenPath { get; set; }
        dynamic RawJson { get; set; }
        string getAufgabenText();
        bool checksSolution();
        void ReadAufgabenJS();
    }

    public class Grundschule : IStufe
    {
        public List<string> AufgabenListe { get; set; } = new List<string>();
        public string aufgabenPath { get; set; } = "../../data/grundschule.json";
        public dynamic RawJson { get; set; }

        public Grundschule()
        {
            ReadAufgabenJS();
        }
        public bool checksSolution()
        {
            return false;
        }

        public string getAufgabenText()
        {
            return "Hello";
        }

        public void ReadAufgabenJS()
        {
            using (StreamReader sr = new StreamReader(aufgabenPath))
            {
                RawJson = JsonConvert.DeserializeObject(sr.ReadToEnd());
            }
            Dictionary<string,dynamic> liste = new Dictionary<string, dynamic>();
            liste = RawJson.ToObject(typeof(Dictionary<string,dynamic>));
            Dictionary<string, string> dic2 = new Dictionary<string, string>();


            foreach (var item in liste)
            {
                AufgabenListe.Add(item.Key);
                dic2 = item.Value.ToObject(typeof(Dictionary<string, string>));
            }
        }
    }
}

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
        public List<string> AufgabenListe { get ; set ; }
        public string aufgabenPath { get; set; } = "data/grundschule.json";
        public dynamic RawJson { get ; set; }

        public bool checksSolution()
        {
            throw new NotImplementedException();
        }

        public string getAufgabenText()
        {
            throw new NotImplementedException();
        }

        public void ReadAufgabenJS()
        {
            using (StreamReader sr = new StreamReader(aufgabenPath))
            {
                RawJson = JsonConvert.DeserializeObject(sr.ReadToEnd());
            }

            foreach (var item in RawJson)
            {
                AufgabenListe.Add(item);
            }

        }
    }
}

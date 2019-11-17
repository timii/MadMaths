using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace MadMaths
{
    public interface IStufe
    {
        List<string> ThemenListe { get; set; }
        Dictionary<string, string> Aufgaben { get; set; }
        Uri aufgabenPath { get; set; }
        dynamic RawJson { get; set; }
        string getAufgabenText();
        bool checksSolution();
        void ReadAufgabenJS();
    }

    public class Grundschule : IStufe
    {
        public List<string> ThemenListe { get; set; } = new List<string>();
        public Dictionary<string, string> Aufgaben { get; set; } = new Dictionary<string, string>();
        public Uri aufgabenPath { get; set; } = new Uri("MadMaths;component/data/grundschule.json", UriKind.Relative);
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
            return Aufgaben["Addieren1"];
        }

        public void ReadAufgabenJS()
        {
            var streamResourceInfo = Application.GetResourceStream(aufgabenPath);
            using (StreamReader sr = new StreamReader(streamResourceInfo.Stream))
            {
                RawJson = JsonConvert.DeserializeObject(sr.ReadToEnd());
            }
            Dictionary<string, dynamic> ThemenNamen = new Dictionary<string, dynamic>();
            ThemenNamen = RawJson.ToObject(typeof(Dictionary<string, dynamic>));

            foreach (var item in ThemenNamen)
            {
                ThemenListe.Add(item.Key);
                Dictionary<string, string> temp = item.Value.ToObject(typeof(Dictionary<string, string>));
                Aufgaben = Aufgaben.Union(temp).ToDictionary(pair => pair.Key, pair => pair.Value);     // fügt die Aufgaben aus der json hinzu
            }
        }
    }

    public class Mittelstufe : IStufe
    {
        public List<string> ThemenListe { get; set; } = new List<string>();
        public Dictionary<string, string> Aufgaben { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, List<string>> Gleichungssysteme = new Dictionary<string, List<string>>();
        public Uri aufgabenPath { get; set; } = new Uri("MadMaths;component/data/mittelstufe.json", UriKind.Relative);
        public dynamic RawJson { get; set; }

        public Mittelstufe()
        {
            ReadAufgabenJS();
        }

        public bool checksSolution()
        {
            return false;
        }

        public string getAufgabenText()
        {
            return "hell, my old friend";
        }

        public void ReadAufgabenJS()
        {
            var streamResourceInfo = Application.GetResourceStream(aufgabenPath);
            using (StreamReader sr = new StreamReader(streamResourceInfo.Stream))
            {
                RawJson = JsonConvert.DeserializeObject(sr.ReadToEnd());
            }
            Dictionary<string, dynamic> ThemenNamen = new Dictionary<string, dynamic>();
            ThemenNamen = RawJson.ToObject(typeof(Dictionary<string, dynamic>));

            foreach (var item in ThemenNamen)
            {
                ThemenListe.Add(item.Key);
                if (item.Key == "Gleichungssysteme2x2")
                {
                    Gleichungssysteme = item.Value.ToObject(typeof(Dictionary<string, List<string>>));
                }
                else
                {
                    Dictionary<string, string> temp = item.Value.ToObject(typeof(Dictionary<string, string>));
                    Aufgaben = Aufgaben.Union(temp).ToDictionary(pair => pair.Key, pair => pair.Value);     // fügt die Aufgaben aus der json hinzu
                }
            }
        }
    }

    public class Oberstufe : IStufe
    {
        public List<string> ThemenListe { get; set; } = new List<string>();
        public Dictionary<string, string> Aufgaben { get; set; } = new Dictionary<string, string>();
        public Uri aufgabenPath { get; set; } = new Uri("MadMaths;component/data/oberstufe.json", UriKind.Relative);
        public dynamic RawJson { get; set; }

        public bool checksSolution()
        {
            return false;
        }

        public string getAufgabenText()
        {
            throw new NotImplementedException();
        }

        public void ReadAufgabenJS()
        {
            var streamResourceInfo = Application.GetResourceStream(aufgabenPath);
            using (StreamReader sr = new StreamReader(streamResourceInfo.Stream))
            {
                RawJson = JsonConvert.DeserializeObject(sr.ReadToEnd());
            }
            Dictionary<string, dynamic> ThemenNamen = new Dictionary<string, dynamic>();
            ThemenNamen = RawJson.ToObject(typeof(Dictionary<string, dynamic>));

            foreach (var item in ThemenNamen)
            {
                ThemenListe.Add(item.Key);
                Dictionary<string, string> temp = item.Value.ToObject(typeof(Dictionary<string, string>));
                Aufgaben = Aufgaben.Union(temp).ToDictionary(pair => pair.Key, pair => pair.Value);     // fügt die Aufgaben aus der json hinzu
            }
        }
    }
}
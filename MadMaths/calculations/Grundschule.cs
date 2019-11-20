using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace MadMaths.calculations
{
    public interface IStufe
    {
        List<string> ThemenListe { get; set; }
        Dictionary<string, Dictionary<string, string>> Aufgaben { get; set; }
        Uri aufgabenPath { get; set; }
        dynamic RawJson { get; set; }
        string getAufgabenText(string aufgabe);
        bool checksSolution();
        void ReadAufgabenJS();
    }

    public class Grundschule : IStufe
    {
        public List<string> ThemenListe { get; set; } = new List<string>();
        public Dictionary<string, Dictionary<string, string>> Aufgaben { get; set; } = new Dictionary<string, Dictionary<string, string>>();
        public Uri aufgabenPath { get; set; } = new Uri("MadMaths;component/data/grundschule.json", UriKind.Relative);
        public dynamic RawJson { get; set; }
        Random rand;

        public Grundschule()
        {
            ReadAufgabenJS();
            rand = new Random();
        }
        public bool checksSolution()
        {
            return false;
        }

        public string getAufgabenText(string aufgabe)
        {
            return string.Format(Aufgaben[aufgabe].ElementAt(rand.Next(0, Aufgaben[aufgabe].Count)).Value, rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10));
        }

        public void ReadAufgabenJS()
        {
            var streamResourceInfo = Application.GetResourceStream(aufgabenPath);
            using (StreamReader sr = new StreamReader(streamResourceInfo.Stream))
            {
                RawJson = JsonConvert.DeserializeObject(sr.ReadToEnd());
            }
            Aufgaben = RawJson.ToObject(typeof(Dictionary<string, Dictionary<string, string>>));

            foreach (var item in Aufgaben)
            {
                ThemenListe.Add(item.Key);
                //Dictionary<string, string> temp = item.Value.ToObject(typeof(Dictionary<string, string>));
                //Aufgaben = Aufgaben.Union(temp).ToDictionary(pair => pair.Key, pair => pair.Value);     // fügt die Aufgaben aus der json hinzu
            }
        }
    }
}

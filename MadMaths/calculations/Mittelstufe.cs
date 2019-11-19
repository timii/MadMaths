using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace MadMaths.calculations
{
    public class Mittelstufe : IStufe
    {
        public List<string> ThemenListe { get; set; } = new List<string>();
        public Dictionary<string, Dictionary<string, string>> Aufgaben { get; set; } = new Dictionary<string, Dictionary<string, string>>();
        public Dictionary<string, List<string>> Gleichungssysteme = new Dictionary<string, List<string>>();
        public Uri aufgabenPath { get; set; } = new Uri("MadMaths;component/data/mittelstufe.json", UriKind.Relative);
        public dynamic RawJson { get; set; }
        Random rand;

        public Mittelstufe()
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
            if (aufgabe == "Gleichungssysteme2x2")
            {
                int r = rand.Next(0, Gleichungssysteme.Count);
                return Gleichungssysteme.ElementAt(r).Value[0] + Environment.NewLine + Gleichungssysteme.ElementAt(r).Value[1];
            }
            else
            {
                //return Aufgaben[aufgabe].ElementAt(rand.Next(0, Aufgaben[aufgabe].Count)).Value;
                return string.Format(Aufgaben[aufgabe].ElementAt(rand.Next(0, Aufgaben[aufgabe].Count)).Value, rand.Next(0, 10), rand.Next(0, 10), rand.Next(0, 10), rand.Next(0, 10), rand.Next(0, 10), rand.Next(0, 10));
            }
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
                    //Dictionary<string, string> temp = item.Value.ToObject(typeof(Dictionary<string, string>));
                    //Aufgaben = Aufgaben.Union(temp).ToDictionary(pair => pair.Key, pair => pair.Value);     // fügt die Aufgaben aus der json hinzu
                    Aufgaben.Add(item.Key, item.Value.ToObject(typeof(Dictionary<string, string>)));
                }
            }
        }
    }
}

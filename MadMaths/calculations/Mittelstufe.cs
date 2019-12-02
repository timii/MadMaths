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
        public object[] AufgabenZahlen { get; set; }
        public string AufgabenKey { get; set; }

        public Mittelstufe()
        {
            ReadAufgabenJS();
            rand = new Random();
        }

        public bool checksSolution(in object BenutzerLösung, out string Lösung)
        {
            var AufgabenFunc = CalcFunctions_Mittelstufe.ms_funcs[AufgabenKey];
            Lösung = AufgabenFunc.DynamicInvoke(AufgabenZahlen).ToString().Replace(" ", string.Empty);
            if (Lösung.ToString() == BenutzerLösung.ToString())
            {
                return true;
            }
            return false;
        }

        public string getAufgabenText(string aufgabe)
        {
            AufgabenZahlen = null;
            if (aufgabe == "Gleichungssysteme2x2")
            {
                var randIndex = rand.Next(0, Gleichungssysteme.Count);
                AufgabenKey = Gleichungssysteme.ElementAt(randIndex).Key;
                aufgabe = Gleichungssysteme.ElementAt(randIndex).Value[0] + Environment.NewLine + Gleichungssysteme.ElementAt(randIndex).Value[1];
                var argsNum = System.Text.RegularExpressions.Regex.Matches(aufgabe, "{").Count;
                AufgabenZahlen = new object[argsNum];
                for (int i = 0; i < argsNum; i++)
                {
                    AufgabenZahlen[i] = (double)rand.Next(1, 100);
                }
                return string.Format(aufgabe, AufgabenZahlen.Select(x => x.ToString()).ToArray());
            }
            else
            {
                var randIndex = rand.Next(0, Aufgaben[aufgabe].Count);
                AufgabenKey = Aufgaben[aufgabe].ElementAt(randIndex).Key;
                aufgabe = Aufgaben[aufgabe].ElementAt(randIndex).Value;
                var argsNum = System.Text.RegularExpressions.Regex.Matches(aufgabe, "{").Count;
                AufgabenZahlen = new object[argsNum];
                for (int i = 0; i < argsNum; i++)
                {
                    AufgabenZahlen[i] = rand.Next(1, 100);
                }
                return string.Format(aufgabe, AufgabenZahlen.Select(x => x.ToString()).ToArray());
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

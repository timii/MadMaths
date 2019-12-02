using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace MadMaths.calculations
{
    public class Oberstufe : IStufe
    {
        public List<string> ThemenListe { get; set; } = new List<string>();
        public Dictionary<string, Dictionary<string, string>> Aufgaben { get; set; } = new Dictionary<string, Dictionary<string, string>>();
        public Uri aufgabenPath { get; set; } = new Uri("MadMaths;component/data/oberstufe.json", UriKind.Relative);
        public dynamic RawJson { get; set; }
        public object[] AufgabenZahlen { get; set; }
        public string AufgabenKey { get; set; }

        Random rand = new Random();

        public Oberstufe()
        {
            ReadAufgabenJS();
            rand = new Random();
        }

        public bool checksSolution(in object BenutzerLösung, out string Lösung)
        {
            var AufgabenFunc = CalcFunctions_Oberstufe.os_funcs[AufgabenKey];
            Lösung = AufgabenFunc.DynamicInvoke(AufgabenZahlen).ToString().Replace(" ", string.Empty);
            if (Lösung.ToString().Replace(" ", string.Empty) == BenutzerLösung.ToString().Replace(" ", string.Empty))
            {
                return true;
            }
            return false;
        }

        public string getAufgabenText(string aufgabe)
        {
            AufgabenZahlen = null;
            var randIndex = rand.Next(0, Aufgaben[aufgabe].Count);
            AufgabenKey = Aufgaben[aufgabe].ElementAt(randIndex).Key;
            aufgabe = Aufgaben[aufgabe].ElementAt(randIndex).Value;
            var argsNum = System.Text.RegularExpressions.Regex.Matches(aufgabe, "{").Count;
            AufgabenZahlen = new object[argsNum];
            for (int i = 0; i < argsNum; i++)
            {
                AufgabenZahlen[i] = rand.Next(1, 10);
            }
            return string.Format(aufgabe, AufgabenZahlen.Select(x => x.ToString()).ToArray());
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

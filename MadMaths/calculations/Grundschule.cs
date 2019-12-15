using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace MadMaths.calculations
{
    public interface IStufe
    {
        /// <summary>
        /// Interface für die Schnittstellen für die Darstellung und Bearbeitung der Aufgaben.
        /// </summary>

        // hier werden die Namen der Themen gespeichert, die später zur Erzeugung der Buttons verwendet werden
        List<string> ThemenListe { get; set; }
        // hier werden die Aufgaben als Dictionary gespeichert, Key(Themenname): Value(Key:AufgabenText)
        Dictionary<string, Dictionary<string, string>> Aufgaben { get; set; }
        Uri aufgabenPath { get; set; }
        // speichert die Json ungeparst
        dynamic RawJson { get; set; }
        string getAufgabenText(string aufgabe);
        bool checksSolution(in object Benutzerlösung, out string Lösung);
        void ReadAufgabenJS();
        // wird zur Speicherung der random erzeugten Zahlen verwendet
        object[] AufgabenZahlen { get; set; }
        string AufgabenKey { get; set; }
    }

    public class Grundschule : IStufe
    {
        public List<string> ThemenListe { get; set; } = new List<string>();
        public Dictionary<string, Dictionary<string, string>> Aufgaben { get; set; } = new Dictionary<string, Dictionary<string, string>>();
        public Uri aufgabenPath { get; set; } = new Uri("MadMaths;component/data/grundschule.json", UriKind.Relative);
        public dynamic RawJson { get; set; }
        Random rand;
        public object[] AufgabenZahlen { get; set; }
        // der spezifische Schlüssel jeder Aufgabe
        public string AufgabenKey { get; set; }

        public Grundschule()
        {
            ReadAufgabenJS();
            rand = new Random();
        }
        public bool checksSolution(in object BenutzerLösung, out string Lösung)
        {
            if (AufgabenKey == "Groesser" || AufgabenKey == "Kleiner")
            {
                Lösung = null;
                bool LösungAngegeben = Int32.TryParse(BenutzerLösung as string,out int benutzerlösung);
                if (LösungAngegeben)
                {
                    if (AufgabenKey == "Groesser") { return CalcFunctions_Grundschule.GroesserKleiner2(Convert.ToInt32(AufgabenZahlen[0]), benutzerlösung); }
                    else { return CalcFunctions_Grundschule.GroesserKleiner2(benutzerlösung, Convert.ToInt32(AufgabenZahlen[0])); }
                }
                else { return false; }
            }
            var AufgabenFunc = CalcFunctions_Grundschule.gs_funcs[AufgabenKey];
            Lösung = AufgabenFunc.DynamicInvoke(AufgabenZahlen).ToString().Replace(" ", string.Empty);

            if (Lösung == BenutzerLösung.ToString().Replace(" ", string.Empty))
            {
                return true;
            }
            return false;
        }

        public string getAufgabenText(string aufgabe)
        {
            var aufgabe_real = aufgabe;
            AufgabenZahlen = null;
            var randIndex = rand.Next(0, Aufgaben[aufgabe].Count);
            AufgabenKey = Aufgaben[aufgabe].ElementAt(randIndex).Key;
            aufgabe = Aufgaben[aufgabe].ElementAt(randIndex).Value;
            var argsNum = Regex.Matches(aufgabe, @"{[0-9]+}").OfType<Match>().Select(m => m.Value).Distinct().Count();      // gibt einzigartige Übereinstimmungen zurück 
            AufgabenZahlen = randnumbers.Zahlen(argsNum, aufgabe_real, AufgabenKey);
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
            }
        }
    }
}

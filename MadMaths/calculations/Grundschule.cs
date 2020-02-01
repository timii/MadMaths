using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace MadMaths.calculations
{
    /// <summary>
    /// Interface für die Schnittstellen für die Darstellung und Bearbeitung der Aufgaben.
    /// </summary>
    public interface IStufe
    {
        /// <summary>
        /// hier werden die Namen der Themen gespeichert, die später zur Erzeugung der Buttons verwendet werden
        /// </summary>
        List<string> ThemenListe { get; set; }
        /// <summary>
        /// hier werden die Aufgaben als Dictionary gespeichert, Key(Themenname): Value(Key:AufgabenText)
        /// </summary>
        Dictionary<string, Dictionary<string, string>> Aufgaben { get; set; }
        Uri aufgabenPath { get; set; }
        /// <summary>
        /// speichert das JObject
        /// </summary>
        dynamic RawJson { get; set; }
        /// <summary>
        /// stellt den Aufgabentext zur Verfügung; fügt ggf. zufällige Zahlen hinzu
        /// </summary>
        /// <param name="aufgabe">Name des ausgewählten Themas</param>
        /// <returns>fertiger Aufgabentext</returns>
        string getAufgabenText(string aufgabe);
        /// <summary>
        /// Vergleicht die Benutzerlösung mit der berechneten Lösung
        /// </summary>
        /// <param name="Benutzerlösung">Die vom Benutzer eingegebene Lösung</param>
        /// <param name="Lösung">Die von den Funktionen berechnete Lösung</param>
        /// <returns>true, wenn Benutzerlösung richtig, sonst false</returns>
        bool checksSolution(in object Benutzerlösung, out string Lösung);
        void ReadAufgabenJS();
        object[] AufgabenZahlen { get; set; } // wird zur Speicherung der random erzeugten Zahlen verwendet
    }

    public class Grundschule : IStufe
    {
        public List<string> ThemenListe { get; set; } = new List<string>();
        public Dictionary<string, Dictionary<string, string>> Aufgaben { get; set; } = new Dictionary<string, Dictionary<string, string>>();
        public Uri aufgabenPath { get; set; } = new Uri("MadMaths;component/data/grundschule.json", UriKind.Relative);
        public dynamic RawJson { get; set; }
        Random rand;
        public object[] AufgabenZahlen { get; set; }

        public Grundschule()
        {
            ReadAufgabenJS();
            rand = new Random();
        }
        public bool checksSolution(in object BenutzerLösung, out string Lösung)
        {
            if (Controller.currentExercise == "Groesser" || Controller.currentExercise == "Kleiner")
            // Sonderbehandlung der Aufgabe, da man die Benutzerlösung an die Rechnungsfunktion weitergeben muss
            {
                Lösung = null;
                bool LösungAngegeben = Int32.TryParse(BenutzerLösung as string, out int benutzerlösung);
                if (LösungAngegeben)
                {
                    if (Controller.currentExercise == "Groesser") { return CalcFunctions_Grundschule.GroesserKleiner2(Convert.ToInt32(AufgabenZahlen[0]), benutzerlösung); }
                    else { return CalcFunctions_Grundschule.GroesserKleiner2(benutzerlösung, Convert.ToInt32(AufgabenZahlen[0])); }
                }
                else { return false; }
            }
            var AufgabenFunc = CalcFunctions_Grundschule.gs_funcs[Controller.currentExercise];
            Lösung = AufgabenFunc.DynamicInvoke(AufgabenZahlen).ToString();

            if (Lösung.Replace(" ", string.Empty).ToLower() == BenutzerLösung.ToString().Replace(" ", string.Empty).ToLower())
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
            Controller.currentExercise = Aufgaben[aufgabe].ElementAt(randIndex).Key;
            aufgabe = Aufgaben[aufgabe].ElementAt(randIndex).Value;
            var argsNum = Regex.Matches(aufgabe, @"{[0-9]+}").OfType<Match>().Select(m => m.Value).Distinct().Count();      // gibt einzigartige(unique) Übereinstimmungen zurück 
            if (argsNum == 0) return aufgabe;
            AufgabenZahlen = randnumbers.Zahlen(argsNum, aufgabe_real, Controller.currentExercise);
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

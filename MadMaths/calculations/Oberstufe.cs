﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace MadMaths.calculations
{
    public class Oberstufe : IStufe
    {
        public List<string> ThemenListe { get; set; } = new List<string>();
        public Dictionary<string, Dictionary<string, string>> Aufgaben { get; set; } = new Dictionary<string, Dictionary<string, string>>();
        public Uri aufgabenPath { get; set; } = new Uri("MadMaths;component/data/oberstufe.json", UriKind.Relative);
        public dynamic RawJson { get; set; }
        public object[] AufgabenZahlen { get; set; }
        Random rand = new Random();

        public Oberstufe()
        {
            ReadAufgabenJS();
            rand = new Random();
        }

        public bool checksSolution(in object BenutzerLösung, out string Lösung)
        {
            var AufgabenFunc = CalcFunctions_Oberstufe.os_funcs[Controller.currentExercise];
            Lösung = AufgabenFunc.DynamicInvoke(AufgabenZahlen).ToString();
            //var ArrayToString = AufgabenFunc.DynamicInvoke(AufgabenZahlen);
            string[] Loesungs_seperator = Lösung.Split(' ');
            string[] User_seperator = BenutzerLösung.ToString().Split(' ');
            bool vergleich = Enumerable.SequenceEqual(Loesungs_seperator.OrderBy(x => x), User_seperator.OrderBy(x => x));

            if (vergleich)
            {
                return true;
            }

            //if (Lösung.Replace(" ", string.Empty).ToLower() == BenutzerLösung.ToString().Replace(" ", string.Empty).ToLower())
            //{
            //    return true;
            //}
            return false;
        }

        public string getAufgabenText(string aufgabe)
        {
            var aufgabe_real = aufgabe;

            AufgabenZahlen = null;
            var randIndex = rand.Next(0, Aufgaben[aufgabe].Count);
            Controller.currentExercise = Aufgaben[aufgabe].ElementAt(randIndex).Key;
            aufgabe = Aufgaben[aufgabe].ElementAt(randIndex).Value;
            var argsNum = Regex.Matches(aufgabe, @"{[0-9]+}").OfType<Match>().Select(m => m.Value).Distinct().Count();
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

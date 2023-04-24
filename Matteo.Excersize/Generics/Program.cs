using System;
using System.Text;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            /*DataStore<Person> datastore = new DataStore<Person>();
           datastore.printProperties(new Person());*/

            #region object Person
            Person CarloCracco = new Person()  {Name = "Carlo", Surname = "Cracco", cf = "90C4C432DDJ", age = 58};
            Person BrunoBarbieri = new Person() { Name = "Bruno", Surname = "Barbieri", cf = "SASA232K39CM", age = 61};
            Person AntonioCannavacciuolo = new Person() { Name = "Antonio", Surname = "Cannavacciuolo", cf = "KM08MGFK4389", age = 48};
            #endregion

            azienda swuiefhw = new azienda() { iva = "Q" };
            
            List<Person> person = new List<Person>()
            {
                CarloCracco,
                BrunoBarbieri,
                AntonioCannavacciuolo
            };

            string filepath = @"f:\person.csv";
            Console.WriteLine($"Elimino il file {filepath}\n");
            TextFileGenerator.Savetofile(person, filepath);
            Thread.Sleep(800);
            var listaGiusta = TextFileGenerator.ReadFromFile<Person>(filepath);
            var listaSbagliata = TextFileGenerator.ReadFromFile<azienda>(filepath);
            Console.WriteLine($"Lettura del file {filepath} in corso......\n");

            #region listaGiusta
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Questo serve per visualizzare la lista giusta");
            Console.ResetColor();
            if (listaGiusta != null)
            {               
                Console.WriteLine($"L'elenco della lista sul file {filepath}: \n");
                Thread.Sleep(1000);
                for (int i = 0; i < listaGiusta.Count; i++)
                {
                    Console.WriteLine($"{listaGiusta[i].Name} {listaGiusta[i].Surname} {listaGiusta[i].cf} {listaGiusta[i].age}");
                }
            }
            else Console.WriteLine($"Questo file non è corretto");

            #endregion

            Console.WriteLine("----------------------------------------------------------------\n");

            #region listasbagliata
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Questo serve per visualizzare l'errore, quando la lista restituisce NULL\n");
            Console.ResetColor();
            if (listaSbagliata != null)
            {
                Console.WriteLine($"L'elenco della lista sul file {filepath}: \n");
                Thread.Sleep(1000);
                for (int i = 0; i < listaSbagliata.Count; i++)
                {
                    Console.WriteLine($"{listaSbagliata[i].iva}");
                }
            }
            else Console.WriteLine("Il file non esiste");
            #endregion

            Console.Read();
        }


        public class DataStore<T> where T : class, new()// t è convenzionale. sta per Type
        {
            static int _index = 4;
            public T[] _data = new T[_index];
            static T entry = new T();

            public void add(T person)
            {

            }
            public void remove(T items)
            {
                if (_data[_data.Length - 1] != null) getMoreSpace();
                var element = Array.IndexOf(_data, Array.Find(_data, x => x == null));
                _data[element] = items;

            }

            public void getMoreSpace()
            {
                T[] _nextData = new T[_data.Length + 4];
                Array.Copy(_data, _nextData, _data.Length);
                _data = _nextData;
            }

            public void printProperties(T person)
            {
                var campi = person.GetType().GetProperties();
                foreach (var prop in campi)
                {
                    Console.WriteLine(prop.Name);// nome della property / campo 

                }
            }
        }

        public static class TextFileGenerator
        {
            public static void Savetofile<T>(List<T> data, string filePath)
            {
                StringBuilder line = new StringBuilder();
                var cols = data[0].GetType().GetProperties();

                if (!File.Exists(filePath)) appendText(cols, line, data, filePath);
                else
                {
                    var rows = File.ReadAllLines(filePath);
                    var header = rows[0].Split(",");
                    if (header.Length != cols.Length)
                    {
                        File.WriteAllText(filePath, String.Empty);
                        appendText(cols, line, data, filePath);
                    }
                    
                }
                                
                Console.WriteLine($"Creato il file {filePath}");
                Console.WriteLine($"-----------------------------------------------\n");
            }

            private static void appendText<T>(PropertyInfo[] cols, StringBuilder line, List<T> data, string filepath)
            {
                foreach (var col in cols)
                {
                    if (col != cols.Last()) line.Append(string.Format($"{col.Name},"));
                    else line.Append(string.Format($"{col.Name}"));
                    
                }
                File.AppendAllText(filepath, line.ToString());
                foreach (var row in data)
                {
                    line = new StringBuilder();
                    line.AppendLine();

                    foreach (var col in cols)
                    {
                        string value = col.GetValue(row).ToString();
                        if (col != cols.Last()) line.Append(string.Format($"{value},"));
                        else line.Append(string.Format($"{value}"));
                    }
                    File.AppendAllText(filepath, line.ToString());
                }
                
            }

            public static List<T> ReadFromFile<T>(string filePath) where T : class, new()
            {
                T data = new T(); // creo l'istanzia di tipo T
                var cols = data.GetType().GetProperties(); // prende solo le proprietà dell'oggetto T
                string[] rows = File.ReadAllLines(filePath);// legge dal file e lo inserisce nell'array in ogni elemento ogni riga
                string[] header = rows[0].Split(",");// l'header è un array di stringhe, che prende solo la prima riga e lo splitta con il separatore ","

                List<string> listHeader = new List<string>();// si crea una nuova lista per recuperare le proprietà di header

                foreach (var col in cols)
                {
                    listHeader.Add(col.Name);// si aggiunge alla lista i nomi dell proprietà dell'header
                }

                for (int i = 0; i < header.Length; i++)
                {
                    if (listHeader.Contains(header[i])) continue;
                    else return null;
                }

                List<T> listObject = new List<T>(); // si crea un'altra lista per essere aggiunto con le variabili e le sue proprietà

                foreach (var row in rows)
                {
                    if (row == rows.First()) continue; // evitiamo che prende l'header (che non fa parte dell'oggetto)

                    data = new T();
                    string[] vals = row.Split(","); // splitta ogni riga in ogni elemento dell'array
                    for (int i = 0; i < header.Length; i++) //Questo ciclo serve per convertire il valore della riga (che abbiamo splittato) da string alla sua proprietà per poi aggiungere alla lista.
                    {
                        var convertedValue = Convert.ChangeType(vals[i], cols[i].PropertyType); // in questa fase fa la conversione
                        data.GetType().GetProperty(cols[i].Name).SetValue(data, convertedValue);
                        //Qui lo setta all'oggetto: data.GetType().GetProperty(cols[i].Name) è come dire che: data.Name
                    }
                    listObject.Add(data);// aggiunge alla lista l'oggetto con le sue proprietà
                }
                return listObject; // ritorna la lista
            }
        }
        public class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string cf { get; set; }
            public int age { get; set; }
            //public string alla { get; set; }
        }
        public class azienda
        {
            public string iva;
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataBinding_TRPO
{
    class WageList
    {
        public List<Wage> wages = new List<Wage>();

        public void Save(string fileName)
        {
            string jsonString = JsonSerializer.Serialize(wages);

            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.WriteLine(jsonString);
            }

        }

        public void Load(string fileName)
        {
            using (StreamReader sr = File.OpenText(fileName))
            {
                string jsonString = sr.ReadToEnd();


                List<Wage>? wagesLoaded = JsonSerializer.Deserialize<List<Wage>>(jsonString);

                if (wagesLoaded.Count > 0 && wagesLoaded != null)
                {
                    wages.Clear();
                    for (int i = 0; i < wagesLoaded.Count; i++)
                    {
                        wages.Add(wagesLoaded[i]);
                    }
                }
            }
        }

        public Wage Search(int id) 
        {
            foreach (var item in wages)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}

using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System.Text.Json;
namespace MyApp 
{
    internal class Program
    {
 

        static void Main(string[] args)
        {
            
            string path_to_slovarik = "slovarik";
            string path_to_save_slovarik = "save";
            var slovarik=new Dictionary<string, List<string>>();
            if (IsFileEmpty(path_to_save_slovarik))
            {
                 //slovarik = new Dictionary<string, List<string>>();
            }
            else
            {
              

                slovarik = ReadFromFile(path_to_save_slovarik);
                foreach (KeyValuePair<string, List<string>> pair in slovarik)
                {
                    Console.WriteLine("Key: " + pair.Key);
                    Console.WriteLine("Values: " + string.Join(", ", pair.Value));
                    Console.WriteLine();
                }
            }

            static Dictionary<string, List<string>> ReadFromFile(string path_to_save_slovarik)
            {
                string json = File.ReadAllText(path_to_save_slovarik);
                Dictionary<string, List<string>> slovarik = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);

                return slovarik;
            }
           
            //string str;
            Console.WriteLine("0 add 1 reser 2 remove 3 save dictionary 4 save string ");
            Console.WriteLine("input key string");
            while (true)
            {
                var cs = Console.ReadLine();
                int cas = Convert.ToInt32(cs);
                switch (cas)
                {
              
                    case 0:
                        string key=Console.ReadLine();
                        List<string> perevod = new List<string>();
                        perevod.Add(Console.ReadLine());
                        slovarik.Add(key, perevod);
                        break;
                    case 1:
                        string key_reset = Console.ReadLine();
                        List<string> slova;
                        slovarik.TryGetValue(key_reset, out slova);
                        string sl = Console.ReadLine();
                        slova.Add(sl);
                        slovarik[key_reset] = slova;
                        break;
                    case 2:
                        string key_remove = Console.ReadLine();
                        List<string> slova_remove;
                        slovarik.TryGetValue(key_remove, out slova_remove);
                        string sl_remove = Console.ReadLine();
                        slova_remove.Remove(sl_remove);
                        if (slova_remove.Count()==0) slovarik.Remove(key_remove);
                        slovarik[key_remove] = slova_remove;
                        break;
                    case 3:
                        using (StreamWriter writer = new StreamWriter(path_to_save_slovarik))
                        {
                            foreach (var item in slovarik)
                            {
                                writer.WriteLine(item.Key + "," + item.Value);
                            }
                        }
                        break;
                    case 4:
                        using (StreamWriter writer = new StreamWriter(path_to_slovarik))
                        {
                            var key_save= Console.ReadLine();
                            writer.Write("myFile.txt", slovarik, key_save);
                        }
                        break;
                }
            }
        }

        private static bool IsFileEmpty(string path_to_save_slovarik)
        {
            throw new NotImplementedException();
        }
    }
}
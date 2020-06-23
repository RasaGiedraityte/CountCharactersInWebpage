using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Net.Http;




namespace EntryTaskCodingSchool
{
    class Program
    {
        static void Main()
        {
            //ask user to enter web page link and read it
            Console.Write("Enter web page link, for example http://google.com: ");
            string input = Console.ReadLine();
            var html = new System.Net.WebClient().DownloadString(input);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //if file exists,delete it
            if (System.IO.File.Exists(path + @"\WriteText.txt"))
            {
                System.IO.File.Delete(path + @"\WriteText.txt");
            }

            using (System.IO.StreamWriter file = System.IO.File.AppendText(path + @"\WriteText.txt"))
            {
                var CharC = html.ToLookup(c => c);
                foreach (var c in CharC)
                {
                    //file.Write("Char:{0} Count:{1}", c.Key, CharC[c.Key].Count() + Environment.NewLine);
                    file.Write(c.Key.ToString() + " = " + CharC[c.Key].Count() + Environment.NewLine);
                }
            }

            Console.WriteLine("Done. File saved to: " + path + @"\WriteText.txt");
            Console.WriteLine("Press Enter to exit");
            Console.ReadKey();
        }

    }
}

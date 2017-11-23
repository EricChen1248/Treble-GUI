using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Treble_GUI.Classes.Exceptions;
using Treble_GUI.Properties;

namespace Treble_GUI.Classes
{
    internal static class Server
    {
        private const string ServerLocation = "Database/";

        /// <summary>
        /// Pulls the data from file in a Dictionary of Lists with headers as keys
        /// </summary>
        /// <param name="dataBaseName"></param>
        /// <returns></returns>
        public static Dictionary<string, List<string>> GetDatabase(string dataBaseName)
        {
            var results = new Dictionary<string, List<string>>();
            using( var sr = new StreamReader(ServerLocation + dataBaseName + ".txt"))
            {
                // Read in headers for database
                var firstLine = sr.ReadLine()?.Split(',');
                var headers = new List<string>();

                if (firstLine == null)
                    throw new DatabaseError();
                foreach (var s in firstLine)
                {
                    if (s == "")
                        continue;

                    results[s] = new List<string>();
                    headers.Add(s);
                }

                // Read in the rest of database until end
                while (sr.EndOfStream == false)
                {
                    var line = sr.ReadLine()?.Split(',');

                    for (var i = 0; i < headers.Count; i++)
                    {
                        if (line == null)
                            throw new DatabaseError();

                        results[headers[i]].Add(line[i]);
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Saves data to dataFile with the original data. Order doesn't matter as headers are hashed.
        /// </summary>
        /// <param name="dataBaseName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool SaveToDatabase(string dataBaseName, Dictionary<string, List<string>> data)
        {
            var headers = data.Select(pair => pair.Key).ToList();

            // Add headers to dataFile holder
            var dataFile = headers.Aggregate("", (current, header) => current + (header + ","));
            dataFile += "\n";


            // Add line by line in order of headers to dataFile holder
            for (var i = 0; i < data[headers[0]].Count; i++)
            {
                dataFile = headers.Aggregate(dataFile, (current, header) => current + (data[header][i] + ","));
                dataFile += "\n";
            }

            var attempts = 0;
            while (attempts < 10)
            {
                try
                {

                    using (var sw = new StreamWriter(ServerLocation + dataBaseName + ".txt", false))
                    {
                        sw.Write(dataFile);
                    }

                    return true;
                }
                catch (IOException)
                {
                    ++attempts;
                    Console.WriteLine(Resources.Database_IOError_with_Attempt_Count, ServerLocation + dataBaseName, attempts);
                }
            }

            return false;
        }
    }
}
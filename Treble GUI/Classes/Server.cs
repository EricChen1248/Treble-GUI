using System;
using System.IO;


internal class Server
{
    private const string serverLocation = "Database/";
    public string GetDatabase(string dataBaseName)
    {
        var results = "";
        using( var sr = new StreamReader(serverLocation + dataBaseName))
        {
            results = sr.ReadToEnd();
        }

        return results;
    }
}
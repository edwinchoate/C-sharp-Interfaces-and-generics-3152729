using System;
using System.Collections.Generic;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args) {
            // Create a Dictionary that maps strings to strings
            Dictionary<string, string> fileTypes = new Dictionary<string, string>();
            // Add some file type extensions and their descriptions
            fileTypes.Add(".txt", "Text File");
            fileTypes.Add(".htm", "HTML Web Page");
            fileTypes.Add(".html", "HTML Web Page");
            fileTypes.Add(".css", "Cascading Style Sheet");
            fileTypes.Add(".xml", "XML Data");

            // TODO: How many key/value pairs are there?
            Console.WriteLine(fileTypes.Count);

            // TODO: try adding an existing key
            try 
            {
                fileTypes.Add(".txt", "Text File 2");
            }
            catch (ArgumentException e) 
            {
                Console.WriteLine("That key is already in the dictionary");
            }

            // TODO: try removing and then finding a key
            fileTypes.Remove(".txt");
            Console.WriteLine("Is .txt in the fileTypes? {0}", fileTypes.ContainsKey(".txt"));

            Console.WriteLine();

            // TODO: Print the contents of the Dictionary
            foreach (KeyValuePair<string, string> kvp in fileTypes) 
            {
                Console.WriteLine("Key: {0}, Value: {0}", kvp.Key, kvp.Value);
            }

            // Console.WriteLine("\nHit Enter to continue...");
            // Console.ReadLine();
        }
    }
}

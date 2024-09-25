using System;
using System.Collections.Generic;

namespace BasicInterfaces
{
    // TODO: Define an IStorable interface that provides the ability to load and
    // save the information for an object
    interface IStorable 
    {
        void Save();
        void Load();
        bool UnsavedChanges { get; set; }
    }

    // TODO: Implement IStorable on the Document class
    class Document : IStorable
    {
        private string name;

        public Document(string s)
        {
            name = s;
            Console.WriteLine("Created a document with name '{0}'", s);
        }

        public bool UnsavedChanges { get; set; }

        // TODO: Implement the IStorable interface methods and properties
        public void Save () 
        {
            Console.WriteLine("The file was saved.");
        }

        public void Load () 
        {
            Console.WriteLine("The file was loaded.");
        }
    }

    class Program
    {
        static void Main(string[] args) {
            Document d = new Document("Test Document");

            // TODO: Exercise the IStorable interface
            d.Load();
            d.Save();
            d.UnsavedChanges = false;

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}

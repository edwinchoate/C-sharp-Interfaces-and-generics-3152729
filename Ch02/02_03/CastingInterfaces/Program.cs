using System;
using System.Collections.Generic;

namespace CastingInterfaces
{
    interface IStorable
    {
        void Save();
        void Load();
        Boolean NeedsSave { get; set; }
    }

    class Document : IStorable
    {
        private string name;

        public Document(string s) {
            name = s;
            Console.WriteLine("Created a document with name '{0}'", s);
        }

        public void Save() {
            Console.WriteLine("Saving the document");
        }

        public void Load() {
            Console.WriteLine("Loading the document");
        }

        public Boolean NeedsSave {
            get; set;
        }
    }

    class Program
    {
        static void Main(string[] args) {
            Document d = new Document("Test Document");

            // TODO: Use the 'is' operator
            if (d is IStorable) 
                d.Save();

            // TODO: Use the 'as' operator
            IStorable i = d as IStorable;
            if (i != null) 
                i.Save();

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}

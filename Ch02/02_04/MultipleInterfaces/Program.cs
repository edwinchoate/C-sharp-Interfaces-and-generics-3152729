using System;
using System.Collections.Generic;

namespace MultipleInterfaces
{
    interface IStorable
    {
        void Save();
        void Load();
        Boolean NeedsSave { get; set; }
    }

    // TODO: Create an IEncryptable interface
    interface IEncryptable 
    {
        void Encrypt();
        void Decrypt();
    }

    // TODO: Implement from both interfaces
    class Document : IStorable, IEncryptable
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

        // TODO: Implement IEncryptable
        public void Encrypt () 
        {
            Console.WriteLine("Encrypting the document");
        }

        public void Decrypt () 
        {
            Console.WriteLine("Decrypting the document");
        }
    }

    class Program
    {
        static void Main(string[] args) {
            Document d = new Document("Test Document");

            // TODO: Exercise the interfaces
            d.Load();
            d.Encrypt();
            d.Save();
            d.Decrypt();

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}

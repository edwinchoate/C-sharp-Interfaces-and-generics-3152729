using System;
using System.Collections.Generic;
// TODO: Include the namespace that contains INotifyPropertyChanged
using System.ComponentModel;

namespace NETInterfaces
{
    interface IStorable
    {
        void Save();
        void Load();
        Boolean NeedsSave { get; set; }
    }

    // TODO: Implement INotifyPropertyChanged
    class Document : IStorable, INotifyPropertyChanged
    {
        private string name;
        private Boolean mNeedsSave = false;

        // TODO: INotifyPropertyChanged requires the implementation of 1 event
        public event PropertyChangedEventHandler PropertyChanged;

        // TODO: Define a utility function to call the PropertyChanged event
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public Document(string s) {
            name = s;
            Console.WriteLine("Created a document with name '{0}'", s);
        }

        public string DocName {
            get { return name; }
            set { 
                name = value;
                NotifyPropertyChanged("DocName");
            }
        }

        public void Save() {
            Console.WriteLine("Saving the document");
        }

        public void Load() {
            Console.WriteLine("Loading the document");
        }

        public Boolean NeedsSave {
            get { return mNeedsSave; }
            set { 
                mNeedsSave = value;
                NotifyPropertyChanged("NeedsSave");
            }
        }
    }

    class Program
    {
        static void Main(string[] args) {
            Document d = new Document("Test Document");

            // TODO: implement a delegate to handle the PropertyChanged event
            d.PropertyChanged += (object sender, PropertyChangedEventArgs e) => {
                Console.WriteLine($"{e.PropertyName} changed");
            };
            
            // Change a couple properties to trigger the event
            d.DocName = "My Document";
            d.NeedsSave = true;

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}

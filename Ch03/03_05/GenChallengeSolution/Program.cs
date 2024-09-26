using System;
using System.Collections.Generic;

namespace GenChallengeSolution
{
    public class ClassicCar
    {
        public string m_Make;
        public string m_Model;
        public int m_Year;
        public int m_Value;

        public ClassicCar(string make, string model, int year, int val) {
            m_Make = make;
            m_Model = model;
            m_Year = year;
            m_Value = val;
        }
    }

    class Program
    {
        static void Main(string[] args) {
            List<ClassicCar> carList = new List<ClassicCar>();
            populateData(carList);

            // How many cars are in the collection?
            Console.WriteLine("{0} cars", carList.Count);

            // How many Fords are there?
            Console.WriteLine("{0} Fords", carList.FindAll((car) => car.m_Make == "Ford").Count);

            // What is the most valuable car?

            int highestValue = 0;
            ClassicCar mvc = null;
            foreach (ClassicCar car in carList) 
            {
                if (car.m_Value > highestValue)
                {
                    highestValue = car.m_Value;
                    mvc = car;
                }
            }
            Console.WriteLine($"Most valuable: {mvc.m_Year} {mvc.m_Make} {mvc.m_Model}");
            
            // carList.Sort((car1, car2) => car2.m_Value.CompareTo(car1.m_Value));
            // ClassicCar mvc = carList[0];
            // Console.WriteLine($"Most valuable: {mvc.m_Year} {mvc.m_Make} {mvc.m_Model}");

            // What is the entire collection worth?
            int totalWorth = 0;
            carList.ForEach((car) => totalWorth += car.m_Value);
            Console.WriteLine("Total collection value: {0}", totalWorth);

            // How many unique manufacturers are there?
            List<string> uniqueMakes = new List<string>();
            foreach (ClassicCar car in carList) 
            {
                if (!uniqueMakes.Contains(car.m_Make))
                    uniqueMakes.Add(car.m_Make);
            }
            Console.WriteLine("{0} unique manufacturers", uniqueMakes.Count);


            // Console.WriteLine("\nHit Enter key to continue...");
            // Console.ReadLine();
        }

        static void populateData(List<ClassicCar> theList) {
            theList.Add(new ClassicCar("Alfa Romeo", "Spider Veloce", 1965, 15000));
            theList.Add(new ClassicCar("Alfa Romeo", "1750 Berlina", 1970, 20000));
            theList.Add(new ClassicCar("Alfa Romeo", "Giuletta", 1978, 45000));

            theList.Add(new ClassicCar("Ford", "Thunderbird", 1971, 35000));
            theList.Add(new ClassicCar("Ford", "Mustang", 1976, 29800));
            theList.Add(new ClassicCar("Ford", "Corsair", 1970, 17900));
            theList.Add(new ClassicCar("Ford", "LTD", 1969, 12000));

            theList.Add(new ClassicCar("Chevrolet", "Camaro", 1979, 7000));
            theList.Add(new ClassicCar("Chevrolet", "Corvette Stringray", 1966, 21000));
            theList.Add(new ClassicCar("Chevrolet", "Monte Carlo", 1984, 10000));

            theList.Add(new ClassicCar("Mercedes", "300SL Roadster", 1957, 19800));
            theList.Add(new ClassicCar("Mercedes", "SSKL", 1930, 14300));
            theList.Add(new ClassicCar("Mercedes", "130H", 1936, 18400));
            theList.Add(new ClassicCar("Mercedes", "250SL", 1968, 13200));
        }
    }
}

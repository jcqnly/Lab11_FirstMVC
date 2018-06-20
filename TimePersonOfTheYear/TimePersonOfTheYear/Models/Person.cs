using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TimePersonOfTheYear.Models
{
    public class Person
    {
        //properties of the Person class
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        //make method that returns a type LIST of PERSON called GetPerson
        //which takes in 2 parameters that is a beginYear and an endYear
        public static List<Person> GetPersons(int beginYear, int endYear)
        {   //declare a new instantiation of the people of type List
            List<Person> people = new List<Person>();
            //direct the path that is in the Environment and CurrentDirectory
            string path = Environment.CurrentDirectory;
            //set a newPath that will reach even further to grab our csv file
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            //declare a new array of string type that will read in all the lines from this file
            string[] myFile = File.ReadAllLines(newPath);
            //loop through the file and get the header info from the CSV file
            for (int i = 1; i < myFile.Length; i++)
            {
                //declare a string array called fields and split the contents of 
                //each line from the file at each comma
                string[] fields = myFile[i].Split(',');
                //in the instantiation of people, add a value for each header
                people.Add(new Person
                {//the numbers within the fields reprent which index that info is in
                    Year = Convert.ToInt32(fields[0]),
                    //set the value of the 2nd index to Honor
                    Honor = fields[1],
                    //set the value of the 3rd index to Name
                    Name = fields[2],
                    //set the value of the 4th index to Country
                    Country = fields[3],
                    //if the field is empty, display a 0, otherwise convert it to an int
                    BirthYear = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    //if the field is empty, display a 0, otherwise convert it to an int
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    //set the 5th value of the fields index to Title
                    Title = fields[6],
                    //set the 6th value of the fields index to Category
                    Category = fields[7],
                    //set the 7th value of the fields index to Context
                    Context = fields[8],
                });
            }
            //then use a LINQ query that will only fetch the info for the years that were selected
            List<Person> listofPeople = people.Where(p => (p.Year >= beginYear) && (p.Year <= endYear)).ToList();
            //and add that data to a List called listofPeople and return it
            return listofPeople;
        }
    }
}

using System;
using System.Collections.Generic;

namespace day1
{
    class Program
    {
        public interface IAddPerson
        {
            bool CanIDonate();
        }

        public class PersonWhoDonatesBlood : IAddPerson
        {
            public string Name { get; set; }
            private readonly int weight;
            private readonly int age;
            private readonly bool isPersonSick, didPersonDrinkAlcohol, isHemoglobinOK, isBloodPressureOK;
            
            public PersonWhoDonatesBlood(string name, bool isPersonSick, int weight, int age, bool didPersonDrinkAlcohol, bool isHemoglobinOK, bool isBloodPressureOK) {
                Name = name;
                this.weight = weight;
                this.age = age;
                this.isPersonSick = isPersonSick;
                this.didPersonDrinkAlcohol = didPersonDrinkAlcohol;
                this.isHemoglobinOK = isHemoglobinOK;
                this.isBloodPressureOK = isBloodPressureOK;
            }

            public bool CanIDonate() {
                if ((!isPersonSick) && (weight > 55) && (age > 16) && (!didPersonDrinkAlcohol) && (isHemoglobinOK) && (isBloodPressureOK))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public abstract class BloodDonation {
            public abstract void WhatsMyName(string name);
        }

        public class DonateBlood : BloodDonation
        {
            private List<PersonWhoDonatesBlood> People { get; set; }
            
            public DonateBlood(List<PersonWhoDonatesBlood> people)
            {
                People = people;
            } 
            public override void WhatsMyName(string name)
            {
                bool doesPersonExist = false;
                foreach(PersonWhoDonatesBlood person in People)
                {
                    if ((person.Name.Equals(name)) && (person.CanIDonate()))
                    {
                        Console.WriteLine("Person is on the donation list and is eligible to donate blood :)");
                        doesPersonExist = true;
                    }
                    else if ((person.Name.Equals(name)) && (!person.CanIDonate()))
                    {
                        Console.WriteLine("Person is on the donation list but isn't eligible to donate blood :(");
                        doesPersonExist = true;
                    }                   
                }
                if((!name.Equals("exit")) && (!doesPersonExist))
                {
                    Console.WriteLine("Person is not on the donation list!");
                }                 
            }
        }

        static void Main(string[] args)
        {
            string name = "";

            List<PersonWhoDonatesBlood> donatingFolks = new List<PersonWhoDonatesBlood>
            {
                new PersonWhoDonatesBlood("Mateo", false, 73, 23, false, true, true),
                new PersonWhoDonatesBlood("Larissa", false, 62, 21, false, true, true),
                new PersonWhoDonatesBlood("Leonarda", true, 58, 28, false, false, true)
            };

            BloodDonation bloodDonation = new DonateBlood(donatingFolks);

            Console.WriteLine("Give a name to check out if this person is on the donation list and if it's eligible to donate: ");
                      
            while(!name.Equals("exit")) {
                name = Console.ReadLine();
                bloodDonation.WhatsMyName(name);
            }

            Console.ReadLine();
            
        }
    }
}

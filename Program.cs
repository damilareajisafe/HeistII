using System.Xml.Linq;

namespace HeistII
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> rolodex = new List<IRobber>()
            {
                new Hacker()
                {
                    Name = "Shadow",
                    SkillLevel = 9,
                    PercentageCut = 15
                },

                new Hacker()
                {
                    Name = "Cipher",
                    SkillLevel = 7,
                    PercentageCut = 10
                },

                new LockSpecialist()
                {
                    Name = "Picklock",
                    SkillLevel = 8,
                    PercentageCut = 12
                },

                new LockSpecialist()
                {
                    Name = "Keymaster",
                    SkillLevel = 6,
                    PercentageCut = 8
                },

                new Muscle()
                {
                    Name = "Tank",
                    SkillLevel = 9,
                    PercentageCut = 20
                },

                new Muscle()
                {
                    Name = "Bulldozer",
                    SkillLevel = 7,
                    PercentageCut = 15
                }
            };

            Console.WriteLine($"There are currently {rolodex.Count} operatives in the rolodex for you to choose from.");
            Console.WriteLine("You may also choose to include more.");
            string name = null;
            bool done = false;

            while (!done)
            {
                Console.WriteLine("Enter the name of a new possible crew member.");
                name = Console.ReadLine();
                if (name == "")
                {
                    done = true;
                    break;
                }

                Console.WriteLine(@"Choose the operatives specialty
1. Hacker (Disables alarms)
2. Muscle (Disarms guards)
3. Lock Specialist (cracks vault)");

                IRobber newOperative;
                int specialty;

                while (!int.TryParse(Console.ReadLine(), out specialty) || specialty < 1 || specialty > 3)
                {   
                    Console.WriteLine("Invalid response. Please enter a valid option.");
                }

                if (specialty == 1)
                {
                    newOperative = new Hacker();
                }
                else if (specialty == 2)
                {
                    newOperative = new Muscle();
                }
                else
                {
                    newOperative = new LockSpecialist();
                }

                int skillLevel;
                Console.WriteLine("Enter the new member's skill level."); 
                while (!int.TryParse(Console.ReadLine(), out skillLevel) || skillLevel <= 0 || skillLevel >= 100)
                {
                    Console.WriteLine("Invalid response. Please enter a number between 1 and 99.");
                }

                int percentageCut;
                Console.WriteLine("Enter the percentage cut the crew member demands for each mission");
                while (!int.TryParse(Console.ReadLine(), out percentageCut) || percentageCut <= 0 || percentageCut >= 100)
                {
                    Console.WriteLine("Invalid response. Please enter a number between 1 and 99.");
                }

                newOperative.Name = name;
                newOperative.SkillLevel = skillLevel;
                newOperative.PercentageCut = percentageCut;

                rolodex.Add(newOperative);
            }

            Console.WriteLine($"You now have {rolodex.Count} operatives to choose from");
            Console.WriteLine("Here is the list:.");
            int sn = 1;
            foreach(IRobber operative in rolodex)
            {
                Console.WriteLine(@$"{sn}. Name: {operative.Name}
Specialty: {operative.GetType().Name}
Skill Level: {operative.SkillLevel}
Desired Percentage cut: {operative.PercentageCut}%");
                sn += 1;
            }
        }
    }
}
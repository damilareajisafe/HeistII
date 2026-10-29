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

            //            Console.WriteLine($"You now have {rolodex.Count} operatives to choose from");
            //            Console.WriteLine("Here is the list:.");
            //            int sn = 1;
            //            foreach(IRobber operative in rolodex)
            //            {
            //                Console.WriteLine(@$"{sn}. Name: {operative.Name}
            //Specialty: {operative.GetType().Name}
            //Skill Level: {operative.SkillLevel}
            //Desired Percentage cut: {operative.PercentageCut}%");
            //                sn += 1;
            //            }

            Bank newBank = new Bank();
            newBank.AlarmScore = new Random().Next(101);
            newBank.VaultScore = new Random().Next(101);
            newBank.SecurityGuardScore = new Random().Next(101);
            newBank.CashOnHand = new Random().Next(50000, 1000001);

            //List<int> scores = new List<int>
            //{
            //    newBank.AlarmScore,
            //    newBank.VaultScore,
            //    newBank.SecurityGuardScore
            //};

            //int mostSecure = scores.Max();
            //int leastSecure = scores.Min();

            Dictionary<string, int> securityScores = new Dictionary<string, int>
            {
                {"Alarm", newBank.AlarmScore},
                {"Vault", newBank.VaultScore},
                {"Security Guards", newBank.SecurityGuardScore}
            };

            KeyValuePair<string, int> mostSecure = securityScores.MaxBy(pair => pair.Value);
            KeyValuePair<string, int> leastSecure = securityScores.MinBy(pair => pair.Value);

            Console.WriteLine($"Bank Recon Report");
            Console.WriteLine($@"Most Secure: {mostSecure.Key}
Least Secure: {leastSecure.Key}");

            List<IRobber> crew = new List<IRobber>();
            int remainingLoot = newBank.CashOnHand;
            Console.WriteLine($"You now have {rolodex.Count} operatives to choose from");



            while (true)
            {
                List<IRobber> availableOperatives = new List<IRobber>();
                int index = 1;
                foreach (IRobber operative in rolodex)
                {
                    if (remainingLoot > operative.PercentageCut / 100m * newBank.CashOnHand && !crew.Contains(operative))
                    {
                        availableOperatives.Add(operative);
                        Console.WriteLine(@$"{index}. Name: {operative.Name}
                Specialty: {operative.Specialty}
                Skill Level: {operative.SkillLevel}
                Desired Percentage cut: {operative.PercentageCut}%");
                        index += 1;
                    }
                }

                if(availableOperatives.Count == 0)
                {
                    Console.WriteLine("There are no operatives left for you to choose from");
                    break;
                }
                else
                {
                    Console.WriteLine("Pick your operatives for the heist");

                    string response = Console.ReadLine();
                    if (response == "")
                    {
                        break;
                    }

                    int option;
                    while (!int.TryParse(response, out option) || option < 1 || option > rolodex.Count)
                    {
                        Console.WriteLine("Invalid response. Please enter a valid option.");
                        response = Console.ReadLine();
                    }

                    crew.Add(availableOperatives[option - 1]);

                    remainingLoot -= (int)(rolodex[option - 1].PercentageCut / 100m * remainingLoot);
                }
               
            }

            Console.WriteLine("List of crew members:");
            int sn = 1;
            foreach (IRobber operative in crew)
            {
                Console.WriteLine(@$"{sn}. Name: {operative.Name}
                Specialty: {operative.Specialty}
                Skill Level: {operative.SkillLevel}
                Desired Percentage cut: {operative.PercentageCut}%");
                sn += 1;
            }
        }
    }
}
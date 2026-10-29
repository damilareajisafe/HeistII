using System;
using System.Collections.Generic;
using System.Text;

namespace HeistII
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; } = 50;
        public int PercentageCut { get; set; } = 5;
        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= SkillLevel;
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased security {SkillLevel} points");
            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
        }

        public string Specialty { get; } = "Hacker";
    }
}

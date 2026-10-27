using System;
using System.Collections.Generic;
using System.Text;

namespace HeistII
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; } = 50;
        public int PercentageCut { get; set; } = 5;
        public void PerformSkill(Bank bank)
        {
            int securityScore = bank.SecurityGuardScore;
            securityScore -= SkillLevel;
            Console.WriteLine($"{Name} is handling the security guards. Decreased security {securityScore} points");
            if (securityScore <= 0)
            {
                Console.WriteLine($"{Name} has neutralized the guards!");
            }
        }
    }
}

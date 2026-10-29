using System;
using System.Collections.Generic;
using System.Text;

namespace HeistII
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; } = 50;
        public int PercentageCut { get; set; } = 5;
        public void PerformSkill(Bank bank)
        {
            bank.VaultScore -= SkillLevel;
            Console.WriteLine($"{Name} is cracking the vault. Decreased security {SkillLevel} points");
            if (bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has successfuly cracked the vault!");
            }
        }

        public string Specialty { get; } = "Lock Specialist";
    }
}

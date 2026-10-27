using System;
using System.Collections.Generic;
using System.Text;

namespace HeistII
{
    public class Bank
    {
        public int CashOnHand { get; set; } = 50000;
        public int AlarmScore { get; set; } = 60;
        public int VaultScore { get; set; } = 50;
        public int SecurityGuardScore { get; set; } = 65;

        public bool IsSecure
        {
            get
            {
                if (AlarmScore <= 0 && VaultScore <= 0 && SecurityGuardScore <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CertamenApp
{
    public class Forces : ISphere
    {
        public string Name { get; } = "Forces";
        public int Level { get; set; }
        public int Bonus { get; set; } 
        public string Description { get; set; } = "Command over fundamental forces of the universe, energy, and gravity.";

        public Forces()
        {
            Random increase = new Random();
            int value = 0;
            for (int i = 0; i < 1; i++)
            {
                value = increase.Next(0, 6);
            }
            Level += value;
        }


        public void attack()
        {
            int power;
            Random increase = new Random();
            power = increase.Next(3, 6);
            Bonus = power;
        }
        public void defend(int power)
        {
            Random increase = new Random();
            for (int i = 0; i < 1; i++)
            {
                power = increase.Next(1, 2);
            }
            Bonus += power;
        }
        public void heal(int power)
        {
            Random increase = new Random();
            for (int i = 0; i < 1; i++)
            {
                power = increase.Next(1, 2);
            }
            Bonus += power;
        }
        public void cleanUp()
        {
            Bonus = 0;
        }
    }
}

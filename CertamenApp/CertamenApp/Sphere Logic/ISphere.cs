using System;
using System.Collections.Generic;
using System.Text;

namespace CertamenApp
{
    public interface ISphere
    {
        public string Name { get; }
        public int Level { get; set; }
        public int Bonus { get; set; }
        public string Description { get; set; }


        public void attack() { }
        public void defend() { }
        public void heal() { }
        public void cleanUp() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolve
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOrgs = 64;
            string[] orgs = new string[numOrgs];
            Evolution ev = new Evolution();

            for (int i = 0; i < numOrgs; i++)
            {
                orgs[i] = ev.Init();
                Console.WriteLine(orgs[i]);
            }
            ev.Tournament(numOrgs, orgs);
            Console.ReadKey();
        }
    }
}

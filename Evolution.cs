using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolve
{
    class Evolution
    {
        private static int length = 3, botStart = 1, topStart = 6;//One larger than actual max
        static Random r = new Random();

        public string GetName()
        {
            string name = ",";
            string[] cons = new string[23];
            string[] vows = new string[6];
            cons[0] = "B";
            cons[1] = "C";
            cons[2] = "D";
            cons[3] = "F";
            cons[4] = "G";
            cons[5] = "H";
            cons[6] = "J";
            cons[7] = "K";
            cons[8] = "L";
            cons[9] = "M";
            cons[10] = "N";
            cons[11] = "P";
            cons[12] = "Qu";
            cons[13] = "R";
            cons[14] = "S";
            cons[15] = "T";
            cons[16] = "W";
            cons[17] = "X";
            cons[18] = "Y";
            cons[19] = "Z";
            cons[20] = "Sh";
            cons[21] = "Ng";
            cons[22] = "Th";
            vows[0] = "A";
            vows[1] = "E";
            vows[2] = "I";
            vows[3] = "O";
            vows[4] = "U";
            vows[5] = "Y";
            for(int i = 1; i <= 6; i++)
            {
                if (i == 1)
                {
                    name += cons[RandNum(0, cons.Length)];
                }
                else if (i % 2 == 1 && i > 2)
                { 
                    name += cons[RandNum(0, cons.Length)].ToLower();
                }
                else
                {
                    name += vows[RandNum(0, vows.Length)].ToLower();
                }
            }
            name.ToLower();
            return name;
        }
        public string life //Syntax: int,*length, 0,0,0,Name?
        {
            get
            {
                return life;
            }
            set 
            {
                life = value;
            }
        }

        public Evolution()
        {
        }

        public string Init()
        {
            string str = "";
            for (int i = 0; i < length; i++)
            {
                if (i != 0)
                {
                    str += ",";
                }
                str += (RandNum(botStart, topStart).ToString());
            }
            str += GetName();
            return str;
        }

        public void Evolve()
        {
            int[] lifeI = new int[length];
            for (int i = 0; i < length; i++)
            {
                lifeI[i] = int.Parse(life.Split(',')[i]);
            }
            //Evolve code
            //End evolve code
        }

        public int RandNum(int min, int max)
        {
            int n = r.Next(min, max);
            return n;
        }

        public string[] Fight(string[] orgs, bool write, int orgs1, int orgs2)
        {
            string org1 = orgs[orgs1], org2 = orgs[orgs2];
            int org1Health, org2Health, org1Atk, org2Atk, org1Def, org2Def, damage, totDamage, org1SHealth, org2SHealth;
            string org1Name, org2Name;
            org1Name = org1.Split(',')[3];
            org2Name = org2.Split(',')[3];
            org1SHealth = org1Health = int.Parse(org1.Split(',')[0]);
            org2SHealth = org2Health = int.Parse(org2.Split(',')[0]);
            org1Atk = int.Parse(org1.Split(',')[1]);
            org2Atk = int.Parse(org2.Split(',')[1]);
            org1Def = int.Parse(org1.Split(',')[2]);
            org2Def = int.Parse(org2.Split(',')[2]);
            while(org1Health > 0 && org2Health > 0)
            {
                totDamage = 0;
                damage = (org1Atk - org2Def);
                if (damage > 0)
                {
                   
                    if (write)
                    { Console.WriteLine("" + org1Name + " hits " + org2Name + " for {0} ({1} -> {2})", damage, org2Health, org2Health - damage); }
                    org2Health -= damage;
                    totDamage += damage;
                }
                else 
                {
                    if (write) 
                        Console.WriteLine("" + org1Name + " does not damage " + org2Name + "");
                }
                damage = (org2Atk - org1Def);
                if (damage > 0)
                {
                    
                    if (write)
                    { Console.WriteLine("" + org2Name + " hits " + org1Name + " for {0} ({1} -> {2})", damage, org1Health, org1Health - damage); }
                    org1Health -= damage;
                    totDamage += damage;
                }
                else
                { 
                    if (write)
                        Console.WriteLine("" + org2Name + " does not damage " + org1Name + ""); 
                }

                if(totDamage == 0)
                {
                    if (write)
                    {
                        Console.WriteLine("No damage is dealt");
                    }
                    if (org1Health * org1Def > org2Health * org2Def)
                    {
                        org2Health = 0;
                        if (write)
                            Console.WriteLine("" + org1Name + "'s toughness allows it to persevere.");
                    }
                    else if (org1Health * org1Def < org2Health * org2Def)
                    {
                        org1Health = 0;
                        if (write)
                            Console.WriteLine("" + org2Name + "'s toughness allows it to persevere.");
                    }
                    else
                        switch (RandNum(0, 1))
                        {
                            case 0:
                                org1Health = 0;
                                if(write)
                                { Console.WriteLine("" + org1Name + " is eaten by a Grue. " + org2Name + " looks on in confusion, unaware of its victory..."); }
                                break;
                            case 1:
                                org2Health = 0;
                                if (write)
                                { Console.WriteLine("" + org2Name + " is eaten by a Grue. " + org1Name + " looks on in confusion, unaware of its victory..."); }
                                break;
                        }
                }
                if (org1Health <= 0 && org2Health <= 0)
                {
                    Console.WriteLine(org1Name + " and " + org2Name + " both perished. Do you feel bad yet?");
                    org1 = org2 = "0,0,0,Zombie";
                }
                else if(org1Health <= 0)
                {
                    Console.WriteLine("" + org1Name + " perishes, " + org2Name + " is victorious!");
                    org2Health = org2SHealth;
                }
                else if(org2Health <= 0)
                {
                    Console.WriteLine("" + org2Name + " perishes, " + org1Name + " is victorious!");
                    org1Health = org1SHealth;

                }
                orgs[orgs1] = org1Health + "," + org1Atk + "," + org1Def + "," + org1Name;
                orgs[orgs2] = org2Health + "," + org2Atk + "," + org2Def + "," + org2Name;
                return orgs;
            }
            return orgs;
        }//End Fight

        public void Tournament(int numOrgs, string[] orgs)
        {
            int stripper, round = 1;
            string hold;
            Sort:
            Console.WriteLine("\nStart of round {0}!\n", round);
            round++;
            stripper = 1;
            while (stripper != 0)
            {
                stripper = 0;
                for (int i = 0; i <= orgs.Length - 2; i++)
                {
                    if (int.Parse(orgs[i].Split(',')[0]) <= 0)
                    {
                        hold = orgs[i];
                        orgs[i] = orgs[i + 1];
                        orgs[i + 1] = hold;
                        stripper = 1;
                    }
                }
            }
            while (numOrgs != 2)
            {
                
                for(int i = 0; i < numOrgs; i += 2)
                {
                    Fight(orgs, false, i, i+1);
                }
                numOrgs /= 2;
                goto Sort;
            }
            Fight(orgs, true, 1, 2);
        }
    }
}

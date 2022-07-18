using System;
using System.Collections.Generic;
using System.Text;
using CertamenApp.Character_Creation;

namespace CertamenApp.Menus
{
    public class Menu
    {
        

        Character player = new Character();
        EnemyLow low = new EnemyLow();
        EnemyMid mid = new EnemyMid();
        EnemyHigh high = new EnemyHigh();
        int playerHealth;
        int playerShield;
        int enemyHealth;
        int enemyShield;
        int bAttack;
        int bDefend;
        int bHeal;
        int areteRoll;
        Random rnd = new Random();

       
        public int DamageRolls()
        {
            
            for (int x = 0; x < bAttack; x++)
            {
                areteRoll = rnd.Next(1, 11);
                if (areteRoll > 6 && areteRoll < 10)
                {
                    player.Successess++;
                }
                else if(areteRoll == 10)
                {
                    player.Successess += 2;
                }

            }
            return player.Successess;
        }
        public int ShieldRolls()
        {
            
            for (int x = 0; x < bDefend; x++)
            {
                areteRoll = rnd.Next(1, 11);
                if (areteRoll > 6 && areteRoll < 10)
                {
                    player.Successess++;
                }
                else if (areteRoll == 10)
                {
                    player.Successess += 2;
                }

            }
            return player.Successess;
        }
        public int HealRolls()
        {
            
            for (int x = 0; x < bHeal; x++)
            {
                areteRoll = rnd.Next(1, 11);
                if (areteRoll > 6 && areteRoll < 10)
                {
                    player.Successess++;
                }
                else if (areteRoll == 10)
                {
                    player.Successess += 2;
                }

            }
            return player.Successess;
        }
        
        
        public Menu() { }

        public void mageSpheres()
        {
            foreach (ISphere item in player.Spheres)
            {
                Console.WriteLine($"{item.Name} at level {item.Level}!");
            }
        }

        public void StartMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Press enter to Begin.");
            Console.ReadLine();
            Console.WriteLine("Power wells up from inside you!");
            Console.WriteLine("You've Awakened to endless possibilities.");
            Console.WriteLine();
            Mainmenu();
        }
        public void MainBanner()
        {
            Console.WriteLine("       --------------------------------");
            Console.WriteLine("       |          CERTAMEN:           |");
            Console.WriteLine("       | A battle of Mages and Magic! |");
            Console.WriteLine("       --------------------------------");
        }
        
        public void Mainmenu()
        {
            
            Console.WriteLine("(1) Display Character Stats");
            Console.WriteLine("(2) Sphere Info");
            Console.WriteLine("(3) Start Battle");
            Console.WriteLine("(4) Exit");
            int menuOption = 0;
            try
            {
                menuOption = int.Parse(Console.ReadLine());
                if(menuOption < 1 && menuOption > 4)
                {
                    throw new FormatException(message:"Invalid input\n");
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid input\n");
            }

            if (menuOption == 1)
            {
                Console.Clear();
                Console.WriteLine($"Your power level, known as Arete is: {player.Arete}");
                Console.WriteLine($"Your health is: {player.Resevoir}\n");
                Console.WriteLine("You know the following Spheres:");
                foreach (ISphere item in player.Spheres)
                {
                    Console.WriteLine($"-{item.Name} at level {item.Level}!");
                }
                Console.WriteLine();
                Mainmenu();
            }

            if (menuOption == 2)
            {
                Console.Clear();
                foreach (ISphere item in player.Spheres)
                {
                    Console.WriteLine($"-{item.Name}: {item.Description}");
                }
                Console.WriteLine();
                Mainmenu();
            }

            if (menuOption == 3)
            {
                Console.Clear();
                Console.WriteLine("Prepare For Battle!\n");
                Difficulty();
            }

            if (menuOption == 4)
            {
                Console.Clear();
                Console.WriteLine("Safe Travels Young Mage.\n");
                Environment.Exit(0);
            }


        }
        public void Difficulty()
        {
            
            Console.WriteLine("Select Difficulty!");
            Console.WriteLine("(1) Easy");
            Console.WriteLine("(2) Moderate");
            Console.WriteLine("(3) Hard");
            int menuOption = 0;

            try
            {
                menuOption = int.Parse(Console.ReadLine());
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid Input\n");
            }

            if (menuOption == 1)
            {
                Console.Clear();
                Console.WriteLine($"A random {low.Name} appears!\n");
                BattleMenuLow();
            }

            if (menuOption == 2)
            {
                Console.Clear();
                Console.WriteLine($"A random {mid.Name} appears!\n");
                BattleMenuMid();
            }

            if (menuOption == 3)
            {
                Console.Clear();
                Console.WriteLine($"A random {high.Name} appears!\n");
                BattleMenuHigh();
            }


        }

        public void BattleMenuLow(bool continuing = false)
        {
            if (continuing == false)
            {
                playerHealth = player.Resevoir;
                playerShield = player.Shield;
                enemyHealth = low.Resevoir;
                enemyShield = low.Shield;
                continuing = true;
            }

            while (playerHealth > 0 && enemyHealth > 0)
            {
                Console.WriteLine("-- Player Turn --\n");
                Console.WriteLine($"Player Health: {playerHealth} Shield: {playerShield}");
                Console.WriteLine($"{low.Name}'s Health: {enemyHealth} Shield: {enemyShield}");
                Console.WriteLine("(1) Attack");
                Console.WriteLine("(2) Defend");
                Console.WriteLine("(3) Heal");
                int menuOption;
                try
                {
                    menuOption = int.Parse(Console.ReadLine());

                    if (menuOption == 1)
                    {
                        int i = 1;
                        Console.WriteLine("Choose Attack Sphere.\n");
                        foreach (ISphere item in player.Spheres)
                        {
                            Console.WriteLine($"({i}) {item.Name} Lv. {item.Level}");
                            i++;
                        }

                        int attackOption = int.Parse(Console.ReadLine());

                        int sphere = 0;
                        int selection = 1;
                        for (int x = 1; x <= player.Spheres.Count; x++)
                        {
                            if (attackOption == selection)
                            {
                                player.Spheres[sphere].attack();
                                bAttack = player.Spheres[sphere].Bonus;
                                DamageRolls();
                                Console.WriteLine($"You deal {player.Successess} damage to the {low.Name}!");
                                if (enemyShield > player.Successess)
                                {
                                    enemyShield -= player.Successess;
                                }
                                else
                                {
                                    enemyHealth -= (player.Successess - enemyShield);
                                    enemyShield = 0;
                                }
                                player.Spheres[sphere].cleanUp();
                                player.PlayerCleanUp();
                            }
                            sphere++;
                            selection++;
                        }
                    }
                    if (menuOption == 2)
                    {
                        int i = 1;
                        Console.WriteLine("Choose Shield Sphere\n");
                        foreach (ISphere item in player.Spheres)
                        {
                            Console.WriteLine($"({i}) {item.Name} Lv. {item.Level}");
                            i++;
                        }
                        int shieldOption = int.Parse(Console.ReadLine());

                        int sphere = 0;
                        int selection = 1;
                        for (int x = 1; x <= player.Spheres.Count; x++)
                        {
                            if (shieldOption == selection)
                            {
                                player.Spheres[sphere].defend();
                                bDefend = player.Spheres[sphere].Bonus + player.Arete;
                                ShieldRolls();
                                Console.WriteLine($"You conjure a shield! it can absorb {player.Successess} damage.");
                                playerShield += player.Successess;
                                player.Spheres[sphere].cleanUp();
                                player.PlayerCleanUp();
                            }
                            sphere++;
                            selection++;
                        }
                    }
                    if (menuOption == 3)
                    {
                        int i = 1;
                        Console.WriteLine("Choose Healing Sphere.\n");
                        foreach (ISphere item in player.Spheres)
                        {
                            Console.WriteLine($"({i}) {item.Name} Lv. {item.Level}");
                            i++;
                        }
                        int healOption = int.Parse(Console.ReadLine());

                        int sphere = 0;
                        int selection = 1;
                        for (int x = 1; x <= player.Spheres.Count; x++)
                        {
                            if (healOption == selection)
                            {
                                player.Spheres[sphere].heal();
                                bHeal = player.Spheres[sphere].Bonus + player.Arete;
                                HealRolls();
                                Console.WriteLine($"With the power of {player.Spheres[sphere].Name} you heal {player.Successess} damage!");
                                playerHealth += player.Successess;
                                player.Spheres[sphere].cleanUp();
                                player.PlayerCleanUp();
                            }
                            sphere++;
                            selection++;
                        }
                    }
                    if (menuOption < 1 && menuOption > 3)
                    {
                        throw new FormatException(message:"Invalid input");
                    }
                }
                
                catch(FormatException)
                {
                    Console.WriteLine("Invalid Input\n");
                }

                if (enemyHealth > 0)
                {
                    Console.WriteLine($"-- {low.Name}'s Turn --\n");

                    int enemyChoice = rnd.Next(0, 3);
                    int randomSphere = rnd.Next(0, 2);

                    if (enemyChoice == 1 && enemyShield < 6)
                    {
                        int sphereShield = randomSphere;
                        low.Spheres[sphereShield].defend();
                        bDefend = low.Spheres[sphereShield].Bonus + low.Arete;

                        Random rnd = new Random();
                        for (int x = 0; x < bDefend; x++)
                        {
                            areteRoll = rnd.Next(1, 11);
                            if (areteRoll > 6)
                            {
                                low.Successess++;
                            }
                        }

                        Console.WriteLine($"{low.Name} conjures a shield! It can absorb {low.Successess} damage.\n");
                        enemyShield += low.Successess;
                        low.Spheres[sphereShield].cleanUp();
                        low.CleanUp();
                    }
                    else if (enemyChoice == 2 && enemyHealth < 10)
                    {
                        int sphereHeal = randomSphere;
                        low.Spheres[sphereHeal].heal();
                        bHeal = low.Spheres[sphereHeal].Bonus + low.Arete;

                        Random rnd = new Random();
                        for (int x = 0; x < bHeal; x++)
                        {
                            areteRoll = rnd.Next(1, 11);
                            if (areteRoll > 6)
                            {
                                low.Successess++;
                            }
                        }

                        Console.WriteLine($"{low.Name} heals {low.Successess} damage!\n");
                        enemyHealth += low.Successess;
                        low.Spheres[sphereHeal].cleanUp();
                        low.CleanUp();
                    }
                    else
                    {
                        int sphereAttack = randomSphere;
                        low.Spheres[sphereAttack].attack();
                        bAttack = low.Spheres[sphereAttack].Bonus + low.Arete;

                        Random rnd = new Random();
                        for (int x = 0; x < bAttack; x++)
                        {
                            areteRoll = rnd.Next(1, 11);
                            if (areteRoll > 6)
                            {
                                low.Successess++;
                            }
                        }

                        Console.WriteLine($"{low.Name} deals {low.Successess} damage to you!\n");
                        if (playerShield > low.Successess)
                        {
                            playerShield -= low.Successess;
                        }
                        else
                        {
                            playerHealth = playerHealth - (low.Successess - playerShield);
                            playerShield = 0;
                        }

                        low.Spheres[sphereAttack].cleanUp();
                        low.CleanUp();
                    }
                }
            }

            if (enemyHealth <= 0)
            {
                
                WinScreen();
                Console.WriteLine();
                Mainmenu();
            }
            if (playerHealth <= 0)
            {
               
                GameOver();
                Console.WriteLine();
                Mainmenu();
            }
        }

        public void BattleMenuMid(bool continuing = false)
        {
            if (continuing == false)
            {
                playerHealth = player.Resevoir;
                playerShield = player.Shield;
                enemyHealth = mid.Resevoir;
                enemyShield = mid.Shield;
                continuing = true;
            }

            while (playerHealth > 0 && enemyHealth > 0)
            {
                Console.WriteLine("-- Player Turn --\n");
                Console.WriteLine($"Player Health: {playerHealth} Shield: {playerShield}");
                Console.WriteLine($"{mid.Name}'s Health: {enemyHealth} Shield: {enemyShield}");
                Console.WriteLine("(1) Attack");
                Console.WriteLine("(2) Defend");
                Console.WriteLine("(3) Heal");
                int menuOption;
                try
                {
                    menuOption = int.Parse(Console.ReadLine());
                    if (menuOption == 1)
                    {
                        int i = 1;
                        Console.WriteLine("Choose Attack Sphere.\n");
                        foreach (ISphere item in player.Spheres)
                        {
                            Console.WriteLine($"({i}) {item.Name} Lv. {item.Level}");
                            i++;
                        }
                        int attackOption = int.Parse(Console.ReadLine());

                        int sphere = 0;
                        int selection = 1;
                        for (int x = 1; x <= player.Spheres.Count; x++)
                        {
                            if (attackOption == selection)
                            {
                                player.Spheres[sphere].attack();
                                bAttack = player.Spheres[sphere].Bonus;
                                DamageRolls();
                                Console.WriteLine($"You deal {player.Successess} damage to the {mid.Name}!");
                                if (enemyShield > player.Successess)
                                {
                                    enemyShield -= player.Successess;
                                }
                                else
                                {
                                    enemyHealth -= (player.Successess - enemyShield);
                                    enemyShield = 0;
                                }
                                player.Spheres[sphere].cleanUp();
                                player.PlayerCleanUp();
                            }
                            sphere++;
                            selection++;
                        }
                    }
                    if (menuOption == 2)
                    {
                        int i = 1;
                        Console.WriteLine("Choose Shield Sphere\n");
                        foreach (ISphere item in player.Spheres)
                        {
                            Console.WriteLine($"({i}) {item.Name} Lv. {item.Level}");
                            i++;
                        }
                        int shieldOption = int.Parse(Console.ReadLine());

                        int sphere = 0;
                        int selection = 1;
                        for (int x = 1; x <= player.Spheres.Count; x++)
                        {
                            if (shieldOption == selection)
                            {
                                player.Spheres[sphere].defend();
                                bDefend = player.Spheres[sphere].Bonus + player.Arete;
                                ShieldRolls();
                                Console.WriteLine($"You conjure a shield! it can absorb {player.Successess} damage.");
                                playerShield += player.Successess;
                                player.Spheres[sphere].cleanUp();
                                player.PlayerCleanUp();
                            }
                            sphere++;
                            selection++;
                        }
                    }
                    if (menuOption == 3)
                    {
                        int i = 1;
                        Console.WriteLine("Choose Healing Sphere.\n");
                        foreach (ISphere item in player.Spheres)
                        {
                            Console.WriteLine($"({i}) {item.Name} Lv. {item.Level}");
                            i++;
                        }
                        int healOption = int.Parse(Console.ReadLine());

                        int sphere = 0;
                        int selection = 1;
                        for (int x = 1; x <= player.Spheres.Count; x++)
                        {
                            if (healOption == selection)
                            {
                                player.Spheres[sphere].heal();
                                bHeal = player.Spheres[sphere].Bonus + player.Arete;
                                HealRolls();
                                Console.WriteLine($"With the power of {player.Spheres[sphere].Name} you heal {player.Successess} damage!");
                                playerHealth += player.Successess;
                                player.Spheres[sphere].cleanUp();
                                player.PlayerCleanUp();
                            }
                            sphere++;
                            selection++;
                        }
                    }
                    if (menuOption < 1 && menuOption > 3)
                    {
                        throw new FormatException();
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid Input\n");
                }

                if (enemyHealth > 0)
                {
                    Console.WriteLine($"-- {mid.Name}'s Turn --\n");

                    int enemyChoice = rnd.Next(0, 3);
                    int randomSphere = rnd.Next(0, 2);
                    
                    if (enemyChoice == 1 && enemyShield < 6)
                    {
                        int sphereShield = randomSphere;
                        mid.Spheres[sphereShield].defend();
                        bDefend = mid.Spheres[sphereShield].Bonus + mid.Arete;

                        Random rnd = new Random();
                        for (int x = 0; x < bDefend; x++)
                        {
                            areteRoll = rnd.Next(1, 11);
                            if (areteRoll > 6)
                            {
                                mid.Successess++;
                            }
                        }

                        Console.WriteLine($"{mid.Name} conjures a shield! It can absorb {mid.Successess} damage.\n");
                        enemyShield += mid.Successess;
                        mid.Spheres[sphereShield].cleanUp();
                        mid.CleanUp();
                    }
                    else if (enemyChoice == 2 && enemyHealth <= 10)
                    {
                        int sphereHeal = randomSphere;
                        mid.Spheres[sphereHeal].heal();
                        bHeal = mid.Spheres[sphereHeal].Bonus + mid.Arete;

                        Random rnd = new Random();
                        for (int x = 0; x < bHeal; x++)
                        {
                            areteRoll = rnd.Next(1, 11);
                            if (areteRoll > 6)
                            {
                                mid.Successess++;
                            }
                        }

                        Console.WriteLine($"{mid.Name} heals {mid.Successess} damage!\n");
                        enemyHealth += mid.Successess;
                        mid.Spheres[sphereHeal].cleanUp();
                        mid.CleanUp();
                    }
                    else
                    {
                        int sphereAttack = randomSphere;
                        mid.Spheres[sphereAttack].attack();
                        bAttack = mid.Spheres[sphereAttack].Bonus + mid.Arete;

                        Random rnd = new Random();
                        for (int x = 0; x < bAttack; x++)
                        {
                            areteRoll = rnd.Next(1, 11);
                            if (areteRoll > 6)
                            {
                                mid.Successess++;
                            }
                        }

                        Console.WriteLine($"{mid.Name} deals {mid.Successess} damage to you!\n");
                        if (playerShield > mid.Successess)
                        {
                            playerShield -= mid.Successess;
                        }
                        else
                        {
                            playerHealth = playerHealth - (mid.Successess - playerShield);
                            playerShield = 0;
                        }

                        mid.Spheres[sphereAttack].cleanUp();
                        mid.CleanUp();
                    }

                }
            }

            if (enemyHealth <= 0)
            {
                
                WinScreen();
                Console.WriteLine();
                Mainmenu();
            }
            if (playerHealth <= 0)
            {
                
                GameOver();
                Console.WriteLine();
                Mainmenu();
            }
        }

        public void BattleMenuHigh(bool continuing = false)
        {
            if (continuing == false)
            {
                playerHealth = player.Resevoir;
                playerShield = player.Shield;
                enemyHealth = high.Resevoir;
                enemyShield = high.Shield;
                continuing = true;
            }
            
            while (playerHealth > 0 && enemyHealth > 0)
            {
                Console.WriteLine("-- Player Turn --\n");
                Console.WriteLine($"Player Health: {playerHealth} Shield: {playerShield}");
                Console.WriteLine($"{high.Name}'s Health: {enemyHealth} Shield: {enemyShield}");
                Console.WriteLine("(1) Attack");
                Console.WriteLine("(2) Defend");
                Console.WriteLine("(3) Heal");
                int menuOption;
                try
                {
                    menuOption = int.Parse(Console.ReadLine());
                    if (menuOption == 1)
                    {
                        int i = 1;
                        Console.WriteLine("Choose Attack Sphere.\n");
                        foreach (ISphere item in player.Spheres)
                        {
                            Console.WriteLine($"({i}) {item.Name} Lv. {item.Level}");
                            i++;
                        }
                        int attackOption = int.Parse(Console.ReadLine());

                        int sphere = 0;
                        int selection = 1;
                        for (int x = 1; x <= player.Spheres.Count; x++)
                        {
                            if (attackOption == selection)
                            {
                                player.Spheres[sphere].attack();
                                bAttack = player.Spheres[sphere].Bonus;
                                DamageRolls();
                                Console.WriteLine($"You deal {player.Successess} damage to the {high.Name}!");
                                if (enemyShield > player.Successess)
                                {
                                    enemyShield -= player.Successess;
                                }
                                else
                                {
                                    enemyHealth -= (player.Successess - enemyShield);
                                    enemyShield = 0;
                                }
                                player.Spheres[sphere].cleanUp();
                                player.PlayerCleanUp();
                            }
                            sphere++;
                            selection++;
                        }
                    }
                    if (menuOption == 2)
                    {
                        int i = 1;
                        Console.WriteLine("Choose Shield Sphere\n");
                        foreach (ISphere item in player.Spheres)
                        {
                            Console.WriteLine($"({i}) {item.Name} Lv. {item.Level}");
                            i++;
                        }

                        int shieldOption = int.Parse(Console.ReadLine());

                        int sphere = 0;
                        int selection = 1;
                        for (int x = 1; x <= player.Spheres.Count; x++)
                        {
                            if (shieldOption == selection)
                            {
                                player.Spheres[sphere].defend();
                                bDefend = player.Spheres[sphere].Bonus + player.Arete;
                                ShieldRolls();
                                Console.WriteLine($"You conjure a shield! it can absorb {player.Successess} damage.");
                                playerShield += player.Successess;
                                player.Spheres[sphere].cleanUp();
                                player.PlayerCleanUp();
                            }
                            sphere++;
                            selection++;
                        }
                    }
                    if (menuOption == 3)
                    {
                        int i = 1;
                        Console.WriteLine("Choose Healing Sphere.\n");
                        foreach (ISphere item in player.Spheres)
                        {
                            Console.WriteLine($"({i}) {item.Name} Lv. {item.Level}");
                            i++;
                        }
                        int healOption = int.Parse(Console.ReadLine());

                        int sphere = 0;
                        int selection = 1;
                        for (int x = 1; x <= player.Spheres.Count; x++)
                        {
                            if (healOption == selection)
                            {
                                player.Spheres[sphere].heal();
                                bHeal = player.Spheres[sphere].Bonus + player.Arete;
                                HealRolls();
                                Console.WriteLine($"With the power of {player.Spheres[sphere].Name} you heal {player.Successess} damage!");
                                playerHealth += player.Successess;
                                player.Spheres[sphere].cleanUp();
                                player.PlayerCleanUp();
                            }
                            sphere++;
                            selection++;
                        }
                    }
                    if (menuOption < 1 && menuOption > 3)
                    {
                        throw new FormatException();
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid Input\n");
                }

                if (enemyHealth > 0)
                {
                    Console.WriteLine($"-- {high.Name}'s Turn --\n");

                    int enemyChoice = rnd.Next(0, 3);
                    int randomSphere = rnd.Next(0, 4);
                    
                    if (enemyChoice == 1 && enemyShield < 6)
                    {
                        int sphereShield = randomSphere;
                        high.Spheres[sphereShield].defend();
                        bDefend = high.Spheres[sphereShield].Bonus + high.Arete;

                        for (int x = 0; x < bDefend; x++)
                        {
                            areteRoll = rnd.Next(1, 11);
                            if (areteRoll > 6)
                            {
                                high.Successess++;
                            }
                        }

                        Console.WriteLine($"{high.Name} conjures a shield! It can absorb {high.Successess} damage.\n");
                        enemyShield += high.Successess;
                        high.Spheres[sphereShield].cleanUp();
                        high.CleanUp();
                    }
                    else if (enemyChoice == 2 && enemyHealth <= 10)
                    {
                        int sphereHeal = randomSphere;
                        high.Spheres[sphereHeal].heal();
                        bHeal = high.Spheres[sphereHeal].Bonus + high.Arete;

                        for (int x = 0; x < bHeal; x++)
                        {
                            areteRoll = rnd.Next(1, 11);
                            if (areteRoll > 6)
                            {
                                high.Successess++;
                            }
                        }

                        Console.WriteLine($"{high.Name} heals {high.Successess} damage!\n");
                        enemyHealth += high.Successess;
                        high.Spheres[sphereHeal].cleanUp();
                        high.CleanUp();
                    }
                    else
                    {
                        int sphereAttack = randomSphere;
                        high.Spheres[sphereAttack].attack();
                        bAttack = high.Spheres[sphereAttack].Bonus + high.Arete;

                        for (int x = 0; x < bAttack; x++)
                        {
                            areteRoll = rnd.Next(1, 11);
                            if (areteRoll > 6)
                            {
                                high.Successess++;
                            }
                        }

                        Console.WriteLine($"{high.Name} deals {high.Successess} damage to you!\n");
                        if (playerShield > high.Successess)
                        {
                            playerShield -= high.Successess;
                        }
                        else
                        {
                            playerHealth = playerHealth - (high.Successess - playerShield);
                            playerShield = 0;
                        }

                        high.Spheres[sphereAttack].cleanUp();
                        high.CleanUp();
                    }
                }
            }

            if (enemyHealth <= 0)
            {
                
                WinScreen();
                Console.WriteLine();
                Mainmenu();
            }
            if (playerHealth <= 0)
            {
                
                GameOver();
                Console.WriteLine();
                Mainmenu();
            }
            
        }


        public void GameOver()
        {
            Console.WriteLine("-------------");
            Console.WriteLine("| Game Over |");
            Console.WriteLine("-------------");
        }

        public void WinScreen()
        {
            Console.WriteLine("------------");
            Console.WriteLine("| You Win! |");
            Console.WriteLine("------------");
        }

        

    }
}

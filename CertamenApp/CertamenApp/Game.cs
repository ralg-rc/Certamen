using System;
using System.Collections.Generic;
using System.Text;
using CertamenApp.Menus;
using CertamenApp.Character_Creation;


namespace CertamenApp
{
    public class Game 
    {
        public Game()
        {
            Menu menu = new Menu();
            menu.MainBanner();
            menu.StartMenu();
            menu.Mainmenu();
        }



    }
}

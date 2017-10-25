using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FightClub_V_3._0.VIewModel;


namespace FightClub_V_3._0.VIewModel
{
    public class AutorizationViewModel
    {
        Player hero;
        Player enemy;
        Game newgame;
        String heroname;
        public AutorizationViewModel(Autorization WinAuto)
        {
            heroname = WinAuto.Nicknamefield.Text;
            WinAuto.LogIn.Click += LOgInClick;

        }

        public void LOgInClick(object sender, RoutedEventArgs e)
        {
            hero = new Player(heroname);
            enemy = new Player("ENEMY");
            newgame = new Game();
            newgame.Show();
            App.Current.MainWindow.Hide();
            GameViewModel gmvm = new GameViewModel(newgame, hero, enemy);
        }

     
    }
}

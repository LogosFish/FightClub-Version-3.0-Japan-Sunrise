using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FightClub_V_3._0.VIewModel
{
    public class GameViewModel
    {

        
        Boolean round = true;
        Player hero;
        Player enemy;
        Random rnd;
        Game game;
        public GameViewModel(Game newgame, Player Hero, Player Enemy) 
        {
            game = newgame;
            hero = Hero;
            enemy = Enemy;
            costyl(game);
            game.HeroName.Content = hero.Name;
            foreach (var item in game.Deff.Children)
            {
                if (item is Button)
                {
                    ((Button)item).IsEnabled = false;
                }
            }
            hero.Block += Log;
            hero.Death += Log;
            hero.Wound += Log;
            enemy.Death += Log;
            enemy.Wound += Log;
            enemy.Block += Log;
            enemy.Death += EndGame;
            hero.Death += EndGame;
            game.Closing += GameCLosing;
        }

        public void Round(Game thisGame)
        {
            if (round)
            {
                foreach (var item in thisGame.Attack.Children)
                {
                    if (item is Button)
                    {
                        ((Button)item).IsEnabled = false;
                    }
                }
                foreach (var item in thisGame.Deff.Children)
                {
                    if (item is Button)
                    {
                        ((Button)item).IsEnabled = true;
                    }
                }
                round = !round;
            }
            else
            {
                foreach (var item in thisGame.Attack.Children)
                {
                    if (item is Button)
                    {
                        ((Button)item).IsEnabled = true;
                    }
                }
                foreach (var item in thisGame.Deff.Children)
                {
                    if (item is Button)
                    {
                        ((Button)item).IsEnabled = false;
                    }
                }
                round = !round;
            }
        }
        public void costyl(Game thisGame)
        {
            foreach (var item in thisGame.Attack.Children)
            {
                if (item is Button)
                {
                    ((Button)item).Click += ButtonAttackClick;
                }
            }

            foreach (var item in thisGame.Deff.Children)
            {
                if (item is Button)
                {
                    ((Button)item).Click += ButtonDeffClick;
                }
            }
        }

       

        public void EndGame(object sender, PlayerAtributes e)
        {
            game.HeroHP.Value = hero.HP;
            game.EnemyHP.Value = enemy.HP;
            if (enemy.HP == 0)
            {
                MessageBox.Show("YOU WIN!");
            }
            else
            {
                MessageBox.Show("You lose");
            }
            game.Close();
            hero.Block -= Log;
            hero.Death -= Log;
            hero.Wound -= Log;
            enemy.Death -= Log;
            enemy.Wound -= Log;
            enemy.Block -= Log;
            enemy.Death -= EndGame;
            hero.Death -= EndGame;
        }


        public void Log(object sender, PlayerAtributes e)
        {
            game.GameLog.Text += "Player " + e.name + " " + e.message + " - " + e.hp + "HP" + "\n";
        }



        private void ButtonDeffClick(object sender, RoutedEventArgs e)
        {
            rnd = new Random();
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "HeadDeff":
                    hero.SetBlock(0);
                    break;
                case "BodyDeff":
                    hero.SetBlock(1);
                    break;
                case "LegDeff":
                    hero.SetBlock(2);
                    break;
            }
            hero.GetHit(rnd.Next(0, 3));
            game.HeroHP.Value = hero.HP;
            game.EnemyHP.Value = enemy.HP;
            Round(game);
        }

        private void ButtonAttackClick(object sender, RoutedEventArgs e)
        {

            rnd = new Random();
            Button btn = (Button)sender;
            enemy.SetBlock(rnd.Next(0, 3));
            switch (btn.Name)
            {
                case "HeadAttack":
                    enemy.GetHit(0);
                    break;
                case "BodyAttack":
                    enemy.GetHit(1);
                    break;
                case "LegAttack":
                    enemy.GetHit(2);
                    break;
            }
            game.HeroHP.Value = hero.HP;
            game.EnemyHP.Value = enemy.HP;
            Round(game);
        }

        public void GameCLosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.MainWindow.Show();
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightClub_V_3._0.VIewModel;

namespace FightClub_V_3._0
{
    public class Player
    {

        String name;
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        int blocked;
        int Blocked { get; set; }

        int hp = 100;
        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
            }
        }

        public const int WoundCount = 25;

        public delegate void MyDelegate(object sender, PlayerAtributes e);

        public event MyDelegate Block;
        public event MyDelegate Wound;
        public event MyDelegate Death;

        public Player(String Nickname)
        {
            name = Nickname;
        }

        public Player()
        {
        }


        public void GetHit(int part)
        {
            if (blocked == part)
            {
                Block(this, new PlayerAtributes(name, hp, "Blocked attack"));
                
            }
            else
            {
                hp -= WoundCount;
                Wound(this, new PlayerAtributes(name, hp, "got wound"));
                if (hp <= 0)
                {
                    Death(this, new PlayerAtributes(name, hp, "die"));
                }
            }
            
        }
        public void SetBlock(int part)
        {
            blocked = part;
        }

    }
    public enum BodyParts
    {
        Head,
        Body,
        Leg
    }

}



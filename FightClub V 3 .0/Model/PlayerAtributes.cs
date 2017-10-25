using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub_V_3._0
{
    public class PlayerAtributes
    {
        public String name;
        public int hp;
        public String message;
        public PlayerAtributes(String Name, int HP , String Message)
        {
            hp = HP;
            name = Name;
            message = Message;
        }
    }
}

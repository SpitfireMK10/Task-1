using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_Term_2
{
    class RangedUnit : Unit
    {
        public int Xpos
        {
            get { return xPos; }
            set { xPos = value; }
        }


        public int Ypos
        {
            get { return yPos; }
            set { yPos = value; }
        }


        public int health
        {
            get { return Health; }
            set { Health = value; }
        }


        public int speed
        {
            get { return Speed; }
            set { Speed = value; }
        }


        public int attack
        {
            get { return Attack; }
            set { Attack = value; }
        }


        public int attackRange
        {
            get { return AttackRange; }
            set { AttackRange = value; }
        }


        public string faction
        {
            get { return Faction; }
            set { Faction = value; }
        }


        public string symbol
        {
            get { return Symbol; }
            set { Symbol = value; }
        }

        public override bool withinAttackRange(Unit unit, int distance , int range) // this is the code that will see what unit is within attack range
        {
            if (distance <= range)
            {
                return true;
            }
            else
                return false;
        }
        public override void NewPos(int i, int j) //this will set a units new position
        {
            xPos = xPos + i;
            Ypos = Ypos + j;
        }
        public override bool closestUnit(Unit unit) // this will set the current closest unit to true so that the unit can move towards it
        {
            bool closest = true;
            return closest;
        }
        public override void combatWithUnit(int attackDMG) // this runs when units are in combat and will lower the units health by the enemys attack damage
        {
            health = health - attackDMG;                        
        }
        public override bool death(int hp) // this will return true if the unit is dead so that it stops moving 
        {
            if (hp < 0)
            {
                return true;
            }
            else
                return false;
        }
        public override string toString()
        {
            return "Faction: " + faction + "\r\nSymbol: " + Symbol + "\r\nRange: " + attackRange + "\r\nAttack Damage: " + attack + "\r\nHealth: " + health + "\r\nSpeed: " + speed + "\r\nY Postion: " + Xpos + "\r\nX Postion: " + Ypos;
            
        }
    }
}

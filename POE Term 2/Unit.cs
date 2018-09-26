using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_Term_2
{
    abstract class Unit
    {
        protected int xPos;
        protected int yPos;
        protected int Health;
        protected int Speed;
        protected int Attack;
        protected int AttackRange;
        protected string Faction;
        protected string Symbol;

        public Unit() { }
        abstract public void NewPos(int x, int y);
        abstract public void combatWithUnit(int attackDMG);
        abstract public bool withinAttackRange(Unit unit, int distance, int range);
        abstract public bool closestUnit(Unit unit);
        abstract public bool death(int hp);
        abstract public string toString();
    }
}

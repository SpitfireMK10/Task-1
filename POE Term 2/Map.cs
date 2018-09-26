using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace POE_Term_2
{
    public class Map
    {
        Button[,] mapGen = new Button[20,20];
        MeleeUnit[] melee = new MeleeUnit[20];
        RangedUnit[] ranged = new RangedUnit[20];
        TextBox Info = new TextBox();
        int Horizontal =0, Vertical=0;
        Random rnd = new Random();
        int red=0;
        int blue=0;
        int xpos, ypos,unitType;
        int counter=0;
        int tick = 0;
        int x1, x2, y1, y2;
        double distance0 = 20, distance;



        public Map(Form form)
        {
            
        }

        public void MapGenerator(Form form)
        {
            #region Map Generator
            
            Point timeL = new Point(840, 420);
            Info.ReadOnly = true;
            Info.Location = timeL;
            Info.Width = 220;
            Info.Height = 220;
            Info.Multiline = true;
            form.Controls.Add(Info);

            if (tick == 0)
            {

                for (int x = 0; x < 20; x++)
                {
                    Horizontal = Horizontal + 40;
                    for (int y = 0; y < 20; y++)
                    {
                        Vertical = Vertical + 40;
                        mapGen[x, y] = new Button();
                        mapGen[x, y].Size = new System.Drawing.Size(40, 40);
                        mapGen[x, y].Location = new Point(Horizontal, Vertical);
                        mapGen[x, y].Text = "-";
                        mapGen[x, y].ForeColor = Color.BurlyWood;
                        form.Controls.Add(mapGen[x, y]);
                    }
                    Vertical = 0;
                }

                while (red <= 9)
                {
                    melee[counter] = new MeleeUnit();                   // this spawns 10 red units randomised between melee and ranged
                    ranged[counter] = new RangedUnit();
                    xpos = rnd.Next(0, 19);
                    ypos = rnd.Next(0, 19);
                    if (mapGen[xpos, ypos].Text == "-")
                    {
                        unitType = rnd.Next(1, 3);
                        if (unitType == 1)
                        {
                            mapGen[xpos, ypos].Text = "R";
                            mapGen[xpos, ypos].ForeColor = Color.Red;
                            ranged[counter].Xpos = xpos;
                            ranged[counter].Ypos = ypos;
                            ranged[counter].health = 50;
                            ranged[counter].speed = 1;
                            ranged[counter].attack = 25;
                            ranged[counter].attackRange = 4;
                            ranged[counter].faction = "Red";
                            ranged[counter].symbol = "Ranged";
                            mapGen[xpos, ypos].Click += new EventHandler(button_Click);
                            counter++;
                            red++;
                        }
                        else if (unitType == 2)
                        {
                            mapGen[xpos, ypos].Text = "M";
                            mapGen[xpos, ypos].ForeColor = Color.Red;
                            melee[counter].Xpos = xpos;
                            melee[counter].Ypos = ypos;
                            melee[counter].health = 100;
                            melee[counter].speed = 2;
                            melee[counter].attack = 50;
                            melee[counter].attackRange = 1;
                            melee[counter].faction = "Red";
                            melee[counter].symbol = "Melee";
                            mapGen[xpos, ypos].Click += new EventHandler(button_Click);
                            counter++;
                            red++;
                        }
                    }
                }

                while (blue <= 9)
                {
                    melee[counter] = new MeleeUnit();                           // this spawns 10 blue units randomised between melee and ranged
                    ranged[counter] = new RangedUnit();
                    xpos = rnd.Next(0, 19);
                    ypos = rnd.Next(0, 19);
                    if (mapGen[xpos, ypos].Text == "-")
                    {
                        unitType = rnd.Next(1, 3);
                        if (unitType == 1)
                        {
                            mapGen[xpos, ypos].Text = "R";
                            mapGen[xpos, ypos].ForeColor = Color.Blue;
                            ranged[counter].Xpos = xpos;
                            ranged[counter].Ypos = ypos;
                            ranged[counter].health = 50;
                            ranged[counter].speed = 1;
                            ranged[counter].attack = 25;
                            ranged[counter].attackRange = 4;
                            ranged[counter].faction = "Blue";
                            ranged[counter].symbol = "Ranged";
                            mapGen[xpos, ypos].Click += new EventHandler(button_Click);
                            counter++;
                            blue++;
                        }
                        else if (unitType == 2)
                        {
                            mapGen[xpos, ypos].Text = "M";
                            mapGen[xpos, ypos].ForeColor = Color.Blue;
                            melee[counter].Xpos = xpos;
                            melee[counter].Ypos = ypos;
                            melee[counter].health = 100;
                            melee[counter].speed = 2;
                            melee[counter].attack = 50;
                            melee[counter].attackRange = 1;
                            melee[counter].faction = "Blue";
                            melee[counter].symbol = "Melee";
                            mapGen[xpos, ypos].Click += new EventHandler(button_Click);
                            counter++;
                            blue++;
                        }

                    }
                }
                tick++;
            }
            #endregion
           
        }

        public void Movement()
        {
            
        }
        #region Click
        public void button_Click(object sender, EventArgs args)
        {

            int btnX;
            int btnY;

            btnX = (((((Button)sender).Location.X) / 40)-1);  //this is divided by 40 and minused by 1 so that it can directly correlate to the x and y of the array 
            btnY = (((((Button)sender).Location.Y) / 40)-1);
            if(btnX <0)
            {
                btnX = 0;
            }
            if (btnY < 0)
            {
                btnY = 0;
            }
            for (int i=0;i<20;i++)
            {
                if(btnX == melee[i].Xpos && btnY == melee[i].Ypos)
                {
                   Info.Text = ("" + melee[i].toString());
                }
                else if (btnX == ranged[i].Xpos && btnY == ranged[i].Ypos)
                {
                    Info.Text = ("" + ranged[i].toString());
                }
            }
        }
        #endregion
    }
}

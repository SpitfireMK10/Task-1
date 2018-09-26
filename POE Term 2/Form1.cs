using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POE_Term_2
{
    public partial class Form1 : Form
    {
        bool pause = false;
        int counter = 0;
        TextBox timer = new TextBox();

        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Start/Stop
            Button Stop = new Button();
            Button Start = new Button();
            Point StartL = new Point(840, 80);
            Point StopL = new Point(840, 40);

            Start.Location = StartL;
            Start.Width = 120;
            Start.Height = 40;
            Start.Text = "Resume";
            this.Controls.Add(Start);
            Start.Click += new EventHandler(StartButton);

            Stop.Location = StopL;
            Stop.Width = 120;
            Stop.Height = 40;
            Stop.Text = "Pause";
            this.Controls.Add(Stop);
            Stop.Click += new EventHandler(StopButton);


            #endregion
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Map map = new Map(this);                                    //this is the timer tick where it spawns the buttons initially and then runs through movement and combat methods until paused is pressed
            if (counter == 0)
            {
                timer = new TextBox();
                Point timeL = new Point(840, 120);
                timer.ReadOnly = true;
                timer.Location = timeL;
                timer.Width = 120;
                timer.Height = 40;
                this.Controls.Add(timer);
                
                
                map.MapGenerator(this);
            }

            if (pause == false)
            {
                map.Movement();
                counter++;       
            }

            timer.Text = (counter.ToString());


        }
        public void StartButton(object sender, EventArgs args)
        {
            pause = false;
        }
        public void StopButton(object sender, EventArgs args)
        {
            pause = true;
        }
    }
}

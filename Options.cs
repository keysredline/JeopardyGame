using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeopardy
{
    public partial class Options : Form
    {
        public static Options instance;
        public List<Player> player = new List<Player>();
        public Options()
        {
            InitializeComponent();
            instance = this;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){}

        //create player objs from txtboxs
        //send player objs into a list
        private void btnStart_Click(object sender, EventArgs e)
        {
            player.Clear();
            int index = comboBox1.SelectedIndex;//get index
            //Form1.instance.p1.Text = "s00";
            for (int i = -1; i < index; i++)//add players to objs
            {
                string name = this.Controls[$"txtPlayer{i + 2}"].Text;//set var to txt boxs data
                player.Add(new Player(name, 0));//add new obj olayer to list

            }
            Form1.instance.timer();//call game timer that / game will be saved and ended after time is up
            AddPlayerStats(index);

        }
        //dispers player info to form1 display boxes
        public void AddPlayerStats(int index)
        {
                if (index == 1)
                {
                    Form1.instance.p1.Text = player[0].Name;
                    Form1.instance.p1s.Text = player[0].Score.ToString();
                    Form1.instance.p2.Text = player[1].Name;
                    Form1.instance.p2s.Text = player[1].Score.ToString();
                }
                else if (index == 2)
                {
                    Form1.instance.p1.Text = player[0].Name;
                    Form1.instance.p1s.Text = player[0].Score.ToString();
                    Form1.instance.p2.Text = player[1].Name;
                    Form1.instance.p2s.Text = player[1].Score.ToString();
                    Form1.instance.p3.Text = player[2].Name;
                    Form1.instance.p3s.Text = player[2].Score.ToString();
                }
                else
                    Form1.instance.p1.Text = player[0].Name;
                    Form1.instance.p1s.Text = player[0].Score.ToString();

            
        }
        }//class
}//

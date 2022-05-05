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
    public partial class FormQA : Form
    {
        public static FormQA instance;
        public TextBox txt1, txt2;
        public UserControl1 txt11;
        private int counter = 10;
        private Timer timer1;
        public FormQA()
        {
            InitializeComponent();
            instance = this;
            txt1 = textBox1;
            txt2 = textBox2;
            txt11 = txtBxLine1;
            timer();
        }


        private void CheckAnswer()
        {
            timer1.Dispose();
            if (txtBxLine1.Texts == txt2.Text.ToLower())
            {
                //MessageBox.Show("score");
                //obj[1].Score += 10;
                Options.instance.player[Form1.instance.currentPlayer].Score += Form1.instance.boxValue;
                MessageBox.Show("score" + Options.instance.player[Form1.instance.currentPlayer].Score);
            }
            else
            {
                Options.instance.player[Form1.instance.currentPlayer].Score -= Form1.instance.boxValue;
                MessageBox.Show("wrong");
            }
            UpdateScores();
            
        }

        private void UpdateScores()
        {
            if(Form1.instance.currentPlayer == 0)
                Form1.instance.p1s.Text = Options.instance.player[0].Score.ToString();
            else if(Form1.instance.currentPlayer == 1)
                Form1.instance.p2s.Text = Options.instance.player[1].Score.ToString();
            else if (Form1.instance.currentPlayer == 2)
                Form1.instance.p3s.Text = Options.instance.player[2].Score.ToString();
        }
        private void roundBTN1_Click(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
            CheckAnswer();
        }
        public void timer()
        {
            int counter = 10;
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            roundBTN2.Text = counter.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                timer1.Stop();
                CheckAnswer();
                textBox2.ForeColor = Color.Black;
            }

            roundBTN2.Text = counter.ToString();
        }

    }//class
}

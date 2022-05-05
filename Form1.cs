using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
//Dev: Justin Fredericks
//Date: 12/03/2021
//Class: 151
//Script: Jeopardy 

namespace Jeopardy
{
    public partial class Form1 : Form
    {
        public List<QnA> Qs = new List<QnA>();
        public static Form1 instance;//use a var allowing a connection ref between forms
        public RoundBTN p1, p1s, p2, p2s, p3, p3s;//vars set for use outside of this form
        public TextBox tx1;
        public int currentPlayer = 0;
        public int boxValue = 0;
        //FormQnA formQA = new FormQnA();
        public int Qbx=0;
        public int Abx = 0;
        public Form1()
        {
            InitializeComponent();
            var splash = new SplashScreen();
            instance = this;//set instance var of this form
            //set local vars = to public vars
            p1 = btnP1Name;
            p1s = btnP1Score;
            p2 = btnP2Name;
            p2s = btnP2Score;
            p3 = btnP3Name;
            p3s = btnP3Score;
            tx1 = textBox1;
            splash.Show();
            LoadXML();

        }

        #region Player click
        private void btnP1Name_Click(object sender, EventArgs e)
        {
            currentPlayer = 0;
        }

        private void btnP2Name_Click(object sender, EventArgs e)
        {
            currentPlayer = 1;
        }

        private void btnP3Name_Click(object sender, EventArgs e)
        {
            currentPlayer = 2;
        }
        #endregion
        #region Games Boxes
        private void SetQnABoxes(int x)
        {//loads box Qs and As into display form FormQA
            FormQA.instance.txt1.Text = Qs[x].Question;
            FormQA.instance.txt2.Text = Qs[x].Answer;
            //FormQA.instance.txt11.Texts = Qs[x].Question;

        }
        private void btnMon1x1_Click(object sender, EventArgs e)
        {
            boxValue = 100;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(0);
            btnMon1x1.Text = "";
            qCounter += 1;
            //FormQA.instance.txt1.Text = "hello there  \r\nmy hear";
        }
        private void btnMon2x1_Click(object sender, EventArgs e)
        {
            boxValue = 200;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(1);
            btnMon2x1.Text = "";
            qCounter += 1;
        }
        private void btnMon3x1_Click(object sender, EventArgs e)
        {
            boxValue = 300;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(2);
            btnMon3x1.Text = ""; qCounter += 1;
        }

        private void btnMon4x1_Click(object sender, EventArgs e)
        {
            boxValue = 400;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(3);
            btnMon4x1.Text = ""; qCounter += 1;
        }

        private void btnMon5x1_Click(object sender, EventArgs e)
        {
            boxValue = 500;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(4);
            btnMon5x1.Text = ""; qCounter += 1;
        }

        private void btnMon1x2_Click(object sender, EventArgs e)
        {
            boxValue = 100;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(5);
            btnMon1x2.Text = ""; qCounter += 1;
        }

        private void btnMon2x2_Click(object sender, EventArgs e)
        {
            boxValue = 200;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(6);
            btnMon2x2.Text = ""; qCounter += 1;
        }

        private void btnMon3x2_Click(object sender, EventArgs e)
        {
            boxValue = 300;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(7);
            btnMon3x2.Text = ""; qCounter += 1;
        }

        private void btnMon4x2_Click(object sender, EventArgs e)
        {
            boxValue = 400;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(8);
            btnMon4x2.Text = ""; qCounter += 1;
        }

        private void btnMon5x2_Click(object sender, EventArgs e)
        {
            boxValue = 500;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(9);
            btnMon5x2.Text = ""; qCounter += 1;
        }

        private void btnMon1x3_Click(object sender, EventArgs e)
        {
            boxValue = 100;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(10);
            btnMon1x3.Text = ""; qCounter += 1;
        }

        private void btnMon2x3_Click(object sender, EventArgs e)
        {
            boxValue = 200;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(11);
            btnMon2x3.Text = ""; qCounter += 1;
        }

        private void btnMon3x3_Click(object sender, EventArgs e)
        {
            boxValue = 300;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(12);
            btnMon3x3.Text = ""; qCounter += 1;
        }

        private void btnMon4x3_Click(object sender, EventArgs e)
        {
            boxValue = 400;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(13);
            btnMon4x3.Text = ""; qCounter += 1;
        }

        private void btnMon5x3_Click(object sender, EventArgs e)
        {
            boxValue = 500;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(14);
            btnMon5x3.Text = ""; qCounter += 1;
        }

        private void btnMon1x4_Click(object sender, EventArgs e)
        {
            boxValue = 100;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(15);
            btnMon1x4.Text = ""; qCounter += 1;
        }

        private void btnMon2x4_Click(object sender, EventArgs e)
        {
            boxValue = 200;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(16);
            btnMon2x4.Text = ""; qCounter += 1;
        }

        private void btnMon3x4_Click(object sender, EventArgs e)
        {
            boxValue = 300;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(17);
            btnMon3x4.Text = ""; qCounter += 1;
        }

        private void btnMon4x4_Click(object sender, EventArgs e)
        {
            boxValue = 400;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(18);
            btnMon4x4.Text = ""; qCounter += 1;
        }

        private void btnMon5x4_Click(object sender, EventArgs e)
        {
            boxValue = 500;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(19);
            btnMon5x4.Text = ""; qCounter += 1;
        }

        private void btnMon1x5_Click(object sender, EventArgs e)
        {
            boxValue = 100;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(20);
            btnMon1x5.Text = ""; qCounter += 1;
        }

        private void btnMon2x5_Click(object sender, EventArgs e)
        {
            boxValue = 200;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(21);
            btnMon2x5.Text = ""; qCounter += 1;
        }

        private void btnMon3x5_Click(object sender, EventArgs e)
        {
            boxValue = 300;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(22);
            btnMon3x5.Text = ""; qCounter += 1;
        }

        private void btnMon4x5_Click(object sender, EventArgs e)
        {
            boxValue = 400;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(23);
            btnMon4x5.Text = ""; qCounter += 1;
        }

        private void btnMon5x5_Click(object sender, EventArgs e)
        {
            boxValue = 500;
            FormQA y = new FormQA();
            y.Show();
            SetQnABoxes(24);
            btnMon5x5.Text = ""; qCounter += 1;
        }
#endregion
        /// <summary>
        /// set up a xml doc object
        /// load the xml file
        /// parse the file by nodes
        /// add parent attr into a var
        /// add child nodes inner txt data into vars
        /// create a new obj(QnA) and add it to List(Qs) 
        /// </summary>
        private void LoadXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("jeop.xml");
            foreach (XmlNode node in doc.DocumentElement)
            {
                string category = node.Attributes[0].Value;
                string Q = (node["Q"].InnerText);
                string A = (node["A"].InnerText);

                Qs.Add(new QnA(category,Q,A));
            }
           // QnALoad();
            ButtonDisplay();
        }
        //loads the list data of parent nodes(game data titles) into the header displays
        private void ButtonDisplay()
        {
            btnCat1.Text = Qs[0].Category;
            btnCat2.Text = Qs[5].Category;
            btnCat3.Text = Qs[10].Category;
            btnCat4.Text = Qs[15].Category;
            btnCat5.Text = Qs[20].Category;

        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {//open results form
            FormResults x = new FormResults();
            x.Show();
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {//save game results into the db
            SaveGame();
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveGame();
            timer();
        }
        private void SaveGame()
        {
            //if (Options.instance.player.Count() >=1) { 
            DataAdapter.InsertNonSerialized(Options.instance.player);//sending the list of players to be serial
            foreach (Player item in Options.instance.player)//parse the List of its objects sending them to be inserted into the DB
            {
                item.InsertPerson();
            }
        
        }

        private void playersToolStripMenuItem_Click(object sender, EventArgs e)
        {//opens up options form 
            Options playerSet = new Options();
            playerSet.Show();
      
        }

        //timer 
        public void timer()
        {
            int counter = 1000
                ;
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000; // 1 second
            timer1.Start();
            label1.Text = counter.ToString();
        }
        private int counter = 10000;
        private Timer timer1;
        private int qCounter=0; 
        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0 || qCounter ==25)
            {
                timer1.Stop();
                MessageBox.Show("Game Over");
            }
                
            label1.Text = counter.ToString();
        }

    }//class
}//ns


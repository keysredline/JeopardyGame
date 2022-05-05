using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Jeopardy
{
    class WriteXML
    {
        public string name { get; set; }
        public int score { get; set; }

        public WriteXML(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public void Write(XmlDocument doc){
            doc.Load("scores.xml");
            XmlNode game = doc.CreateElement("game");//wrapper node
            
            XmlNode score = doc.CreateElement("score");
            score.InnerText = name.ToString();
            game.AppendChild(score);//obj identifier + Code = unique ticket #

            XmlNode nameX = doc.CreateElement("nameX");
            nameX.InnerText = score.ToString();
            game.AppendChild(nameX);

            doc.DocumentElement.AppendChild(game);
            doc.Save("receipt.xml");
        }
    }//class
}

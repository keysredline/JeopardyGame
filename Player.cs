using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    [Serializable]
    public class Player
    {
        private string name;
        private int score;
        private int game;
        public Player() { }
        public string Name { get => name; set => name = value; }
        public int Score { get => score; set => score = value; }
        public int Game { get => game; set => game = value; }

        public Player( int game)
        {

            this.game = game;
        }
        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public Player(string name, int score, int game)
        {
            this.name = name;
            this.score = score;
            this.game = game;
        }
        internal void InsertPerson()
        {
           // DAdapter y = new DAdapter();
            game = DataAdapter.Insert(this);
            //game = y.Insert(this);
        }
        internal static List<Player> GetAllPerson()
        {
            //call the DB Get method to get all the records
            //DAdapter x = new DAdapter();
            return DataAdapter.GetAllPlayer();
            //return x.GetAllPlayer();
        }

    }//class
}

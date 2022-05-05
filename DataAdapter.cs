using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
//Dev: Justin F
//Date: 12/03/2021
//Class: 151
//Script: Jeopardy 
namespace Jeopardy
{
    /// <summary>
    /// static methods to connect to, disconnect from, store data to and retrieve data from database Player table
    /// </summary>
    static class DataAdapter
    {
        static SqlConnection oConn = new SqlConnection("Data Source=stusql-cis151-101-fa21.cimq4ah3jd04.us-east-2.rds.amazonaws.com,1433;" +
                    "Initial Catalog= jf0934599; User Id=jf0934599;Password=934599;");
        /// <summary>
        /// connect using the oConn connection string
        /// </summary>
        private static void Connect()
        {
            try
            {
                oConn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// disconnect from the open connection
        /// </summary>
        private static void Disconnect()
        {
            try
            {
                oConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// send game data to game tables (PlayerK -> plaayersK () 1 - many relation) as each game can have many players
        /// using a flag we check the player count so we can run the correct query
        /// set up a var that hold lst used PK value, in order to add game data together with same identity
        /// takes in the created list of players so index values can be used while sending the query
        /// flag var is needed to check the player number within the List
        /// </summary>
        /// <param name="player"></param>
        public static void InsertNonSerialized(List<Player> player)
        {
            try
            {
                int flag = player.Count();
                string sqlIns = "";

                if (flag == 1)
                {
                    sqlIns = $"DECLARE @DataID int; " +
                    $"INSERT INTO PlayerK default values;" +
                    $"SELECT @DataID = scope_identity();" + 
                    $"INSERT INTO playersK([name],Score,GameID) VALUES('{player[0].Name}', '{player[0].Score}',scope_identity() );";
                    SqlCommand cmdns = new SqlCommand(sqlIns, oConn);
                    Connect();
                    cmdns.ExecuteNonQuery();
                }
                else if (flag == 2)
                {
                    sqlIns = $"DECLARE @DataID int; " +
                    $"INSERT INTO PlayerK default values;" +
                    $"SELECT @DataID = scope_identity();" +
                    $"INSERT INTO playersK([name],Score,GameID) VALUES('{player[0].Name}', '{player[0].Score}',@DataID);" +
                    $"INSERT INTO playersK([name],Score,GameID) VALUES('{player[1].Name}', '{player[1].Score}', @DataID);";
                    SqlCommand cmdns = new SqlCommand(sqlIns, oConn);
                    Connect();
                    cmdns.ExecuteNonQuery();

                }
                else
                {
                    sqlIns = $"DECLARE @DataID int; " +
                    $"INSERT INTO PlayerK default values;" +
                    $"SELECT @DataID = scope_identity();" +
                    $"INSERT INTO playersK([name],Score,GameID) VALUES('{player[0].Name}', '{player[0].Score}',@DataID);" +
                    $"INSERT INTO playersK([name],Score,GameID) VALUES('{player[1].Name}', '{player[1].Score}',@DataID);" +
                    $"INSERT INTO playersK([name],Score,GameID) VALUES('{player[2].Name}', '{player[2].Score}',@DataID);";
                    SqlCommand cmdns = new SqlCommand(sqlIns, oConn);
                    Connect();
                    cmdns.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Form1.instance.tx1.Text = (ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }
        /// <summary>
        /// use a nested aggregated function to return the high score and game data it was in 
        /// </summary>
        /// <returns></returns>
        public static List<Player> GetHighScore()
        {
            List<Player> list = new List<Player>();
            Connect();
            try
            {
                string sqlIns = $"select * " +
                $"from playersK " +
                $"where Score = (select max(Score) from playersK);";
                SqlCommand cmd = new SqlCommand(sqlIns, oConn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Player(
                    reader["name"].ToString(),
                    Convert.ToInt32(reader["Score"]),
                    Convert.ToInt32(reader["GameID"])));
                }
            }
            catch (Exception ex)
            {
                Form1.instance.tx1.Text = (ex.Message);
            }
            finally
            {
                Disconnect();
            }
            return list;
        }
        /// <summary>
        /// serialize the data then insert the Player object into the table as a new row
        /// </summary>
        /// <param name="Player"></param>
        public static int Insert(Player Player)
        {
            
            int id = 0;
            string data = Serializer.SerializeNow(Player);
            // set up sql command to include a select to get the new identity value
            string sqlIns = "INSERT INTO Player(name) VALUES(@data); SELECT CAST(scope_identity() AS int);";
            Connect();

            try
            {
                SqlCommand cmdIns = new SqlCommand(sqlIns, oConn);  // create a new command object to run our sql
                cmdIns.Parameters.AddWithValue("@data", data);      // explain that the @data parameter should be replaced by the value of data variable

                id = (int)cmdIns.ExecuteScalar();                   // ExecuteScalar returns a value. In our case, the ID since that is what our query asked for

            }
            catch (Exception ex)
            {
                Form1.instance.tx1.Text = (ex.Message);
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
            return id;
        }
        public static List<Player> GetAllPlayer()
        {
            List<Player> allPlayer = new List<Player>();

            Connect();

            try
            {

                string sql = "SELECT * FROM Player";
                //string sql =  "select min(Score) from testPlayer";
                SqlCommand cmd = new SqlCommand(sql, oConn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //while we are getting records from the DB
                    //we need to be deserializing them and
                    //creating objects
                    Player Player = (Player)Serializer.DeSerializeNow(reader["name"].ToString());
                    Player.Game = (int)reader["id"];
                    allPlayer.Add(Player);
                }
            }
            catch (Exception ex)
            {
                Form1.instance.tx1.Text = (ex.Message);
            }
            finally
            {
                Disconnect();
            }
            return allPlayer;
        }
        //public static int Insert(Player Player)
        //{
        //    int id = 0;
        //    int HighScore = 0;
        //    string name = Serializer.SerializeNow(Player.Name);
        //    string score = Serializer.SerializeNow(Player.Score.ToString());
        //    // set up sql command to include a select to get the new identity value
        //    string sqlIns = $"INSERT INTO Player(name,Score) VALUES('{name}','{score}'); SELECT CAST(scope_identity() AS int);";
        //    Connect();


        //    try
        //    {
        //        SqlCommand cmdIns = new SqlCommand(sqlIns, oConn);  // create a new command object to run our sql
        //        cmdIns.ExecuteNonQuery();     // explain that the @data parameter should be replaced by the value of data variable

        //        id = (int)cmdIns.ExecuteScalar();                   // ExecuteScalar returns a value. In our case, the ID since that is what our query asked for

        //    }
        //    catch (Exception ex)
        //    {
        //        Form1.instance.lb.Text = ex.Message;
        //        //Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        Disconnect();
        //    }
        //    return id;
        //}
        /// <summary>
        /// select all of the Player rows from the db table. de-serialize to return Player object list
        /// </summary>
        /// <returns></returns>
        /// 
        //public static List<Player> GetAllPlayer()
        //{
        //    List<Player> allPlayer = new List<Player>();

        //    Connect();

        //    try
        //    {

        //        string sql = "SELECT * FROM Player";
        //        // string sql = "SELECT max([name]) FROM Player";
        //        SqlCommand cmd = new SqlCommand(sql, oConn);
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            //while we are getting records from the DB
        //            //we need to be deserializing them and
        //            //creating objects
        //            //Player Player = (Player)Serializer.DeSerializeNow(reader["name"].ToString());
        //            Player Player = (new Player(Serializer.DeSerializeNow(reader["name"].ToString()));
        //            Player.Game = (int)reader["id"];
        //            allPlayer.Add(Player);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Form1.instance.tx1.Text = (ex.Message);
        //    }
        //    finally
        //    {
        //        Disconnect();
        //    }
        //    return allPlayer;
        //}

    }//class
}


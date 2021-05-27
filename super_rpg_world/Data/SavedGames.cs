using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace super_rpg_world
{

    public class SavedGames
    {
        public List<Game> AllGames = new List<Game>();
        public static SqlConnection connection;

        public static void Connect(string root)
        {

            try
            {
                connection = new SqlConnection($"Data source={root}; Initial Catalog=RPGWORLD; integrated security=true");
            }
            catch
            {
                Console.WriteLine("No se pudo conectar con la base de datos");
                Console.ReadKey();
            }

        }

        public static void SaveNew()
        {
            //Case nuevo jugador
            string savingPlayer = $"INSERT INTO Players(PlayerName, PlayerLevel, St, Intel, Cr, Rs, Age, TimeLife, LongLife, Gender, Race, Class, cure, fury, meditate, vampire, HpMax, HpTotal, ManaMax, ManaTotal, XpMax, XpTotal) VALUES('{Program.Player.Name}', {Program.Player.Lvl}, {Program.Player.St}, {Program.Player.In}, {Program.Player.Cr},{Program.Player.Rs}, {Program.Player.Age},{Program.Player.LongLife}, {Program.Player.LifeTime}, '{Program.Player.Gender}', '{Program.Player.Race}', '{Program.Player.Class}', '{Program.Player.cure}', '{Program.Player.fury}', '{Program.Player.meditate}', '{Program.Player.vampire}', {Program.Player.Hp[1]}, {Program.Player.Hp[0]}, {Program.Player.Mana[1]}, {Program.Player.Mana[0]}, {Program.Player.Xp[1]},{Program.Player.Xp[0]})";
            string savingInv = $"INSERT INTO Inventory(Potion) VALUES({Program.Inventory.Potion.quantity})";
            string savingWorld = $"INSERT INTO Worlds(corruption, WorldName) VALUES({Program.Gea.corruption}, '{Program.Gea.Name}')";
            //NOW a Query to create a new savegame archive with te latest rows (those we've created just now)
            string NewSavedGame = $"INSERT INTO SavedGames(PlayerID, inventoryId, WorldId) values((SELECT TOP 1 PlayerName FROM Players ORDER BY PlayerName DESC), (SELECT TOP 1 Id FROM Inventory ORDER BY Id DESC), (SELECT TOP 1 Id FROM Worlds ORDER BY Id DESC))";

            
            SqlCommand sendPlayer = new SqlCommand(savingPlayer, connection);
            SqlCommand sendInv = new SqlCommand(savingInv, connection);
            SqlCommand sendWorld = new SqlCommand(savingWorld, connection);
            SqlCommand sendNewGame = new SqlCommand(NewSavedGame, connection);
            connection.Open();
            //PELIGRO CON CLAVE DUPLICADA (SqlException)
            sendPlayer.ExecuteNonQuery();
            sendInv.ExecuteNonQuery();
            sendWorld.ExecuteNonQuery();
            System.Threading.Thread.Sleep(1000);
            sendNewGame.ExecuteNonQuery();
            connection.Close();
            
        }

        public static bool LoadMenu(List<Game> Games)
        {
            List<string> menuList = VisualList(Games);
            menuList.Add("<< Atrás");

            if (Games.Count <= 0)
            {
                Boxy NoGamesMs = new Boxy(22, 0, 15, true, "No hay juegos guardados");
                Console.ReadKey();
                NoGamesMs.Erase();
                return false;
            }
            else
            {
                Menu SavedGames = new Menu(12, true);
                int game = SavedGames.Read(menuList, "Elige qué partida quieres cargar", 3);
                if (game < Games.Count)
                {
                    //Game LOADED
                    LoadGame(Games[game]);
                    Console.Clear();
                    Boxy LoadedMs = new Boxy(18, 0, 15, true, "Partida cargada");
                    Console.ReadKey();
                    LoadedMs.Erase();
                return true;
                }
                else
                {
                    SavedGames.Erase();
                    return false;
                }


            }

        }

        public static void LoadGame(Game game)
        {
            Program.Player = game.SavedPlayer;
            Program.Player.existent = true;
            Program.Gea = game.SavedWorld;
            Program.Inventory = game.SavedInv;
        }

        public static List<Game> GetAll()
        {
            string getAll = $"SELECT Id FROM SavedGames";
            SqlCommand getGames = new SqlCommand(getAll, connection);
            connection.Open();
            SqlDataReader reader = getGames.ExecuteReader();

            List<int> Finds = new List<int>();

            while (reader.Read())
            {
                Finds.Add(Convert.ToInt32(reader[0]));
            }

            connection.Close();

            List<Game> LoadedGames = new List<Game>();

            foreach (int i in Finds)
            {
                LoadedGames.Add(new Game(i, GetPlayer(i), GetInv(i), GetWorld(i)));
            }

            return LoadedGames;

        }

        public static Player GetPlayer(int gameId)
        {
            Player load = new Player();
            string getAll = $"SELECT Players.* FROM SavedGames LEFT JOIN Players ON (SELECT PlayerId FROM SavedGames WHERE id = {gameId})=Players.PlayerName";
            SqlCommand getGames = new SqlCommand(getAll, connection);
            connection.Open();
            SqlDataReader reader = getGames.ExecuteReader();
            while (reader.Read())
            {
                load.Name = reader[0].ToString();
               load.Lvl = Convert.ToInt32(reader[1]);  
               load.St = Convert.ToInt32(reader[2]);  
               load.In = Convert.ToInt32(reader[3]);  
               load.Cr = Convert.ToInt32(reader[4]);  
               load.Rs = Convert.ToInt32(reader[5]);  
               load.Age = Convert.ToInt32(reader[6]);  
               load.LifeTime = Convert.ToInt32(reader[7]);  
               load.LongLife = Convert.ToInt32(reader[8]);  
               load.Gender = reader[9].ToString();  
                load.Race = reader[10].ToString();  
                load.Class = reader[11].ToString();  
                load.cure = Convert.ToBoolean(reader[12]);  
                load.fury = Convert.ToBoolean(reader[13]);  
                load.meditate = Convert.ToBoolean(reader[14]);  
                load.vampire = Convert.ToBoolean(reader[15]);  
                load.Hp[1] = Convert.ToInt32(reader[16]);  
                load.Hp[0] = Convert.ToInt32(reader[17]);  
                load.Mana[1] = Convert.ToInt32(reader[18]);  
                load.Mana[0] = Convert.ToInt32(reader[19]);  
                load.Xp[1] = Convert.ToInt32(reader[20]);  
                load.Xp[0] = Convert.ToInt32(reader[21]);
                break;
            }

            connection.Close();
            return load;
        }
        
        public static Inventory GetInv(int gameId)
        {
            Inventory load = new Inventory();
            string getAll = $"SELECT Inventory.* FROM SavedGames LEFT JOIN Inventory ON (SELECT InventoryId FROM SavedGames WHERE id = {gameId})=Inventory.Id";
            SqlCommand getGames = new SqlCommand(getAll, connection);
            connection.Open();
            SqlDataReader reader = getGames.ExecuteReader();
            while (reader.Read())
            {
                load.Id = Convert.ToInt32(reader[0]);
                load.Potion.quantity = Convert.ToInt32(reader[1]);              
                break;
            }
            connection.Close();

            return load;
        }

        public static World GetWorld(int gameId)
        {
            World load = new World();
            string getAll = $"SELECT Worlds.* FROM SavedGames LEFT JOIN Worlds ON (SELECT WorldId FROM SavedGames WHERE id = {gameId})=Worlds.id";
            SqlCommand getGames = new SqlCommand(getAll, connection);
            connection.Open();
            SqlDataReader reader = getGames.ExecuteReader();
            while (reader.Read())
            {
                load.Id = Convert.ToInt32(reader[0]);
                load.corruption = Convert.ToInt32(reader[1]);
                break;
            }
            connection.Close();

            return load;
        }

        public static void Rewrite()
        {
            string rwPlayer = $"UPDATE Players SET PlayerLevel = '{Program.Player.Lvl}', St = {Program.Player.St}, Intel = {Program.Player.In}, Cr = {Program.Player.Cr}, Rs = {Program.Player.Rs}, Age = {Program.Player.Age}, TimeLife = {Program.Player.LifeTime}, LongLife = {Program.Player.LongLife}, Race = '{Program.Player.Race}',Class = '{Program.Player.Class}',cure = '{Program.Player.cure}', fury = '{Program.Player.fury}', meditate = '{Program.Player.meditate}', vampire = '{Program.Player.vampire}', HpMax = {Program.Player.Hp[1]}, HpTotal = {Program.Player.Hp[0]}, ManaMax = {Program.Player.Mana[1]}, ManaTotal = {Program.Player.Mana[0]}, XpMax = {Program.Player.Xp[0]}, XpTotal = {Program.Player.Mana[1]} WHERE Playername = '{Program.Player.Name}';";
            string savingInv = $"UPDATE Inventory SET Potion = {Program.Inventory.Potion.quantity} WHERE Id = {Program.Inventory.Id}";
            string savingWorld = $"UPDATE Worlds SET corruption = {Program.Gea.corruption} WHERE Id = {Program.Gea.Id}";

            SqlCommand sendPlayer = new SqlCommand(rwPlayer, connection);
            SqlCommand sendInv = new SqlCommand(savingInv, connection);
            SqlCommand sendWorld = new SqlCommand(savingWorld, connection);
            connection.Open();
            sendPlayer.ExecuteNonQuery();
            sendInv.ExecuteNonQuery();
            sendWorld.ExecuteNonQuery();
            connection.Close();

        }

        public static List<string> VisualList(List<Game> Games)
        {
            List<string> VisualList = new List<string>();
            foreach (Game elem in Games)
            {
                VisualList.Add($"{elem.SavedPlayer.Name} - nvl {elem.SavedPlayer.Lvl}");
            }

            return VisualList;
        }

        public static void DeleteCurrentGame()
        {
            string delPlayer = $"DELETE Players WHERE Playername = '{Program.Player.Name}';";
            string delInv = $"DELETE Inventory WHERE Id = {Program.Inventory.Id}";
            string delWorld = $"DELETE Worlds WHERE Id = {Program.Gea.Id}";
            string delGame = $"DELETE SavedGames WHERE PlayerID = '{Program.Player.Name}'";

            SqlCommand sendPlayer = new SqlCommand(delPlayer, connection);
            SqlCommand sendInv = new SqlCommand(delInv, connection);
            SqlCommand sendWorld = new SqlCommand(delWorld, connection);
            SqlCommand sendGame = new SqlCommand(delGame, connection);
            connection.Open();
            sendGame.ExecuteNonQuery();
            sendPlayer.ExecuteNonQuery();
            sendInv.ExecuteNonQuery();
            sendWorld.ExecuteNonQuery();
            connection.Close();
        }

        public static bool CheckPlayerName(string newPlayer)
        {
            List<string> players = new List<string>();
            string getAll = $"SELECT PlayerName FROM Players";
            SqlCommand getGames = new SqlCommand(getAll, connection);
            connection.Open();
            SqlDataReader reader = getGames.ExecuteReader();
            while (reader.Read())
            {
                players.Add(reader[0].ToString());              
            }
            connection.Close();

            foreach (string playerName in players)
            {
                if (playerName == newPlayer)
                {
                    return true;
                }
            }

            return false;

        }
    }
}

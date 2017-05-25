using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace BrainTrainer
{
	[Serializable]
	public class Manager
	{
		public List<User> Users = new List<User>();

		public User CurrentUser
		{
			get;
			set;
		}

		public Game CurrentGame
		{
			get;
			set;
		}

		public void Serialize(string filename)
		{
			FileStream fs = new FileStream(filename, FileMode.Create);
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(fs, this);
			fs.Close();
		}

		public void Deserialize(string filename)
		{
			FileStream fs = new FileStream(filename, FileMode.Open);
			BinaryFormatter formatter = new BinaryFormatter();
			Manager manager = (Manager)formatter.Deserialize(fs);
			Users = manager.Users;

			//CurrentUser = null;
		}

		public Message SelectGame(string name)
		{
			if (CurrentUser == null)
			{
				return Messages.SelectGame.NoCurrentUser;
			}
			
			foreach (Game game in CurrentUser.Games)
			{
				if (game.Name == name)
				{
					CurrentGame = game;
					return Messages.SelectGame.NoCurrentUser;
				}
			}

			return Messages.SelectGame.NotFound;
		}
	}
}

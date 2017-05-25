using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using BrainTrainer;


namespace RunnerConsole
{
	//status
	//

	//options
	//-g : game
	//list
	//select [game name]
	//start
	//exit

	//-u : user
	//list
	//select [user name]
	//add [user name]
	//delete [user name]
	//change [existing user name] [new user name]
	
	//-exit
	


	static class Program
	{
		static Manager manager;

		static void Parser(string str)
		{
			List<string> args = str.ToLower().Split(' ').ToList();

			if (args[0] == "-g")
			{
				if (args[1] == "list")
				{
					foreach (var e in manager.CurrentUser.Games)
					{
						Console.WriteLine(e.Name);
					}
				}
				else if (args[1] == "select")
				{
					
				}
			}
			else if (args[0] == "-u")
			{
			}

		}

		static void Main(string[] args)
		{
			FileStream fs = new FileStream("asdf", FileMode.Create);
			StreamWriter writer = new StreamWriter(fs);
			writer.Write(true);
			
			

			manager = new Manager();
			try
			{
				manager.Deserialize("save.bin");
			}
			catch
			{

			}

			if (manager.Users.Count == 0)
			{
				
			}
		}
	}
}

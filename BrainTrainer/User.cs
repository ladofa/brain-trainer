using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainTrainer
{
	[Serializable]
	public class User
	{
		public string Name
		{
			get;
			set;
		}

		public List<Game> Games;

		public User(string name)
		{
			Name = name;
			Games.Add(new Games.MemoryStack());
		}
	}
}

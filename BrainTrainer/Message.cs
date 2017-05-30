using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainTrainer
{
	public class Message
	{
		internal Message()
		{
		}
	}

	public static class Messages
	{
		public static class GameSelect
		{
			public static Message NoCurrentUser = new Message();
			public static Message Done = new Message();
			public static Message NotFound = new Message();
			public static Message IllegalNumber = new Message();
		}

		public static class GameList
		{
			public static Message NoCurrentUser = new Message();
			public static Message Done = new Message();
		}
	}



}

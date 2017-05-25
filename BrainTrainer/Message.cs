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
		public static class SelectGame
		{
			public static Message NoCurrentUser = new Message();
			public static Message Done = new Message();
			public static Message NotFound = new Message();
		}
	}



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainTrainer.Games
{
	public class MemoryStack : Game
	{
		public MemoryStack()
			: base("MemoryStick", new Difficulty(2, new []{ "changing", "countAtOnce"}.ToList()))
		{

		}

		List<Symbols> trueStack = new List<Symbols>();
		List<Symbols> userStack = new List<Symbols>();

		Judges finalJudge;

		int round;

		public Judges JudgeRound()
		{
			for (int i = 0; i < userStack.Count; i++)
			{
				if (trueStack[i] != userStack[i])
				{
					finalJudge = Judges.Wrong;
					return Judges.Wrong;
				}
			}

			if (trueStack.Count == userStack.Count)
			{
				if (round == 10)
				{
					finalJudge = Judges.Correct;
				}
				return Judges.Correct;
			}
			else
			{
				return Judges.Continue;
			}
		}

		public abstract class NextRoundInfo
		{
		}

		public class Changed : NextRoundInfo
		{
			public Changed(Symbols s1, Symbols s2)
			{
				symbol1 = s1;
				symbol2 = s2;
			}
			public Symbols symbol1;
			public Symbols symbol2;
		}

		public class Added : NextRoundInfo
		{
			public Added(List<Symbols> symbols)
			{
				this.symbols = symbols;
			}

			public List<Symbols> symbols;
		}


		public NextRoundInfo NextRound()
		{
			if (trueStack.Count > 8 && ExRandom.FlipCoin(Level[0]))
			{
				(var s1, var s2) = ExRandom.NextSymbol2();

				for (int i = 0; i < trueStack.Count; i++)
				{
					if (trueStack[i] == s1)
					{
						trueStack[i] = s2;
					}
					else if (trueStack[i] == s2)
					{
						trueStack[i] = s1;
					}
				}

				return new Changed(s1, s2);
			}
			else
			{
				int num = (int)ExRandom.NextPosGaussian(0, Level[1]) + 1;

				List<Symbols> symbols = new List<Symbols>();
				for (int i = 0; i < num; i++)
				{
					symbols.Add(ExRandom.NextSymbol());
				}

				trueStack.AddRange(symbols);
				return new Added(symbols);
			}

			round++;
		}

		protected override void PostInit()
		{
			trueStack = new List<Symbols>();
			userStack = new List<Symbols>();
			round = 0;
			finalJudge = Judges.Continue;
		}

		protected override Judges MakeJudge()
		{
			return finalJudge;
		}
	}
}

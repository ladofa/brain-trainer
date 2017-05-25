using System;
using System.Collections.Generic;

namespace BrainTrainer
{
	public enum Judges
	{
		Continue,
		Correct,
		Wrong
	}

	public enum Symbols : int
	{
		A,
		S,
		D,
		F,
		L,
		T,
		R,
		B
	}

	[Serializable]
	public abstract class Game
	{
		public Game(string name, Difficulty difficulty)
		{
			this.name = name;
			this.difficulty = difficulty;
		}

		string name;
		public string Name
		{
			get => name;
		}

		Difficulty difficulty;
		public Difficulty Difficulty
		{
			get => difficulty;
		}
	
		double[] level;
		public double[] Level
		{
			get => (double[])level.Clone();
		}

		Judges judge;
		public Judges Judge
		{
			get => judge;
		}

		abstract protected void PostInit();
		public void Init()
		{
			PostInit();
		}

		abstract protected Judges MakeJudge();

		public Judges Finish()
		{
			judge = MakeJudge();
			if (judge != Judges.Continue)
			{
				RecordResult();
			}

			return judge;
		}

		public void GoNext()
		{
			level = difficulty.GenerateRandom();
			Init();
		}

		public void RecordResult()
		{
			difficulty.AddLevel(level, judge == Judges.Correct);
		}
	}
}

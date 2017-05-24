using System;
using System.Collections;

namespace BrainCore
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

	public abstract class Game
	{
		abstract protected void PostInit();
		public void Init()
		{
			PostInit();
		}

		abstract protected Judges Judge();

		public void GoNext()
		{

		}

		public void RecordResult()
		{

		}
    }
}

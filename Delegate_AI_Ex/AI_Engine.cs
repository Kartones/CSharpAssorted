using System;

namespace Delegate_AI_Ex
{
	// AI states enumeration
	public enum aiEngineStates
	{
		Nothing,
		Wandering,
		Attacking
	}

	// Delegate used to control AI behavior
	public delegate void AI_State();

	public class AI_Engine
	{
		// Delegate method (Defaults to doing nothing)
		public AI_State ProcessState = new AI_State(State_Nothing);

		// Method to change AI state
		public void ChangeState(aiEngineStates newState)
		{
			switch(newState)
			{
				case aiEngineStates.Attacking:
					ProcessState = new AI_State(State_Attacking);
					break;
				case aiEngineStates.Wandering:
					ProcessState = new AI_State(State_Wandering);
					break;
				default:
					ProcessState = new AI_State(State_Nothing);
					break;
			}
		}

		// AI state handling methods (just output to console)
        // --------------------------------------------------
		public static void State_Nothing()
		{
			Console.WriteLine("> (AI) Doing nothing");
		}
		public static void State_Wandering()
		{
			Console.WriteLine("> (AI) Wandering");
		}
		public static void State_Attacking()
		{
			Console.WriteLine("> (AI) Attacking");
		}
	}
}

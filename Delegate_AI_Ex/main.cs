using System;

namespace Delegate_AI_Ex
{
	public enum GameStates
	{
		Stopped = 0,
		Running = 1
	}

	public class GameMain
	{
        private GameStates _gameState = GameStates.Stopped;
        public GameStates gameState 
		{
			get
			{
				return _gameState;
			}
			set
			{
				_gameState = value;
			}
		}

		public GameMain()
		{
			_gameState = GameStates.Running;

			Console.WriteLine(">>> Game Engine Init.");
		}

		[STAThread]
		static void Main() 
		{
			string character;

			GameMain game = new GameMain();
			AI_Engine AIEngine = new AI_Engine();

			// Game loop
			while (game.gameState != GameStates.Stopped)
			{
				character = Console.ReadLine();

				// Just to show how delegates work correctly
				switch (character)
                {
                    case "x":
                        game.gameState = GameStates.Stopped;
                        break;
                    case "a":
                        AIEngine.ChangeState(aiEngineStates.Attacking);
                        break;
                    case "w":
                        AIEngine.ChangeState(aiEngineStates.Wandering);
                        break;
                    default:
                        AIEngine.ChangeState(aiEngineStates.Nothing);
                        break;
                }
	
				AIEngine.ProcessState();

				Console.WriteLine("Cycle");
			}

			Console.WriteLine(">>> Game Engine Stopped");
		}
	}
}
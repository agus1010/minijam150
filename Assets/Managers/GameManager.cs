using UnityEngine;
using UnityEngine.Events;


namespace MiniJam150
{
	public enum GAME_STATE
	{
		MAIN_MENU = 0, PLAYING_INTRO = 1, GAME_ONGOING = 2, FINISHED = 3
	}
	public class GameManager : MonoBehaviour
	{
		public GAME_STATE status { get; private set; } = GAME_STATE.MAIN_MENU;

		public UnityEvent GameStatusIsMainMenu;
		public UnityEvent GameStatusIsPlayingIntro;
		public UnityEvent GameStatusIsGameOnGoing;
		public UnityEvent GameStatusIsFinished;


		public void NextStatus()
		{
			status = status + 1;
			getCurrentStateEvent()?.Invoke();
		}


		private UnityEvent getCurrentStateEvent()
		{
			switch (status)
			{
				case GAME_STATE.MAIN_MENU:
					return GameStatusIsMainMenu;
				case GAME_STATE.PLAYING_INTRO:
					return GameStatusIsPlayingIntro;
				case GAME_STATE.GAME_ONGOING:
					return GameStatusIsGameOnGoing;
				default:
					return GameStatusIsFinished;
			}
		}
	}
}
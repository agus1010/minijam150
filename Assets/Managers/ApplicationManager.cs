using UnityEngine;
using UnityEngine.Events;


namespace MiniJam150
{
	public enum GAME_STATE
	{
		MAIN_MENU = 0, PLAYING_INTRO = 1, GAME_ONGOING = 2, FINISHED = 3
	}
	public class ApplicationManager : MonoBehaviour
	{
		public GAME_STATE status { get; private set; } = GAME_STATE.MAIN_MENU;

		public UnityEvent OnMainMenu;
		public UnityEvent OnPlayIntro;
		public UnityEvent OnStartGame;
		public UnityEvent OnFinished;


		public void NextStatus()
		{
			status = status + 1;
			getCurrentStateEvent()?.Invoke();
		}

		private void Awake()
		{
			OnMainMenu?.Invoke();
		}

		private UnityEvent getCurrentStateEvent()
		{
			switch (status)
			{
				case GAME_STATE.PLAYING_INTRO:
					return OnPlayIntro;
				case GAME_STATE.GAME_ONGOING:
					return OnStartGame;
				default:
					return OnFinished;
			}
		}
	}
}
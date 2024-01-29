using UnityEngine;
using UnityEngine.Events;


namespace MiniJam150
{
	public class ScoreManager : MonoBehaviour
	{
		public Player player;
		
		public int Score = 0;
		public float winCondition = .8f;
		public bool wonThisRound => Score / 100f >= winCondition;

		private bool gameFinished = false;
		public UnityEvent FinishGame;
		

		private float delta = 0f;
		private void Update()
		{
			if (gameFinished)
				return;
			if (player.isUnderSpotlight)
			{
				delta += Time.deltaTime;
				if (delta >= 1)
				{
					Score += 1;
					delta = 0;
				}
			}
			if (Score == 100)
			{
				gameFinished = true;
				FinishGame?.Invoke();
			}
		}
	}
}
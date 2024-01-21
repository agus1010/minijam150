using UnityEngine;


namespace MiniJam150
{
	public class ScoreManager : MonoBehaviour
	{
		public PlayerGlobals playerGlobals;
		
		public int Score = 0;
		public float winCondition = .8f;
		public bool wonThisRound => Score / 100f >= winCondition;
		

		private float delta = 0f;
		private void Update()
		{
			if (playerGlobals.isUnderSpotlight)
			{
				delta += Time.deltaTime;
				if (delta >= 1)
				{
					Score += 1;
					delta = 0;
				}
			}
		}
	}
}
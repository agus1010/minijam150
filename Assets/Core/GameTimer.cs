using System.Collections;
using UnityEngine;
using UnityEngine.Events;


namespace MiniJam150
{
	public enum GAME_TIMER_DELAY_SELECTION_MODE
	{
		MIN_DELAY_ALWAYS, MAX_DELAY_ALWAYS, RANDOM_RANGED_DELAY
	}
	public class GameTimer : MonoBehaviour
	{
		[Range(1f, 10000f)] public float maxDelay = 7f;
		public bool run = true;

		public GAME_TIMER_DELAY_SELECTION_MODE mode = GAME_TIMER_DELAY_SELECTION_MODE.MAX_DELAY_ALWAYS;
		public UnityEvent delayElapsed;


		private bool waiting = false;

		private float getTimerDelay()
		{
			switch (mode)
			{
				case GAME_TIMER_DELAY_SELECTION_MODE.MAX_DELAY_ALWAYS:
					return maxDelay;
				case GAME_TIMER_DELAY_SELECTION_MODE.RANDOM_RANGED_DELAY:
					return Random.Range(1f, maxDelay);
				default:
					return 1f;
			}
		}


		public void Reset()
		{
			waiting = true;
			run = true;
		}


		private void FixedUpdate()
		{
			if (!run || waiting) return;
			StartCoroutine(waitSeconds(getTimerDelay()));
		}

		private IEnumerator waitSeconds(float seconds)
		{
			waiting = true;
			yield return new WaitForSeconds(seconds);
			delayElapsed?.Invoke();
			waiting = false;
		}
	}
}
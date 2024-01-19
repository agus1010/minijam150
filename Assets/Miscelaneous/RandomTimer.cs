using UnityEngine;
using UnityEngine.Events;


namespace MiniJam150
{
	public class RandomTimer : MonoBehaviour
	{
		public bool run = true;
		[Range(1f, 10f)] public float maxDelay = 5f;

		public UnityEvent delayElapsed;


		private float targetDelay = 0f;
		private float delayDelta = 0f;


		private void Update()
		{
			if (!run) return;
			if (delayDelta >= targetDelay)
			{
				targetDelay = Random.Range(1f, maxDelay);
				delayDelta = 0f;
				delayElapsed?.Invoke();
				return;
			}
			delayDelta += Time.deltaTime;
		}
	}
}
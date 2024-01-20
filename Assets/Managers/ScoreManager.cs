using System.Collections.Generic;
using UnityEngine;


namespace MiniJam150
{
	public class ScoreManager : MonoBehaviour
	{
		public int Score = 0;

		private List<Miscelaneous.PlayerDetector> detectors;


		public void PlayerDetected(Miscelaneous.PlayerDetector detector)
			=> detectors.Add(detector);

		public void PlayerLeft(Miscelaneous.PlayerDetector detector)
		{
			detectors.Remove(detector);
			if (detectors.Count == 0)
				delta = 0f;
		}
		

		private void Awake()
		{
			detectors = new List<Miscelaneous.PlayerDetector>();
		}

		private float delta = 0f;
		private void Update()
		{
			if (detectors.Count > 0)
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
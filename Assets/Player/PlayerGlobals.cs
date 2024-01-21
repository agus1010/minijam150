using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace MiniJam150
{
	public class PlayerGlobals : MonoBehaviour
	{
		public bool isUnderSpotlight => detectors.Count > 0;

		public UnityEvent PlayerUnderASpotlight;
		public UnityEvent PlayerUnderCoverOfDarkness;


		private List<Miscelaneous.PlayerDetector> detectors;
		public void PlayerDetected(Miscelaneous.PlayerDetector detector)
		{
			detectors.Add(detector);
			if (detectors.Count == 1)
				PlayerUnderASpotlight?.Invoke();
		}

		public void PlayerLeft(Miscelaneous.PlayerDetector detector)
		{
			detectors.Remove(detector);
			if (!isUnderSpotlight)
				PlayerUnderCoverOfDarkness?.Invoke();
		}


		private void Awake()
		{
			detectors = new List<Miscelaneous.PlayerDetector>();
		}
	}
}
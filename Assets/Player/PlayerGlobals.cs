using System.Collections.Generic;
using UnityEngine;


namespace MiniJam150
{
	public class PlayerGlobals : MonoBehaviour
	{
		public bool isUnderSpotlight => detectors.Count > 0;
		
		[SerializeField] private PlayerMovement playerMovement;
		[SerializeField] private CrowdSoundsManager crowdSoundsManager;

		private List<Miscelaneous.ObjectDetector> detectors;
		public void PlayerDetected(Miscelaneous.ObjectDetector detector)
		{
			detectors.Add(detector);
			crowdSoundsManager.PlayAplauses();
		}

		public void PlayerLeft(Miscelaneous.ObjectDetector detector)
		{
			detectors.Remove(detector);
		}


		private void Awake()
		{
			detectors = new List<Miscelaneous.ObjectDetector>();
		}
	}
}
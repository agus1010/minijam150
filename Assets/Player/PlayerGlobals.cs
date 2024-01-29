using System.Collections.Generic;
using UnityEngine;


namespace MiniJam150
{
	public class PlayerGlobals : MonoBehaviour
	{
		public bool isUnderSpotlight => detectors.Count > 0;
		public bool isMoving => playerMovement.isMoving;

		[SerializeField] private PlayerMovement playerMovement;
		[SerializeField] private CrowdSoundsManager crowdSoundsManager;

		private List<Miscelaneous.PlayerDetector> detectors;
		public void PlayerDetected(Miscelaneous.PlayerDetector detector)
		{
			detectors.Add(detector);
			crowdSoundsManager.PlayAplauses();
		}

		public void PlayerLeft(Miscelaneous.PlayerDetector detector)
		{
			detectors.Remove(detector);
		}


		private void Awake()
		{
			detectors = new List<Miscelaneous.PlayerDetector>();
		}
	}
}
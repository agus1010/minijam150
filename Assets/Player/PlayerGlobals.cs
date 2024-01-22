using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace MiniJam150
{
	public class PlayerGlobals : MonoBehaviour
	{
		public bool isUnderSpotlight => detectors.Count > 0;
		public bool isMoving => playerMovement.motion.magnitude > 0f;


		[SerializeField] private PlayerMovement playerMovement;

		private List<Miscelaneous.PlayerDetector> detectors;
		public void PlayerDetected(Miscelaneous.PlayerDetector detector)
		{
			detectors.Add(detector);
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
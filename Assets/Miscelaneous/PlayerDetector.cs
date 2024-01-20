using UnityEngine;
using UnityEngine.Events;


namespace MiniJam150.Miscelaneous
{
	public class PlayerDetector : MonoBehaviour
	{
		public string playerTag;

		public UnityEvent<PlayerDetector> PlayerEntered;
		public UnityEvent<PlayerDetector> PlayerLeft;


		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag(playerTag))
				PlayerEntered?.Invoke(this);
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag(playerTag))
				PlayerLeft?.Invoke(this);
		}
	}
}
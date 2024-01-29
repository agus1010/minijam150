using UnityEngine;
using UnityEngine.Events;


namespace MiniJam150.Miscelaneous
{
	public class ObjectDetector : MonoBehaviour
	{
		public string targetTag;

		public UnityEvent<ObjectDetector, Collider> ObjectDetected;
		public UnityEvent<ObjectDetector, Collider> ObjectLost;

		
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag(targetTag))
				ObjectDetected?.Invoke(this, other);
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag(targetTag))
				ObjectLost?.Invoke(this, other);
		}
	}
}
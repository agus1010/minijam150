using UnityEngine;


namespace MiniJam150
{
    public class GameSpotLight : MonoBehaviour
    {
		public bool isLocked = false;
		public Transform lookAtTarget;

		private void Update()
		{
			if (!isLocked)
				transform.LookAt(lookAtTarget);
		}
	}
}
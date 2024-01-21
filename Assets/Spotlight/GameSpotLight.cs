using UnityEngine;


namespace MiniJam150
{
    public class GameSpotLight : MonoBehaviour
    {
		public bool isLocked = false;
		[SerializeField] private Transform _lookAtTarget;
		public Transform lookAtTarget
		{ 
			get => _lookAtTarget;
			set => _lookAtTarget = value;
		}

		private void Update()
		{
			if (!isLocked)
				transform.LookAt(_lookAtTarget);
		}
	}
}
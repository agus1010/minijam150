using UnityEngine;


namespace MiniJam150
{
    public class GameSpotLight : MonoBehaviour
    {
		[SerializeField] private Transform lookAtTarget;

		private void Update()
		{
			transform.LookAt(lookAtTarget);
		}
	}
}
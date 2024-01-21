using UnityEngine;


namespace MiniJam150
{
	public class SpotlightPositionPicker : MonoBehaviour
	{
		[SerializeField] private float maxMovementTime = 5f;
		[SerializeField] private Vector2 maxHorizontalSpotlightMovement;

		public bool isLocked { get; set; } = true;

		private Vector3 newTargetPosition = Vector3.zero;
		private float currentMaxMovementTime = 0f;
		private float movementDelta = 0f;


		public void AllowPicking()
		{
			isLocked = false;
			GetComponent<RandomTimer>().run = true;
		}

		public void MoveToNewPosition()
		{
			newTargetPosition = new Vector3
				(
					x: Random.Range(-maxHorizontalSpotlightMovement.x, maxHorizontalSpotlightMovement.x),
					y: transform.position.y,
					z: Random.Range(-maxHorizontalSpotlightMovement.y, maxHorizontalSpotlightMovement.y)
				);
			currentMaxMovementTime = Random.Range(1f, maxMovementTime);
			m_run = true & !isLocked;
		}


		private bool m_run = false;
		private void Update()
		{
			if (isLocked || !m_run) return;
			if (transform.position != newTargetPosition)
			{
				movementDelta += Time.deltaTime;
				transform.position = Vector3.Lerp(transform.position, newTargetPosition, movementDelta / currentMaxMovementTime);
			}
			else
			{
				movementDelta = 0f;
				m_run = false;
			}
		}
	}
}
using UnityEngine;
using UnityEngine.Events;


namespace MiniJam150
{
	public enum PICK_NEW_FOCUS_POINT_MODE
	{
		PLANE = 0, CIRCLE = 1
	}
    public class GameSpotLight : MonoBehaviour
    {
		[Header("Config:")]
		public float radius = 5f;
		public Vector2 planeExtents = new Vector2(5f, 5f);
		public PICK_NEW_FOCUS_POINT_MODE mode = PICK_NEW_FOCUS_POINT_MODE.PLANE;

		[Header("Scene References:")]
		[SerializeField] private AutomaticTargetter automaticTargetter;
		[SerializeField] private PositionLerper positionLerper;
		[SerializeField] private GameTimer randomTimer;

		[Header("Debug:")]
		[SerializeField] private bool showSelectablePoints = false;
		
		[Space(15)]
		public UnityEvent<GameSpotLight> PlayerEntered;
		public UnityEvent<GameSpotLight> PlayerLeft;

		private Vector3 centerOfFocusArea;


		public void FirePlayerEntered()
			=> PlayerEntered?.Invoke(this);
		
		public void FirePlayerLeft()
			=> PlayerLeft?.Invoke(this);
		
		public void ForceLookAt(Vector3 position)
		{
			Freeze(true);
			positionLerper.transform.position = position;
			automaticTargetter.transform.LookAt(position);
			positionLerper.gameObject.SetActive(false);
		}

		public void Freeze(bool newValue)
		{
			automaticTargetter.isFrozen = newValue;
			positionLerper.isFrozen = newValue;
			randomTimer.run = newValue;
		}

		public void MoveTowardsNewRandomPosition()
			=> positionLerper.LerpPositionTowards(getNewRandomPoint());

		public void Reset()
		{
			Freeze(false);
			positionLerper.gameObject.SetActive(true);
			SetNewTarget(positionLerper.transform);
			positionLerper.GetComponent<Collider>().enabled = true;
			randomTimer.Reset();
		}

		public void SetNewTarget(Transform target)
			=> automaticTargetter.Target = target;


		private Vector3 getNewRandomPoint()
		{
			if (mode == 0)
				return CustomMath.PickRandomPointWithinCubeVolume(center: centerOfFocusArea, extents: new Vector3(planeExtents.x, 0f, planeExtents.y));
			return CustomMath.PickRandomPointWithinCircleArea(centerOfFocusArea, radius);
		}

		private Vector3 calcCenterOfFocusArea()
		{
			Vector3 center = transform.position;
			center.y = 0f;
			return center;
		}

		private void Start()
		{
			centerOfFocusArea = calcCenterOfFocusArea();
		}

		
		private void OnDrawGizmosSelected()
		{
			if (!showSelectablePoints) return;
			Gizmos.color = Color.yellow;
			Vector3 center = calcCenterOfFocusArea();
			if (mode == 0)
			{
				Vector3 size = new Vector3(planeExtents.x*2, 0f, planeExtents.y*2);
				Gizmos.DrawCube(center, size);
			}
			else
			{
				Gizmos.DrawSphere(center, radius);
			}
			Gizmos.color = Color.white;
		}
	}
}
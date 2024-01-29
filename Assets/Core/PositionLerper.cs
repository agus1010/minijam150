using UnityEngine;


namespace MiniJam150
{
	public enum LERPER_SPEED_MODE
	{
		ALWAYS_MIN, ALWAYS_MAX, RANDOM_RANGE
	}
	public class PositionLerper : MonoBehaviour
	{
		[Range(0.01f, 100f)] public float maxLerpSpeed = 5f;
		public bool isFrozen = false;

		public LERPER_SPEED_MODE mode = LERPER_SPEED_MODE.ALWAYS_MAX;

		private float lerpPosDelta = 0f;
		private Vector3 targetPos = Vector3.zero;
		private float newLerpSpeed = 0.01f;

		private float getLerperSpeed()
		{
			switch (mode)
			{
				case LERPER_SPEED_MODE.ALWAYS_MAX:
					return maxLerpSpeed;
				case LERPER_SPEED_MODE.RANDOM_RANGE:
					return Random.Range(0.01f, maxLerpSpeed);
				default:
					return 0.01f;
			}
		}


		public void LerpPositionTowards(Vector3 newPosition)
		{
			isFrozen = false;
			lerpPosDelta = 0f;
			targetPos = newPosition;
			newLerpSpeed = getLerperSpeed();
		}

		public void LerpPositionTowards(Transform targetPos)
			=> LerpPositionTowards(targetPos.position);


		private float m_lerpPerc;
		private void Update()
		{
			if (isFrozen) return;
			m_lerpPerc = Mathf.Clamp01(lerpPosDelta / newLerpSpeed);
			transform.position = Vector3.Lerp(transform.position, targetPos, m_lerpPerc);
			lerpPosDelta += Time.deltaTime;
			if (m_lerpPerc == 1f)
				isFrozen = true;
		}
	}
}
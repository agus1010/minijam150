using UnityEngine;


namespace MiniJam150
{
	public class Lerper : MonoBehaviour
	{
		public float lerpSpeed = 5f;

		private bool lerpPos = false;
		private float lerpPosDelta = 0f;
		private Vector3 targetPos;

		private bool lerpRot = false;
		private float lerpRotDelta = 0f;
		private Quaternion targetRot;
		

		public void LerpPositionTowards(Transform targetPos)
		{
			lerpPos = true;
			lerpPosDelta = 0f;
			this.targetPos = targetPos.position;
		}

		public void LerpRotationTowards(Transform targetRot)
		{
			lerpRot = true;
			lerpRotDelta = 0f;
			this.targetRot = targetRot.rotation;
		}


		private float m_lerpPerc;
		private void Update()
		{
			if (lerpPos)
			{
				m_lerpPerc = Mathf.Clamp01(lerpPosDelta / lerpSpeed);
				transform.position = Vector3.Lerp(transform.position, targetPos, m_lerpPerc);
				lerpPosDelta += Time.deltaTime;
				lerpPos = m_lerpPerc == 1f;
			}

			if (lerpRot)
			{
				m_lerpPerc = Mathf.Clamp01(lerpRotDelta / lerpSpeed);
				transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, m_lerpPerc);
				lerpRotDelta += Time.deltaTime;
				lerpRot = m_lerpPerc == 1f;
			}
		}
	}
}
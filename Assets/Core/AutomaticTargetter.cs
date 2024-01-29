using UnityEngine;


namespace MiniJam150
{
	public class AutomaticTargetter : MonoBehaviour
	{
		public Transform Target;
		public bool isFrozen = false;


		private Vector3 m_lastTargetPosition = Vector3.zero;
		private void Update()
		{
			if (!isFrozen && Target && m_lastTargetPosition != Target.position)
			{
				transform.LookAt(Target);
				m_lastTargetPosition = Target.position;
			}
		}
	}
}
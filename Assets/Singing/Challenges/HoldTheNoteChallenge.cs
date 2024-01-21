using UnityEngine;
using UnityEngine.InputSystem;


namespace MiniJam150
{
	public class HoldTheNoteChallenge : BaseSingingChallenge
	{
		[SerializeField] private float increment = .1f;
		[SerializeField] private float incrementTimeDelta = .2f;
		[SerializeField] private Vector2 winConditionRange = new Vector2(.25f, .75f);

		public bool holdingSing { get; private set; } = false;

		private bool running = false;


		public override void Reset()
		{
			base.Reset();
			running = true;
		}

		public override void Sing(InputAction.CallbackContext callbackContext)
		{
			holdingSing = callbackContext.started && !callbackContext.canceled;
		}

		public override bool Finish()
		{
			running = false;
			return winConditionRange.x >= singingValue && singingValue <= winConditionRange.y;
		}


		private float m_currentIncrementTimeDelta = 0f;
		private void Update()
		{
			if (!running)
				return;

			m_currentIncrementTimeDelta += Time.deltaTime;
			if (m_currentIncrementTimeDelta < incrementTimeDelta)
				return;
			
			m_currentIncrementTimeDelta = 0f;
			singingValue += (holdingSing ? 1 : -1) * increment;
			singingValue = Mathf.Clamp01(singingValue);
		}
	}
}
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


namespace MiniJam150
{
	public class ShoutItChallenge : BaseSingingChallenge
	{
		[SerializeField] private float increment = .1f;
		[SerializeField] private float incrementTimeDelta = .2f;
		[SerializeField] private Vector2 winConditionRange = new Vector2(.9f, 1f);


		public override void Sing(InputAction.CallbackContext callbackContext)
		{
			throw new System.NotImplementedException();
		}

		public override bool Finish()
		{
			throw new System.NotImplementedException();
		}

		public override void Reset()
		{
			base.Reset();
			
		}
	}
}
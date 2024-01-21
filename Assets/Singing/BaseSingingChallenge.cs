using UnityEngine;
using UnityEngine.InputSystem;


namespace MiniJam150
{
	public abstract class BaseSingingChallenge : MonoBehaviour
	{
		public float singingValue { get; protected set; } = 0f;

		public abstract void Sing(InputAction.CallbackContext callbackContext);
		public abstract bool Finish();
		public virtual void Reset()
		{
			singingValue = 0f;
		}
	}
}
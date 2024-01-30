using UnityEngine;
using UnityEngine.InputSystem;


namespace MiniJam150
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private PlayerInput playerInput;
		[SerializeField] private PlayerMovement playerMovement;

		public bool isMoving => playerMovement.motion != Vector3.zero;
		public bool isUnderSpotlight { get; set; } = false;


		public void Freeze(bool newValue)
			=> playerMovement.isLocked = newValue;

		public void OnUp(InputAction.CallbackContext callbackContext)
			=> putMoveDirection(onXAxis: true, direction: 1, context: callbackContext);

		public void OnDown(InputAction.CallbackContext callbackContext)
			=> putMoveDirection(onXAxis: true, direction: -1, context: callbackContext);

		public void OnLeft(InputAction.CallbackContext callbackContext)
			=> putMoveDirection(onXAxis: false, direction: 1, context: callbackContext);

		public void OnRight(InputAction.CallbackContext callbackContext)
			=> putMoveDirection(onXAxis: false, direction: -1, context: callbackContext);


		private void putMoveDirection(bool onXAxis, int direction, InputAction.CallbackContext context)
		{
			int finalDir = context.performed && !context.canceled ? direction : 0;

			playerMovement.moveDirection = new Vector2(
				x: onXAxis ? finalDir : playerMovement.moveDirection.x,
				y: onXAxis ? playerMovement.moveDirection.y : finalDir
			); ;
		}
	}
}
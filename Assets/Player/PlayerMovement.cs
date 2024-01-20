using UnityEngine;
using UnityEngine.InputSystem;


namespace MiniJam150
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        private CharacterController charController;
        private int up = 0;
        private int left = 0;

        public void MoveUp(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.performed)
                up = 1;
            else if (callbackContext.canceled)
                up = 0;
        }
        public void MoveDown(InputAction.CallbackContext callbackContext)
		{
            if (callbackContext.performed)
                up = -1;
            else if (callbackContext.canceled)
                up = 0;
		}
		public void MoveLeft(InputAction.CallbackContext callbackContext)
		{
            if (callbackContext.performed)
                left = 1;
            else if (callbackContext.canceled)
                left = 0;
		}
		public void MoveRight(InputAction.CallbackContext callbackContext)
		{
            if (callbackContext.performed)
                left = -1;
            else if (callbackContext.canceled)
                left = 0;
		}


		private void Start()
		{
            charController = GetComponent<CharacterController>();
		}

		private void Update()
        {
            charController.Move(new Vector3(up * speed * .1f, 0f, left * speed * .1f));
        }
    }
}
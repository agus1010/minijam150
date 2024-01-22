using UnityEngine;
using UnityEngine.InputSystem;


namespace MiniJam150
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController charController;
        [SerializeField] private Animator animator;
        [SerializeField] private bool _isLocked = false;
        public bool isLocked
        {
            get => _isLocked;
            set => _isLocked = value;
        }

        public Vector3 motion { get; private set; } = Vector3.zero;

        [SerializeField] private float speed = 5f;


        public Vector2 horizontalDirection => new Vector2(up, left);
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


		private void Update()
        {
            if (!isLocked)
            {
                motion = new Vector3(up * speed * .1f, 0f, left * speed * .1f);
                charController.Move(motion);
            }
        }
    }
}
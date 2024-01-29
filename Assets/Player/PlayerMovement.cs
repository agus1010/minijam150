using UnityEngine;


namespace MiniJam150
{
	public class PlayerMovement : MonoBehaviour
	{
        [SerializeField] private CharacterController charController;
        [SerializeField] private float speed = 5f;
        [SerializeField] private bool _isLocked = false;
		

		private Vector3 _moveDirection;
		public Vector3 moveDirection
		{
			get => _moveDirection;
			set => _moveDirection = value.normalized;
		}
		public Vector3 motion { get; private set; } = Vector3.zero;
        public bool isLocked
        {
            get => _isLocked;
            set => _isLocked = value;
        }


		private void Update()
		{
			if (!isLocked)
            {
				motion = new Vector3
				(
					x: moveDirection.x * speed * .1f,
					y: 0f,
					z: moveDirection.y * speed * .1f
				);
				charController.Move(motion);
            }
		}
	}
}
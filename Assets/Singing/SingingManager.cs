using UnityEngine;
using UnityEngine.InputSystem;


namespace MiniJam150
{
	public class SingingManager : MonoBehaviour
	{
		private int tapsInSeconds = 0;


		public void Sing(InputAction.CallbackContext callbackContext)
		{
			if (callbackContext.performed)
			{

			}
			tapsInSeconds += 1;
		}


	}
}
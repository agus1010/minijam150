using UnityEngine;
using UnityEngine.Events;


namespace MiniJam150
{
    public class IntroManager : MonoBehaviour
    {
        public PlayerMovement player;
        public GameSpotLight gameSpotlight;
        public SpotlightPositionPicker picker;
        public Transform startPosition;
        public float timeToBeginGame = 30f;
        public GameObject scoreDisplay;

        public UnityEvent GameStarted;
        
        public void PlayIntro()
        {
            gameSpotlight.lookAtTarget = player.transform;
            picker.isLocked = true;
            picker.GetComponent<RandomTimer>().run = false;
            m_started = true;
			GameStarted?.Invoke();
        }

        public void StartGame()
        {
            gameSpotlight.transform.LookAt(startPosition);
            gameSpotlight.lookAtTarget = picker.transform;
            scoreDisplay.SetActive(true);
        }


        private float m_delta = 0f;
        private bool m_started = false;
		private void Update()
		{
			if (m_started)
            {
                if (m_delta < timeToBeginGame)
                    m_delta += Time.deltaTime;
                else
                {
                    StartGame();
                    m_started = false;
                }
            }
		}
	}
}
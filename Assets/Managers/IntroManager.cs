using UnityEngine;


namespace MiniJam150
{
	public class IntroManager : MonoBehaviour
	{
		public GameSpotLight gameSpotlight;
		public PlayerMovement playerMovement;
		public Transform playerInitialPlace;
		public float totalTime = 2f;
		public Animator animator;

		private bool m_playIntro = false;
		private Transform gameSpotlightOriginalTarget;

		public void StartGame()
		{
			gameSpotlightOriginalTarget = gameSpotlight.lookAtTarget;
			gameSpotlight.lookAtTarget = playerMovement.transform;
			m_playIntro = true;
			animator.SetTrigger("GAME_STARTED");
		}


		private float m_deltaTime = 0f;
		private void Update()
		{
			if (!m_playIntro)
				return;
			m_deltaTime += Time.deltaTime;
			playerMovement.transform.position = Vector3.Lerp(playerMovement.transform.position, playerInitialPlace.transform.position, Mathf.Clamp01(m_deltaTime / totalTime));
			if (m_deltaTime >= totalTime)
			{
				gameSpotlight.lookAtTarget = gameSpotlightOriginalTarget;
				m_playIntro = false;
				gameObject.SetActive(false);
			}
		}
	}
}
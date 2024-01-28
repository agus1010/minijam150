using UnityEngine;


namespace MiniJam150
{
	public class CrowdSoundsManager : MonoBehaviour
	{
		[SerializeField] private AudioSource hubblingNoisesSource;
		[SerializeField] private AudioSource introAplausesSource;
		[SerializeField] private AudioSource singingAplausesSource;
		[SerializeField] private AudioSource outroAplausesSource;

		public void PlayApplauses()
		{
			singingAplausesSource.Play();
		}

		public void PlayEndGame()
		{
			outroAplausesSource.Play();
		}

		public void StartGame()
		{
			m_lowerVolume = true;
		}



		bool m_lowerVolume = false;
		private void Update()
		{
			if (m_lowerVolume)
			{
				hubblingNoisesSource.volume -= Time.deltaTime;
				if (hubblingNoisesSource.volume == 0)
					m_lowerVolume = false;
			}
		}
	}
}
using UnityEngine;


namespace MiniJam150
{
	public class CrowdSoundsManager : MonoBehaviour
	{
		[SerializeField] private AudioSource hubblingNoisesSource;
		[SerializeField] private AudioSource introAplausesSource;
		[SerializeField] private AudioSource singingAplausesSource;
		[SerializeField] private AudioSource outroAplausesSource;

		public void PlayAplauses()
		{
			singingAplausesSource.Play();
		}

		public void StopAplauses()
		{
			singingAplausesSource.Stop();
		}

		public void PlayIntro()
		{
			hubblingNoisesSource.Stop();
			introAplausesSource.Play();
		}

		public void PlayEndGame()
		{
			outroAplausesSource.Play();
		}
	}
}
using UnityEngine;


namespace MiniJam150
{
	public class CrowdSoundsManager : MonoBehaviour
	{
		[SerializeField] private AudioSource hubblingNoisesSource;
		[SerializeField] private AudioSource introAplausesSource;
		[SerializeField] private AudioSource singingAplausesSource;
		[SerializeField] private AudioSource outroAplausesSource;


		

		public void PlayMainMenuSounds()
		{
			hubblingNoisesSource.Play();
		}

		public void PlayIntroSounds()
		{
			hubblingNoisesSource.volume *= .5f;
			introAplausesSource.Play();
		}

		public void PlayAplauses()
		{
			singingAplausesSource.Play();
		}

		public void StopAplauses()
		{
			singingAplausesSource.Stop();
		}

		public void StopAmbientNoice()
		{
			hubblingNoisesSource.Stop();
		}

		public void PlayGameFinishedSounds()
		{
			outroAplausesSource.Play();
			hubblingNoisesSource.Play();
		}
	}
}
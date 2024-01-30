using UnityEngine;
using UnityEngine.Events;


namespace MiniJam150
{
	public class ScoreManager : MonoBehaviour
	{
		[SerializeField] private int _winCondition = 100;
		[SerializeField] private GameTimer gameTimer;
		
		public int score { get; set; } = 0;
		public bool gameFinished => score == _winCondition;
		public int winCondition => _winCondition;

		public UnityEvent GameFinished;


		private bool allowedToAddPoints = false;


		public void AddPoint()
		{
			if (!allowedToAddPoints) return;
			score += 1;
			if (gameFinished)
			{
				gameTimer.run = false;
				GameFinished?.Invoke();
			}
		}

		public void CountForPoints(bool allow)
		{
			if (gameFinished) return;
			allowedToAddPoints = allow;
			if (allow)
				gameTimer.Reset();
			else
				gameTimer.run = false;
		}
	}
}
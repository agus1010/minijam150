using UnityEngine;
using TMPro;


namespace MiniJam150.UI
{
	public class ScoreDisplay : MonoBehaviour
	{
		[SerializeField] private ScoreManager scoreManager;
		[SerializeField] private TextMeshProUGUI scoreDisplay;


		private int m_prevScore = 0;
		private void Start()
		{
			updateInternals();
		}


		private void Update()
		{
			if (m_prevScore != scoreManager.Score)
				updateInternals();
		}

		private void updateInternals()
		{
			m_prevScore = scoreManager.Score;
			scoreDisplay.text = $"Crowd Cheer: {m_prevScore}/100";
		}
	}
}
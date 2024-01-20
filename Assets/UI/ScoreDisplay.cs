using UnityEngine;
using TMPro;


namespace MiniJam150.UI
{
	public class ScoreDisplay : MonoBehaviour
	{
		[SerializeField] private ScoreManager scoreManager;
		[SerializeField] private TextMeshProUGUI scoreDisplay;

		private int m_prevScore = 0;
		private void Update()
		{
			if (m_prevScore != scoreManager.Score)
			{
				m_prevScore = scoreManager.Score;
				scoreDisplay.text = $"Score: {m_prevScore}";
			}
		}
	}
}
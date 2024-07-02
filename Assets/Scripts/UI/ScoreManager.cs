using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IScoreManager
{
    [SerializeField, Header("스코어 텍스트")]
    private TextMeshProUGUI scoreText;
    [SerializeField, Header("콤보 텍스트")]
    private TextMeshProUGUI comboText;
    [SerializeField, Header("하이스코어 텍스트")]
    private TextMeshProUGUI highScoreText;

    public static int Score { get; private set; } = 0;
    public static int Combo { get; private set; } = 0;
    public int HighScore { get; private set; }

    private void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = $"High: {HighScore:D6}";
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("HighScore", Score);
        Debug.Log("Saved");
    }

    public void IncreaseScore(int score)
    {
        Combo = (score < 0) ? 0 : ++Combo;

        int Amount = Mathf.Clamp(Combo, 1, 999) * score;
        Score = Mathf.Clamp(Score + Amount, int.MinValue, int.MaxValue);
        scoreText.text = $"{Score:D6}";
        comboText.text = $"Combo X {Combo:D3}";

        if (Score >= HighScore)
        {
            highScoreText.text = $"High: {Score:D6}";
        }
    }
}

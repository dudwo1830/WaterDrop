using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IGameManager
{
    private IScoreManager scoreManager;
    private IPanelManager panelManager;

    private void Awake()
    {
        scoreManager = GetComponent<IScoreManager>();
        panelManager = GetComponent<IPanelManager>();
    }

    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    public void StopGame()
    {
        Time.timeScale = 0f;
        scoreManager.SaveScore();
        panelManager.ShowReStartPanel();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
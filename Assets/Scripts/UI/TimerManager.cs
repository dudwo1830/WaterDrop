using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField, Header("���� �ð�")]
    private float limitTime = 60f;
    [SerializeField, Header("Ÿ�̸� �����̴�")]
    private Slider limitTimer;
    [SerializeField, Header("Ÿ�̸� �ؽ�Ʈ")]
    private TextMeshProUGUI timerText;

    private IGameManager gameManager;

    private void Start()
    {
        SetTimer(limitTime);
        gameManager = GetComponent<GameManager>();
    }

    private void Update()
    {
        limitTimer.value -= Time.deltaTime;
        timerText.text = $"{(int)limitTimer.value:D2}s";
    }

    public void SetTimer(float time)
    {
        limitTimer.minValue = 0f;
        limitTimer.maxValue = time;
        limitTimer.value = time;
        limitTimer.onValueChanged.AddListener(OnTimerChanged);
    }
    private void OnTimerChanged(float value)
    {
        if (value <= limitTimer.minValue)
        {
            gameManager.StopGame();
        }
    }
}

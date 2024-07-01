using UnityEngine;

public abstract class WaterDropBase: MonoBehaviour, IExplodable
{
    [SerializeField, Header("최소 크기")]
    private float minScale = 0.5f;
    [SerializeField, Header("최대 크기")]
    private float maxScale = 1.5f;

    [SerializeField, Header("최저 속도")]
    private float minSpeed = 1f;
    [SerializeField, Header("최대 속도")]
    private float maxSpeed = 3f;

    [SerializeField, Header("터질 시 점수")]
    private int score = 0;

    private WaterDropMovement waterDropMovement;
    private WaterDropScale waterDropScale;


    private void Awake()
    {
        waterDropMovement = GetComponent<WaterDropMovement>();
        waterDropScale = GetComponent<WaterDropScale>();
    }

    public void Setup(float speed, float scale)
    {
        waterDropMovement.SetSpeed(speed);
        waterDropScale.SetScale(scale);
    }
    public void SetupRandom()
    {
        var speed = Random.Range(minSpeed, maxSpeed);
        var scale = Random.Range(minScale, maxScale);
        Setup(speed, scale);
    }

    public virtual void Explode(IScoreManager scoreManager)
    {
        scoreManager.IncreaseScore(score);
    }
}

using UnityEngine;

public abstract class WaterDropBase: MonoBehaviour, IExplodable
{
    [SerializeField, Header("�ּ� ũ��")]
    private float minScale = 0.5f;
    [SerializeField, Header("�ִ� ũ��")]
    private float maxScale = 1.5f;

    [SerializeField, Header("���� �ӵ�")]
    private float minSpeed = 1f;
    [SerializeField, Header("�ִ� �ӵ�")]
    private float maxSpeed = 3f;

    [SerializeField, Header("���� �� ����")]
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

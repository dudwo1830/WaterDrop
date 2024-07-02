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

    private IWaterDropPool pool;
    private Camera mainCamera;
    private CircleCollider2D col;

    private void Awake()
    {
        waterDropMovement = GetComponent<WaterDropMovement>();
        waterDropScale = GetComponent<WaterDropScale>();

        col = GetComponent<CircleCollider2D>();
    }
   
    private void Start()
    {
        SetupRandom();
        mainCamera = Camera.main;
        pool = GetComponentInParent<IWaterDropPool>();
    }

    private void Update()
    {
        IsOutsideCamera();
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
    public void IsOutsideCamera()
    {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);

        //ȭ�� ���� ���� �ְų� ��ũ�� ���� ���޽� �ݳ�
        var isOut = screenPos.x < 0 || screenPos.x > Screen.width || screenPos.y > Screen.height + 50f;
        if (isOut)
        {
            pool.ReleaseWaterDrop(this);
        }
    }
    
    public virtual void Explode(IScoreManager scoreManager)
    {
        scoreManager.IncreaseScore(score);
        pool.ReleaseWaterDrop(this);
    }
}

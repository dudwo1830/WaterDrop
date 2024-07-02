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

        //화면 양쪽 끝에 있거나 스크린 위에 도달시 반납
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

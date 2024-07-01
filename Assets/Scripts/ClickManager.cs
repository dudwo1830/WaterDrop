using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private Camera mainCamera;
    private IScoreManager scoreManager;


    private void Awake()
    {
        scoreManager = GetComponent<ScoreManager>();
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero, 0f);
            if (hit.collider != null)
            {
                WaterDropBase waterDrop = hit.transform.gameObject.GetComponent<WaterDropBase>();
                if (waterDrop != null)
                {
                    waterDrop.Explode(scoreManager);
                }
            }
        }
    }
}

using UnityEngine;

public class WaterDropManager : MonoBehaviour
{
    [SerializeField, Header("����� ���� �ּ� �ð�")]
    private float minRegenTime = 0.7f;
    [SerializeField, Header("����� ���� �ִ� �ð�")]
    private float maxRegenTime = 1.5f;

    [SerializeField, Header("�����Ǵ� ���� ����")]
    private float width = 2.5f;
    [SerializeField, Header("�����Ǵ� ���� ����")]
    private float height = 2.5f;

    private float regenTime;
    private float Timer;

    private IWaterDropPool pool;
    private IWaterDropImage waterDropImage;

    private void Awake()
    {
        pool = GetComponent<WaterDropPool>();
        waterDropImage = GetComponent<WaterDropImage>();
    }

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= regenTime)
        {
            var waterDrop = pool.GetWaterDrop();
            if (waterDrop != null)
            {
                var waterDropNormal = waterDrop.GetComponent<WaterDropNormal>();
                if (waterDropNormal != null)
                {
                    waterDropImage.SetRandomSprite(waterDropNormal);
                }
                waterDrop.transform.SetParent(transform);
                waterDrop.transform.Translate(GetRandomPosition());
            }
            ResetRegenTime();
        }
    }

    public void ResetRegenTime()
    {
        regenTime = Random.Range(minRegenTime, maxRegenTime);
        Timer = 0f;
    }

    public Vector2 GetRandomPosition()
    {
        float x = Random.Range(-width / 2f, width / 2f);
        float y = Random.Range(0, height); //�Ʒ� ���⿡�� ����

        Vector2 centerPosition = (Vector2)transform.position;
        Vector2 randomPosition = centerPosition + new Vector2(x, y * -1); 

        return randomPosition;
    }
}

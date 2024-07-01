using UnityEngine;

public abstract class WaterDropBase: MonoBehaviour, IExplodable
{
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

    public abstract void Explode();
}

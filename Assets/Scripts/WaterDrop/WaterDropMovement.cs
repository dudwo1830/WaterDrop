using UnityEngine;

public class WaterDropMovement : MonoBehaviour
{
    private float speed = 1f;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    public void SetSpeed(float minSpeed, float maxSpeed)
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }
}

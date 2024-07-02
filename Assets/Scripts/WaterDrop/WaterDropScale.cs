using UnityEngine;

public class WaterDropScale : MonoBehaviour
{
    public void SetScale(float scale)
    {
        transform.localScale *= scale;
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public class WaterDropBomb : WaterDropBase
{
    public override void Explode()
    {
        Debug.Log("Bomb");
    }
}

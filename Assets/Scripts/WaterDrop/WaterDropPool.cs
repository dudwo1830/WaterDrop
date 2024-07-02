using UnityEngine;
using UnityEngine.Pool;

public class WaterDropPool : MonoBehaviour, IWaterDropPool
{
    [SerializeField, Header("물방울 프리팹")]
    public GameObject[] waterDropPrefabs;

    [SerializeField, Header("최대 활성 수량")]
    private int maxSize = 20;

    public ObjectPool<WaterDropBase> Pool { get; private set; }

    private void Awake()
    {
        Pool = new ObjectPool<WaterDropBase>
            (CreateFunc, ActionOnGet, ActionOnRelease, ActionOnDestory);
    }

    public WaterDropBase CreateFunc()
    {
        var index = Random.Range(0, waterDropPrefabs.Length);
        var waterDrop = Instantiate(waterDropPrefabs[index]).GetComponent<WaterDropBase>();
        return waterDrop;
    }
    public void ActionOnGet(WaterDropBase waterDrop)
    {
        waterDrop.gameObject.SetActive(true);
    }
    public void ActionOnRelease(WaterDropBase waterDrop)
    {
        waterDrop.gameObject.SetActive(false);
    }

    public void ActionOnDestory(WaterDropBase waterDrop)
    {

    }

    public WaterDropBase GetWaterDrop()
    {
        if (Pool.CountActive >= maxSize)
        {
            return null;
        }
        return Pool.Get();
    }
    public void ReleaseWaterDrop(WaterDropBase waterDrop)
    {
        Pool.Release(waterDrop);
    }
}

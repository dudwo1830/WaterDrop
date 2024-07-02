using UnityEngine;

public class WaterDropImage : MonoBehaviour, IWaterDropImage
{
    [SerializeField, Header("일반 물방울 랜덤 이미지")]
    private Sprite[] sprites;

    public void SetRandomSprite(WaterDropNormal waterDrop)
    {
        var spriteRenderer = waterDrop.GetComponent<SpriteRenderer>();
        var collider = waterDrop.GetComponent<CircleCollider2D>();
        if (spriteRenderer != null)
        {
            var index = Random.Range(0, sprites.Length);
            spriteRenderer.sprite = sprites[index];
            if (collider != null)
            {
                //콜라이더 리셋
                collider.enabled = false;
                collider.enabled = true;
            }
        }
    }
}

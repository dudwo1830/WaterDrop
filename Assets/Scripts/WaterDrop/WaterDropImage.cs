using UnityEngine;

public class WaterDropImage : MonoBehaviour, IWaterDropImage
{
    [SerializeField, Header("�Ϲ� ����� ���� �̹���")]
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
                //�ݶ��̴� ����
                collider.enabled = false;
                collider.enabled = true;
            }
        }
    }
}

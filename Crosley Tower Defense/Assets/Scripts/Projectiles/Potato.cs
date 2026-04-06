using UnityEngine;

public class Potato : CollidingProjectile
{
    [SerializeField] Sprite spriteHit;
    [SerializeField] SpriteRenderer sr;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasCollided) return;

        Triceracopter triceracopter = collision.gameObject.GetComponent<Triceracopter>();
        if (triceracopter != null)
        {
            triceracopter.TakeDamage(damage);
            hasCollided = true;
            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        sr.sprite = spriteHit;
    }
}

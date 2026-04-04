using UnityEngine;

public class CollidingProjectile : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] int damage = 10;

    bool hasCollided = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasCollided) return;

        Triceracopter triceracopter = collision.gameObject.GetComponent<Triceracopter>();
        if (triceracopter != null)
        {
            triceracopter.TakeDamage(damage);
            hasCollided = true;
        }
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

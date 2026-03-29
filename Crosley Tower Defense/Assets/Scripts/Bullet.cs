using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 25;

    private Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    private void FixedUpdate()
    {
        if (!target) return;

        if (Vector2.Distance(target.position, transform.position) < 0.1f)
        {
            Destroy(gameObject);
        }

        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check parent exists before accessing it
        if (collision.gameObject.transform.parent != null &&
            collision.gameObject.transform.parent.GetComponent<Floors>())
        {
            collision.gameObject.transform.parent.GetComponent<Floors>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        //else if (collision.gameObject.GetComponent<Triceracopter>())
        //{
        //    collision.gameObject.GetComponent<Triceracopter>().TakeDamage(bulletDamage);
        //}
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}

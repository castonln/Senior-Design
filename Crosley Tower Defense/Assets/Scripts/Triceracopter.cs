using UnityEngine;
using UnityEngine.LightTransport;
using static UnityEngine.GraphicsBuffer;

public class Triceracopter : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private GameObject bulletPrefab;

    [Header("Attributes")]
    [SerializeField] private Transform firingPoint;
    [SerializeField] private float secondsBetweenFiring = 5f;
    [SerializeField] private int health = 25;

    private Transform shootTarget;

    private float timeSinceFiring = 0f;

    private void Update()
    {
        timeSinceFiring += Time.deltaTime;

        if (timeSinceFiring >= secondsBetweenFiring)
        {
            Shoot();
            timeSinceFiring = 0f;
        }
    }

    public void SetTarget(Transform newTarget)
    {
        shootTarget = newTarget;
    }

    private void Shoot()
    {
        if (!shootTarget) return;

        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(shootTarget);
    }

    public void TakeDamage(int damage)
    {
        if (damage >= health)
        {
            Destroy(gameObject);
        } else
        {
            health -= damage;
        }
    }
}

using UnityEngine;
using UnityEngine.LightTransport;
using static UnityEngine.GraphicsBuffer;

public class Triceracopter : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private GameObject bulletPrefab;

    [Header("Attributes")]
    [SerializeField] private Transform firingPoint;
    [SerializeField] private float bps = 0.5f;
    [SerializeField] private Transform target;
    [SerializeField] private int health = 25;

    private float timeUntilFire = 0f;

    private void Update()
    {
        timeUntilFire += Time.deltaTime;

        if (timeUntilFire >= 1f / bps)
        {
            Shoot();
            timeUntilFire = 0f;
        }
    }
    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
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

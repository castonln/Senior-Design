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
    [SerializeField] private float health = 25;

    private Transform shootTarget;
    private Lane lane;

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

    public void SetTarget(Transform _shootTarget)
    {
        shootTarget = _shootTarget;
    }

    public void SetLane(Lane _lane)
    {
        lane = _lane;
    }

    public Lane GetLane()
    {
        return lane;
    }

    private void Shoot()
    {
        if (!shootTarget) return;

        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(shootTarget);
    }

    public void TakeDamage(float damage)
    {
        if (damage >= health)
        {
            lane.RemoveEnemy(gameObject);
            LevelManager.main.IncreaseCurrency(10);
            Destroy(gameObject);
        } else
        {
            health -= damage;
        }
    }

    public float GetHealth()
    {
        return health;
    }
}

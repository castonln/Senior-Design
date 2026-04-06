using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float damage;

    public void SetDamage(float _damage)
    {
        damage = _damage;
    }
}

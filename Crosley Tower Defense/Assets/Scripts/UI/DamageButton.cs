using UnityEngine;

public class DamageButton : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Tower tower;

    public void OnClick()
    {
        tower.TakeDamage(25);
    }
}

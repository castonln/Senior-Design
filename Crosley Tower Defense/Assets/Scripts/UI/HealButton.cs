using UnityEngine;

public class HealButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Tower tower;

    public void OnClick()
    {
        tower.HealDamage(25);
    }
}

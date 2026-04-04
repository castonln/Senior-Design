using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public int currency;

    private void Awake()
    {
        main = this;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("Can't buy");
            return false;
        }
    }
}

using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int floorHealth = 100;

    [Header("References")]
    [SerializeField] private GameObject[] startingFloors;
    [SerializeField] private Floors floorsContainer;
    [SerializeField] private GameObject floorsParent;

    [Header("Damage Sprites")]
    [SerializeField] private GameObject noDamageSprite;
    [SerializeField] private GameObject loDamageSprite;
    [SerializeField] private GameObject meDamageSprite;
    [SerializeField] private GameObject hiDamageSprite;

    private GameObject curDamageSprite;
    private Stack<GameObject> floors;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        floors = new Stack<GameObject>(startingFloors);
        curDamageSprite = noDamageSprite;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        if (floorHealth <= damage)
        {
            DestroyTopFloor();

            if (floors.Count > 0)
            {
                floorHealth = 100;
            }
        } 
        else
        {
            floorHealth -= damage;
        }
        UpdateDamageSprite();
    }

    public void HealDamage(int health)
    {
        if (floorHealth >= 100)
        {
            CreateNewFloor();
            floorHealth = 100;
        } else
        {
            floorHealth += health;
        }
        UpdateDamageSprite();
    }

    private void UpdateDamageSprite()
    {
        curDamageSprite.GetComponent<SpriteRenderer>().enabled = false;

        if (floorHealth > 75)
        {
            curDamageSprite = noDamageSprite;
        }
        else if (floorHealth > 50)
        {
            curDamageSprite = loDamageSprite;
        } 
        else if (floorHealth > 25)
        {
            curDamageSprite = meDamageSprite;
        } 
        else
        {
            curDamageSprite = hiDamageSprite;
        }

        curDamageSprite.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void DestroyTopFloor()
    {
        GameObject destroyedFloor = floors.Pop();
        Destroy(destroyedFloor);
        floorsContainer.UpdateFloorsFalling();
    }

    private void CreateNewFloor()
    {
        GameObject previousTopFloor = floors.Peek();
        GameObject newTopFloor = Instantiate(
                previousTopFloor,
                previousTopFloor.transform.position + Vector3.up,
                previousTopFloor.transform.rotation,
                floorsParent.transform
            );
        floors.Push(newTopFloor);
        floorsContainer.UpdateFloorsRising();
    }
}
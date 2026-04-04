using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int floorHealth = 100;

    [Header("References")]
    [SerializeField] private Floors floors;
    [SerializeField] private Transform floorsTransform;
    [SerializeField] private FloorsAndGround floorsAndGround;

    [Header("Damage Sprites")]
    [SerializeField] private GameObject noDamageSprite;
    [SerializeField] private GameObject loDamageSprite;
    [SerializeField] private GameObject meDamageSprite;
    [SerializeField] private GameObject hiDamageSprite;

    private GameObject curDamageSprite;
    private Stack<GameObject> floorsStack;

    public static event Action OnFloorStackEmpty;
    public static Tower main;
    private void Awake()
    {
        main = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        floorsStack = new Stack<GameObject>();
        foreach (Transform childTransform in floorsTransform)
        {
            floorsStack.Push(childTransform.gameObject);
        } 
        curDamageSprite = noDamageSprite;
    }

    public void TakeDamage(int damage)
    {
        if (floorHealth <= damage)
        {
            DestroyTopFloor();

            if (floorsStack.Count > 0)
            {
                floorHealth = 100;
            }
            else
            {
                OnFloorStackEmpty?.Invoke();
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
        floorHealth += health;

        if (floorHealth >= 100)
        {
            CreateNewFloor();
            floorHealth = 100;
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
        GameObject destroyedFloor = floorsStack.Pop();
        Destroy(destroyedFloor);
        floorsAndGround.UpdateFloorsAndGroundFalling();
    }

    private void CreateNewFloor()
    {
        GameObject previousTopFloor = floorsStack.Peek();
        GameObject newTopFloor = Instantiate(
                previousTopFloor,
                previousTopFloor.transform.position + Vector3.up,
                previousTopFloor.transform.rotation,
                floors.transform
            );
        floorsStack.Push(newTopFloor);
        floorsAndGround.UpdateFloorsAndGroundRising();
    }
}
using UnityEngine;

public class Floors : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Tower tower;

    [Header("Attributes")]
    [SerializeField] private float fallSpeed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateFloorsFalling()
    {
        transform.Translate(Vector3.up * 1, Space.World);
    }

    public void UpdateFloorsRising()
    {
        transform.Translate(Vector3.down * 1, Space.World);

    }
}

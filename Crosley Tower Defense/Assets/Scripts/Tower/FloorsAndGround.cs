using UnityEngine;

public class FloorsAndGround : MonoBehaviour
{
    public void UpdateFloorsAndGroundFalling()
    {
        transform.Translate(Vector3.up * 1, Space.World);
    }

    public void UpdateFloorsAndGroundRising()
    {
        transform.Translate(Vector3.down * 1, Space.World);

    }
}

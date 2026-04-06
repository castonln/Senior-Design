using System.Collections;
using UnityEngine;

public class FloorsAndGround : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 2f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float shakeDuration = 0.3f;
    [SerializeField] private float shakeMagnitude = 0.1f;

    private bool isMoving = false;

    public bool IsMoving()
    {
        return isMoving;
    }

    public void UpdateFloorsAndGroundFalling()
    {
        StartCoroutine(MoveToTarget(transform.position + Vector3.up, shake: true));
    }

    public void UpdateFloorsAndGroundRising()
    {
        StartCoroutine(MoveToTarget(transform.position + Vector3.down, shake: false));
    }

    private IEnumerator MoveToTarget(Vector3 target, bool shake)
    {
        Vector3 start = transform.position;
        float elapsed = 0f;
        isMoving = true;

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * fallSpeed;
            float t = elapsed * elapsed;
            transform.position = Vector3.Lerp(start, target, t);
            yield return null;
        }

        isMoving = false;

        transform.position = target;

        if (shake)
            StartCoroutine(ShakeCamera());
    }

    private IEnumerator ShakeCamera()
    {
        Vector3 originalPos = cameraTransform.localPosition;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            elapsed += Time.deltaTime;
            float strength = Mathf.Lerp(shakeMagnitude, 0f, elapsed / shakeDuration);
            cameraTransform.localPosition = originalPos + Vector3.up * Mathf.Sin(elapsed * 40f) * strength;
            yield return null;
        }

        cameraTransform.localPosition = originalPos;
    }

    public void ShakeHorizontal()
    {
        StartCoroutine(ShakeCameraHorizontal());
    }

    private IEnumerator ShakeCameraHorizontal()
    {
        Vector3 originalPos = cameraTransform.localPosition;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            elapsed += Time.deltaTime;
            float strength = Mathf.Lerp(shakeMagnitude, 0f, elapsed / shakeDuration);
            float offsetX = Mathf.Sin(elapsed * 40f) * strength;
            cameraTransform.localPosition = new Vector3(originalPos.x + offsetX, originalPos.y, originalPos.z);
            yield return null;
        }

        cameraTransform.localPosition = originalPos;
    }
}
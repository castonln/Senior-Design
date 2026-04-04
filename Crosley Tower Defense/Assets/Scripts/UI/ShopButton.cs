using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private UnityEvent onPressed;
    [SerializeField] private UnityEvent onUnpressed;

    private bool isButtonPressed = false;

    public void OnClick()
    {
        isButtonPressed = !isButtonPressed;

        if (isButtonPressed) onPressed.Invoke();
        else onUnpressed.Invoke();
    }

}
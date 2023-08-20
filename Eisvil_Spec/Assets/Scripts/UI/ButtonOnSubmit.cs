using UnityEngine;

public class ButtonOnSubmit : MonoBehaviour
{
    public delegate void ButtonSubmitEvent();
    public static ButtonSubmitEvent OnButtonSubmitEvent;

    public void OnButtonClick() => OnButtonSubmitEvent.Invoke();
}

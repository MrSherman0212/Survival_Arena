using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Image _pauseScreen;

    public void DoPauseScreen(bool value)
    {
        _pauseScreen.gameObject.SetActive(value);
        if (value) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}

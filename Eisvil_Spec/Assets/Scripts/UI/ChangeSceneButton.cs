using UnityEngine;

public class ChangeSceneButton : MonoBehaviour
{
    public delegate void SceneChangeEvent();
    public static SceneChangeEvent OnSceneChangeEvent;

    public void ChangeScene(string sceneName)
    {
        LevelManager.Instance.LoadScene(sceneName);
        OnSceneChangeEvent.Invoke();
        Time.timeScale = 1;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void SettingsButton()
    {
        GameManager.Instance.ShowSettings();
    }
    public void SettingsInGameButton()
    {
        GameManager.Instance.ShowSettingInGame();
    }
    public void BackToMainMenuButton()
    {
        GameManager.Instance.LeaveSettings();
    }
    public void BackToGameButton()
    {
        GameManager.Instance.BackToGame();
    }
    public void BackToPauseButton()
    {
        GameManager.Instance.LeaveSettingInGame();
    }
    public void QuitButoon()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

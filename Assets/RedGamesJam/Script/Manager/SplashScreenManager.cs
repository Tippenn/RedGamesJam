using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    public void Clicked_SplashScreen()
    {
        AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.click);
        SceneManager.LoadScene("BamMiniGameLobby");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class BamMiniGameLobbyManager : MonoBehaviour
{

    public void Clicked_Play()
    {
        AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.click);
        SceneManager.LoadScene("BamMiniGameScene");
    }

    public void Clicked_Something()
    {
        AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.click);
    }

    public void Clicked_DailyLogin()
    {
        GameManager.Instance.EarnCoin(500f);
        GameManager.Instance.alreadyLogin = true;
    }

    private void Start()
    {
        GameManager.Instance.UpdateLevelSelected();
        AudioManager.Instance.ChangeBGM(AudioManager.Instance.lobbyAndMainMenu);
    }
}

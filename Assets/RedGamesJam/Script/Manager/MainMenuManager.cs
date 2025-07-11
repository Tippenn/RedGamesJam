using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void Clicked_TappyMiniGame()
    {
        SceneManager.LoadScene("TappyMiniGameLobby");
    }

    public void Clicked_BamMiniGame()
    {
        SceneManager.LoadScene("BamMiniGameLobby");
    }

    public void Clicked_OguMiniGame()
    {
        SceneManager.LoadScene("OguMiniGameLobby");
    }    
}

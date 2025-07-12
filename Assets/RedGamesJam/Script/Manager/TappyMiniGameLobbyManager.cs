using UnityEngine;
using UnityEngine.SceneManagement;

public class TappyMiniGameLobbyManager : MonoBehaviour
{
    public void Clicked_Play()
    {
        SceneManager.LoadScene("TappyMiniGameScene");
    }
}

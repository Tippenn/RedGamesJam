using UnityEngine;
using UnityEngine.SceneManagement;

public class OguMiniGameLobbyManager : MonoBehaviour
{
    public void Clicked_Play()
    {
        SceneManager.LoadScene("OguMiniGameScene");
    }
}

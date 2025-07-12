using UnityEngine;
using UnityEngine.SceneManagement;

public class BamMiniGameLobbyManager : MonoBehaviour
{
    public void Clicked_Play()
    {
        SceneManager.LoadScene("BamMiniGameScene");
    }
}

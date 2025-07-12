using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Slider scoreSlider;
    [SerializeField] BamSceneManager bamSceneManager;
    private void OnEnable()
    {
        scoreText.text = bamSceneManager.GetScore().ToString();
        if(PlayerPrefs.GetFloat("BamHighScore") < bamSceneManager.GetScore())
        {
            PlayerPrefs.SetFloat("BamHighScore", bamSceneManager.GetScore());
        }
    }
}

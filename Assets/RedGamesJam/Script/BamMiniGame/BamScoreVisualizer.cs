using TMPro;
using UnityEngine;

public class BamScoreVisualizer : MonoBehaviour
{
    [Header("Source")]
    [SerializeField] private BamSceneManager bamSceneManager;

    [Header("Output")]
    [SerializeField] private TMP_Text scoreText;
    private void Update()
    {
        scoreText.text = bamSceneManager.GetScore().ToString();
    }
}

using TMPro;
using UnityEngine;

public class CountdownVisualizer : MonoBehaviour
{
    [SerializeField] private BamSceneManager bamSceneManager;

    [SerializeField] private float time;
    [SerializeField] private float maxTime;
    [SerializeField] private float currentTime;
    [SerializeField] private int displayCountdown;

    [SerializeField] private TMP_Text textDisplay;
    private void Start()
    {
        maxTime = time;
        currentTime = time;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        displayCountdown = Mathf.CeilToInt(currentTime);
        textDisplay.text = displayCountdown.ToString(); 

        if(currentTime < 0)
        {
            bamSceneManager.OnTimeStart();
        }
    }
}

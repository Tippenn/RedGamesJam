using UnityEngine;
using UnityEngine.UI;

public class BamTimerVisualizer : MonoBehaviour
{
    [Header("Source")]
    [SerializeField] private BamSceneManager bamSceneManager;

    [Header("Output")]
    [SerializeField] private Slider timeSlider;

    private void Start()
    {
        timeSlider.maxValue = bamSceneManager.GetMaxTime();
    }
    private void Update()
    {
       
        timeSlider.value = bamSceneManager.GetCurrentTime();
    }
}

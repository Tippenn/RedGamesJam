using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BiggieVisualizer : MonoBehaviour
{
    [SerializeField] private Image biggieImage;
    [SerializeField] private Sprite jahil;
    [SerializeField] private Sprite baik;
    [SerializeField] private bool isRunning;
    public void TriggerWrongSwipe()
    {
        if (!isRunning)
        {
            StartCoroutine(TriggerWrongSwipes());
            isRunning = true;
        }

    }

    public IEnumerator TriggerWrongSwipes()
    {
        isRunning = true;
        float time = 1f;
        while(time > 0f)
        {
            biggieImage.sprite = jahil;
            time -= Time.deltaTime;
            yield return null;
        }
        biggieImage.sprite = baik;
        isRunning = false;

    }
}

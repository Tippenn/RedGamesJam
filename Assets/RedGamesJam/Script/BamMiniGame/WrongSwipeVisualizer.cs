using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WrongSwipeVisualizer : MonoBehaviour
{
    [SerializeField] private Image wrongImage;
    [SerializeField] private float speed;
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
        float alpha = 0f;
        while(alpha < 1f)
        {
            alpha += Time.deltaTime * speed;
            Color color = new Color(1, 1, 1, alpha);
            wrongImage.color = color;
            yield return null;
        }
        yield return null;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime * speed;
            Color color = new Color(1, 1, 1, alpha);
            wrongImage.color = color;
            yield return null;
        }

        isRunning = false;
        
    }
}

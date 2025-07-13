using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextSwipe : MonoBehaviour
{
    [SerializeField] private Image textSwipeImage;
    private void Start()
    {
        StartCoroutine(DestroyingObject());
    }

    public IEnumerator DestroyingObject()
    {
        float alpha = 1f;
        while (alpha > 0f)
        {
            alpha -= Time.deltaTime;
            Color color = new Color(1, 1, 1, alpha);
            textSwipeImage.color = color;
            yield return null;
        }
        Destroy(gameObject);
    }

}

using UnityEngine;

public class ItemSlider : MonoBehaviour
{
    public MiddleItemVisualizer middleItemVisualizer;
    public BamSceneManager bamSceneManager;
    public RectTransform rectTransform;
    public RectTransform desiredTransform;
    public RectTransform parentTransform;

    public bool alreadyOccupying;
    public void Initialize()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rectTransform.anchoredPosition = Vector2.MoveTowards(rectTransform.anchoredPosition, desiredTransform.anchoredPosition - parentTransform.anchoredPosition, 30f);
    }

}

using UnityEngine;
using UnityEngine.UI;

public class MascotVisualizer : MonoBehaviour
{
    [SerializeField] private Image mascotImage;

    private void Start()
    {
        foreach (MascotLevelInfo mascotLevelInfo in GameManager.Instance.mascotLevelInfos)
        {
            if(GameManager.Instance.GetMascotUsed() == mascotLevelInfo.mascotName)
            {
                mascotImage.sprite = mascotLevelInfo.mascotSprite;
            }
        }
    }
}

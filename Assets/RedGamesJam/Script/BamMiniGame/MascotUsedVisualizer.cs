using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MascotUsedVisualizer : MonoBehaviour
{
    [SerializeField] private TMP_Text mascotName;
    [SerializeField] private TMP_Text mascotDesc;
    [SerializeField] private TMP_Text mascotLevel;
    [SerializeField] private Image mascotImage;
    private void Start()
    {
        UpdateVisual();
    }
    public void UpdateVisual()
    {
        foreach (MascotLevelInfo mascotLevelInfo in GameManager.Instance.mascotLevelInfos)
        {
            if (mascotLevelInfo.mascotName == GameManager.Instance.GetMascotUsed())
            {
                mascotImage.sprite = mascotLevelInfo.mascotSprite;
                mascotName.text = mascotLevelInfo.mascotString;
                
                foreach (MascotLevelBenefit mascotLevelBenefit in mascotLevelInfo.benefit)
                {
                    if (mascotLevelBenefit.unlocked)
                    {
                        mascotDesc.text = mascotLevelBenefit.textDescription;
                        mascotLevel.text = "Lv. " + mascotLevelBenefit.level.ToString();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}

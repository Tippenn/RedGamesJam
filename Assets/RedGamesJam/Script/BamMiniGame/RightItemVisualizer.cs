using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightItemVisualizer : MonoBehaviour
{
    [SerializeField] private BamSceneManager bamSceneManager;

    [SerializeField] private List<ConveyerItem> itemRight;
    [SerializeField] private Image[] placeholderObjects;

    private void Start()
    {
        itemRight = bamSceneManager.GetRightItem();
        int arrayCount = 0;
        foreach (ConveyerItem item in itemRight)
        {
            foreach (BamItemData itemData in bamSceneManager.GetItemDatas())
            {
                if (item == itemData.item)
                {
                    placeholderObjects[arrayCount].sprite = itemData.itemImage;
                    break;
                }
            }
            arrayCount++;
        }

        for (int i = arrayCount; i < placeholderObjects.Length; i++)
        {
            placeholderObjects[i].enabled = false;
        }
    }
}

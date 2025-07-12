using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiddleItemVisualizer : MonoBehaviour
{
    [SerializeField] private BamSceneManager bamSceneManager;

    [SerializeField] private RectTransform itemParent;
    [SerializeField] private List<GameObject> items;
    public ConveyorOccupiedPosition[] conveyorOccupiedPositions;

    [SerializeField] private RectTransform leftItem;
    [SerializeField] private RectTransform rightItem;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void SpawnItem(ConveyerItem conveyerItem)
    {

        foreach (BamItemData item in bamSceneManager.GetItemDatas())
        {
            if(item.item == conveyerItem)
            {
                GameObject go = Instantiate(item.itemGameObject,itemParent.transform);
                items.Add(go);  
                ItemSlider itemSlider = go.GetComponent<ItemSlider>();
                itemSlider.parentTransform = itemParent;
                itemSlider.middleItemVisualizer = this;
                TryMovingDownItem();
                itemSlider.Initialize();

            }
        }
    }

    public void ItemLeftSlide()
    {
        ItemSlider itemSlider = items[0].GetComponent<ItemSlider>();
        itemSlider.desiredTransform = leftItem;

        items.RemoveAt(0);
        TryMovingDownItem();
    }

    public void ItemRightSlide()
    {
        ItemSlider itemSlider = items[0].GetComponent<ItemSlider>();
        itemSlider.desiredTransform = rightItem;

        items.RemoveAt(0);
        TryMovingDownItem();
    }

    public void TryMovingDownItem()
    {
        int count = 0;
        foreach(GameObject go in items)
        {
            ItemSlider itemSlider = go.GetComponent<ItemSlider>();

            itemSlider.desiredTransform = conveyorOccupiedPositions[count].position;
            count++;
        }
    }

}

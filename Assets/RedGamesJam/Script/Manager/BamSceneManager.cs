using UnityEngine;
using System.Collections.Generic;

public class BamSceneManager : MonoBehaviour
{
    [Header("InfoLlevel")]
    [SerializeField] private BamLevelInfo[] levelInfo;

    [Header("Conveyer")]
    [SerializeField] private List<ConveyerItem> itemLeft;
    [SerializeField] private List<ConveyerItem> itemRight;
    [SerializeField] private List<ConveyerItem> itemMiddle;
    [SerializeField] private List<ConveyerItem> itemAllowed;


    [Header("Timer")]
    [SerializeField] private float currentTime;
    [SerializeField] private float maxTime;

    [Header("Score")]
    [SerializeField] private float score;
    private void Awake()
    {
        itemLeft = levelInfo[0].itemLeft;
        itemRight = levelInfo[0].itemRight;
        itemAllowed = levelInfo[0].itemAllowed;
        currentTime = levelInfo[0].timer;
        maxTime = levelInfo[0].timer;
        GenerateItem();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            GameOver();
        }
    }

    public void GenerateItem()
    {
        while(itemMiddle.Count < 6)
        {
            int randomItem = Random.Range(0, itemAllowed.Count);
            itemMiddle.Add(itemAllowed[randomItem]);
        }
    }

    public void GameOver()
    {

    }

    public void Clicked_Left()
    {
        bool benar = false;
        foreach (ConveyerItem item in itemLeft)
        {
            if(item == itemMiddle[0])
            {
                benar = true;
            }
        }

        if(benar == true)
        {
            score += 10000;
            Debug.Log("Benar");
        }
        else
        {
            currentTime--;
            Debug.Log("Salah");
        }

        itemMiddle.RemoveAt(0);

        GenerateItem();
    }

    public void Clicked_Right()
    {
        bool benar = false;
        foreach (ConveyerItem item in itemRight)
        {
            if (item == itemMiddle[0])
            {
                benar = true;
            }
        }

        if (benar == true)
        {
            score += 10000;
            Debug.Log("Benar");
        }
        else
        {
            currentTime--;
            Debug.Log("Salah");
        }

        itemMiddle.RemoveAt(0);

        GenerateItem();
    }

    #region getter
    public float GetScore()
    {
        return score;
    }

    public float GetMaxTime()
    {
        return maxTime;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
    #endregion
}

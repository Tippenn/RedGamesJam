using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BamSceneManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private BamItemData[] itemDatas;

    [Header("InfoLlevel")]
    [SerializeField] private BamLevelInfo[] levelInfo;
    [SerializeField] private int currentLevel;

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
    [SerializeField] private int combo;

    [Header("Event")]
    [SerializeField] private bool isInitialized = false;
    public UnityEvent onTimerStart;
    public UnityEvent<ConveyerItem> onItemSpawn;
    public UnityEvent onItemSwipe;
    public UnityEvent onLeftSwipe;
    public UnityEvent onRightSwipe;
    public UnityEvent onGameOver;
    private void Awake()
    {
        itemLeft = levelInfo[currentLevel].itemLeft;
        itemRight = levelInfo[currentLevel].itemRight;
        itemAllowed = levelInfo[currentLevel].itemAllowed;
        currentTime = levelInfo[currentLevel].timer;
        maxTime = levelInfo[currentLevel].timer;
        GenerateItem();
    }

    private void Update()
    {
        if (!isInitialized) return;

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
            onItemSpawn?.Invoke(itemMiddle[itemMiddle.Count - 1]);
        }
    }

    public void GameOver()
    {
        onGameOver?.Invoke();
    }

    public void OnTimeStart()
    {
        isInitialized = true;
        onTimerStart?.Invoke();
    }
    #region button
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
            combo++;
            if(combo < 10)
            {
                score += 20000 * 1f;
            }
            else if(combo < 20)
            {
                score += 20000 * 1.2f;
            }
            else if (combo < 50)
            {
                score += 20000 * 1.5f;
            }
            else if (combo < 100)
            {
                score += 20000 * 2f;
            }
            else if (combo < 100)
            {
                score += 20000 * 3f;
            }
            else if (combo < 150)
            {
                score += 20000 * 4f;
            }
            else if (combo < 200)
            {
                score += 20000 * 5f;
            }
            else
            {
                score += 20000 * 6f;
            }
            Debug.Log("Benar");
        }
        else
        {
            combo = 0;
            currentTime -= 2;
            Debug.Log("Salah");
        }

        itemMiddle.RemoveAt(0);
        onItemSwipe?.Invoke();
        onLeftSwipe?.Invoke();
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
            combo++;
            if (combo < 10)
            {
                score += 20000 * 1f;
            }
            else if (combo < 20)
            {
                score += 20000 * 1.2f;
            }
            else if (combo < 50)
            {
                score += 20000 * 1.5f;
            }
            else if (combo < 100)
            {
                score += 20000 * 2f;
            }
            else if (combo < 100)
            {
                score += 20000 * 3f;
            }
            else if (combo < 150)
            {
                score += 20000 * 4f;
            }
            else if (combo < 200)
            {
                score += 20000 * 5f;
            }
            else
            {
                score += 20000 * 6f;
            }
            Debug.Log("Benar");
        }
        else
        {
            combo = 0;
            currentTime-=2;
            Debug.Log("Salah");
        }

        itemMiddle.RemoveAt(0);
        onItemSwipe?.Invoke();
        onRightSwipe?.Invoke();
        GenerateItem();
    }

    public void Clicked_Retry()
    {
        SceneManager.LoadScene("BamMiniGameScene");
    }

    public void Clicked_Next()
    {
        SceneManager.LoadScene("BamMiniGameLobby");
    }
    #endregion
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

    public int GetCombo()
    {
        return combo;
    }
    public List<ConveyerItem> GetLeftItem()
    {
        return itemLeft;
    }

    public List<ConveyerItem> GetRightItem()
    {
        return itemRight;
    }

    public List<ConveyerItem> GetMiddleItem()
    {
        return itemMiddle;
    }

    public BamItemData[] GetItemDatas()
    {
        return itemDatas;
    }
    #endregion
}

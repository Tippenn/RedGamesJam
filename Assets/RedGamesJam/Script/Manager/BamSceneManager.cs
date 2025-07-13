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
    [SerializeField] private float scoreBonus;
    [SerializeField] private int combo;

    [Header("Crit")]
    [SerializeField] private float CritChance;

    [Header("Event")]
    [SerializeField] private bool isInitialized = false;
    [SerializeField] private bool isGameover = false;
    public UnityEvent onTimerStart;
    public UnityEvent<ConveyerItem> onItemSpawn;
    public UnityEvent onItemSwipe;
    public UnityEvent onLeftSwipe;
    public UnityEvent onRightSwipe;
    public UnityEvent onCorrectSwipe;
    public UnityEvent onWrongSwipe;
    public UnityEvent onCriticalSwipe;
    public UnityEvent onGameOver;
    private void Awake()
    {
        currentLevel = GameManager.Instance.GetLevelSelected();
        itemLeft = levelInfo[currentLevel].itemLeft;
        itemRight = levelInfo[currentLevel].itemRight;
        itemAllowed = levelInfo[currentLevel].itemAllowed;
        
        maxTime = levelInfo[currentLevel].timer;
        foreach(MascotLevelInfo mascotLevelInfo in GameManager.Instance.mascotLevelInfos)
        {
            if(mascotLevelInfo.mascotName == GameManager.Instance.GetMascotUsed())
            {
                foreach(MascotLevelBenefit mascotLevelBenefit in mascotLevelInfo.benefit)
                {
                    if (mascotLevelBenefit.unlocked)
                    {
                        CritChance = mascotLevelBenefit.critRate;
                        maxTime += mascotLevelBenefit.extraTime;
                        scoreBonus = mascotLevelBenefit.scoreBonus;
                    }
                }
            }
        }

        currentTime = maxTime;
        GenerateItem();
    }

    private void Start()
    {
        AudioManager.Instance.ChangeBGM(AudioManager.Instance.inGame);
    }
    private void Update()
    {
        if (!isInitialized) return;

        currentTime -= Time.deltaTime;
        if(currentTime <= 0 && isGameover == false)
        {
            isGameover = true;
            GameOver();
        }
    }

    public void GenerateItem()
    {
        while(itemMiddle.Count < 9)
        {
            int randomItem = Random.Range(0, itemAllowed.Count);
            itemMiddle.Add(itemAllowed[randomItem]);
            onItemSpawn?.Invoke(itemMiddle[itemMiddle.Count - 1]);
        }
    }

    public void CalculateScore()
    {
        score += (score * scoreBonus / 100f);
    }

    public void GameOver()
    {
        CalculateScore();
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
        AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.tap);
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
            float addedScore;
            if(combo < 10)
            {
                addedScore = 20000 * 1f;
            }
            else if(combo < 20)
            {
                addedScore = 20000 * 1.2f;
            }
            else if (combo < 50)
            {
                addedScore = 20000 * 1.5f;
            }
            else if (combo < 100)
            {
                addedScore = 20000 * 2f;
            }
            else if (combo < 100)
            {
                addedScore = 20000 * 3f;
            }
            else if (combo < 150)
            {
                addedScore = 20000 * 4f;
            }
            else if (combo < 200)
            {
                addedScore = 20000 * 5f;
            }
            else
            {
                addedScore = 20000 * 6f;
            }

            if(Random.Range(0, 100) < CritChance)
            {
                addedScore *= 2f;
                onCriticalSwipe?.Invoke();
            }
            onCorrectSwipe?.Invoke();
            score += addedScore;
            Debug.Log("Benar");
        }
        else
        {            
            combo = 0;
            currentTime -= 2;
            onWrongSwipe?.Invoke();
            Debug.Log("Salah");
        }

        itemMiddle.RemoveAt(0);
        onItemSwipe?.Invoke();
        onLeftSwipe?.Invoke();
        GenerateItem();
    }

    public void Clicked_Right()
    {
        AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.tap);

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
            float addedScore;
            if (combo < 10)
            {
                addedScore = 20000 * 1f;
            }
            else if (combo < 20)
            {
                addedScore = 20000 * 1.2f;
            }
            else if (combo < 50)
            {
                addedScore = 20000 * 1.5f;
            }
            else if (combo < 100)
            {
                addedScore = 20000 * 2f;
            }
            else if (combo < 100)
            {
                addedScore = 20000 * 3f;
            }
            else if (combo < 150)
            {
                addedScore = 20000 * 4f;
            }
            else if (combo < 200)
            {
                addedScore = 20000 * 5f;
            }
            else
            {
                addedScore = 20000 * 6f;
            }

            if (Random.Range(0, 100) < CritChance)
            {
                addedScore *= 2f;
                onCriticalSwipe?.Invoke();
            }
            onCorrectSwipe?.Invoke();
            score += addedScore;
            Debug.Log("Benar");
        }
        else
        {
            combo = 0;
            currentTime-=2;
            onWrongSwipe?.Invoke();
            Debug.Log("Salah");
        }

        itemMiddle.RemoveAt(0);
        onItemSwipe?.Invoke();
        onRightSwipe?.Invoke();
        GenerateItem();
    }

    public void Clicked_Retry()
    {
        AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.click);

        SceneManager.LoadScene("BamMiniGameScene");
    }

    public void Clicked_Next()
    {
        AudioManager.Instance.PlaySFXOneShot(AudioManager.Instance.click);

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

    public float GetScoreBonus()
    {
        return scoreBonus;
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

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
    #endregion
}

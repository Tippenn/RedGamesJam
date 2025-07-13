using Unity.VisualScripting;
using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    [Header("Info")]
    public MascotLevelInfo[] mascotLevelInfos;
    public LevelInfo[] levelInfos;
    public BadgeInfo[] badgeInfos;
    public int levelSelected;
    public LastPlayedLevelInfo bestScores; //incase failed
    public bool alreadyLogin = false;

    [Header("Current Resource")]
    [SerializeField] private int Tickets;
    [SerializeField] private float Coins;
    [SerializeField] private MascotName mascotUsed;

    public void SelectMascot(MascotName mascotName)
    {
        mascotUsed = mascotName;
    }

    public void UpdateLevelSelected()
    {
        foreach(LevelInfo levelInfo in levelInfos)
        {
            if(!levelInfo.levelCompleted)
            {
                levelSelected = levelInfo.level;
                break;
            }

        }
    }

    #region getter
    public float GetCoin()
    {
        return Coins;
    }

    public MascotName GetMascotUsed()
    {
        return mascotUsed;
    }

    public int GetLevelSelected()
    {
        return levelSelected;
    }
    #endregion

    #region setter (in a way)
    public void SpendCoin(float amount)
    {
        Coins -= amount;
    }

    public void EarnCoin(float amount)
    {
        Coins += amount;
    }

    public void ChangeMascot(MascotName name)
    {
        mascotUsed = name;
    }

    public void ChangeLevel(int level)
    {
        levelSelected = level;
    }
    #endregion
}

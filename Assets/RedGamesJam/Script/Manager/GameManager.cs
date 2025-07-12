using UnityEngine;

public class GameManager : PersistentSingleton<GameManager>
{
    [Header("Info")]
    public MascotLevelInfo[] mascotLevelInfo;

    [Header("Current Resource")]
    [SerializeField] private int Tickets;
    [SerializeField] private float Coins;
    [SerializeField] private MascotName mascotUsed;

    public void SelectMascot(MascotName mascotName)
    {
        mascotUsed = mascotName;
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
    #endregion

    public void SpendCoin(float amount)
    {
        Coins -= amount;
    }

    public void ChangeMascot(MascotName name)
    {
        mascotUsed = name;
    }
}

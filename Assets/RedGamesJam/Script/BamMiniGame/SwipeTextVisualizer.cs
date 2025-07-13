using UnityEngine;

public class SwipeTextVisualizer : MonoBehaviour
{
    [SerializeField] private RectTransform textLocation;
    [SerializeField] private RectTransform starLocation;

    [SerializeField] private GameObject failPrefab;
    [SerializeField] private GameObject criticalPrefab;
    [SerializeField] private GameObject starPrefab;

    public void SpawnFailPrefab()
    {
        Instantiate(failPrefab,textLocation);
    }

    public void SpawnCriticalPrefab()
    {
        Instantiate(criticalPrefab, textLocation);
    }

    public void SpawnStarPrefab()
    {
        Instantiate(starPrefab, starLocation);
    }
}

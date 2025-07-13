using UnityEngine;

public class DailyLoginVisualizer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.Instance.alreadyLogin)
        {
            this.gameObject.SetActive(false);
        }
    }
   
}

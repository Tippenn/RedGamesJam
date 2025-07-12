using TMPro;
using UnityEngine;

public class TopBarVisualizer : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;

    private void Update()
    {
        coinText.text = GameManager.Instance.GetCoin().ToString();
    }
}

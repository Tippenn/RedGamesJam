using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComboVisualizer : MonoBehaviour
{
    [SerializeField] private BamSceneManager bamSceneManager;
    [SerializeField] private TMP_Text comboText;
    [SerializeField] private GameObject parentGO;

    private void Start()
    {
       UpdateCombo();
    }

    public void UpdateCombo()
    {
        if(bamSceneManager.GetCombo() == 0)
        {
            parentGO.SetActive(false);
        }
        else
        {
            parentGO.SetActive(true);
            comboText.text = bamSceneManager.GetCombo().ToString();
        }
        
    }
}

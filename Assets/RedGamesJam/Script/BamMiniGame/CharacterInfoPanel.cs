using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoPanel : MonoBehaviour
{
    [SerializeField] private ChooseCharacterPanel chooseCharacterPanel;

    [SerializeField] private Image mascotImage;
    [SerializeField] private TMP_Text mascotDesc;
    [SerializeField] private TMP_Text mascotStringName;
    [SerializeField] private TMP_Text mascotLevel;
    [SerializeField] private TMP_Text mascotUpgradeCost;
    [SerializeField] private Button mascotSelectButton;
    [SerializeField] private Button mascotUpgradeButton;
    public void OnEnable()
    {
        ShowChar();
    }

    public void ShowChar()
    {
        foreach (MascotLevelInfo mascotLevelInfo in GameManager.Instance.mascotLevelInfos)
        {
            if (mascotLevelInfo.mascotName == chooseCharacterPanel.GetCharSelected())
            {
                mascotImage.sprite = mascotLevelInfo.mascotSprite;
                mascotStringName.text = mascotLevelInfo.mascotString;
                mascotDesc.text = mascotLevelInfo.mascotString;
                int index = 0;
                foreach (MascotLevelBenefit mascotLevelBenefit in mascotLevelInfo.benefit)
                {
                    if (mascotLevelBenefit.unlocked)
                    {
                        mascotDesc.text = mascotLevelBenefit.textDescription;
                        mascotLevel.text = "Lv. " + mascotLevelBenefit.level.ToString();
                        mascotSelectButton.interactable = true;
                        if(index == 4)
                        {
                            mascotUpgradeButton.interactable = false;
                        }
                        else
                        {
                            mascotUpgradeButton.interactable = true;
                        }
                    }
                    else
                    {

                        if (index == 0)
                        {
                            mascotDesc.text = "Locked";
                            mascotLevel.text = "";
                            mascotSelectButton.interactable = false;
                        }
                        mascotUpgradeCost.text = mascotLevelBenefit.cost.ToString();
                        if (GameManager.Instance.GetCoin() < mascotLevelBenefit.cost)
                        {
                            mascotUpgradeButton.interactable = false;
                        }
                        else
                        {
                            mascotUpgradeButton.interactable = true;
                        }
                        
                        break;
                    }
                    index++;
                }
            }
        }
    }

    #region not used
    public void ShowOgu()
    {
        foreach (MascotLevelInfo mascotLevelInfo in GameManager.Instance.mascotLevelInfos)
        {
            if(mascotLevelInfo.mascotName == MascotName.Ogu)
            {
                mascotImage.sprite = mascotLevelInfo.mascotSprite;
                mascotStringName.text = mascotLevelInfo.mascotString;
                mascotDesc.text = mascotLevelInfo.mascotString;
                int index = 0;
                foreach (MascotLevelBenefit mascotLevelBenefit in mascotLevelInfo.benefit)
                {
                    if (mascotLevelBenefit.unlocked)
                    {
                        mascotDesc.text = mascotLevelBenefit.textDescription;
                        mascotLevel.text = "Lv. " + mascotLevelBenefit.level.ToString();
                        mascotSelectButton.interactable = true;
                    }
                    else
                    {

                        if (index == 0)
                        {
                            mascotDesc.text = "Locked";
                            mascotLevel.text = "";
                            mascotSelectButton.interactable = false;
                        }
                        mascotUpgradeCost.text = mascotLevelBenefit.cost.ToString();
                        break;
                    }
                    index++;
                }
            }
        }
    }

    public void ShowBam()
    {
        foreach (MascotLevelInfo mascotLevelInfo in GameManager.Instance.mascotLevelInfos)
        {
            if (mascotLevelInfo.mascotName == MascotName.Bam)
            {
                mascotImage.sprite = mascotLevelInfo.mascotSprite;
                mascotStringName.text = mascotLevelInfo.mascotString;
                int index = 0;
                foreach(MascotLevelBenefit mascotLevelBenefit in mascotLevelInfo.benefit)
                {
                    if(mascotLevelBenefit.unlocked)
                    {
                        mascotDesc.text = mascotLevelBenefit.textDescription;
                        mascotLevel.text = "Lv. " + mascotLevelBenefit.level.ToString();
                        mascotSelectButton.interactable = true;

                    }
                    else
                    {
                        
                        if (index == 0)
                        {
                            mascotDesc.text = "Locked";
                            mascotLevel.text = "";
                            mascotSelectButton.interactable = false;
                        }
                        mascotUpgradeCost.text = mascotLevelBenefit.cost.ToString();
                        break;
                    }
                    index++;
                }
            }
        }
    }

    public void ShowTappy()
    {
        foreach (MascotLevelInfo mascotLevelInfo in GameManager.Instance.mascotLevelInfos)
        {
            if (mascotLevelInfo.mascotName == MascotName.Tappy)
            {
                mascotImage.sprite = mascotLevelInfo.mascotSprite;
                mascotStringName.text = mascotLevelInfo.mascotString;
                mascotDesc.text = mascotLevelInfo.mascotString;
                int index = 0;
                foreach (MascotLevelBenefit mascotLevelBenefit in mascotLevelInfo.benefit)
                {
                    if (mascotLevelBenefit.unlocked)
                    {
                        mascotDesc.text = mascotLevelBenefit.textDescription;
                        mascotLevel.text = "Lv. " + mascotLevelBenefit.level.ToString();
                        mascotSelectButton.interactable = true;

                    }
                    else
                    {

                        if (index == 0)
                        {
                            mascotDesc.text = "Locked";
                            mascotLevel.text = "";
                            mascotSelectButton.interactable = false;
                        }
                        mascotUpgradeCost.text = mascotLevelBenefit.cost.ToString();
                        break;
                    }
                    index++;
                }
            }
        }
    }
    #endregion
    public void Clicked_Upgrade()
    {
        foreach (MascotLevelInfo mascotLevelInfo in GameManager.Instance.mascotLevelInfos)
        {
            if (mascotLevelInfo.mascotName == chooseCharacterPanel.GetCharSelected())
            {
                int index = 0;
                foreach (MascotLevelBenefit mascotLevelBenefit in mascotLevelInfo.benefit)
                {
                    if (!mascotLevelBenefit.unlocked)
                    {
                        GameManager.Instance.SpendCoin(mascotLevelBenefit.cost);
                        mascotLevelBenefit.unlocked = true;
                        ShowChar();
                        break;
                    }
                    
                }
            }
        }
    }

    public void Clicked_Select()
    {
        GameManager.Instance.ChangeMascot(chooseCharacterPanel.GetCharSelected());
    }
}

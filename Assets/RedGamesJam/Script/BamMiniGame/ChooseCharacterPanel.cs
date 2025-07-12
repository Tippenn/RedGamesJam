using UnityEngine;

public class ChooseCharacterPanel : MonoBehaviour
{
    [SerializeField] private CharacterInfoPanel characterInfoPanel;
    [SerializeField] private MascotName characterSelected;

    public void Clicked_Bam()
    {
        characterSelected = MascotName.Bam;
    }

    public void Clicked_Ogu()
    {
        characterSelected = MascotName.Ogu;
    }

    public void Clicked_Tappy()
    {
        characterSelected = MascotName.Tappy;
    }

    #region getter
    public MascotName GetCharSelected()
    {
        return characterSelected;
    }
    #endregion
}

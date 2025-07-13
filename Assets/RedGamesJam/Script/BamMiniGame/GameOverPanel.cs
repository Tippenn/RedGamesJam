using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text rewardAmountText;
    [SerializeField] private TMP_Text scoreBonusText;
    [SerializeField] private Slider scoreSlider;
    [SerializeField] BamSceneManager bamSceneManager;
    [SerializeField] private UnityEvent OnScoreDoneGenerating;
    private void OnEnable()
    {
        if(bamSceneManager.GetScore() > GameManager.Instance.levelInfos[bamSceneManager.GetCurrentLevel()].badgeToScore[0].scoreNeeded)
        {
            GameManager.Instance.levelInfos[bamSceneManager.GetCurrentLevel()].levelCompleted = true;
        }

        GameManager.Instance.bestScores.level = bamSceneManager.GetCurrentLevel();
        if(GameManager.Instance.bestScores.score < bamSceneManager.GetScore())
        {
            GameManager.Instance.bestScores.score = bamSceneManager.GetScore();
        }
        GameManager.Instance.EarnCoin(Mathf.RoundToInt(bamSceneManager.GetScore()/10000f));
        scoreText.text = bamSceneManager.GetScore().ToString();
        if (bamSceneManager.GetScore() > GameManager.Instance.levelInfos[bamSceneManager.GetCurrentLevel()].badgeToScore[4].scoreNeeded)
        {
            //reach highscore
            scoreSlider.value = 1f;
        }
        else
        {
            scoreSlider.value = bamSceneManager.GetScore()/ GameManager.Instance.levelInfos[bamSceneManager.GetCurrentLevel()].badgeToScore[4].scoreNeeded;
        }
        rewardAmountText.text = Mathf.RoundToInt(bamSceneManager.GetScore() / 10000f).ToString();
        scoreBonusText.text = "+" + bamSceneManager.GetScoreBonus().ToString() + "%";
        //if(PlayerPrefs.GetFloat("BamHighScore") < bamSceneManager.GetScore())
        //{
        //    PlayerPrefs.SetFloat("BamHighScore", bamSceneManager.GetScore());
        //}
    }

    public IEnumerator StartGeneratingScore()
    {
        yield return null;
    }
}

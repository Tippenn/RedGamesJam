using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfoVisualizer : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text bestScoreText;
    [SerializeField] private TMP_Text leaderboardText;
    [SerializeField] private Slider bestScoreSlider;
    [SerializeField] private Image badgeImage;
    [SerializeField] private Image nextBadgeImage;

    private void Start()
    {
        int index = 0;
        foreach (LevelInfo levelInfo in GameManager.Instance.levelInfos)
        {
            //level 5
            if(index == 4)
            {
                levelText.text = "Level " + (levelInfo.level+1).ToString() + "/5";
                if (GameManager.Instance.bestScores.level == levelInfo.level)
                {
                    int badgeIndex = 0;
                    foreach(BadgeToScore badgeToScore in levelInfo.badgeToScore)
                    {
                        if(GameManager.Instance.bestScores.score > badgeToScore.scoreNeeded)
                        {
                            badgeIndex++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    //max score lewat
                    if(badgeIndex > 4)
                    {
                        bestScoreText.text = GameManager.Instance.bestScores.score.ToString();
                        nextBadgeImage.sprite = GameManager.Instance.badgeInfos[4].badgeImage;
                        badgeImage.sprite = GameManager.Instance.badgeInfos[4].badgeImage;
                        //ngitung leaderboard gimmick
                        float leaderboard;
                        if (GameManager.Instance.bestScores.score > 10000000f)
                        {
                            leaderboard = 1f;
                        }
                        else if(GameManager.Instance.bestScores.score > 7000000f)
                        {
                            leaderboard = 10f;
                        }
                        else if (GameManager.Instance.bestScores.score > 5000000f)
                        {
                            leaderboard = 20f;
                        }
                        else
                        {
                            leaderboard = 50f;
                        }
                        leaderboardText.text = "Top " + leaderboard + "%";
                        bestScoreSlider.value = 1f;
                    }
                    else
                    {
                        leaderboardText.text = "";
                        bestScoreText.text = GameManager.Instance.bestScores.score.ToString() + "/" + levelInfo.badgeToScore[badgeIndex].scoreNeeded.ToString();
                        bestScoreSlider.value = GameManager.Instance.bestScores.score / levelInfo.badgeToScore[badgeIndex].scoreNeeded;
                        if(badgeIndex == 0)
                        {
                            badgeImage.sprite = GameManager.Instance.badgeInfos[badgeIndex].badgeImage;
                        }
                        else
                        {
                            badgeImage.sprite = GameManager.Instance.badgeInfos[badgeIndex - 1].badgeImage;
                        }
                        
                        nextBadgeImage.sprite = GameManager.Instance.badgeInfos[badgeIndex].badgeImage;
                    }
                    
                }

            }
            if (!levelInfo.levelCompleted)
            {
                leaderboardText.text = "";
                levelText.text ="Level " + (levelInfo.level + 1).ToString() + "/5";
                if(GameManager.Instance.bestScores.level == levelInfo.level)
                {                    
                    bestScoreText.text = GameManager.Instance.bestScores.score + "/" + levelInfo.badgeToScore[0].scoreNeeded.ToString();
                    bestScoreSlider.value = GameManager.Instance.bestScores.score / levelInfo.badgeToScore[0].scoreNeeded;
                }
                else
                {
                    bestScoreSlider.value = 0f;
                    bestScoreText.text = "0" + "/" + levelInfo.badgeToScore[0].scoreNeeded.ToString();
                }
                
                break;
            }
            index++;
        }
    }
}

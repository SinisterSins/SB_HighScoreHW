using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int currentScore;

    public TMP_Text finalScoreText;
    public TMP_Text highScoreText;
    public void ChangeScore(int points) //updates score
    {
        currentScore += points;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    public void HighScoreUpdate()
    {
        //is there already a highscore?
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            //is new score higher than saved?
            if(currentScore > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", currentScore);
            }
        }
        else
        {
            //no highscore? set it
            PlayerPrefs.SetInt("SavedHighScore", currentScore);
        }
        //Updating our TMP
        finalScoreText.text = "Score: " + currentScore.ToString();
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("SavedHighScore").ToString();
    }
}

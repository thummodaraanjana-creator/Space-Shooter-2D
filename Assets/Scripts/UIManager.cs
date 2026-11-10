using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image LivesDisplay;

    private int _score = 0;

    public Text ScoreText;

    public Sprite[] LivesSprites;

    public void UpdateLives(int currLives)
    {
        if (currLives >= 0 && currLives < LivesSprites.Length)
        {
            LivesDisplay.sprite = LivesSprites[currLives];
        }
    }// Update is called once per frame

    public void UpdateScore()
    {
        _score += 10;
        ScoreText.text = "Score: " + _score;
    }

}//class

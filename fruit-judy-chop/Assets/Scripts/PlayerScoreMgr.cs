using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections.Generic;

public class PlayerScoreMgr : MonoBehaviour
{
    public InputField NameField;
    public Text scoreText;
    private List<string> playerScores;
    private List<string> allScores;

    private void Start()
    {
        FileManager fm = new FileManager();
        allScores = fm.GetScores();
        playerScores = new List<string>();
    }

    private void Update()
    {
        if(NameField.text != Stats.playerName)
        {
            SetPlayerName();
        }
    }

    public void SetPlayerName()
    {
        NameField.characterLimit = 25;
        Stats.playerName = NameField.text;

        if (NameField.text == "")
        {
            scoreText.text = "Please provide a name.";
        }
        else {
            GetPlayerScores();
            if(playerScores.Count == 0)
            {
                scoreText.text = "No scores found for " + Stats.playerName;
            }
            else
            {
                PrintPrevPlayerScores();
            }
        }
    }

    void GetPlayerScores()
    {
        playerScores = new List<string>();
        string[] data = new string[2];
        foreach (string score in allScores)
        {
            data = score.Split(',');
            if(data[1] == Stats.playerName)
            {
                playerScores.Add(score);
            }
        }
    }

    void PrintPrevPlayerScores()
    {
        int lastScoreIndex = playerScores.Count - 1;
        int numScores = 0;
        string scoreString = "";

        while(lastScoreIndex >= 0 && numScores <= 3)
        {
            ++numScores;

            scoreString += "\n" + numScores.ToString() + ". " + 
                playerScores[lastScoreIndex].Split(',')[0];

            --lastScoreIndex;
        }

        scoreText.text = "Previous Scores for " + Stats.playerName + "\n" + scoreString;
    }

    public void StartGame()
    {
        if (Stats.playerName != "")
        {
            Stats.timeOffset = Time.time;
            Stats.CurrentScore = 0;
            Stats.LivesLeft = 3;
            SceneManager.LoadScene("Main");
        }
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}

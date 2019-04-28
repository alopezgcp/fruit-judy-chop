using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections.Generic;

public class PlayerScoreMgr : MonoBehaviour
{
    public InputField NameField;
    public Text scoreText;
    public Text topScoreText;

    private List<string> playerScores;
    private List<string> allScores;

    private void Start()
    {
        FileManager fm = new FileManager();
        allScores = fm.GetScores();
        playerScores = new List<string>();

        PrintTopScore();
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

    void PrintTopScore()
    {
        string entryA, entryB;
        int scoreA, scoreB;

        //insertion sort
        for (int i = 0; i < allScores.Count - 1; ++i)
        {
            for (int j = i; j >= 0; --j)
            {
                entryA = allScores[j];
                scoreA = int.Parse(entryA.Split(',')[0]);

                entryB = allScores[j + 1];
                scoreB = int.Parse(entryB.Split(',')[0]);

                if (scoreA < scoreB)
                {
                    allScores[j] = entryB;
                    allScores[j + 1] = entryA;
                }
            }
        }

        string name = allScores[0].Split(',')[1];
        string score = allScores[0].Split(',')[0];
        topScoreText.text = "Top Score\n" + name + " - " + score;
    }

    public void StartGame()
    {
        if (Stats.playerName != "")
        {
            SceneManager.LoadScene("Main");
        }
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}

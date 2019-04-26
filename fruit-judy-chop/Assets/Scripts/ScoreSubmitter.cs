using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ScoreSubmitter : MonoBehaviour
{
    private void Start()
    {
        SubmitScore();
    }

    public void SubmitScore()
    {
        int score = Stats.CurrentScore;

        string newEntry = score.ToString() + "," + Stats.playerName; //e.g. "1350,myName"
        FileManager fm = new FileManager();
        fm.WriteScoreToFile(newEntry);
    }
}

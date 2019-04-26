using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EndManager : MonoBehaviour
{
    public Text statsText;

    private void Start()
    {
        DisplayStats();
    }

    public void DisplayStats()
    {
        statsText.text = Stats.playerName + "\n" + Stats.CurrentScore + "\n" + Stats.finalGameTime;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("HomeMenu");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
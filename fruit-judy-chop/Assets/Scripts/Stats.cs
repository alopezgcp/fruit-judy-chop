using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour {

    public static string playerName = "";
	public static int CurrentScore = 0;
    public static int PointsPerSlice = 20;

    public static float gameTime = 200f;
    public static float timeRemaining = 200f;

    public static float fruitSpeed = 1f;
    public static float fruitSpawnRate = 1f;
    public static float fruitScale = 1f;
    public static float bladeScale = 1f;

    private int min = 0;
    private int sec = 0;
    private int ms = 0;

    public Text scoreText;
    public Text timerText;

	void Start ()
    {
        CurrentScore = 0;
		scoreText.text = "Score: " + CurrentScore.ToString();
        timeRemaining = gameTime;
	}
    
    private void Update()
    {
        // update score
        scoreText.text = "Score: " + CurrentScore.ToString();
        // update game clock
        timeRemaining -= Time.deltaTime;
        min = (int)timeRemaining / 60;
        sec = (int)timeRemaining % 60;
        ms = (int)(timeRemaining * 100) % 100;
        timerText.text = "Time: " + min.ToString("00") + ":" + sec.ToString("00") + ":" + ms.ToString("00");
        if (timeRemaining <= 0f) SceneManager.LoadScene("HighScoreMenu");
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {

    public static string playerName = "";
	public static int CurrentScore = 0;
    public static int LivesLeft = 3;
    public static float timeOffset = 0f;
    public static string finalGameTime = "";

    public static float fruitSpeed = 1f;
    public static float fruitSpawnRate = 1f;
    public static float fruitScale = 1f;
    public static float bladeScale = 1f;

    private int min = 0;
    private int sec = 0;
    private int ms = 0;

    public Text scoreText;
    public Text timerText;
    public Text livesText;

	void Start ()
    { 
		scoreText.text = CurrentScore.ToString();
        livesText.text = "Lives: " + LivesLeft.ToString();
	}

    private void Update()
    {
        // update game clock
        min = (int)(Time.time - timeOffset) / 60;
        sec = (int)(Time.time -timeOffset) % 60;
        ms = (int)((Time.time - timeOffset) * 100) % 100;
        timerText.text = min.ToString("00") + ":" + sec.ToString("00") + ":" + ms.ToString("00");
        finalGameTime = timerText.text;
    }
}

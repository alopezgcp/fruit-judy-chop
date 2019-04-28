using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setup : MonoBehaviour
{
    public Slider fruitSizeSlider;
    public Slider spawnSlider;
    public Slider speedSlider;
    public Slider bladeSizeSlider;

    public Toggle slideLock;
    public Dropdown gameTime;

    public GameObject fruit;
    public Text gameTimeWarning;

    private void Update()
    {
        fruit.transform.localScale = new Vector3(fruitSizeSlider.value, fruitSizeSlider.value, 1f);
    }

    public void NextScene()
    {
        Stats.fruitScale = fruitSizeSlider.value;
        Stats.fruitSpawnRate = spawnSlider.value;
        Stats.fruitSpeed = speedSlider.value;
        Stats.bladeScale = bladeSizeSlider.value;

        if (gameTime.value != 0)
        {
            SceneManager.LoadScene("PlayerScoreMenu");
        }
        else
            gameTimeWarning.text = "Please select a game time.";
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void ToggleSliders()
    {
        // fruit size
        if (fruitSizeSlider.interactable) fruitSizeSlider.interactable = false;
        else fruitSizeSlider.interactable = true;
        // spawn rate
        if (spawnSlider.interactable) spawnSlider.interactable = false;
        else spawnSlider.interactable = true;
        // fruit speed
        if (speedSlider.interactable) speedSlider.interactable = false;
        else speedSlider.interactable = true;
        // blade size
        if (bladeSizeSlider.interactable) bladeSizeSlider.interactable = false;
        else bladeSizeSlider.interactable = true;
    }

    public void SetGameTime()
    {
        if (gameTime.value == 1) Stats.gameTime = 30f;
        else if (gameTime.value == 2) Stats.gameTime= 60f;
        else if (gameTime.value == 3) Stats.gameTime = 120f;
    }
}

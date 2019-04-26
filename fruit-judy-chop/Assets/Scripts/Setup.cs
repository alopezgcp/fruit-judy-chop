using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setup : MonoBehaviour
{
    public Slider speedSlider;
    public Slider spawnSlider;
    public Slider fruitSizeSlider;
    public Slider bladeSizeSlider;

    public GameObject frog;
    public GameObject car;

    private void Update()
    {
        frog.transform.localScale = new Vector3(frogSizeSlider.value, frogSizeSlider.value, 1f);
        car.transform.localScale = new Vector3(carSizeSlider.value, carSizeSlider.value, 1f);
    }

    public void NextScene()
    {
        Stats.carSpeed = speedSlider.value;
        Stats.carSpawnRate = spawnSlider.value;
        Stats.carScale = carSizeSlider.value;
        Stats.frogScale = frogSizeSlider.value;

        SceneManager.LoadScene("PlayerScoreMenu");
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}

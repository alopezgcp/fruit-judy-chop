using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    
	void OnTriggerEnter2D ()
	{
		Stats.CurrentScore += 100;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour {

	public Rigidbody2D rb;

    private void Start()
    {
        transform.localScale = new Vector3(Stats.frogScale, Stats.frogScale, 1f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            rb.MovePosition(rb.position + Vector2.right);
            transform.rotation = Quaternion.Euler(0, 0, 270);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            rb.MovePosition(rb.position + Vector2.left);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            rb.MovePosition(rb.position + Vector2.up);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            rb.MovePosition(rb.position + Vector2.down);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Car")
		{
            --Stats.LivesLeft;
            if(Stats.LivesLeft > 0)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            else SceneManager.LoadScene("HighScoreMenu");
		}
	}
}

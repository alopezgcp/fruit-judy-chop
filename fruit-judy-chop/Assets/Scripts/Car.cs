using UnityEngine;

public class Car : MonoBehaviour {

	public Rigidbody2D rb;
	float speed = 1f;

	void Start ()
	{
        speed = Stats.carSpeed;
        transform.localScale = new Vector3(Stats.carScale, Stats.carScale, 1f);
	}

	void FixedUpdate () {
		Vector2 forward = new Vector2(transform.right.x, transform.right.y);
		rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

	public GameObject fruitSlicedPrefab;
	public float startForce = 15f;

	Rigidbody2D rb;

	void Start ()
	{
        transform.localScale = new Vector3(Stats.fruitScale, Stats.fruitScale, Stats.fruitScale);
		rb = GetComponent<Rigidbody2D>();
        startForce *= Stats.fruitSpeed;
		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Blade")
		{
			Vector3 direction = (col.transform.position - transform.position).normalized;

			Quaternion rotation = Quaternion.LookRotation(direction);

			GameObject slicedFruit = Instantiate(fruitSlicedPrefab, transform.position, rotation);
            slicedFruit.transform.localScale = new Vector3(Stats.fruitScale, Stats.fruitScale, Stats.fruitScale);
			Destroy(slicedFruit, 3f);
            Stats.CurrentScore += Stats.PointsPerSlice;
            Debug.Log(Stats.CurrentScore);
            Destroy(gameObject);
		}
	}

}

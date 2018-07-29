using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuffinController : MonoBehaviour {


    public float delayDestroy=3f;

    private Vector3 direction;
    private float speed = 10f;

	void Start () {

        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        Destroy(this.gameObject, delayDestroy);
	}

    private void FixedUpdate()
    {
        transform.Translate(direction.normalized * speed);
    }


}

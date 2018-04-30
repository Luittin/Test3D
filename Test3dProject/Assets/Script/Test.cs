using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public float speed;

    public GameObject capsulLight;

    private float x;
    private float y;
    private float z;

	// Use this for initialization
	void Start () {
	}

    void Update()
    {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;
        Instantiate(capsulLight, transform.position, Quaternion.identity);
        if(Input.GetKey(KeyCode.S))
        {   y -= speed;
            gameObject.transform.position = new Vector3(x, y, z);            
        }
        if (Input.GetKey(KeyCode.W))
        {   y += speed;
            gameObject.transform.position = new Vector3(x, y, z);
        }
        if (Input.GetKey(KeyCode.A))
        {   x -= speed;
            gameObject.transform.position = new Vector3(x, y, z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            x += speed;
            gameObject.transform.position = new Vector3(x, y, z);
        }
    }
}

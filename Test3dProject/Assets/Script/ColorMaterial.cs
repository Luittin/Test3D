using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMaterial : MonoBehaviour {

    public Color colorOne;
    public Color colorTwo;

    private Renderer rendererr;

	// Use this for initialization
	void Start () {
        rendererr = GetComponent<Renderer>();
        rendererr.material.color = colorTwo;
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnMouseDown()
    {
        rendererr.material.color = colorTwo;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            rendererr.material.color = colorOne;
            Destroy(collision.gameObject);
        }
    }
}

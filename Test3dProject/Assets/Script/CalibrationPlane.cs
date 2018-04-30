using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationPlane : MonoBehaviour {

    public GameObject cube;
    public GameObject sphere;
    public GameObject directionLight;

    public GameObject prefabPhoto;
    public GameObject prefPhotos;

    private bool FirstClick = false;
    private bool SecondClick = false;
    private bool ThirdClick = false;
    private bool FourClick = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    private void OnMouseDown()
    {
        if(!FirstClick && !SecondClick && !ThirdClick)
        {
            FirstClick = true;
            Instantiate(prefabPhoto, new Vector3(-25.0f, -15.0f, -10.0f), Quaternion.identity);
            transform.position = new Vector3(-Variabless.x_scale, -Variabless.y_scale, -6.9f);
        }
        else if(FirstClick && !SecondClick && !ThirdClick)
        {
            SecondClick = true;
            Instantiate(prefabPhoto, new Vector3(-25.0f, -15.0f, -10.0f), Quaternion.identity);
            transform.position = new Vector3(Variabless.x_scale, -Variabless.y_scale, -6.9f);
        }
        else if (FirstClick && SecondClick && !ThirdClick)
        {
            ThirdClick = true;
            Instantiate(prefabPhoto, new Vector3(-25.0f, -15.0f, -10.0f), Quaternion.identity);
            transform.position = new Vector3(Variabless.x_scale, Variabless.y_scale, -6.9f);
        }
        else if (FirstClick && SecondClick && ThirdClick)
        {
            Instantiate(prefabPhoto, new Vector3(-25.0f, -15.0f, -10.0f), Quaternion.identity);
            cube.transform.position = new Vector3(1.31f, 0.16f, -8.0f);
            sphere.transform.position = new Vector3(-1.87f,0.14f,-8.0f);
            directionLight.transform.position = new Vector3(0.0f,0.0f,-11.4f);
            Instantiate(prefPhotos, new Vector3(-25.0f, -16.0f, -10.0f), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}

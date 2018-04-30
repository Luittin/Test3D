using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCalibration : MonoBehaviour {

    public GameObject objectForCalibration;
    public GameObject button;

    public GameObject scale;

    private void Start()
    {

    }

    public void onClickButton()
    {
        Variabless.x_scale = scale.transform.position.x;
        Variabless.y_scale = scale.transform.position.y;

        objectForCalibration.transform.position = new Vector3(-Variabless.x_scale, Variabless.y_scale,-6.9f);
        Destroy(button);
    }
}

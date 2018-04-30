using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VideoTest : MonoBehaviour {
    private WebCamTexture WebCamTexture;

    private GameObject lightPoint;

    private int x_Left;
    private int x_Right;
    private int y_Up;
    private int y_Down;
    // Use this for initialization
    void Start()
    {
        lightPoint = GameObject.Find("Directional light");

        x_Left = (int) (Variabless.First_x + Variabless.Second_x)/2;
        x_Right = (int)(Variabless.Third_x + Variabless.Four_x) / 2;
        y_Up = (int)(Variabless.First_y + Variabless.Four_y) / 2;
        y_Down = (int)(Variabless.Second_y + Variabless.Third_y) / 2;

        print(x_Left + "   " + x_Right + "     " + y_Up + "      " + y_Down);

        Variabless.x_step = (Variabless.x_scale * 2) / ( x_Left - x_Right);
        Variabless.y_step = (Variabless.y_scale * 2) / ( y_Down - y_Up);

        WebCamTexture = new WebCamTexture();
        WebCamTexture.Play();
    }

    void Update()
    {
        Color32[] pix = WebCamTexture.GetPixels32();
        int with = WebCamTexture.width;
        int hight = WebCamTexture.height;

        int index = MaxRedColor.MaxRedColors(pix);

        if (index > 0)
        {
            int lines = (int)(index + 1) / 640;
            int stakes = index - (lines * 640);

            float x_position = -((-Variabless.x_scale) + (stakes - x_Right) * Variabless.x_step);
            float y_position = (-Variabless.y_scale) + (lines - y_Down) * Variabless.y_step;

            if(x_position > 4.5f)
            {
                x_position = 4.5f;
            }
            else if(x_position < -4.5f)
            {
                x_position = -4.5f;
            }

            if(y_position > 1.7f)
            {
                y_position = 1.7f;
            }
            else if(y_position < -1.7f)
            {
                y_position = -1.7f;
            }

            lightPoint.transform.position = new Vector3(x_position, y_position, -11.14f);
        }
    }
}

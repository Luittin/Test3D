using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxRedColor : MonoBehaviour {

	public static int MaxRedColors(Color32[] pix)
    {
        Color32 col = new Color32(0, 255, 255, 255);
        int index = -1;

        for(int i = 0; i < pix.Length; i++)
        {
            if(pix[i].r > col.r)
            {
                col = pix[i];
                index = i;
            }
            else if(pix[i].r == col.r)
            {
                if(pix[i].g < col.g || pix[i].b < col.b)
                {
                    col = pix[i];
                    index = i;
                }
            }
        }


        return index;
    }
}

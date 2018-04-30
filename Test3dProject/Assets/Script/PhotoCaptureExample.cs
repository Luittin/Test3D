using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.XR.WSA.WebCam;

public class PhotoCaptureExample : MonoBehaviour {

    PhotoCapture photoCaptureObject = null;
    Texture2D targetTexture = null;
    List<byte> buffer = new List<byte>();

    // Use this for initialization
    void Start()
    {
        Resolution cameraResolution = PhotoCapture.SupportedResolutions.OrderByDescending((res) => res.width * res.height).First();
        targetTexture = new Texture2D(cameraResolution.width, cameraResolution.height);

        // Create a PhotoCapture object
        PhotoCapture.CreateAsync(false, delegate (PhotoCapture captureObject) {
            photoCaptureObject = captureObject;
            CameraParameters cameraParameters = new CameraParameters();
            cameraParameters.hologramOpacity = 0.0f;
            cameraParameters.cameraResolutionWidth = cameraResolution.width;
            cameraParameters.cameraResolutionHeight = cameraResolution.height;
            cameraParameters.pixelFormat = CapturePixelFormat.BGRA32;

            // Activate the camera
            photoCaptureObject.StartPhotoModeAsync(cameraParameters, delegate (PhotoCapture.PhotoCaptureResult result) {
                // Take a picture
                photoCaptureObject.TakePhotoAsync(OnCapturedPhotoToMemory);
            });
        });
        Destroy(this.gameObject);
    }

    void OnCapturedPhotoToMemory(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame)
    {
        // Copy the raw image data into the target texture
        photoCaptureFrame.UploadImageDataToTexture(targetTexture);
        photoCaptureFrame.CopyRawImageDataIntoBuffer(buffer);

        Color32[] pix = targetTexture.GetPixels32();
        int with = targetTexture.width;
        int hight = targetTexture.height;

        int index = MaxRedColor.MaxRedColors(pix);

        int lines = (int)(index + 1) / 640;
        int stakes = index - (lines * 640);

        if (Variabless.First_x == -1)
        {
            Variabless.First_x = stakes;
            Variabless.First_y = lines;
            print(stakes);
        }
        else if(Variabless.Second_x == -1)
        {
            Variabless.Second_x = stakes;
            Variabless.Second_y = lines;
            print(stakes);
        }
        else if (Variabless.Third_x == -1)
        {
            Variabless.Third_x = stakes;
            Variabless.Third_y = lines;
            print(stakes);
        }
        else if (Variabless.Four_x == -1)
        {
            Variabless.Four_x = stakes;
            Variabless.Four_y = lines;
            print(stakes);
        }

        // Deactivate the camera
        photoCaptureObject.StopPhotoModeAsync(OnStoppedPhotoMode);
    }

    void OnStoppedPhotoMode(PhotoCapture.PhotoCaptureResult result)
    {
        // Shutdown the photo capture resource
        photoCaptureObject.Dispose();
        photoCaptureObject = null;
    }
}

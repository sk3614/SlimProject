using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float targetwidthAspect = 16.0f;

        float targetHeightAspect = 9.0f;

        Camera mainCamera = Camera.main;

        mainCamera.aspect = targetwidthAspect / targetHeightAspect;

        float widthRatio = (float)Screen.width / targetwidthAspect;
        float heightRatio = (float)Screen.height / targetHeightAspect;

        float heightadd = ((widthRatio / (heightRatio / 100)) - 100) / 200;
        float widthtadd = ((heightRatio / (widthRatio / 100)) - 100) / 200;
        if (heightRatio > widthRatio)
            widthtadd = 0.0f;
        else
            heightadd = 0.0f;

        mainCamera.rect = new Rect(
            mainCamera.rect.x + Mathf.Abs(widthtadd),
            mainCamera.rect.y + Mathf.Abs(heightadd),
            mainCamera.rect.width + (widthtadd * 2),
            mainCamera.rect.height + (heightadd * 2));
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

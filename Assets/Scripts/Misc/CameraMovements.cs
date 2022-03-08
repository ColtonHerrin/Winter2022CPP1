using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{

    public float minXClamp = -35.21f;
    public float maxXClamp = 8.48f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.instance.playerInstance)
        {
            Vector3 cameraTransform;

            cameraTransform = transform.position;

            cameraTransform.x = GameManager.instance.playerInstance.transform.position.x;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, minXClamp, maxXClamp);

            transform.position = cameraTransform;
        }
    }
}

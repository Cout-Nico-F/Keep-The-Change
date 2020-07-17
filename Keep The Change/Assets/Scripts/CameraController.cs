using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player; // GO for the camera to follow
    [SerializeField] Vector3 offset; // offset for the Camera Following the GO
    [SerializeField] bool followPlayer = false; // checkbox in the Inspector

    [SerializeField] Vector3 moveScreenRight = new Vector3 (28,0,0);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer == true)
        { 
            if (player != null) transform.position = player.transform.position + offset;
        }
    }

    public void MoveCameraRight()
    {
        transform.position = transform.position + moveScreenRight;
    }

}

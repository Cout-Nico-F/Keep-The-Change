using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player = null; // GO for the camera to follow
    [SerializeField] private Vector3 offset = Vector3.zero; // offset for the Camera Following the GO
    [SerializeField] private bool followPlayer = false; // checkbox in the Inspector
    [SerializeField] private float setVolume = 0f;
    [SerializeField] private Vector3 moveScreenRight = new Vector3 (28,0,0);

    void Start()
    {
        GetComponent<Camera>().transparencySortMode = TransparencySortMode.CustomAxis;
        GetComponent<Camera>().transparencySortAxis = new Vector3(0, 1, 0);
        setVolume = AudioListener.volume;
        AudioListener.volume = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (followPlayer == true)
        { 
            if (player != null) transform.position = player.transform.position + offset;
        }

        if (AudioListener.volume < setVolume)
        {
            AudioListener.volume += 0.0085f;
        }
    }
/*
    float elapsedTime = 0;
    float currentVolume = AudioListener.volume;
 
        while(elapsedTime<delay) {
            elapsedTime += Time.deltaTime;
            AudioListener.volume = Mathf.Lerp(currentVolume, 0, elapsedTime / delay);
            yield return null;
*/


    public void MoveCameraRight()
    {
        transform.position = transform.position + moveScreenRight;
    }

}

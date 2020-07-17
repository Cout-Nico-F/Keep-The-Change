using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float startSpeed = 5f;
    float horizontalInput;
    float verticalInput;

        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }
    void PlayerMovement()
    {
        
        transform.Translate(Vector3.right * Time.deltaTime * startSpeed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * startSpeed * verticalInput);
    }
}

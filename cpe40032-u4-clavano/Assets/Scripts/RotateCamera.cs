using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 35; // Controls camera rotation's speed..



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Gets Horizontal Input to control rotation..

        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime); // Rotates by the y-axis...
    }
}

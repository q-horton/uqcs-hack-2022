using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCam : MonoBehaviour
{
    public Camera cam;
    public int orbitRange = 100;
    public int orbitPeriod = 60;
    public int viewAngle = 20;

    float theta;
    float x;
    float y;
    float z;
    float phi;

    // Start is called before the first frame update
    void Start()
    {
        theta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        theta += Time.deltaTime * 2 * Mathf.PI / orbitPeriod;
        x = orbitRange * Mathf.Cos(theta);
        y = orbitRange * Mathf.Tan(viewAngle * Mathf.PI / 180);
        z = orbitRange * Mathf.Sin(theta);
        phi = 270 - 180 * theta / Mathf.PI;

        cam.transform.position = new Vector3(x, y, z);
        cam.transform.rotation = Quaternion.Euler(viewAngle, phi, 0);
        
    }
}

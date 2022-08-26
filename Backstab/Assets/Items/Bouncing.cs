using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    public GameObject pickupBody;
    public GameObject pickupBase;

    float theta;
    float speed = 1f;
    float x;
    float y;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        theta = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        theta += speed * Time.deltaTime;
        x = pickupBase.transform.position.x;
        y = pickupBase.transform.position.y + 0.5f * Mathf.Sin(theta) + 1.5f;
        z = pickupBase.transform.position.z;
        pickupBody.transform.position = new Vector3(x, y, z);
    }
}

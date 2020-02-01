using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exposeAxis : MonoBehaviour
{

    public float inputX;

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        Debug.Log(inputX);
    }
}

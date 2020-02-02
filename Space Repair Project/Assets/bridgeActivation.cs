using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeActivation : MonoBehaviour
{
    [SerializeField] buttonOnOff activatingButton;
    Transform openBridge;


    void Start()
    {
        openBridge = transform.GetChild(0);
    }

    void Update()
    {
        if(activatingButton.activated)
        {
            openBridge.gameObject.SetActive(false);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCondition : MonoBehaviour
{

    [SerializeField] collection levi;
    [SerializeField] collection spodnji;
    [SerializeField] collection desni;
    [SerializeField] collection sredina;


    public bool winGame = false;


    // Update is called once per frame
    void Update()
    {
        if(levi.allActivated && desni.allActivated && spodnji.allActivated && sredina.allActivated)
        {
            winGame = true;
        }
    }
}

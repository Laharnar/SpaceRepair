using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCondition : MonoBehaviour
{

    [SerializeField] collection levi = default;
    [SerializeField] collection spodnji = default;
    [SerializeField] collection desni = default;
    [SerializeField] Reactor reactor = default;

    public bool winGame = false;
    public float percentageDone;


    // Update is called once per frame
    void Update()
    {
        percentageDone = 0;
        if (levi.allActivated)
            percentageDone = 0.33f;
        if (desni.allActivated)
            percentageDone += 0.33f;
        if (spodnji.allActivated)
            percentageDone += 0.34f;
        if (desni.allActivated)
        {

            PlayAnimation[] ai = GameObject.FindObjectsOfType<PlayAnimation>();
            for (int i = 0; i < ai.Length; i++)
            {
                ai[i].SetAngry();
            }
        }
        if (levi.allActivated && desni.allActivated && spodnji.allActivated)
        {
            //reactor.canBeFilled = true;
            winGame = true;
        }
        /*if (reactor.isFilled)
        {
            winGame = true;
        }*/
    }
}

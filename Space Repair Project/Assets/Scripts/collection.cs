using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collection : MonoBehaviour
{
    [SerializeField] List<buttonOnOff> buttonsThatNeedToBeActive;
    private int buttonNum;

    [SerializeField] public bool allActivated;
    [SerializeField] GameObject aktivirajMene;

    // Start is called before the first frame update
    void Start()
    {
        buttonNum = buttonsThatNeedToBeActive.Count;
        //print(buttonNum);
    }

    // Update is called once per frame
    void Update()
    {
        bool ok = true;
        foreach(buttonOnOff button in buttonsThatNeedToBeActive) {
            if(!button.activated)
            {
                ok = false;
                aktivirajMene.SetActive(false);
            }
            if(button.activated)
            {
                aktivirajMene.SetActive(true);
            }
        }
        if (ok)
        {
            allActivated = true;
        }
    }
}

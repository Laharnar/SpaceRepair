using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collection : MonoBehaviour
{
    [SerializeField] List<buttonOnOff> buttonsThatNeedToBeActive;
    private int buttonNum;

    [SerializeField] bool allActivated;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonNum = buttonsThatNeedToBeActive.Count;
        print(buttonNum);
    }

    // Update is called once per frame
    void Update()
    {
        allActivated = true;
        foreach(buttonOnOff button in buttonsThatNeedToBeActive) {
            if(!button.activated)
            {
                allActivated = false;
            }
        }

    }
}

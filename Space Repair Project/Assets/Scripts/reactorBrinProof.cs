using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reactorBrinProof : MonoBehaviour
{
    [SerializeField] GameObject reactorActive = default;
    [SerializeField] GameObject reactorSelected = default;
    [SerializeField] GameObject reactorBroken = default;
    

    [SerializeField] private int stage = 1;
    [SerializeField] winCondition winCondition = default;
    public bool reactorRepaired = false;
    private bool won = false;
    private string txt = "Press 'Space' to repair the Power Reactor";

    [SerializeField] Text textToDisplay;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(winCondition.winGame)
        {
            stage = 2;
            reactorBroken.SetActive(false);
            reactorActive.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (stage == 1)
        {
            TextIn();
            reactorSelected.SetActive(true);
            txt = "Press 'Space' to repair the Power Reactor.";
        }
        if (stage == 2)
        {
            TextIn();
            txt = "Press 'Space' to repair the finish the repair.";
            Debug.Log("Win game");
            reactorRepaired = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D other) {
        reactorSelected.SetActive(false);
        TextOut();
    }   

    private void OnCollisionStay2D(Collision2D other) {
    
        if(Input.GetButtonDown("Jump"))
            {
                Debug.Log("Space Pressed");
                if (stage == 1)
                {
                    TextIn();
                    txt = "The reactor needs energy."; 
                }
                if (stage == 2)
                {
                    won = true;
                }

            }
    }

    private void TextIn()
    {
        textToDisplay.CrossFadeAlpha(1.0f, 0.5f, false);
        textToDisplay.text = txt;
    }
    private void TextOut()
    {
        textToDisplay.CrossFadeAlpha(0.0f, 0.5f, false);
    }
}

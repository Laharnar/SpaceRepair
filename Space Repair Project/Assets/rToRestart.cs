using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rToRestart : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && (Player.Lost || Player.PlayerSc.won || Time.time < 30))// hard coded reset in middle of intro
        {
            SceneManager.LoadScene("Level");
        }
    }
}

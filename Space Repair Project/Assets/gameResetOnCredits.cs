using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameResetOnCredits : MonoBehaviour
{

    [SerializeField] Text fadeFirst;
    [SerializeField] Text fadeSecond;
    [SerializeField] Text fadeLast;

    void Start()
    {
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) )
        {
            SceneManager.LoadScene("Level");
        }
    }
}

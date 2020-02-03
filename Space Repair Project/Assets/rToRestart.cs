using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rToRestart : MonoBehaviour
{
    public BoolData restarted;
    // Start is called before the first frame update
    private void Awake()
    {
        if(restarted!= null)restarted.value = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if (restarted!= null)restarted.value = true;
            SceneManager.LoadScene("Level");
        }
    }
}

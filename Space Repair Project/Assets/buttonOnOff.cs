using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonOnOff : MonoBehaviour
{
    Transform child;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("dekat zgor button");
            child = transform.GetChild(0);
            child.gameObject.SetActive(false);
            GetComponent<Collider2D>().enabled = false;
        }
    }
}

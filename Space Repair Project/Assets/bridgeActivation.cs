using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeActivation : MonoBehaviour
{
    [SerializeField] buttonOnOff activatingButton;
    Transform openBridge;
    [SerializeField] PlaySound sound;

    void Start()
    {
        if(!sound) sound = GetComponent<PlaySound>();
        openBridge = transform.GetChild(0);
    }

    void Update()
    {
        if(activatingButton.activated && openBridge.gameObject.activeSelf)
        {
            openBridge.gameObject.SetActive(false);
            if (sound) sound.PlaySoundFx();
        }
    }
}

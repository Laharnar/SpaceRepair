using UnityEngine;

public class PlayerLight:MonoBehaviour {
    public GameObject lightBig, lightSmall;
    public BoolData lightIsOn;

    private void Awake()
    {
        lightIsOn.value = false;
    }


    private void Update()
    {
        lightBig.gameObject.SetActive(lightIsOn.value);
        lightSmall.gameObject.SetActive(!lightIsOn.value);

    }

    public void LoseLight()
    {
        lightIsOn.value = false;
    }
}

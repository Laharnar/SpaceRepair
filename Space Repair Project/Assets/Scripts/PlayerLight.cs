using System.Collections;
using UnityEngine;

public class PlayerLight:MonoBehaviour {
    public GameObject lightBig, lightSmall;
    public BoolData lightIsOn;
    public FloatData timer;

    private void Awake()
    {
        lightIsOn.value = false;
    }


    private void Update()
    {
        lightBig.gameObject.SetActive(lightIsOn.value);
        lightSmall.gameObject.SetActive(!lightIsOn.value);

    }

    public IEnumerator SlowCountdownTimer(float steps)
    {
        timer.value = 1;
        for (int i = 0; i < steps; i++)
        {
            yield return new WaitForSeconds(1);
            timer.value -= 1f / steps;
        }
        timer.value = 0;
    }

    public void LoseLight()
    {
        lightIsOn.value = false;
    }
}

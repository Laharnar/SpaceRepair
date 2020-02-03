using UnityEngine;
using UnityEngine.UI;

public class Reactor: InteractibleItem {

    public Transform[] turretStates;
    public int state = 0;

    public bool activated;
    float lastActivatedTime;
    // win conditions
    public bool repaired = false;
    public bool canBeFilled = false;
    public bool isFilled;
    public Image errorImage;
    public winCondition buttonsProgress;

    private void Awake()
    {
        onActivateLocally += ReactorActivated;
        SetReactorVisuals(0);
    }
    private void Update()
    {
        errorImage.fillAmount = 1-buttonsProgress.percentageDone;
    }

    void ReactorActivated(object src)
    {
        if (lastActivatedTime+1 >= Time.time)
        {
            return;
        }
        lastActivatedTime = Time.time;
        activated = true;

        if (!repaired && state == 0)
        {
            state++;
            repaired = true;
        }
        if (canBeFilled && state == 1)
        {
            state++;
            isFilled = true;
        }

        if (state == 3)
        {
            state = 2;
        }
        SetReactorVisuals(state);
    }

    public void SetReactorVisuals(int id)
    {
        Debug.Log("setting visuals to "+id);
        for (int i = 0; i < turretStates.Length; i++)
        {
            turretStates[i].gameObject.SetActive(false);
        }

        turretStates[id].gameObject.SetActive(true);
    }
}

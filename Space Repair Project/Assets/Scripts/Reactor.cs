using UnityEngine;

public class Reactor: InteractibleItem {

    public Transform[] turretStates;
    public int state = 0;

    public bool activated;
    public bool repaired = false;
    float lastActivatedTime;
    public BoolData reactorActivateCondition;

    private void Awake()
    {
        onActivateLocally += ReactorActivated;
        SetReactorVisuals(0);
    }

    void ReactorActivated(object src)
    {
        if (!reactorActivateCondition.value)
        {
            Debug.Log("Can't activate reactor.");
            return;
        }
        if (lastActivatedTime+1 >= Time.time)
        {
            return;
        }
        lastActivatedTime = Time.time;
        activated = true;
        state++;

        if (state == 3)
        {
            state = 2;
        }
        SetReactorVisuals(state);
        if (state == 2)
        {
            repaired = true;
        }
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

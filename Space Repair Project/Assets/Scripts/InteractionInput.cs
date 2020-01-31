using System.Collections.Generic;
using UnityEngine;

public class InteractionInput:MonoBehaviour {
    [SerializeField] KeyCode interactionKey;

    public List<InteractibleItem> itemsInRange = new List<InteractibleItem>();

    public void OnItemEnterRange(InteractibleItem item)
    {
        itemsInRange.Add(item);
    }
    public void OnItemExitRange(InteractibleItem item)
    {
        itemsInRange.Remove(item);
    }

    private void Update()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            for (int i = 0; i < itemsInRange.Count; i++)
            {
                itemsInRange[0].behaviour.OnInteractionActivated();
            }
        }
    }
}

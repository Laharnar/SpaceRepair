using UnityEngine;

public abstract class Interaction:ScriptableObject {
    public string itemTag;
    public abstract void OnInteractionActivated();
}

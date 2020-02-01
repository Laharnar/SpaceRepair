using UnityEngine;

[CreateAssetMenu]
public class LightPickup : Interaction {

    public BoolData hasLight;
    public float timeOut = 4;

    public override void OnInteractionActivated(InteractionInput source)
    {
        hasLight.value = true;
        Player.PlayerSc.light.Invoke("LoseLight", timeOut);
    }
}
using System;
using UnityEngine;



[CreateAssetMenu]
public class Door : Interaction {

    public override void OnInteractionActivated(InteractionInput source)
    {
        Open();
    }

    private void Open()
    {
        throw new NotImplementedException();
    }
}

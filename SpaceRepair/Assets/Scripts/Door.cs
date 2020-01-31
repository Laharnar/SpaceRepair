using System;
using UnityEngine;

[CreateAssetMenu]
public class Door : Interaction {
    public override void OnInteractionActivated()
    {
        Open();
    }

    private void Open()
    {
        throw new NotImplementedException();
    }
}

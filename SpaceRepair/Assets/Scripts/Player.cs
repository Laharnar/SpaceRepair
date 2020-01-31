using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    internal static Player player;
    public InteractionInput input;

    // Start is called before the first frame update
    void Start()
    {
        player = this;
    }

}

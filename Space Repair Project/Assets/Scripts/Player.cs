using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static GameObject _player;
    static Player _Player;
    public static Player PlayerSc {
        get { return _Player; }
    }

    internal static GameObject playerGo {
        get {
            if (_player != null) return _player.gameObject;
            else
            {
                Debug.Log("Temp player created");
                _player = new GameObject("temp player");
            }
            return _player;
        }
        set {
            _player = value;
        }
    }
    public InteractionInput input;

    // Start is called before the first frame update
    void Awake()
    {
        _Player = this;
        playerGo = this.gameObject;
    }

}

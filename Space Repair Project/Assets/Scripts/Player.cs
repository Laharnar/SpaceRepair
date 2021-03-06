﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static GameObject _player;
    static Player _Player;

    [SerializeField] reactorBrinProof reactor;

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

    public static bool Lost { get => PlayerSc == null; }

    public InteractionInput input;
    public new PlayerLight light;
    public AlienInteractions life;
    public bool won;// for triggering videos and whatever

    // Start is called before the first frame update
    void Awake()
    {
        if(life==null)life = GetComponent<AlienInteractions>();
        _Player = this;
        playerGo = this.gameObject;
    }

    private void Update()
    {
        if (reactor.reactorRepaired)
        {
            won = true;
        }
    }

}

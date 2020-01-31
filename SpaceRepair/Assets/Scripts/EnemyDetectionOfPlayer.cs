using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyDetectionOfPlayer : MonoBehaviour
{
    [SerializeField] Player player;
    public bool detectingPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        // terribly slow code
        player = GameObject.FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            detectingPlayer = false;
        }
    }
}

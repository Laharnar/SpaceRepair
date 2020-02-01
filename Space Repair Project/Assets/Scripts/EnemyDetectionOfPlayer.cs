using Bolt;
using System.Collections;
using UnityEngine;

public class EnemyDetectionOfPlayer : MonoBehaviour
{
    public bool detectingPlayer = false;

    public Vector2 recommendedDirection; // direction to followPlayer
    

    private void OnDrawGizmos()
    {
        if (detectingPlayer)
        {

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 1);
        }
        else
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, 0.5f);
        }
    }

    private void Update()
    {
        if (detectingPlayer) {
            recommendedDirection = Player.playerGo.transform.position - transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.playerGo)
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player.playerGo)
        {
            detectingPlayer = false;
        }
    }
}

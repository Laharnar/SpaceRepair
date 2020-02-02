using Bolt;
using System;
using System.Collections;
using UnityEngine;



public class EnemyDetectionOfPlayer : MonoBehaviour
{
    public bool detectingPlayer = false;

    public Vector2 recommendedDirection; // direction to followPlayer
    public Vector2 lastKnownPosition;
    public EnemyFollow followAi;
    public float returnSpeed = 0.8f;
    public float maxRand = 10;

    PlaySound playSound;

    private void Start()
    {
        playSound = GetComponent<PlaySound>();
        playSound.PlaySoundFx();
    }

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

            // special ai, follows player
            FlowMachine mf = GetComponent<FlowMachine>();
            if (mf.enabled)
            {
                GetComponent<FlowMachine>().enabled = false;
                lastKnownPosition = transform.position;
                followAi.OnDetectEnemy(Player.playerGo.transform);
            }
        }
    }

    IEnumerator MoveTo(Vector2 pos)
    {
        GetComponent<Rigidbody2D>().velocity = ((Vector3)pos - transform.position).normalized * returnSpeed;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;

        float start = Time.time;
        while (Vector2.Distance(pos, transform.position) > 1f && Time.time < start+3)
        {
            yield return null;
        }
        GetComponent<FlowMachine>().enabled = true;
        if (Vector3.Distance(transform.position, pos) > 10)
        {
            lastKnownPosition = transform.position;
        }
    }

    public void Return()
    {
        Vector3 v = transform.position +((Vector3)lastKnownPosition - transform.position).normalized
            *UnityEngine.Random.Range(((Vector3)lastKnownPosition-transform.position).magnitude, maxRand);
        StartCoroutine(MoveTo(v));
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

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyDetectionOfPlayer : MonoBehaviour
{
    [SerializeField] Player player;
    public bool detectingPlayer = false;

    public Vector2 recommendedDirection; // direction to followPlayer

    // Start is called before the first frame update
    void Start()
    {
        // terribly slow code
        player = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (detectingPlayer) {
            recommendedDirection = player.transform.position - transform.position;
        }
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

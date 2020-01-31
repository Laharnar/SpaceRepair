using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class InteractibleItem:MonoBehaviour {
    // Put on doors, characters etc.
    public Interaction behaviour;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.player)
        {
            Player.player.input.OnItemEnterRange(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == Player.player)
        {
            Player.player.input.OnItemExitRange(this);
        }
    }
}

using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class InteractibleItem:MonoBehaviour {

    // Put on doors, characters etc.
    public Interaction behaviour;
    InteractionInput inputSource;
    public bool somethingCanInteract = false;
    public bool automaticallyInteractWhenInRange = false;
    public bool consumeOnInteraction = false;
    public bool useBehaviour = true;
    public Action<object> onActivateLocally;

    private void Start()
    {
        // custom, only player can interact.
        inputSource = Player.PlayerSc.input;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.gameObject == Player.playerGo)
        {
            if (automaticallyInteractWhenInRange)
            {
                behaviour.OnInteractionActivated(inputSource);
            }
            else
            {
                somethingCanInteract = true;
                inputSource.OnItemEnterRange(this);
            }
            if (consumeOnInteraction)
            {
                Destroy(gameObject);
            }
        }
    }

    internal void Activate(object src)
    {
        if (onActivateLocally!= null)
        {
            onActivateLocally(src);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.root.gameObject == Player.playerGo)
        {
            somethingCanInteract = false;
            inputSource.OnItemExitRange(this);
        }
    }

    private void OnDrawGizmos()
    {
        if (somethingCanInteract == true)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
        }
        else
        {
            Gizmos.color = Color.grey;
            Gizmos.DrawWireCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
        }
    }
}

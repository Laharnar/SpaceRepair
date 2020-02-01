using UnityEngine;

public class Bullet:MonoBehaviour {
    public FloatData bulletSpeed;

    private void Update()
    {
        transform.Translate(Vector3.up*Time.deltaTime*bulletSpeed.value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == Player.playerGo)
        {
            Debug.Log("Recieved dmg.");
            Destroy(gameObject);
        }
    }
}

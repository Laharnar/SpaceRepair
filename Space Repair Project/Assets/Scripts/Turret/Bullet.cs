using UnityEngine;

public class Bullet:MonoBehaviour {
    public FloatData bulletSpeed;
    public Vector2 direction = new Vector2();

    private void Update()
    {
        transform.Translate(new Vector3(direction.x, direction.y, 0)*Time.deltaTime*bulletSpeed.value);
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

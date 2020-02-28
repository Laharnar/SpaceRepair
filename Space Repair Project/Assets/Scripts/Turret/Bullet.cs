using UnityEngine;

public class Bullet:MonoBehaviour {
    public FloatData bulletSpeed;
    public Vector2 direction = new Vector2();
    public bool destroyEnemies = true;

    private void Start()
    {
    }

    private void Update()
    {
        transform.Translate(-Vector2.right*Time.deltaTime*bulletSpeed.value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject == Player.playerGo)
        {
            Debug.Log("Recieved dmg.");
            //Destroy(collision.gameObject);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            //Debug.Log("Uniči se na zidu");
        }
        // destroy enemies
        if (destroyEnemies)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("EnemySlime") || collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
    }
}

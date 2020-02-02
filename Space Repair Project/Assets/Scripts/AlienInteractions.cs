using UnityEngine;

public class AlienInteractions : MonoBehaviour {
    public int life = 4;
    internal bool isDead;

    internal void CaughtByAlien(EnemyFollow enemyFollow)
    {
        life--;
        if (life <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }
}

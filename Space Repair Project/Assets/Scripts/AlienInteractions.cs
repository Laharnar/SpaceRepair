using UnityEngine;

public class AlienInteractions : MonoBehaviour {
    public int life = 4;
    internal void CaughtByAlien(EnemyFollow enemyFollow)
    {
        life--;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}

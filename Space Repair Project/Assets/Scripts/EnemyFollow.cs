using UnityEngine;

public class EnemyFollow :MonoBehaviour{
    public float moveSpeed=1;
    public float closeDistance = 1;
    public float loseDistance = 4;
    public EnemyDetectionOfPlayer detection;
    public float slerpValue = 0.7f;
    public bool tracking = false;
    public Vector2 curDir;
    public Rigidbody2D rig;
    Transform other;

    private void Update()
    {
        if(tracking)
            TrackingEnemy(other);
    }

    public void TrackingEnemy(Transform other)
    {
        Debug.Log("tracking");
        Vector2 v = other.position - transform.position;
        //v = Vector3.Slerp(curDir, v, slerpValue);
        //curDir = v;

        rig.velocity = (v).normalized * moveSpeed;
        if (v.magnitude < closeDistance)
        {
            AlienInteractions ai = other.GetComponent<AlienInteractions>();
            if (ai) ai.CaughtByAlien(this);
            else Debug.Log("AlienInteractions script is missing on player.");
            tracking = false;
            detection.Return();
        }
        if (v.magnitude > loseDistance)
        {
            tracking = false;
            detection.Return();
        }
    }

    public void OnDetectEnemy(Transform other)
    {
        //.
        tracking = true;
        curDir = transform.up;
        this.other = other;
    }
}

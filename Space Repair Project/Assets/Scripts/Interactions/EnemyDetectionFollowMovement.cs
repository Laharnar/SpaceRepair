using Bolt;
using UnityEngine;

public class EnemyDetectionFollowMovement:MonoBehaviour {

    public Transform detection;
    public Vector3 whereUnitIsGoing;
    EnemyDetectionOfPlayer detectionSrc;

    private void Update()
    {
        VariableDeclarations vd = Variables.Object(gameObject);
        if (vd.IsDefined("moveDirection"))
        {
            Vector2 moveDir = (Vector2)vd.Get("moveDirection");
            whereUnitIsGoing = moveDir;
            detection.up = whereUnitIsGoing;
        }

        if (detectionSrc.detectingPlayer)
        {
            whereUnitIsGoing = detectionSrc.recommendedDirection;
        }
    }
}

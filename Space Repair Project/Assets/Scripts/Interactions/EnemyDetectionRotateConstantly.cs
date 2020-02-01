using UnityEngine;

public class EnemyDetectionRotateConstantly : MonoBehaviour {

    public Transform detection;
    EnemyDetectionOfPlayer detectionSrc;

    public Vector3 rotateConstantlyBy;
    public bool pingPong= false;
    public bool goingLeft = true;
    public float offsetAngle = 0;
    public float offsetMinus = 0;
    public float offsetPlus = 0;

    private void Update()
    {
        
        detection.Rotate(
            goingLeft ? rotateConstantlyBy : -rotateConstantlyBy);
        Debug.Log(detection.eulerAngles.z);
        if (detection.eulerAngles.z > 175+ offsetAngle+offsetPlus)
        {
            goingLeft = false;
        }
        else if(detection.eulerAngles.z < 5+ offsetAngle+offsetMinus)
        {
            goingLeft = true;
        }
    }
}

using UnityEngine;

public class PlayAnimation:MonoBehaviour {
    Animator animator;
    public string boolAnimation;
    public bool setValue;
    public bool canBeAngry = false;
    public bool angryOnStart = false;
    
    

    public void SetAngry()
    {
        if (canBeAngry)
        {
            animator.SetBool("Angry", true);
            gameObject.GetComponent<EnemyDetectionRotateConstantly>().enabled = true;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool(boolAnimation, setValue);
        if (angryOnStart)
        {
            SetAngry();
        }
    }
}

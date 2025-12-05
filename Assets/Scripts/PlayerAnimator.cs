using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PlayAttackAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
    }
    public void EatHeal()
    {
        if (animator != null)
        {
            animator.SetTrigger("Eat");
        }
    }
    public void Dance()
    {
        if (animator != null) 
        {
            animator.SetTrigger("Dance");
        }
    }
    public void Action()
    {
        if (animator != null)
        {
            animator.SetTrigger("Action");
        }
    }
}

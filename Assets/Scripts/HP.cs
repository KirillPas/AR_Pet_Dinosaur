using UnityEngine;
using System.Collections;
public class HP : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int maxhp = 100;
    private int currenthp;
    public bool f = false;
    private EnemyAttack _enemyattack;

    public int Maxhp
    {
        get {return maxhp;}
        set {maxhp = value;}
    }
    public int Currenthp
    {
        get { return currenthp; }
        set { currenthp = value; }
    }
    [SerializeField] private AudioClip _die;
    [SerializeField] private AudioSource Die;

    private bool canTakeDamage = true;
    public float damageCooldown = 3f;
    void Start()
    {
        currenthp = maxhp;
    }
    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            f = true;
            Currenthp -= damage;
            if (Currenthp <= 0)
            {
                Death();
            }
            StartCoroutine(DamageCooldownRoutine());
        }
    }
    public void Death()
    {
        if (Die != null)
            Die.PlayOneShot(_die);
        if (_animator != null)
            _animator.SetBool("Death", true);
        StartCoroutine(DestroyAfterAnimation());
    }
    private IEnumerator DamageCooldownRoutine()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }
    private IEnumerator DestroyAfterAnimation()
    {
        // ∆дем длину анимации смерти
        float animationLength = 0f;
        if (_animator != null)
        {
            AnimatorStateInfo state = _animator.GetCurrentAnimatorStateInfo(0);
            animationLength = state.length;
        }
        yield return new WaitForSeconds(Mathf.Max(animationLength, 5f));

        Destroy(gameObject);
        
    }
}

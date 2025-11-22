using UnityEngine;
using System.Collections;
public class HP : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _animatorAttack;
    [SerializeField] private int maxhp = 100;
    private int currenthp;
    private SpawnerEnemy coll;

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

    [SerializeField] private AudioClip _Damage;
    [SerializeField] private AudioSource Damage;
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
            currenthp -= damage;
            if (_animatorAttack != null)
            {
                _animatorAttack.SetBool("Attack", true);
                _animatorAttack.SetBool("Attack", false);
            }    
            if (currenthp <= 0)
                Death();
            StartCoroutine(DamageCooldownRoutine());
            if (Damage != null)
                Damage.PlayOneShot(_Damage);
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
        coll.EnemyDied();
    }
}

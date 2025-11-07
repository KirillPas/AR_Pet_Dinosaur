using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private int maxhp = 100;
    private int currenthp;

    [SerializeField] private AudioClip damage;
    [SerializeField] private AudioSource Damage;
    [SerializeField] private AudioClip die;
    [SerializeField] private AudioSource Die;
    void Start()
    {
        currenthp = maxhp;
    }
    public void TakeDamage(int _damage)
    {
        currenthp -= _damage;
        Damage.PlayOneShot(damage);

        if (currenthp <= 0)
            Death();
    }
    public void Death()
    {
        Die.PlayOneShot(die);
        //Заморзка сцены и кнопки с перезагрузкой
    }
}

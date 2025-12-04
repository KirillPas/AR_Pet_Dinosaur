using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Attack : MonoBehaviour
{
    [Header("Настройки атаки")]
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    public int attackDamage = 10;
    public LayerMask enemyLayer;
    public PlayerAnimator playerAnimator;

    private bool canAttack = true;
    private Camera arCamera;

    public void UpDamage(int value)
    {
        playerAnimator.EatHeal();
        attackDamage += value;
    }
    public void UpCooldown(float value)
    {
        playerAnimator.EatHeal();
        attackCooldown -= value;
    }
    void Start()
    {
        arCamera = Camera.main;
    }

    void Update()
    {
        if (!canAttack)
            return;
        if (EnemyAttack.isbool)
            return;

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("[Attack] Mouse click detected", this);
            TryAttack(Input.mousePosition);
        }
#endif
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            Debug.Log($"[Attack] Touch detected. phase = {t.phase}", this);

            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("[Attack] Touch Began → TryAttack", this);
                TryAttack(t.position);
            }
        }
    }

    void TryAttack(Vector2 screenPos)
    {
        Ray ray = arCamera.ScreenPointToRay(screenPos);

        if (!Physics.Raycast(ray, out RaycastHit hit, 100f, enemyLayer))
        {
            Debug.Log("[Attack] Raycast: промах по enemyLayer", this);
            return;
        }
        float distance = Vector3.Distance(transform.position, hit.transform.position);

        if (distance > attackRange)
        {
            Debug.Log($"[Attack] Враг слишком далеко: {distance} > {attackRange}", this);
            return;
        }

        AttackEnemy(hit.collider.gameObject);
    }

    void AttackEnemy(GameObject enemy)
    {
        Debug.Log("[PlayerAttack] Попал по врагу: " + enemy.name);

        HpEnemy enemyHealth = enemy.GetComponent<HpEnemy>();

        if (playerAnimator != null && enemyHealth.currentHealth > 0)
        {
            playerAnimator.PlayAttackAnimation();
        }
        if (enemyHealth != null && enemyHealth.currentHealth > 0)
        {
            enemyHealth.TakeDamage(attackDamage);

            EnemyAttack enemyattack = enemy.GetComponent<EnemyAttack>();
            if (enemyattack != null)
            {
                Debug.Log("[PlayerAttack] Вызываю OnPlayerHitEnemy у " + enemy.name);
                enemyattack.OnPlayerHitEnemy();
            }
            else
            {
                Debug.LogWarning("[PlayerAttack] У врага нет EnemyAttack");
            }
        }
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    [Header("Настройки атаки")]
    public float attackRange = 2f;          // Радиус атаки
    public float attackCooldown = 1f;       // КД
    public int attackDamage = 10;           // Урон
    public LayerMask enemyLayer;            // Слой врагов
    public PlayerAnimator playerAnimator;   // Скрипт анимации

    private bool canAttack = true;
    private Camera arCamera;

    void Start()
    {
        arCamera = Camera.main;
        Debug.Log($"[Attack] Start. arCamera = {arCamera}", this);

        if (arCamera == null)
            Debug.LogError("[Attack] Camera.main НЕ найдена!", this);
    }

    void Update()
    {
        // Показываем, что Update вообще работает
        // (сильно спамит, можно потом убрать)
        // Debug.Log("[Attack] Update", this);

        if (!canAttack)
            return;

#if UNITY_EDITOR
        // Для теста в редакторе мышью
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("[Attack] Mouse click detected", this);
            TryAttack(Input.mousePosition);
        }
#endif

        // На телефоне — тач
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
        if (arCamera == null)
        {
            Debug.LogError("[Attack] TryAttack: arCamera == null", this);
            return;
        }

        Debug.Log($"[Attack] TryAttack at screenPos = {screenPos}", this);

        Ray ray = arCamera.ScreenPointToRay(screenPos);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1f);
        Debug.Log($"[Attack] Ray origin = {ray.origin}, dir = {ray.direction}", this);

        if (!Physics.Raycast(ray, out RaycastHit hit, 100f, enemyLayer))
        {
            Debug.Log("[Attack] Raycast: промах по enemyLayer", this);
            return;
        }

        Debug.Log($"[Attack] Raycast HIT: {hit.collider.name}, layer = {hit.collider.gameObject.layer}", this);

        float distance = Vector3.Distance(transform.position, hit.transform.position);
        Debug.Log($"[Attack] Distance to target = {distance}", this);

        if (distance > attackRange)
        {
            Debug.Log($"[Attack] Враг слишком далеко: {distance} > {attackRange}", this);
            return;
        }

        AttackEnemy(hit.collider.gameObject);
    }

    void AttackEnemy(GameObject enemy)
    {
        Debug.Log($"[Attack] AttackEnemy → {enemy.name}", this);

        if (playerAnimator != null)
        {
            Debug.Log("[Attack] PlayAttackAnimation()", this);
            playerAnimator.PlayAttackAnimation();
        }
        else
        {
            Debug.LogWarning("[Attack] playerAnimator == null", this);
        }

        HpEnemy enemyHealth = enemy.GetComponent<HpEnemy>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(attackDamage);
            Debug.Log($"[Attack] Враг атакован! Урон: {attackDamage}", this);
        }
        else
        {
            Debug.LogWarning("[Attack] У цели нет компонента HpEnemy", this);
        }

        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        Debug.Log("[Attack] КД начался", this);
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
        Debug.Log("[Attack] КД закончился, можно снова атаковать", this);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

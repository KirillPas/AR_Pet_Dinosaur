using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject m_Enemy;
    [SerializeField] private AimBehaviour aimBehaviour;
    void Update()
    {
        if (m_Enemy == null)
        {
            var instantiate = Instantiate(m_Enemy, aimBehaviour.transform.position, Quaternion.identity);
        }
    }
}

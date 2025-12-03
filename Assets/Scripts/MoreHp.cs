using UnityEngine;

public class MoreHp : MonoBehaviour
{
    [SerializeField] public HpPlayer HpPlayer;
    [SerializeField] public int up_maxhp = 10;
    [SerializeField] private string playerTag = "Player";
    private bool playerInRange = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            HpPlayer = other.GetComponent<HpPlayer>();
            if (HpPlayer != null)
            {
                playerInRange = true;
                Debug.Log("[MoreHp] Игрок вошёл в зону увеличения хп");
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (other.GetComponent<HpPlayer>() == HpPlayer)
            {
                playerInRange = false;
                HpPlayer = null;
                Debug.Log("[MoreHp] Игрок вышел из зоны увеличения хп");
            }
        }
    }
    void Update()
    {
        if (!playerInRange || HpPlayer == null)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            UseMoreMaxHp();
        }
    }
    public void UseMoreMaxHp()
    {
        HpPlayer.UpMaxHp(up_maxhp);
        Destroy(gameObject);
    }
}

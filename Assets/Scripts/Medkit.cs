using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] public HpPlayer HpPlayer;
    [SerializeField] private int _heal = 25;
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
                Debug.Log("[Medkit] Игрок вошёл в зону аптечки");
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
                Debug.Log("[Medkit] Игрок вышел из зоны аптечки");
            }
        }
    }
    private void Update()
    {
        if (!playerInRange || HpPlayer == null)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            UseMedkit();
        }
    }
    private void UseMedkit()
    {
        HpPlayer.Heal(_heal);
        Debug.Log("[Medkit] Аптечка использована");

        Destroy(gameObject);
    }
}

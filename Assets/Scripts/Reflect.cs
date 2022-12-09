using UnityEngine;

public class Reflect : MonoBehaviour
{
    [SerializeField] private float _speedMultiplier = 1;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var player = collision.gameObject.GetComponent<Player>();
            player.Rb.velocity *= _speedMultiplier;
        }
    }
}

using System.Collections;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public AudioClip getCoin;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PointController.instance.AddCoin();
            AudioSourceController.instance.PlayOneShot(getCoin);
            Destroy(gameObject);
        }
    }
}

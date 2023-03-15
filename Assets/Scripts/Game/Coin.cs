using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioManager audioManager;
    private readonly int rotSpeedZ = 100;
    private readonly int rotSpeed = 0;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        transform.Rotate(rotSpeed, rotSpeed, rotSpeedZ * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            PlayerController.gold++;
            audioManager.PlaySound("PickUpCoin");
        }
    }
}

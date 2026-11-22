using UnityEngine;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HorseInteraction : MonoBehaviour
{
    [SerializeField] private AudioClip horseSound;
    [SerializeField] private string playerTag = "Player";

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        TryPlaySound(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        TryPlaySound(collision.collider);
    }

    private void TryPlaySound(Collider other)
    {
        if (horseSound == null || !IsPlayer(other))
        {
            return;
        }

        audioSource.PlayOneShot(horseSound);
    }

    private bool IsPlayer(Collider other)
    {
        Transform current = other.transform;

        while (current != null)
        {
            if (current.CompareTag(playerTag))
            {
                return true;
            }

            current = current.parent;
        }

        return false;
    }
}

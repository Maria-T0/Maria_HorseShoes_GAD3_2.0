using UnityEngine;
public class HorseShoe : MonoBehaviour
{
    [SerializeField] private Pole pole;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] public Transform horseShoeSnap;
    [SerializeField] private Transform tableSnap;
    [SerializeField] public GameObject horseShoePrefab;
    public float RewardScore;

    private void OnTriggerEnter(Collider other)
    {
        // Check if horseshoe hit the pole
        if (other.CompareTag("Pole"))
        {
            Debug.Log("HorseShoe hit the pole! Score increased!");
            if (scoreSystem != null)
            {
                scoreSystem.AddScore();
            }
        }
        else if (other.CompareTag("NotTable"))
        {
            Debug.Log("HorseShoe entered not table trigger");
        }
        else if (other.CompareTag("Table"))
        { 
            horseShoeSnap.position = tableSnap.position;
            horseShoeSnap.rotation = tableSnap.rotation;
        }
    }
}

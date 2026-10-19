using UnityEngine;
public class HorseShoe : MonoBehaviour
{
    [SerializeField] private Pole pole;
    [SerializeField] public Transform horseShoeSnap;
    [SerializeField] private Transform tableSnap;
    [SerializeField] public GameObject horseShoePrefab;
    public ScoreManager scoreManager; // Reference to the ScoreManager script
    public float RewardScore;
    public int points = 1; // Points awarded for hitting the pole

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.instance.AddPoint(points);   

        // Check if horseshoe hit the pole
        if (other.CompareTag("Pole"))
        {
           
            Debug.Log("HorseShoe hit the pole! Points increased!");
   
                scoreManager.AddPoint(points);
            
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
    private void Awake()
    {
        
    }
}

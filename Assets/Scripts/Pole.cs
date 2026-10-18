using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.PlayerLoop;
using System.Runtime.CompilerServices;
using TMPro;

public class Pole : MonoBehaviour
{
    [SerializeField] private HorseShoe horseShoe;

    [SerializeField] private TMP_Text hitText; // TextMeshPro text to update when a horseshoe hits the pole

    private bool spawn = false;
    private float spawnTimer = 0f;
    private const float SPAWN_DELAY = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horseShoe.horseShoePrefab = GameObject.FindGameObjectWithTag("HorseShoe");
    }

    void Update()
    {
        if (spawn)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= SPAWN_DELAY)
            {
                DelayedSpawn();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Try to find a HorseShoe component either on the collider itself or on a parent (handles Rigidbody on the Snap parent)
        HorseShoe incoming = other.GetComponent<HorseShoe>() ?? other.GetComponentInParent<HorseShoe>();

        if (incoming != null || other.CompareTag("HorseShoe"))
        {
            Debug.Log("HorseShoe entered the pole trigger");

            // Position the horseshoe snap (keeps existing behavior)
            horseShoe.transform.position = horseShoe.horseShoeSnap.position;
            horseShoe.transform.rotation = horseShoe.horseShoeSnap.rotation;

            // Update score if a ScoreSystem is attached

                scoreManager.AddPoint();

            // Update the TextMeshPro text (if assigned in the inspector)
            if (hitText != null)
            {
                hitText.text = "Hit!"; // change to any message you prefer, or set to scoreSystem's value if available
            }

            spawn = true;
            spawnTimer = 0f;
        }
    }

    private void DelayedSpawn()
    {
        Instantiate(horseShoe.horseShoePrefab, horseShoe.horseShoeSnap.position, horseShoe.horseShoeSnap.rotation);
        spawn = false;
        spawnTimer = 0f;
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.PlayerLoop;
using System.Runtime.CompilerServices;

public class Pole : MonoBehaviour
{
    [SerializeField] private HorseShoe horseShoe;
    private bool spawn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horseShoe.horseShoePrefab = GameObject.FindGameObjectWithTag("HorseShoe");
    }

    void Update()
    {
        if (spawn)
        {
            Invoke("DelayedSpawn", 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HorseShoe"))
        {
            Debug.Log("HorseShoe entered the pole trigger");
            horseShoe.transform.position = horseShoe.horseShoeSnap.position;
            horseShoe.transform.rotation = horseShoe.horseShoeSnap.rotation;

            spawn = true;
        }
    }

    private void DelayedSpawn()
    {
        Instantiate(horseShoe.horseShoePrefab, horseShoe.horseShoeSnap.position, horseShoe.horseShoeSnap.rotation);
        spawn = false;

        Destroy(horseShoe);
    }
}
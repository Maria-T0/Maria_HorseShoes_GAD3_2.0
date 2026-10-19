using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Pole : MonoBehaviour
{
    [SerializeField] private HorseShoe horseShoe;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horseShoe.horseShoePrefab = GameObject.FindGameObjectWithTag("HorseShoe");
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.instance.AddScore();
        HorseShoe incoming = other.GetComponent<HorseShoe>() ?? other.GetComponentInParent<HorseShoe>();

        if (incoming != null || other.CompareTag("HorseShoe"))
        {
            Debug.Log("HorseShoe entered the pole trigger");
            horseShoe.transform.position = horseShoe.horseShoeSnap.position;
            horseShoe.transform.rotation = horseShoe.horseShoeSnap.rotation;
        }
    }
}
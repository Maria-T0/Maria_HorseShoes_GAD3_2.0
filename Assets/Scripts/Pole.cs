using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Pole : MonoBehaviour
{
    [SerializeField] private HorseShoe horseShoe;
    [SerializeField, Min(1)] private int points = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horseShoe.horseShoePrefab = GameObject.FindGameObjectWithTag("HorseShoe");
    }

    private void OnTriggerEnter(Collider other)
    {
        HorseShoe incoming = other.GetComponent<HorseShoe>() ?? other.GetComponentInParent<HorseShoe>();

        if (incoming != null || other.CompareTag("HorseShoe"))
        {
            ScoreManager.instance.AddScore(points);
            Debug.Log("HorseShoe entered the pole trigger");

            HorseShoe shoeToReset = incoming != null ? incoming : horseShoe;
            shoeToReset.SnapToPoleAndReturnToTable();
        }
    }
}
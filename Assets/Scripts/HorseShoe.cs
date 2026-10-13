using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;
public class HorseShoe : MonoBehaviour
{
    [SerializeField] private Pole pole;
    [SerializeField] public Transform horseShoeSnap;
    [SerializeField] private Transform tableSnap;
    [SerializeField] public GameObject horseShoePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NotTable"))
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

using UnityEngine;
using System.Collections;
using UnityEngine;

public class HorseShoe : MonoBehaviour
{
    [SerializeField] private Pole pole;
    [SerializeField] public Transform horseShoeSnap;
    [SerializeField] private Transform tableSnap;
    [SerializeField] public GameObject horseShoePrefab;

    private Coroutine returnToTableCoroutine;

    public void SnapToPoleAndReturnToTable()
    {
        if (horseShoeSnap == null || tableSnap == null)
        {
            return;
        }

        MoveToSnap(horseShoeSnap);

        if (returnToTableCoroutine != null)
        {
            StopCoroutine(returnToTableCoroutine);
        }

        returnToTableCoroutine = StartCoroutine(ReturnToTableAfterDelay());
    }

    private IEnumerator ReturnToTableAfterDelay()
    {
        yield return new WaitForSeconds(6f);
        MoveToSnap(tableSnap);
        returnToTableCoroutine = null;
    }

    private void MoveToSnap(Transform snap)
    {
        transform.SetPositionAndRotation(snap.position, snap.rotation);

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.linearVelocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
    }
}

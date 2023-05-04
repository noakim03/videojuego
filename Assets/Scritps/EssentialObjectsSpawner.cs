using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialObjectsSpawner : MonoBehaviour
{
    [SerializeField] GameObject essentialObjectPrefab;

    private void Awake()
    {
        var existingObject = FindObjectsOfType<EssentialObjects>();
        if (existingObject.Length == 0)
            Instantiate(essentialObjectPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}

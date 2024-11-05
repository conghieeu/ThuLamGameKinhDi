using System.Collections.Generic;
using Mono.CSharp;
using UnityEngine;

public class GhostPatronPoints : MonoBehaviour
{
    public static List<GameObject> CheckPoints { get; set; }

    private void Start()
    {
        CheckPoints = new List<GameObject>();
        foreach (Transform child in transform)
        {
            CheckPoints.Add(child.gameObject);
        }
    }
}

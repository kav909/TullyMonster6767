using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MonstershootsBlades : MonoBehaviour
{
    [SerializeField] GameObject mob;
    [SerializeField] List<GameObject> blades;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("player");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

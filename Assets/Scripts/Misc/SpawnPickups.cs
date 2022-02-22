using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickups : MonoBehaviour
{
    public Pickups[] pickupsPrefabArray;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(pickupsPrefabArray[4], transform.position, transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

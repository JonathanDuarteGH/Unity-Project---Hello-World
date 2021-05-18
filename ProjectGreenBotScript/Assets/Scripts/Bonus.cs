using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour

{
    //counter for the remaining collectable in the scene
    public int counter;

    // Prefab that will be instantiated
    public GameObject bonusObject;

    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.FindGameObjectsWithTag("Pick Up").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pickup()
    {
        counter--;
        if (counter == 0)
        {
            SpawnBonus();
        }

        Debug.Log("Pickup message has been received");
    }

    void SpawnBonus()
    {
        // Instantiate our Prefab!
        GameObject.Instantiate(bonusObject, transform);
    }
}

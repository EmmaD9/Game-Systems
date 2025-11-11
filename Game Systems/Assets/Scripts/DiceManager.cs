using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private GameObject Die;

    //[SerializeField] private bool physicsDice;
    //[SerializeField] private bool rgenDice;
    [SerializeField]
    private float range = 4;

    private int diceValue;

    //[SerializeField] private float diceForce;


    public void RollDice()
    {
        Debug.Log("rolling all dice");

        // Find all GameObjects tagged as "die"
        GameObject[] dice = GameObject.FindGameObjectsWithTag("Die");

        foreach (GameObject die in dice)
        {

            float diceForce = UnityEngine.Random.Range(-range, range);
            Rigidbody rb = die.GetComponent<Rigidbody>();

            //Reset velocities for consistent rolls
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            //Random force in random direction
            Vector3 randomDirection = new Vector3(
            UnityEngine.Random.Range(-1f, 1f),
            UnityEngine.Random.Range(0.5f, 1.5f), // ensure upward bias
            UnityEngine.Random.Range(-1f, 1f)
            ).normalized;

            float forceMagnitude = UnityEngine.Random.Range(range * 0.8f, range * 1.2f);
            rb.AddForce(randomDirection * forceMagnitude, ForceMode.Impulse);

            // Random torque for realistic spin
            Vector3 randomTorque = new Vector3(
                UnityEngine.Random.Range(-range, range),
                UnityEngine.Random.Range(-range, range),
                UnityEngine.Random.Range(-range, range)
            );
            rb.AddTorque(randomTorque, ForceMode.Impulse);
        }
    }

    public void SpawnDice()
    {
        if (Die == null)
        {
            Debug.LogError("Die prefab not assigned!");
            return;
        }
        GameObject newDie = Instantiate(Die);
        newDie.name = "Die";

        Die = newDie;
    }

    void Update()
    {
        //Rigidbody rb = Die.GetComponent<Rigidbody>();

        //spawn on update to break the game (idk conner liked it)
        //SpawnDice();
        
        
        //
        //Value Logic: doesn't work right now
        /*
        switch (Die.transform.rotation.x)
        {
            case 0:
                diceValue = 3;
                Debug.Log("dice value is " + diceValue);
                break;

            case 90:
                diceValue = 1;
                Debug.Log("dice value is " + diceValue);
                break;

            case 180:
                diceValue = 6;
                Debug.Log("dice value is " + diceValue);
                break;

            case 270:
                diceValue = 4;
                Debug.Log("dice value is " + diceValue);
                break;


        }
        */
    }
}

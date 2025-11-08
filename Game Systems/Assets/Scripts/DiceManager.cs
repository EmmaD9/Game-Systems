using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private GameObject Die;

    [SerializeField] private bool physicsDice;
    [SerializeField] private bool rgenDice;
    [SerializeField] 
    private float range = 4;

    //[SerializeField] private float diceForce;

    private void Start()
    {
    }
    public void RollDice()
    {
        Debug.Log("die should roll");
        float diceForce = UnityEngine.Random.Range(-range, range);
        Rigidbody rb = Die.GetComponent<Rigidbody>();

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

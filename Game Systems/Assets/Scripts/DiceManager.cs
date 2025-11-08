using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private GameObject Die;

    [SerializeField] private bool physicsDice;
    [SerializeField] private bool rgenDice;

    //[SerializeField] private float diceForce;

    private void Start()
    {
        
    }
    public void RollDice()
    {
        //Debug.Log("applied a force");
        float diceForce = UnityEngine.Random.Range(-10.0f, 10.0f);
        Rigidbody rb = Die.GetComponent<Rigidbody>();
        //rb.AddForce(Vector3.up * diceForce, ForceMode.Impulse);
        rb.AddForce(Vector3.left * diceForce, ForceMode.Impulse);
        //rb.AddForce(Vector3.right * diceForce, ForceMode.Impulse);
    }
}

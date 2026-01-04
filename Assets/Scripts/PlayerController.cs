using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInteraction playerInteraction;
    PlayerMovement playerMovement;
    public bool isInputBlocked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInteraction = gameObject.GetComponent<PlayerInteraction>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        isInputBlocked = false;
    }

    // Update is called once per frame
    public void blockInput() {
        Debug.Log("block input fired");
        isInputBlocked = true;
        playerInteraction.isInputBlocked = true;
        playerMovement.isInputBlocked = true;
    }

    public void unblockInput() {
        Debug.Log("unblock input fired");
        isInputBlocked = false;
        playerInteraction.isInputBlocked = false;
        playerMovement.isInputBlocked = false;
    }
}

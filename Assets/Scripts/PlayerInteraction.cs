using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject objectToInteract;
    private GameObject empty;
    public bool isInputBlocked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        empty = new GameObject();
        isInputBlocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<DialogueTrigger>()) {
            objectToInteract = collider.gameObject;
        }       
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider == objectToInteract.GetComponent<Collider2D>()) {
            objectToInteract = empty;
        }
    }

    public void Interact(InputAction.CallbackContext context) {
        if(!isInputBlocked) {
            if(context.started) {
            objectToInteract.GetComponent<DialogueTrigger>().PlayNaniScript();
            }
        }
    }
}

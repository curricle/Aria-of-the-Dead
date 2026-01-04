using UnityEngine;
using Naninovel;
using System;
using System.Runtime.Serialization;

public class DialogueTrigger : MonoBehaviour
{
    public string ScriptName;
    public string Label;

    private bool canReceiveInteraction;
    private int interactionCount;
    [SerializeField] int maxInteractions;

    private void Start()
    {
        interactionCount = 1;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        canReceiveInteraction = true;
        Debug.Log("Can receive interaction: " + canReceiveInteraction);

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        canReceiveInteraction = false;
        Debug.Log("Can receive interaction: " + canReceiveInteraction);
    }

    public void PlayNaniScript() {

        Label = interactionCount.ToString(); 
        Debug.Log("Interaction count: " + interactionCount + "; Label: " + Label);
        
        if(canReceiveInteraction) {
            var controller = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
            controller.isInputBlocked = true;
            controller.blockInput();

            var inputManager = Engine.GetServiceOrErr<IInputManager>();
            inputManager.ProcessInput = true;

            var scriptPlayer = Engine.GetServiceOrErr<IScriptPlayer>();
            scriptPlayer.LoadAndPlayAtLabel(ScriptName, Label).Forget();
        
            if(interactionCount < maxInteractions) {
                interactionCount++;
            }
            else {
                interactionCount = maxInteractions;
            }
        
        }

        
       
    }
}
using Naninovel;
using Naninovel.Commands;
using UnityEngine;
using UnityEngine.InputSystem;

[CommandAlias("adventure")]
public class SwitchToAdventureMode : Command
{
    [ParameterAlias("reset")]
    public BooleanParameter ResetState = true;

    public override async UniTask Execute (AsyncToken token = default)
    {
        // 1. Disable Naninovel input.
        var inputManager = Engine.GetServiceOrErr<IInputManager>();
        inputManager.ProcessInput = false;

        // 2. Stop script player.
        var scriptPlayer = Engine.GetServiceOrErr<IScriptPlayer>();
        scriptPlayer.Stop();

        // 3. Hide text printer.
        var hidePrinter = new HidePrinter();
        hidePrinter.Execute(token).Forget();

        // 4. Reset state (if required).
        if (ResetState)
        {
            var stateManager = Engine.GetServiceOrErr<IStateManager>();
            await stateManager.ResetState();
        }

        // 5. Switch cameras.
        var advCamera = GameObject.FindWithTag("GameviewCamera").GetComponent<Camera>();
        advCamera.enabled = true;
        var naniCamera = Engine.GetServiceOrErr<ICameraManager>().Camera;
        naniCamera.enabled = false;

        // 6. Enable character control.
        var controller = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        controller.unblockInput();
    }
}
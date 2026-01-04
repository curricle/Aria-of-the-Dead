using Naninovel;
using Naninovel.Commands;
using UnityEngine;
using UnityEngine.SceneManagement;

[CommandAlias("load")]
public class LoadSceneFromNani : Command
{
    public StringParameter Scene;

    public override async UniTask Execute (AsyncToken token = default)
    {
        GameObject.FindWithTag("GameController").GetComponent<LoadScene>().LoadSelectedScene(Scene);
    }
}
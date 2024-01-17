
using UnityEngine;

public class ReloadState : ActionBaseState
{
    public override void EnterState(ActionsStateManager manager)
    {

        manager.anime.SetTrigger("reload");
        manager.ammo.isReloading = true;
        

        

    }


    public override void UpdateState(ActionsStateManager manager)
    {
        manager.rightHand.weight = Mathf.Lerp(manager.rightHand.weight, 0, Time.deltaTime * 10);
        manager.leftHand.weight = Mathf.Lerp(manager.leftHand.weight, 0, Time.deltaTime * 10);

    }
}

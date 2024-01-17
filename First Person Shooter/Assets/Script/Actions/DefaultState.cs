
using UnityEngine;

public class DefaultState :ActionBaseState
{
    public override void EnterState(ActionsStateManager manager)
    {
        


    }


    public override void UpdateState(ActionsStateManager manager)
    {
        if(Input.GetKeyDown(KeyCode.R) && canReload(manager))
        {
            manager.Switch(manager.reloadState);
            

        }

        manager.rightHand.weight = Mathf.Lerp(manager.rightHand.weight, 1, Time.deltaTime*10);
        manager.leftHand.weight = Mathf.Lerp(manager.leftHand.weight, 1, Time.deltaTime*10);

    }

    bool canReload(ActionsStateManager manager)
    {
        if(manager.ammo.currentAmmo==manager.ammo.clipSize)
        {
            return false;
        }
        else if(manager.ammo.magazine==0 && manager.ammo.currentAmmo==0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}

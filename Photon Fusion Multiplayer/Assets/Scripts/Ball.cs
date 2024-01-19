using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : NetworkBehaviour
{
    [Networked] private TickTimer life { get; set; }

    public void Init()
    {
        life = TickTimer.CreateFromSeconds(Runner, 5f);

    }
    public override void FixedUpdateNetwork()
    {
        if(life.Expired(Runner))
        {
            Runner.Despawn(Object);
        }
        else
        {
            transform.position += transform.forward * 5 * Runner.DeltaTime;
        }
        
    }


}

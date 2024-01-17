using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private NetworkCharacterController characterController;
    [SerializeField] private float speed = 30f;

    [SerializeField] private GameObject ball;
    private Vector3 forward= Vector3.forward;

    [Networked] private TickTimer delay { get; set; }
    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<NetworkCharacterController>();
        
    }

    //The FIxedUpdateNetwork gets called every simulation tick, this may occur multiple times per rendering frame
    public override void FixedUpdateNetwork()
    {
        if(GetInput(out NetworkInputData data))
        {
            if(data.direction.magnitude>0)
            {
                forward = data.direction;
            }

            if(HasStateAuthority && delay.ExpiredOrNotRunning(Runner))
            {
                
                if ((data.buttons | NetworkInputData.MOUSEBUTTON0) !=0)
                {
                    delay = TickTimer.CreateFromSeconds(Runner, 0.5f);
                    Runner.Spawn(ball, transform.position + forward, Quaternion.LookRotation(forward), Object.InputAuthority, (runner, o) =>
                    {
                        //Initialize the ball befor synchronizing it
                        o.GetComponent<Ball>().Init();
                    }
                    );
                }

            }
            

            //Normalize to prevent cheating so no player will have the upper hand
            data.direction.Normalize();

            characterController.Move(speed  *data.direction * Runner.DeltaTime);
        }
    }


}

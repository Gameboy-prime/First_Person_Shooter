using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRigidbody : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField]
    private float moveSpeed;

    private float vertical;
    private float horizontal;

    private const string VERTICAL="Vertical";
    private const string HORIZONTAL= "Horizontal";


    void Start()
    {
        player= GetComponent<Rigidbody>();
    }

    void Update()
    {
        vertical= Input.GetAxis(VERTICAL);
        horizontal= Input.GetAxis(HORIZONTAL);

    }

    void FixedUpdate()
    {
        player.velocity= new Vector3(horizontal*moveSpeed,0,vertical*moveSpeed);
      
    }
}

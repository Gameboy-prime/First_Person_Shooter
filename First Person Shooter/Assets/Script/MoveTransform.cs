using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransform : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private const string VERTICAL="Vertical";
    private const string HORIZONTAL= "Horizontal";

    void Update()
    {
        float vertical= Input.GetAxis(VERTICAL);
        float horizontal= Input.GetAxis(HORIZONTAL);

        transform.Translate(transform.forward*vertical*moveSpeed,Space.World);
        transform.Translate(transform.right*horizontal*moveSpeed, Space.World);
    }
    
}

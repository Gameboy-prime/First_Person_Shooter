using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActionsStateManager : MonoBehaviour
{

    public DefaultState defaultState= new DefaultState();
    public ReloadState reloadState= new ReloadState();
    ActionBaseState currentState;

    public AmmoSystem ammo;

    [HideInInspector] public Animator anime;

    public MultiAimConstraint rightHand;
    public TwoBoneIKConstraint leftHand;

    AudioSource audio;

    [SerializeField] AudioClip magIn;
    [SerializeField] AudioClip magOut;
    [SerializeField] AudioClip slideMag;

    
    // Start is called before the first frame update
    void Start()
    {
        anime= GetComponent<Animator>();
        Switch(defaultState);

        audio= GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        
    }

    public void Switch(ActionBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
        

    }

    public void ReloadWeapons()
    {
        ammo.Reload();

        Switch(defaultState);
        ammo.isReloading = false;
    }

    public void MagIn()
    {
        audio.PlayOneShot(magIn);
    }

    public void MagOut()
    {
        audio.PlayOneShot(magOut);
    }

    public void SlideMag()
    {
        audio.PlayOneShot(slideMag);
    }
}

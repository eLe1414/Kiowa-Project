using FishNet.Component.Animating;
using UnityEngine;

public class Animating_Net : MonoBehaviour
{
    #region Local Variables

    [SerializeField, Tooltip("Componente Anomator")]
    private Animator _animator;

    [SerializeField, Tooltip("Componente Anomator")]
    private NetworkAnimator _networkAnimator;

    private const string MOVING = "Moving";
    private const string JUMP = "Jump";

    #endregion Local Variables




    #region Class Properties

    #endregion Class Properties




    #region Unity Methods

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _networkAnimator = GetComponent<NetworkAnimator>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }   // END Update

    #endregion Unity Methods




    #region Local Methods

    public void SetMoving(bool value)
    {
        _animator.SetBool(MOVING, value);
    }

    public void Jump()
    {
        _networkAnimator.SetTrigger(JUMP);
    }

    #endregion Local Methods

}   // END Class
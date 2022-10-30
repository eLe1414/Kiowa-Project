using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;


public class FPSCameraController : NetworkBehaviour
{
    [Header("Input")]
    [SerializeField] 
    private Vector3 inputVector;

    [SerializeField]
    private Vector3 moveVector;
    
    [Header("MoveTransition")]
    [SerializeField]
    private float moveSpeed;
    
    [Header("Angles")]
    [SerializeField]
    private float minAngles, maxAngles;


    public bool isPaused;

    private float yAxisRot;
    private float xAxisRot;


    [SerializeField]
    private Rigidbody rb;

    public Transform camPos;
    public FirstPersonController fpsControllerInput;

    public void Awake()
    {
        Debug.Log("FPSCameraController => Awake");

        fpsControllerInput = new FirstPersonController();
    }

    private void Start()
    {
        Debug.Log("FPSCameraController => Start");

        //rb = GetComponent<Rigidbody>();
        //camPos = transform.GetChild(1);
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        Debug.Log("FPSCameraController => OnStartClient");

        //Debug.Log("FPSCameraController => OnStartClient => Owner.ClientId: " + base.Owner.Objects);

        //foreach (NetworkObject obj in base.Owner.Objects)
        //{
        //    Debug.Log("FPSCameraController => OnStartClient => obj.transform.name: " + obj.transform.name);
        //}


        if (base.IsOwner)
        {
            Debug.Log("FPSCameraController => OnStartClient => Owner: " + base.IsOwner);

            rb = GetComponent<Rigidbody>();
            camPos = transform.GetChild(1);

            fpsControllerInput.Player.Move.Enable();
        }
    }

    public override void OnStopClient()
    {
        base.OnStopClient();

        Debug.Log("FPSCameraController => OnStopClient");

        if (base.IsOwner)
        {
            Debug.Log("FPSCameraController => OnStopClient => Owner: " + base.IsOwner);
            fpsControllerInput.Player.Move.Disable();
        }
    }

    private void Update()
    {
        //Debug.Log("FPSCameraController => Update => Antes del Owner");

        //Debug.Log("FPSCameraController => Update => IsOwner       : " + base.IsOwner);
        //Debug.Log("FPSCameraController => Update => Owner.ClientId: " + base.Owner.ClientId);
        ////Debug.Log("FPSCameraController => Update => Owner.ClientId: " + base.Owner.CustomData.ToString());

        // Si el objeto no pertenece a esta conexión del cliente no se ejecuta el código siguiente
        if (!base.IsOwner)
        {
            //Debug.Log("FPSCameraController => Update => Salimos porque no es Owner");

            return;
        }

        //Debug.Log("FPSCameraController => Update => Es Owner");

        if (!isPaused)
        {
            //Debug.Log("FPSCameraController => Update => No pausado");

            SetInputVector();
            SetMoveVector();
            SetArmsRotation();
        }
    }

    private void FixedUpdate()
    {
        //Debug.Log("FPSCameraController => FixedUpdate => Antes del Owner");

        //Debug.Log("FPSCameraController => FixedUpdate => IsOwner: " + base.IsOwner + " => Owner: " + base.Owner);

        // Si el objeto no pertenece a esta conexión del cliente no se ejecuta el código siguiente
        if (!base.IsOwner)
        {
            //Debug.Log("FPSCameraController => FixedUpdate => Salimos porque no es Owner");

            return;
        }

        //Debug.Log("FPSCameraController => FixedUpdate => Es Owner");

        if (!isPaused)
        {
            //Debug.Log("FPSCameraController => FixedUpdate => No pausado");

            TranslationRigidbody();
            RotationRigidbody();
        }
    }

    //private void OnEnable()
    //{
    //    Debug.Log("FPSCameraController => OnEnable => Owner: " + base.IsOwner);

    //    fpsControllerInput.Player.Move.Enable();
    //    //fpsControllerInput.Player.Run.Enable();
    //    //fpsControllerInput.Player.SwitchXandYMove.Enable();
    //}

    //private void OnDisable()
    //{
    //    Debug.Log("FPSCameraController => OnDisable => Owner: " + base.IsOwner);

    //    fpsControllerInput.Player.Move.Disable();
    //    //fpsControllerInput.Player.Run.Disable();
    //    //fpsControllerInput.Player.SwitchXandYMove.Disable();
    //}

    private void SetInputVector ()
    {
        inputVector.x = fpsControllerInput.Player.Move.ReadValue<Vector2>().x;
        inputVector.z = fpsControllerInput.Player.Move.ReadValue<Vector2>().y;

        yAxisRot += Mouse.current.delta.x.ReadValue();
        xAxisRot -= Mouse.current.delta.y.ReadValue();

        xAxisRot = Mathf.Clamp (xAxisRot, minAngles, maxAngles);
    }

    private void SetMoveVector ()
    {
        moveVector = transform.forward * inputVector.z + transform.right * inputVector.x;
    }

    private void TranslationRigidbody ()
    {
        rb.MovePosition (rb.position + moveVector * moveSpeed * Time.fixedDeltaTime);
    }

    private void RotationRigidbody()
    {
        Quaternion deltaRotation = Quaternion.AngleAxis (yAxisRot, Vector3.up);
        rb.MoveRotation (deltaRotation);
    }

    private void SetArmsRotation()
    {
        Quaternion _armsRotation = Quaternion.AngleAxis(xAxisRot, Vector3.right);
        camPos.localRotation = _armsRotation;
    }
}
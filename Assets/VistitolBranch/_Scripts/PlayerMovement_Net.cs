using FishNet.Object;
using UnityEngine;

public class PlayerMovement_Net : NetworkBehaviour
{
    #region Local Variables

    [Header("Componentes propios")]
    [SerializeField, Tooltip("Gestion del movimiento (scrip Unity)")]
    private CharacterController _characterController;

    [SerializeField, Tooltip("Gestion de las animaciones")]
    private Animating_Net _animating;   // Podemos usar MONO porquer se controla en el script llamante si el objeto pertenece al cliente

    [SerializeField, Tooltip("Velocidad del movimiento")]
    private float _moveSpeed = 5f;

    [SerializeField, Tooltip("Velocidad de rotación")]
    private float _rotationSpeed = 150f;

    private const string AXIS_H = "Horizontal";
    private const string AXIS_V = "Vertical";

    #endregion Local Variables




    #region Class Properties

    #endregion Class Properties




    #region Unity Methods

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animating = GetComponent<Animating_Net>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        // Si el objeto no pertenece a esta conexión del cliente no se ejecuta el código siguiente
        if (!base.IsOwner)
        {
            return;
        }

        float horizontal = Input.GetAxisRaw(AXIS_H);
        float vertical = Input.GetAxisRaw(AXIS_V);

        transform.Rotate(new Vector3(0f, horizontal * _rotationSpeed * Time.deltaTime));

        Vector3 offset = new Vector3(0f, Physics.gravity.y, vertical) * (_moveSpeed * Time.deltaTime);

        offset = transform.TransformDirection(offset);

        _characterController.Move(offset);


        // Otra manera de asegurarse de que el código solo se ejecuta si eres el propietario del objeto
        //MovePlayer();

        bool isMoving = (horizontal != 0f || vertical != 0f);

        _animating.SetMoving(isMoving);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animating.Jump();
        }
        
    }   // END Update

    #endregion Unity Methods




    #region Local Methods

    //[Client(RequireOwnership = true)]
    //private void MovePlayer()
    //{
    //    float horizontal = Input.GetAxisRaw(AXIS_H);
    //    float vertical = Input.GetAxisRaw(AXIS_V);

    //    Vector3 offset = new Vector3(horizontal, Physics.gravity.y, vertical) * (_moveSpeed * Time.deltaTime);

    //    _characterController.Move(offset);
    //}

    #endregion Local Methods

}   // END Class
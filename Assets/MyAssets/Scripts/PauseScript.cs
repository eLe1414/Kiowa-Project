using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScript : NetworkBehaviour
{
    #region Local Variables

    public static PauseScript THIS;

    [Header("Paneles del Menú")]
    [SerializeField, Tooltip("Panel de Opciones")]
    private GameObject _optionsPanel;

    [SerializeField, Tooltip("Panel de Salida a la habitación")]
    private GameObject _exitHallPanel;

    [SerializeField, Tooltip("Panel de Salida de la aplicación")]
    private GameObject _exitAppPanel;

    [Space]
    [SerializeField, Tooltip("Controlador de la cámara FPS")]
    private FPSCameraController _fpsCameraController;

    #endregion Local Variables




    #region Class Properties

    public FPSCameraController FPSCameraController
    {
        get
        {
            return _fpsCameraController;
        }
        set
        {
            _fpsCameraController = value;
        }
    }

    #endregion Class Properties




    #region Unity Methods

    private void Awake()
    {
        Debug.Log("PauseScript => Awake");

        //if (THIS == null)
        //{
        //    THIS = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

    }

    private void Start()
    {
        //_fpsCameraController = FindObjectOfType<FPSCameraController>();
        //_optionsPanel.SetActive(false);
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        Debug.Log("PauseScript => OnStartClient");

        THIS = this;

        _optionsPanel.SetActive(false);
    }

    private void Update()
    {
        Debug.Log("PauseScript => Update => Antes del Owner");
        
        Debug.Log("PauseScript => Update => IsOwner: " + base.IsOwner);

        if (base.IsOwner)
        {
            Debug.Log("PauseScript => Update => Después del Owner");

            PauseMode();
        }
        //PauseMode();
    }

    #endregion Unity Methods




    #region Local Methods

    public void ShowPanel(GameObject _panel)
    {
        Debug.Log("PauseScript => ShowPanel => Antes del Owner");

        Debug.Log("PauseScript => ShowPanel => IsOwner: " + base.IsOwner);

        if (base.IsOwner)
        {
            Debug.Log("PauseScript => ShowPanel => Después del Owner");

            _panel.SetActive(true);
        }
    }

    public void HidePanel (GameObject _panel)
    {
        Debug.Log("PauseScript => HidePanel => Antes del Owner");

        Debug.Log("PauseScript => HidePanel => IsOwner: " + base.IsOwner);

        if (base.IsOwner)
        {
            Debug.Log("PauseScript => HidePanel => Después del Owner");

            _panel.SetActive(false);
        }
    }

    //public void ExitApp()
    //{
    //    Application.Quit();
    //}

    /// <summary>
    /// Inicializamos los paneles según han de estar cada vez que se pulsa "Esc"/"O".
    /// </summary>
    [ObserversRpc(IncludeOwner = true)]
    public void SetInitPanel()
    {
        Debug.Log("PauseScript => SetInitPanel");

        Debug.Log("PauseScript => SetInitPanel => IsOwner: " + base.IsOwner);

        _optionsPanel.SetActive(true);
        _exitHallPanel.SetActive(false);
        _exitAppPanel.SetActive(false);
    }

    public void PauseMode()
    {
        Debug.Log("PauseScript => PauseMode");

        Debug.Log("PauseScript => PauseMode => IsOwner: " + base.IsOwner);


        if (_fpsCameraController == null)
        {
            Debug.Log("PauseScript => PauseMode => _fpsCameraController: null");
            return;
        }

        Debug.Log("PauseScript => PauseMode => Keyboard.current: " + Keyboard.current);

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            _fpsCameraController.isPaused = !_fpsCameraController.isPaused;
            _optionsPanel.SetActive(_fpsCameraController.isPaused);
            _exitHallPanel.SetActive(false);
        }
    }

    #endregion Local Methods
}
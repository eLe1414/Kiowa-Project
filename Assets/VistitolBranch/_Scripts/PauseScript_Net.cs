using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScript_Net : NetworkBehaviour
{
    #region Local Variables

    //public static PauseScript_Net THIS;

    [Header("Paneles del Menú")]
    [SerializeField, Tooltip("Panel de Opciones")]
    private GameObject _startMenu;

    private StartMenu_Net _startMenuNet;

    //[SerializeField, Tooltip("Panel de Opciones")]
    //private GameObject _optionsPanel;

    //[SerializeField, Tooltip("Panel de Salida a la habitación")]
    //private GameObject _exitHallPanel;

    //[SerializeField, Tooltip("Panel de Salida de la aplicación")]
    //private GameObject _exitAppPanel;

    [Space]
    [SerializeField, Tooltip("Controlador de la cámara FPS")]
    private FPSCameraController _fpsCameraController;

    #endregion Local Variables




    #region Class Properties

    //public FPSCameraController FPSCameraController
    //{
    //    get
    //    {
    //        return _fpsCameraController;
    //    }
    //    set
    //    {
    //        _fpsCameraController = value;
    //    }
    //}

    #endregion Class Properties




    #region Unity Methods

    private void Awake()
    {
        //Debug.Log("PauseScript_Net => Awake");

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

    //private void Start()
    //{
    //    //_fpsCameraController = FindObjectOfType<FPSCameraController>();
    //    //_optionsPanel.SetActive(false);
    //}

    public override void OnStartClient()
    {
        base.OnStartClient();

        Debug.Log("PauseScript_Net => OnStartClient");

        //Debug.Log("PauseScript_Net => OnStartClient => Owner.ClientId: " + base.Owner.Objects);

        //foreach (NetworkObject obj in base.Owner.Objects)
        //{
        //    Debug.Log("PauseScript_Net => OnStartClient => obj.transform.name: " + obj.transform.name);
        //}



        //THIS = this;

        //_optionsPanel.SetActive(false);
        //_startMenuNet.HideOptionsPanel();

        Debug.Log("PauseScript_Net => OnStartClient => Owner: " + base.IsOwner);

        _fpsCameraController = GetComponent<FPSCameraController>();

        //_startMenuNet = _startMenu.GetComponent<StartMenu_Net>();
        _startMenu = GameObject.FindGameObjectWithTag("StartMenu");

        _startMenuNet = _startMenu.GetComponent<StartMenu_Net>();
        _startMenuNet.HideOptionsPanel();
        _startMenuNet.HideExitHallPanel();
        _startMenuNet.HideExitAppPanel();
    }

    private void Update()
    {
        //Debug.Log("PauseScript_Net => Update => Antes del Owner");
        
        //Debug.Log("PauseScript_Net => Update => IsOwner       : " + base.IsOwner);
        //Debug.Log("PauseScript_Net => Update => Owner.ClientId: " + base.Owner.ClientId);
        ////Debug.Log("PauseScript_Net => Update => Owner.ClientId: " + base.Owner.CustomData.ToString());

        if (base.IsOwner)
        {
            //Debug.Log("PauseScript_Net => Update => Después del Owner");

            PauseMode();
        }
        //PauseMode();
    }

    #endregion Unity Methods




    #region Local Methods

    public void ShowPanel(GameObject _panel)
    {
        //Debug.Log("PauseScript_Net => ShowPanel => Antes del Owner");

        //Debug.Log("PauseScript_Net => ShowPanel => IsOwner: " + base.IsOwner + " => Owner: " + base.Owner);

        if (base.IsOwner)
        {
            //Debug.Log("PauseScript_Net => ShowPanel => Después del Owner");

            _panel.SetActive(true);
        }
    }

    public void HidePanel (GameObject _panel)
    {
        //Debug.Log("PauseScript_Net => HidePanel => Antes del Owner");

        //Debug.Log("PauseScript_Net => HidePanel => IsOwner: " + base.IsOwner + " => Owner: " + base.Owner);

        if (base.IsOwner)
        {
            //Debug.Log("PauseScript_Net => HidePanel => Después del Owner");

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
    //[ObserversRpc(IncludeOwner = true)]
    //public void SetInitPanel()
    //{
    //    Debug.Log("PauseScript => SetInitPanel");

    //    Debug.Log("PauseScript => SetInitPanel => IsOwner: " + base.IsOwner);

    //    //_optionsPanel.SetActive(true);
    //    _startMenuNet.ShowOptionsPanel();
    //    //_exitHallPanel.SetActive(false);
    //    _startMenuNet.HideExitHallPanel();
    //    //_exitAppPanel.SetActive(false);
    //    _startMenuNet.HideExitAppPanel();
    //}

    public void PauseMode()
    {
        //Debug.Log("PauseScript_Net => PauseMode");

        //Debug.Log("PauseScript_Net => PauseMode => IsOwner: " + base.IsOwner + " => Owner: " + base.Owner);


        if (_fpsCameraController == null)
        {
            //Debug.Log("PauseScript_Net => PauseMode => _fpsCameraController: null");
            return;
        }

        //Debug.Log("PauseScript_Net => PauseMode => Keyboard.current: " + Keyboard.current.escapeKey.isPressed);

        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            //Debug.Log("PauseScript_Net => PauseMode => _fpsCameraController.isPaused: " + _fpsCameraController.isPaused);

            _fpsCameraController.isPaused = !_fpsCameraController.isPaused;

            //Debug.Log("PauseScript_Net => PauseMode => _fpsCameraController.isPaused: " + _fpsCameraController.isPaused);

            //_optionsPanel.SetActive(_fpsCameraController.isPaused);
            _startMenuNet.SetOptionsPanel(_fpsCameraController.isPaused);

            //_exitHallPanel.SetActive(false);
            _startMenuNet.HideExitHallPanel();
            //_exitAppPanel.SetActive(false);
            _startMenuNet.HideExitAppPanel();
        }
    }

    #endregion Local Methods
}
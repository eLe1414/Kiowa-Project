using UnityEngine;

public class StartMenu_Net : MonoBehaviour
{
    #region Local Variables

    [Header("Paneles del Start Menú")]
    [SerializeField, Tooltip("Panel de Opciones")]
    private GameObject _optionsPanel;

    [SerializeField, Tooltip("Panel de Salida a la habitación")]
    private GameObject _exitHallPanel;

    [SerializeField, Tooltip("Panel de Salida de la aplicación")]
    private GameObject _exitAppPanel;

    #endregion Local Variables




    #region Class Properties

    #endregion Class Properties




    #region Unity Methods

    private void Awake()
    {
        HideOptionsPanel();
        HideExitHallPanel();
        HideExitAppPanel();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        //Debug.Log("StartMenu_Net => Update => Estado del componente: " + gameObject.activeSelf);

    }   // END Update

    #endregion Unity Methods




    #region Local Methods

    public void SetOptionsPanel(bool status)
    {
        //Debug.Log("StartMenu_Net => SetOptionsPanel");

        _optionsPanel.SetActive(status);
    }

    public void ShowOptionsPanel()
    {
        //Debug.Log("StartMenu_Net => ShowOptionsPanel");

        _optionsPanel.SetActive(true);
    }

    public void HideOptionsPanel()
    {
        //Debug.Log("StartMenu_Net => HideOptionsPanel");

        _optionsPanel.SetActive(false);
    }

    public void ShowExitHallPanel()
    {
        //Debug.Log("StartMenu_Net => ShowExitHallPanel");

        _exitHallPanel.SetActive(true);
    }

    public void HideExitHallPanel()
    {
        //Debug.Log("StartMenu_Net => HideExitHallPanel");

        _exitHallPanel.SetActive(false);
    }

    public void ShowExitAppPanel()
    {
        //Debug.Log("StartMenu_Net => ShowExitAppPanel");

        _exitAppPanel.SetActive(true);
    }

    public void HideExitAppPanel()
    {
        //Debug.Log("StartMenu_Net => HideExitAppPanel");

        _exitAppPanel.SetActive(false);
    }

    #endregion Local Methods

}   // END Class
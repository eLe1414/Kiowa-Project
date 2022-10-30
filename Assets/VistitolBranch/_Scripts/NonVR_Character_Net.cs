using FishNet.Object;
using UnityEngine;

public class NonVR_Character_Net : NetworkBehaviour
{
    #region Local Variables

    [SerializeField, Tooltip("Menú de opciones")]
    private GameObject _startMenu;

    #endregion Local Variables




    #region Class Properties

    #endregion Class Properties




    #region Unity Methods

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }   // END Update

    #endregion Unity Methods




    #region Local Methods

    //[ObserversRpc(IncludeOwner = true)]
    //public void ShowPanel(GameObject _panel)
    //{
    //    Debug.Log("NonVR_Character_Net => ShowPanel => Antes del Owner");

    //    Debug.Log("NonVR_Character_Net => ShowPanel => IsOwner: " + base.IsOwner);

    //    if (base.IsOwner)
    //    {
    //        Debug.Log("NonVR_Character_Net => ShowPanel => Después del Owner");

    //        _startMenu.SetActive(true);
    //    }
    //}

    //[ObserversRpc(IncludeOwner = true)]
    //public void HidePanel(GameObject _panel)
    //{
    //    Debug.Log("NonVR_Character_Net => HidePanel => Antes del Owner");

    //    Debug.Log("NonVR_Character_Net => HidePanel => IsOwner: " + base.IsOwner);

    //    if (base.IsOwner)
    //    {
    //        Debug.Log("NonVR_Character_Net => HidePanel => Después del Owner");

    //        _startMenu.SetActive(false);
    //    }
    //}

    #endregion Local Methods

}   // END Class
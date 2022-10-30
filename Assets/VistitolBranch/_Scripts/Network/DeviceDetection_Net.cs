using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class DeviceDetection_Net : MonoBehaviour
{
    
    [SerializeField, Tooltip("Player para modo \"VR\"")]
    private XROrigin xrOrigin;
    
    [SerializeField, Tooltip("Player para modo \"Desktop\"")]
    private GameObject desktopCharacter;

    private bool OnlyTestPurpose;
    private bool _vrDetection;

    public bool VRDetection
    {
        get
        {
            return _vrDetection;
        }
        private set
        {
            _vrDetection = value;
        }
    }

    private void Start()
    {
        Debug.Log("DeviceDetection_Net => Start => Identificamos si hay VR conectado");

#if (UNITY_EDITOR)
        OnlyTestPurpose = true;
#else
        OnlyTestPurpose = false;
#endif

        /*
         * Si estamos en el Editor de Unity no validamos las VR,
         * en el editor no funciona el emulador,
         * ejecutamos en modo escritorio directamente
         */

        // Informamos modo de ejecución para otras clases: "Desktop"
        VRDetection = false;

        if (!OnlyTestPurpose)
        {
            if (CheckForVR())
            {
                // Tenemos gafas conectadas, Validamos el dispositivo
                if (ValidateVR())
                {
                    // Dispositivo SI válido

                    // Informamos modo de ejecución para otras clases: "VR"
                    VRDetection = true;
                }
            }
        }

        // Ejecutamos en modo "Desktop" (false) o "VR" (true)
        SwitchDevice(VRDetection);
    }

    /// <summary>
    /// Chequeamos si hay dispositivo "VR" o no.
    /// </summary>
    /// <returns>True: si tenemos dispositivo conectado</returns>
    private bool CheckForVR()
    {
        Debug.Log("DeviceDetection_Net => CheckForVR");

        if (!XRSettings.isDeviceActive)
        {
            // TODO: DeviceDetection_Net => CheckForVR => Mostrar ventana informando de esto (lo de abajo)
            Debug.Log("You haven't Plugged In any headset yet! \n Continue in Desktop mode.");

            return false;
        }

        return true;
    }

    /// <summary>
    /// Validamos si el dispositivo conectado es válido.
    /// </summary>
    /// /// <returns>True: si el dispositivo conectado es válido</returns>
    private bool ValidateVR()
    {
        Debug.Log("DeviceDetection_Net => ValidateVR");

        if (XRSettings.isDeviceActive && XRSettings.loadedDeviceName == "MockHMD Display")
        {
            // TODO: DeviceDetection_Net => CheckForVR => Mostrar ventana informando de esto (lo de abajo)
            Debug.Log("DeviceDetection_Net => ValidateVR => Currently Using Mock HMD. \n Continue in Desktop mode.");

            return false;
        }
        else
        {
            Debug.Log("DeviceDetection_Net => ValidateVR => Got a Headset: " + XRSettings.loadedDeviceName +
                ", Active: " + XRSettings.isDeviceActive);

            return true;
        }
    }

    /// <summary>
    /// Preparamos el Player para su ejecución en modo "Desktop" o "VR"
    /// </summary>
    /// <param name="_vrDetection"></param>
    private void SwitchDevice(bool vrDetection)
    {
        Debug.Log("DeviceDetection_Net => SwitchDevice => vrDetection: " + vrDetection);

        if (vrDetection)
        {
            // Ejecutamos en modo "VR"

            XRGeneralSettings xrSettings = XRGeneralSettings.Instance;
            XRManagerSettings xrManager = xrSettings.Manager;
            XRLoader xrLoader = xrManager.activeLoader;

            Debug.Log("DeviceDetection_Net => SwitchDevice => xrSettings: " + xrSettings);

            if (xrSettings == null)
            {
                Debug.Log("XRGeneralSettings, and XRLoader  is null");
                return;
            }

            Debug.Log("DeviceDetection_Net => SwitchDevice => xrManager: " + xrManager);

            if (xrManager == null)
            {
                Debug.Log(" XRManagerSettings is null");
                return;
            }

            Debug.Log("DeviceDetection_Net => SwitchDevice => xrLoader: " + xrLoader);

            if (xrLoader == null)
            {
                Debug.Log("XRLoader is null");
                xrOrigin.gameObject.SetActive(false);
                desktopCharacter.SetActive(true);
                return;
            }

            Debug.Log("DeviceDetection_Net => SwitchDevice => Activamos el Player VR");

            // Activamos el Player para "VR"
            // Revisar que desactivando el padre no se fastidia nada
            //xrOrigin.gameObject.SetActive(true);
            xrOrigin.TrackablesParent.parent.parent.gameObject.SetActive(true);

            // Desactivamos el Player para "Desktop"
            desktopCharacter.SetActive(false);
        }
        else
        {
            // Ejecutamos en modo "Desktop"

            Debug.Log("DeviceDetection_Net => SwitchDevice => Activamos el Player Desktop");

            // Desactivamos el Player para "VR"
            //xrOrigin.gameObject.SetActive(false);
            xrOrigin.TrackablesParent.parent.parent.gameObject.SetActive(false);

            // Activamos el Player para "Desktop"
            desktopCharacter.SetActive(true);
        }
    }
}
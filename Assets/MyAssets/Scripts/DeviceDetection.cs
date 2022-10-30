using UnityEngine;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Management;

public class DeviceDetection : MonoBehaviour
{
    private bool OnlyTestPurpose;

    [SerializeField] bool fpsController;
    [SerializeField] XROrigin xrOrigin;
    [SerializeField] GameObject desktopCharacter;


    public bool vrDetection { get; private set; }

    void Start()
    {

        if (fpsController)
            vrDetection = false;
        else
            vrDetection = true;

#if (UNITY_EDITOR) 
        OnlyTestPurpose = true;
#elif(!UNITY_EDITOR)
        OnlyTestPurpose = false;
#endif
        if (OnlyTestPurpose)
        {
            SwitchDevice(vrDetection);
        }
        else
        {
            if (!XRSettings.isDeviceActive)
                Debug.Log("You haven't Plugged In any headset yet!");
            else if (XRSettings.isDeviceActive && XRSettings.loadedDeviceName == "MockHMD Display")
            {
                vrDetection = false;
                SwitchDevice(vrDetection);
                Debug.Log("Currently Using Mock HMD");
            }
            else
            {
                vrDetection = true;
                SwitchDevice(vrDetection);
                Debug.Log("Got a Headset " + XRSettings.isDeviceActive);
            }
        }
    }

    void SwitchDevice(bool _vrDetection)
    {
        if (_vrDetection)
        {
            var xrSettings = XRGeneralSettings.Instance;
            var xrManager = xrSettings.Manager;
            var xrLoader = xrManager.activeLoader;

            if (xrSettings == null)
            {
                Debug.Log("XRGeneralSettings, and XRLoader  is null");
                return;
            }

            if (xrManager == null)
            {
                Debug.Log(" XRManagerSettings is null");
                return;
            }

            if (xrLoader == null)
            {
                Debug.Log("XRLoader is null");
                xrOrigin.gameObject.SetActive(false);
                desktopCharacter.SetActive(true);
                return;
            }

            Debug.Log("XRLoader is NOT null");
            xrOrigin.gameObject.SetActive(true);
            desktopCharacter.SetActive(false);
        }
        else
        {
            xrOrigin.gameObject.SetActive(false);
            desktopCharacter.SetActive(true);
        }
    }
}
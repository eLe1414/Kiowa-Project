using FishNet.Object;
using UnityEngine;

public class CameraControllerVR_Net : NetworkBehaviour
{
    #region Local Variables

    #endregion Local Variables




    #region Class Properties

    #endregion Class Properties




    #region Unity Methods

    public override void OnStartClient()
    {
        base.OnStartClient();

        //Debug.Log("CameraControllerVR_Net => OnStartClient");

        if (base.IsOwner)
        {
            //Debug.Log("CameraControllerVR_Net => OnStartClient: activamos la cámara");

            //Debug.Log("CameraControllerVR_Net => OnStartClient => IsOwner       : " + base.IsOwner);
            //Debug.Log("CameraControllerVR_Net => OnStartClient => Owner.ClientId: " + base.Owner.ClientId);

            //Debug.Log("CameraControllerVR_Net => OnStartClient => Owner.ClientId: " + base.Owner.Objects);

            //foreach (NetworkObject obj in base.Owner.Objects)
            //{
            //    Debug.Log("CameraControllerVR_Net => OnStartClient => obj.transform.name: " + obj.transform.name);
            //}

            gameObject.SetActive(true);

        }
    }

    #endregion Unity Methods




    #region Local Methods

    #endregion Local Methods

}   // END Class
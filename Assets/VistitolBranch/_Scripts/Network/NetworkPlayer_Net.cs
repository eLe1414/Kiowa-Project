using FishNet.Object;
using Unity.XR.CoreUtils;
using UnityEngine;

public class NetworkPlayer_Net : NetworkBehaviour
{
    #region Local Variables

    [Header("Componentes del Avatar")]
    [SerializeField, Tooltip("Cabeza del avatar, es la cámara")]
    private Transform _head;

    [SerializeField, Tooltip("Mano izquierda del avatar")]
    private Transform _leftHand;

    [SerializeField, Tooltip("Mano derecha del avatar")]
    private Transform _rightHand;

    [Header("Componentes del Rig XR original")]
    [SerializeField, Tooltip("Cabeza del Rig, es la cámara")]
    private Transform _headRig;

    [SerializeField, Tooltip("Mano izquierda del Rig")]
    private Transform _leftHandRig;

    [SerializeField, Tooltip("Mano derecha del Rig")]
    private Transform _rightHandRig;

    #endregion Local Variables




    #region Class Properties

    #endregion Class Properties




    #region Unity Methods

    private void Start()
    {
        XROrigin xrOrigin = FindObjectOfType<XROrigin>();

        //Debug.Log("NetworkPlayer_Net => Start => xrOrigin: " + xrOrigin);

        //if (xrOrigin == null)
        //{
        //    Debug.Log("NetworkPlayer_Net => Start => xrOrigin: NULL");
        //}

        //Debug.Log("NetworkPlayer_Net => Start => xrOrigin: " + xrOrigin.name);

        _headRig = xrOrigin.transform.Find("Camera Offset/Main Camera");
        _leftHandRig = xrOrigin.transform.Find("Camera Offset/LeftHand Controller (GrabItems)");
        _rightHandRig = xrOrigin.transform.Find("Camera Offset/Right_Hand_Ray Interactor (Teleport)");
    }

    private void Update()
    {
        if (base.IsOwner)
        {
            // No estoy seguro de si hacer esto
            _head.gameObject.SetActive(false);
            _leftHand.gameObject.SetActive(false);
            _rightHand.gameObject.SetActive(false);

            // No se puede usar esto ya que "CommonUsages" hace referencia a valores locales, no se refrescarían en el servidor
            //MapPosition(_head, XRNode.Head);
            //MapPosition(_leftHand, XRNode.LeftHand);
            //MapPosition(_rightHand, XRNode.RightHand);

            MapPosition(_head, _headRig);
            MapPosition(_leftHand, _leftHandRig);
            MapPosition(_rightHand, _rightHandRig);
        }

    }   // END Update

    #endregion Unity Methods




    #region Local Methods

    /// <summary>
    /// Mapeamos la posición de cada uno de los componentes.
    /// </summary>
    /// <param name="target">Componente a seguir (cabeza y manos)</param>
    /// <param name="xrNode">Componente XR</param>
    //private void MapPosition(Transform target, XRNode xrNode)
    private void MapPosition(Transform target, Transform rigTransform)
    {
        // No se puede usar esto ya que "CommonUsages" hace referencia a valores locales, no se refrescarían en el servidor
        //InputDevices.GetDeviceAtXRNode(xrNode).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        //InputDevices.GetDeviceAtXRNode(xrNode).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.SetPositionAndRotation(rigTransform.position, rigTransform.rotation);
    }

    #endregion Local Methods

}   // END Class
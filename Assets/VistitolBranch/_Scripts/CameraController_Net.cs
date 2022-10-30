using Cinemachine;
using FishNet.Object;
using UnityEngine;

public class CameraController_Net : NetworkBehaviour
{
    #region Local Variables

    #endregion Local Variables




    #region Class Properties

    #endregion Class Properties




    #region Unity Methods

    private void Awake()
    {
        FirstObjectNoftifier_Net.OnFirstObjectSpawned += FirstObjectNoftifier_OnFirstObjectSpawned;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }   // END Update

    private void OnDestroy()
    {
        FirstObjectNoftifier_Net.OnFirstObjectSpawned -= FirstObjectNoftifier_OnFirstObjectSpawned;
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (base.IsOwner)
        {
            gameObject.SetActive(true);
        }
    }

    #endregion Unity Methods




    #region Local Methods

    /// <summary>
    /// Llamado cuando se crea el primer cliente local.
    /// </summary>
    /// <param name="obj">Cliente creado</param>
    private void FirstObjectNoftifier_OnFirstObjectSpawned(Transform obj)
    {
        CinemachineVirtualCamera vc = GetComponent<CinemachineVirtualCamera>();
        vc.Follow = obj;
        vc.LookAt = obj;
    }

    #endregion Local Methods

}   // END Class
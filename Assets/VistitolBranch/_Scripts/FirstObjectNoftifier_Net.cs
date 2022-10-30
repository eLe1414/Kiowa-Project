using FishNet.Object;
using System;
using UnityEngine;

public class FirstObjectNoftifier_Net : NetworkBehaviour
{
    #region Local Variables

    public static event Action<Transform> OnFirstObjectSpawned;

    #endregion Local Variables




    #region Class Properties

    #endregion Class Properties




    #region Unity Methods

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (base.IsOwner)
        {
            // LocalConnection: devuelve la conexión del cliente que hace la llamada
            // FirstObject: primer objeto creado en el cliente
            NetworkObject nob = base.LocalConnection.FirstObject;

            // Si el primer objeto es este objeto
            if (nob == base.NetworkObject)
            {
                OnFirstObjectSpawned?.Invoke(transform);
            }
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }   // END Update

    #endregion Unity Methods




    #region Local Methods

    #endregion Local Methods

}   // END Class
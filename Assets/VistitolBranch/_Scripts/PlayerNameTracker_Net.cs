using FishNet.Connection;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Transporting;
using System;
using UnityEngine;

/// <summary>
/// Selección del nombre del Player y su sincronización con el servidor.
/// </summary>
public class PlayerNameTracker_Net : NetworkBehaviour
{
    #region Local Variables

    /// <summary>
    /// Instancia de este objeto (Singleton).
    /// </summary>
    private static PlayerNameTracker_Net _instance;

    /// <summary>
    /// Se llama cuando un jugador cambia de nombre.
    /// </summary>
    public static event Action<NetworkConnection, string> OnNameChange;


    /// <summary>
    /// Coleccion con los nombres de los jugadores de esa conexion.
    /// </summary>
    [SyncObject]
    private readonly SyncDictionary<NetworkConnection, string> _playerNames = new SyncDictionary<NetworkConnection, string>();

    #endregion Local Variables




    #region Class Properties

    #endregion Class Properties




    #region Unity Methods

    private void Awake()
    {
        _instance = this;
        _playerNames.OnChange += _playerNames_OnChange;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }   // END Update

    #endregion Unity Methods




    #region Local Methods

    public override void OnStartServer()
    {
        base.OnStartServer();
        base.NetworkManager.ServerManager.OnRemoteConnectionState += ServerManager_OnRemoteConnectionState;
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
        base.NetworkManager.ServerManager.OnRemoteConnectionState -= ServerManager_OnRemoteConnectionState;
    }

    /// <summary>
    /// Opcional, se llama cuando la colección "_playerNames" cambia.
    /// </summary>
    /// <param name="op"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="asServer"></param>
    private void _playerNames_OnChange(SyncDictionaryOperation op, NetworkConnection key, string value, bool asServer)
    {
        if (op == SyncDictionaryOperation.Add || op == SyncDictionaryOperation.Set)
        {
            OnNameChange?.Invoke(key, value);
        }
    }

    /// <summary>
    /// Se llama cuando el estado de una conexion remota de cliente cambia.
    /// </summary>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    private void ServerManager_OnRemoteConnectionState(NetworkConnection arg1, RemoteConnectionStateArgs arg2)
    {
        if (arg2.ConnectionState != RemoteConnectionState.Started)
        {
            _playerNames.Remove(arg1);
        }
    }



    /// <summary>
    /// Devielve el nombre del jugador.
    /// Funciona en cliente y Servidor.
    /// </summary>
    /// <param name="conn"></param>
    /// <returns></returns>
    public static string GetPlayerName(NetworkConnection conn)
    {
        if (_instance._playerNames.TryGetValue(conn, out string result))
        {
            return result;
        }
        else
        {
            return string.Empty;
        }
    }




    /// <summary>
    /// Permite a los clientes cambiar su nombre.
    /// Solo los clientes pueden llamar a este método.
    /// </summary>
    /// <param name="name"></param>
    [Client]
    public static void SetName(string name)
    {
        _instance.ServerSetName(name);
    }


    /// <summary>
    /// Pone el nombre en el servidor.
    /// Envía mensajes al servidor.
    /// Nadie va a poseer el script "PlayerNameTracker" (false), los clientes pueden usarlo.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="sender"></param>
    [ServerRpc(RequireOwnership = false)]
    private void ServerSetName(string name, NetworkConnection sender = null)
    {
        _playerNames[sender] = name;
    }

    #endregion Local Methods

}   // END Class
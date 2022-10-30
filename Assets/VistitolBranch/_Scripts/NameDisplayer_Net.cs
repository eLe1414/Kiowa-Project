using FishNet.Connection;
using FishNet.Object;
using TMPro;
using UnityEngine;

public class NameDisplayer_Net : NetworkBehaviour
{
    #region Local Variables

    [SerializeField]
    private TextMeshPro _text;

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

    private void SetName()
    {
        string result = null;

        // Owner does not exist
        if (base.Owner.IsValid)
        {
            result = PlayerNameTracker_Net.GetPlayerName(base.Owner);
        }

        if (string.IsNullOrEmpty(result))
        {
            result = "Unset";
        }

        _text.text = result;
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        //PDTE: Debemos informar aquí el nombre a mostrar

        SetName();

        PlayerNameTracker_Net.OnNameChange += PlayerNameTracker_OnNameChange;
    }

    public override void OnStopClient()
    {
        base.OnStopClient();

        PlayerNameTracker_Net.OnNameChange -= PlayerNameTracker_OnNameChange;
    }

    public override void OnOwnershipClient(NetworkConnection prevOwner)
    {
        base.OnOwnershipClient(prevOwner);

        SetName();
    }

    private void PlayerNameTracker_OnNameChange(NetworkConnection arg1, string arg2)
    {
        if (arg1 != base.Owner)
        {
            return;
        }

        SetName();
    }

    #endregion Local Methods

}   // END Class
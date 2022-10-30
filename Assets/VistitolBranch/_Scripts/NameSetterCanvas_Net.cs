using TMPro;
using UnityEngine;

public class NameSetterCanvas_Net : MonoBehaviour
{
    #region Local Variables

    [SerializeField]
    private TMP_InputField _input;

    #endregion Local Variables




    #region Class Properties

    #endregion Class Properties




    #region Unity Methods

    private void Awake()
    {
        // Pulso "intro" en el Input Text
        _input.onSubmit.AddListener(_input_onSubmit);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }   // END Update

    #endregion Unity Methods




    #region Local Methods

    private void _input_onSubmit(string text)
    {
        PlayerNameTracker_Net.SetName(text);
    }

    #endregion Local Methods

}   // END Class
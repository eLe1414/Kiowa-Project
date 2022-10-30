using UnityEngine;

public class LookAtCamera_Net : MonoBehaviour
{
    #region Local Variables

    private Camera _camera;

    #endregion Local Variables




    #region Class Properties

    #endregion Class Properties




    #region Unity Methods

    private void Start()
    {
        
    }

    private void Update()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
        }

        // Por si la cámara no está en la escena
        if (_camera == null)
        {
            return;
        }

        transform.LookAt(_camera.transform);

    }   // END Update

    #endregion Unity Methods




    #region Local Methods

    #endregion Local Methods

}   // END Class
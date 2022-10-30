using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialMenu_Hector : MonoBehaviour
{
    #region Local Variables

    [Header("Configuraci�n del men�")]
    [SerializeField, Tooltip("Lista de los Items del men�")]
    private List<RadialMenuItem_Hector> _radialMenuItems;

    [SerializeField, Tooltip("Item prefab")]
    private GameObject _radialMenuItemPrefab;

    [SerializeField, Tooltip("Radio del men�")]
    private float _radius = 300f;

    [Header("Configuraci�n de los Items")]
    [SerializeField, Tooltip("Lista de los Items del men�")]
    private List<Texture> _radialMenuItemIcons;

    [Header("Componentes del Men� Radial")]
    [SerializeField, Tooltip("Imagen del Men� Radial")]
    private RawImage _radialIconRawImage;

    [Header("Variables Corutinas para los efectos")]
    [SerializeField, Tooltip("Posici�n central")]
    private Vector3 _endPosition = new Vector3(0f, 0f, 0f);


    private const float NUMBER_OF_FLAGS = 8;
    public GameObject emojiIcon;

   

    #endregion Local Variables




    #region Class Properties

    #endregion Class Properties




    #region Unity Methods

    private void Start()
    {
        _radialMenuItems = new List<RadialMenuItem_Hector>();
    }

    private void Update()
    {
        
    }   // END Update

    #endregion Unity Methods




    #region Local Methods

    /// <summary>
    /// Si el men� radial est� abierto lo cerramos o al contrario.
    /// </summary>
    public void Toggle()
    {
        if (_radialMenuItems.Count == 0)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    /// <summary>
    /// Abrimos el men� radial.
    /// </summary>
    private void Open()
    {
        for (int i = 0; i < NUMBER_OF_FLAGS; i++)
        {
            // PDTE: Ver c�mo mandar el nombre, si se ha de mostrar
            AddRadialMenuItem("Button: " + i.ToString(), _radialMenuItemIcons[i], SetTargetRadialIcon);
        }

        Rearrange();
    }

    /// <summary>
    /// Cerramos el men� Radial.
    /// </summary>
    private void Close()
    {
        for (int i = 0; i < NUMBER_OF_FLAGS; i++)
        {
            GameObject radialMenuItem = _radialMenuItems[i].gameObject;

            Destroy(radialMenuItem);
        }

        _radialMenuItems.Clear();
    }

    /// <summary>
    /// A�adimos los Items individuales al men�.
    /// </summary>
    /// <param name="itemText">Texto del Item</param>
    private void AddRadialMenuItem(string itemText, Texture texture, RadialMenuItem_Hector.RadialMenuItemHectorDelegate callback_Hector)
    {
        GameObject newRadialMenu = Instantiate(_radialMenuItemPrefab, transform);

        RadialMenuItem_Hector radialMenuItem = newRadialMenu.GetComponent<RadialMenuItem_Hector>();
        
        radialMenuItem.SetText(itemText);
        radialMenuItem.SetRawImageIcon(texture);
        radialMenuItem.SetRadialMenuItemHectorDelegate(callback_Hector);

        radialMenuItem.name = itemText;

        _radialMenuItems.Add(radialMenuItem);
    }

    /// <summary>
    /// Reordena las entradas.
    /// </summary>
    private void Rearrange()
    {
        // Calculamos cuanto han de gira las entradas
        // Dividimos 360 entre el n�mero de entradas totales
        float radiansOfSeparation = (Mathf.PI * 2) / _radialMenuItems.Count;

        // Calculamos la "x" y la "y" usando el seno y coseno
        for (int i = 0; i < _radialMenuItems.Count; i++)
        {
            float x = Mathf.Sin(radiansOfSeparation * i) * _radius;
            float y = Mathf.Cos(radiansOfSeparation * i) * _radius;

            _radialMenuItems[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(x, y, 0);
        }
    }

    /// <summary>
    /// Se ejecuta cuando se hace click en el icono del Men� radial por medio de un delegado.
    /// Para poner la imagen en el bot�n central.
    /// </summary>
    /// <param name="radialMenuItem">Item pulsado</param>
    private void SetTargetRadialIcon(RadialMenuItem_Hector radialMenuItem)
    {
        _radialIconRawImage.texture = radialMenuItem.GetRawImageIcon();
        emojiIcon.SetActive(true);
        IconFader.THIS.StartIconFade();
        
    }

      


    #endregion Local Methods

}   // END Class
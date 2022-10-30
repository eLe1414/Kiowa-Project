using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

<<<<<<<< HEAD:Assets/VistitolBranch/_Scripts/UI/RadialMenuItem_Hector.cs
public class RadialMenuItem_Hector : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
========
public class RadialMenuItem_Victor : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
>>>>>>>> main:Assets/VistitolBranch/_Scripts/UI/RadialMenuItem_Victor.cs
{
    #region Local Variables

    [Header("Componentes del Item")]
    [SerializeField, Tooltip("Texto del Item")]
    private TextMeshProUGUI _textMesh;

    [SerializeField, Tooltip("Imagen del Item")]
    private RawImage _iconRawImage;

    [Header("Componentes Auxiliares")]
    private RectTransform _rectTransform;

    [Header("Variables Corutinas para los efectos")]
    [SerializeField, Tooltip("Escala original")]
    private Vector3 _startScale = new Vector3(1.0f, 1.0f, 1.0f);

    [SerializeField, Tooltip("Escala destino")]
    private Vector3 _endScale = new Vector3(1.6f, 1.6f, 1.6f);


    [Tooltip("Controla de Corutina: OnPointerEnter")]
    private Coroutine _onPointerEnter;

    [Tooltip("Controla de Corutina: OnPointerExit")]
    private Coroutine _onPointerExit;



    // Tiempo en el que se aplica el Decremento/Incremento de la escala (del 60%)
    private const float MAX_TIME_SCALE = 0.25f;


<<<<<<<< HEAD:Assets/VistitolBranch/_Scripts/UI/RadialMenuItem_Hector.cs
    public delegate void RadialMenuItemHectorDelegate(RadialMenuItem_Hector radialMenuItem);
========
    public delegate void RadialMenuItemDelegate(RadialMenuItem_Victor radialMenuItem);
>>>>>>>> main:Assets/VistitolBranch/_Scripts/UI/RadialMenuItem_Victor.cs

    private RadialMenuItemHectorDelegate _radialMenuItemDelegate;


    #endregion Local Variables




    #region Class Properties

    #endregion Class Properties




    #region Unity Methods

    private void Awake()
    {
        _rectTransform = _iconRawImage.GetComponent<RectTransform>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }   // END Update

    #endregion Unity Methods




    #region Local Methods

    /// <summary>
    /// Arrancamos la Coroutina de "OnPointerEnter".
    /// </summary>
    private void StartOnPointerEnterCoroutine()
    {
        _onPointerEnter = StartCoroutine(nameof(OnPointerEnterCorutine));
    }

    /// <summary>
    /// Arrancamos la Coroutina de "OnPointerExit".
    /// </summary>
    private void StartOnPointerExitCoroutine()
    {
        _onPointerExit = StartCoroutine(nameof(OnPointerExitCorutine));
    }

    /// <summary>
    /// Hacemos los efectos de aumento usando una Coroutina.
    /// </summary>
    private IEnumerator OnPointerEnterCorutine()
    {
        float elapsedTime = 0;

        _rectTransform.transform.localScale = _startScale;

        while (elapsedTime < MAX_TIME_SCALE)
        {
            _rectTransform.localScale = Vector3.Lerp(_rectTransform.transform.localScale, _endScale, (elapsedTime / MAX_TIME_SCALE));

            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// Hacemos los efectos de disminuci�n usando una Coroutina.
    /// </summary>
    private IEnumerator OnPointerExitCorutine()
    {
        float elapsedTime = 0;

        _rectTransform.transform.localScale = _endScale;

        while (elapsedTime < MAX_TIME_SCALE)
        {
            _rectTransform.localScale = Vector3.Lerp(_rectTransform.transform.localScale, _startScale, (elapsedTime / MAX_TIME_SCALE));

            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// Ponemos el texto recibido en el texto del Item.
    /// </summary>
    /// <param name="itemText">Texto a poner</param>
    public void SetText(string itemText)
    {
        _textMesh.text = itemText;
    }

    /// <summary>
    /// Ponemos la imagen en el icono del Item.
    /// </summary>
    /// <param name="texture">Imagen a poner</param>
    public void SetRawImageIcon(Texture texture)
    {
        _iconRawImage.texture = texture;
    }

    /// <summary>
    /// Devolvemos la imagen del icono del Item.
    /// </summary>
    /// <returns>Imagen del icono actual</returns>
    public Texture GetRawImageIcon()
    {
        return _iconRawImage.texture;
    }

    /// <summary>
    /// Delegado a ejecutar cuando se hace click en el icono del men� radial.
    /// </summary>
    /// <param name="callback_Hector">Delegado</param>
    public void SetRadialMenuItemHectorDelegate(RadialMenuItemHectorDelegate callback_Hector)
    {
        _radialMenuItemDelegate = callback_Hector;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _radialMenuItemDelegate?.Invoke(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartOnPointerEnterCoroutine();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartOnPointerExitCoroutine();
    }

    #endregion Local Methods

}   // END Class
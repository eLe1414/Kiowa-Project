using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customization : MonoBehaviour
{
    // Paneles
    [Header("Paneles")]
    public GameObject interactable;
    public GameObject customMenu;

    // Customizacion
    [Header("Custom Menus")]
    public GameObject customHairAndFacial;
    public GameObject customHair;
    public GameObject customFacial;
    public GameObject customCloth;
    public GameObject customBody;
    public GameObject customAccesories;

    // Meshes
    [Header("Meshes")]
    // ScriptableObject
    public AssetSO assets;

    public MeshFilter body;
    public MeshFilter hair;
    public MeshFilter facialHair;
    //public MeshFilter cloth;
    public MeshFilter accessory;

    

    // Start is called before the first frame update
    void Start()
    {
        ShowPanel(interactable);
        HidePanel(customMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Función para cuando pulsas el boton para abrir el menu de customizacion
    public void OpenCustomMenu()
    {
        HidePanel(interactable);
        ShowPanel(customMenu);
    }

    // Funcion para cuando pulsas el boton de customizar el pelo
    public void CustomHairButton()
    {
        ShowPanel(customHairAndFacial);
        HidePanel(customCloth);
        HidePanel(customBody);
        HidePanel(customAccesories);
    }

    // Funcion para cuando pulsas el boton de customizar la vestimenta
    public void CustomClothButton()
    {
        ShowPanel(customCloth);
        HidePanel(customHairAndFacial);
        HidePanel(customBody);
        HidePanel(customAccesories);
    }

    // Funcion para cuando pulsas el boton de customizar el cuerpo
    public void CustomBodyButton()
    {
        ShowPanel(customBody);
        HidePanel(customCloth);
        HidePanel(customHairAndFacial);
        HidePanel(customAccesories);
    }

    // Funcion para cuando pulsas el boton de customizar los accesorios
    public void CustomAccesoriesButton()
    {
        ShowPanel(customAccesories);
        HidePanel(customCloth);
        HidePanel(customBody);
        HidePanel(customHairAndFacial);
    }

    public void RandomizerButton()
    {
        body.mesh = assets.bodies[Random.Range(0, assets.bodies.Length)];
        hair.mesh = assets.hairs[Random.Range(0, assets.hairs.Length)];
        facialHair.mesh = assets.facialHairs[Random.Range(0, assets.facialHairs.Length)];
        //cloth.mesh = assets.clothes[Random.Range(0, assets.clothes.Length)];
        accessory.mesh = assets.accessories[Random.Range(0, assets.accessories.Length)];
    }

    public void FinalizarButton()
    {
        HidePanel(customMenu);
        ShowPanel(interactable);
    }

    public void SelectHair()
    {
        HidePanel(customFacial);
        ShowPanel(customHair);
    }

    public void SelectFacial()
    {
        HidePanel(customHair);
        ShowPanel(customFacial);
    }

    //-------------------------------------------------------------

    // Funciones para cambiar a distintas opciones de pelo
    public void SetHair01() {CustomHair(0);}

    public void SetHair02() {CustomHair(1);}

    public void SetHair03() {CustomHair(2);}

    public void SetHair04() {CustomHair(3);}

    //-------------------------------------------------------------

    // Funciones para cambiar a distintas opciones de vello facial
    public void SetFacialHair01() {CustomFacialHair(0);}

    public void SetFacialHair02() {CustomFacialHair(1);}

    public void SetFacialHair03() {CustomFacialHair(2);}

    public void SetFacialHair04() {CustomFacialHair(3);}


    //-------------------------------------------------------------

    // Funciones para cambiar a distintas opciones de cuerpo
    public void SetBody01() {CustomBody(0);}

    public void SetBody02() {CustomBody(1);}

    //-------------------------------------------------------------

    // Funciones para cambiar a distintas opciones de accesorios

    public void SetAccesories01() {CustomAccessory(0);}

    public void SetAccesories02() {CustomAccessory(1);}

    public void SetAccesories03() {CustomAccessory(2);}

    public void SetAccesories04() {CustomAccessory(3);}

    //-------------------------------------------------------------

    public void ShowPanel(GameObject _panel)
    {
        _panel.SetActive(true);
    }

    public void HidePanel(GameObject _panel)
    {
        _panel.SetActive(false);
    }

    // Asignación de un peinado predeterminado a nuestro avatar (Autor: MariaP)
    public void CustomHair(int _numInArray){
        hair.mesh = assets.hairs[_numInArray];
    
    }

    // Asignación de un vello facial predeterminado a nuestro avatar (Autor: MariaP)
    public void CustomFacialHair(int _numInArray){
        facialHair.mesh = assets.facialHairs[_numInArray];
    
    }

    // Asignación de un accesorio predeterminado a nuestro avatar (Autor: MariaP)
    public void CustomAccessory(int _numInArray){
        accessory.mesh = assets.accessories[_numInArray]; 
    
    }

    // Asignación de un genero predeterminado a nuestro avatar (Autor: MariaP)
    public void CustomBody(int _numInArray){
        body.mesh = assets.bodies[_numInArray]; 
    
    }
}

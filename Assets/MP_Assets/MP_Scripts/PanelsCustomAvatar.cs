using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsCustomAvatar : MonoBehaviour
{


    // ********** DEFINICIÓN DE VARIABLES **********

    public Customizer customizer;



    // ********** MÉTODOS PROPIOS **********

    // Asignación del peinado seleccionado en la UI
    public void SelectHair(int _value){
        customizer.CustomHair(_value);
    }

    // Asignación del vello facial seleccionado en la UI
    public void SelectFacialHair(int _value){
        customizer.CustomFacialHair(_value);
    }

    // Asignación de un accesorio seleccionado en la UI
    public void SelectAccessory(int _value){
        customizer.CustomAccessory(_value);
    }

    // Asignación de ropa
    public void SelectClothes(int _value){
        customizer.CustomCloth(_value);
    }

    // Asignación de cuerpo (morfología)
    public void SelectBody(int _value){
        customizer.CustomBody(_value);
    }

    public void AvatarRandom(){
        customizer.Randomize();
    }

   

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customizer : MonoBehaviour
{

    // ********** DEFINICIÓN DE VARIABLES **********

    public AssetSO assets;

    public MeshFilter body;
    public MeshFilter hair;
    public MeshFilter facialHair;
    public Material cloth;
    public MeshFilter accessory;


    // ********** FUNCIONES PREDETERMINADAS **********

    // Dotamos de aleatoridad al avatar cuando se comienza la configuración del mismo.
    void Start(){
        Randomize();
    }


    // ********** MÉTODOS PROPIOS **********


    // Asignación de assets aleatorios a nuestro avatar
    public void Randomize(){

        body.mesh = assets.bodies[Random.Range(0, assets.bodies.Length)];
        hair.mesh = assets.hairs[Random.Range(0, assets.hairs.Length)];
        facialHair.mesh = assets.facialHairs[Random.Range(0, assets.facialHairs.Length)];
        accessory.mesh = assets.accessories[Random.Range(0, assets.accessories.Length)];

        // si es un cuerpo de mujer se le asigna una textura dentro de los valores 4 a 7
        if(AmIAWoman()){
            cloth.mainTexture = assets.clothes [Random.Range(4, assets.clothes.Length)];

        } else cloth.mainTexture = assets.clothes[Random.Range(0, 4)];


    }

    // Asignación de una forma de cuerpo predeterminado para avatar
    public void CustomBody(int _numInArray){
        body.mesh = assets.bodies[_numInArray]; 
        
        if(AmIAWoman()){
            cloth.mainTexture = assets.clothes [4];

        } else cloth.mainTexture = assets.clothes[0];
    
    }

    // Asignación de un peinado predeterminado a nuestro avatar
    public void CustomHair(int _numInArray){
        hair.mesh = assets.hairs[_numInArray];
    
    }

    // Asignación de un tipo de vello facial predeterminado a nuestro avatar
    public void CustomFacialHair(int _numInArray){
        facialHair.mesh = assets.facialHairs[_numInArray]; 
    
    }

    // Asignación de un accesorio predeterminado a nuestro avatar
    public void CustomAccessory(int _numInArray){
        accessory.mesh = assets.accessories[_numInArray]; 
    
    }

    // Comprobamos si el cuerpo actual es e mujer para asignarle a posteriori una texturas determinadas
    public bool AmIAWoman(){

        if (body.GetComponent<MeshFilter>().mesh.name == "body.man Instance"){
            return false;

        }else return true;
    }

    // Asignación de ropa predeterminada a nuestro avatar
    public void CustomCloth(int _numInArray){
        cloth.mainTexture = assets.clothes[_numInArray]; 
    
    }



    

}

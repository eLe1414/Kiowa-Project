using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (menuName = "Character Assets", fileName = "New Character Asset")]

public class AssetSO : ScriptableObject
{

    // ********** DEFINICIÓN DE VARIABLES **********

    // [Assets: bodies, hair, facial hair, clothes, accessories]

    public Color[] SkinColor;

    public Mesh[] bodies;
    public Mesh[] hairs;
    public Mesh[] facialHairs;
    public Texture[] clothes;
    public Mesh[] accessories;

}

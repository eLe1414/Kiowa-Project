using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager THIS;

    public GameObject loginUI;
    public GameObject registerUI;

    private void Awake(){
        if (THIS==null){
            THIS=this;
        }
        else if (THIS!=null){
            Destroy(this);
        }
    }

    public void LoginScreen(){
        loginUI.SetActive(true);
        registerUI.SetActive(false);
    }

    public void RegisterScreen(){
        loginUI.SetActive(false);
        registerUI.SetActive(true);
    }
}

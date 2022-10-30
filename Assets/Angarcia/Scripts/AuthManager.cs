using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
   [Header("Login")]
   [SerializeField] private TMP_Text warningText=null;
   [SerializeField] private TMP_Text warningTextRegister=null;
   [SerializeField] private TMP_InputField loginPasswordInput=null;
   [SerializeField] private TMP_InputField loginUserNameInput=null;

   public void LogIn(){
      if(loginUserNameInput.text=="" || loginPasswordInput.text==""){
         warningText.text="Faltan campos por rellenar";
         return;
      }
      if(loginUserNameInput.text=="123456" && loginPasswordInput.text=="123456"){
         //SceneManager.LoadScene(0);
      }else{
         warningText.text="Usuario o contraeña incorrectos";
      }
   }

   public void Register(){
      warningTextRegister.text="No se permite registrar nuevos usuarios";
      
   }
}

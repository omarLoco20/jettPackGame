using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Space]
    [Header("Login")]
    public TMP_InputField newUserEmailInput;
    public TMP_InputField newUserPasswordInput;

    public Database updateUserEmailScript;

    public void ChangeUsername()
    {
        string newUserEmail = newUserEmailInput.text;
        string newUserPassword = newUserPasswordInput.text;

        if (!string.IsNullOrEmpty(newUserEmail))
        {
           
            if (IsValidEmail(newUserEmail))
            {
                Debug.Log("Correo electrónico válido: " + newUserEmail);
                // Continuar con el proceso de inicio de sesión
                updateUserEmailScript.ChangeUsername(newUserEmail);
                Debug.Log("Correo Cambiado Correctamente");
            }
            else
            {
                Debug.LogError("Formato de correo electrónico incorrecto");
            }
           

        }
        if(newUserPassword != null && IsValidEmail(newUserEmail))
        {
            // Continuar con el proceso de inicio de sesión
            updateUserEmailScript.UpdateScore(newUserPassword);
            Debug.Log("Contraseña Cambiada Correctamente");
        }
        Debug.Log("me ejecuté");

    }
    public void Auntentification()
    {
       
        if (newUserEmailInput.text == updateUserEmailScript.checkEmail())
        {
            Debug.Log("Inicio de Sesion Exitosa");
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Los datos que ingresastes no coinciden. Deseas crear una Cuenta nueva ?");
        }
    }
    public string GetNewUserName()
    {
        return newUserEmailInput.text;
    }
    bool IsValidEmail(string email)
    {
        // Verificar si el correo electrónico contiene "@gmail.com" para el inicio de sesion
        return email.EndsWith("@gmail.com");
    }
}

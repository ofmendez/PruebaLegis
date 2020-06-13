using System;
using System.Collections;
using System.Collections.Generic;
using MaterialUI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Login : MonoBehaviour {
    public AppManager appManager;
    public GameObject screenRegister;
    public GameObject screenLogin;
    public Button submit;
    public Button goToRegister;
    public InputField emailIf;
    public InputField passwordIf;
    Firebase.Auth.FirebaseAuth auth;
    public Toaster toaster;


    void Start() {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        submit.onClick.AddListener(() => {
            ValidateFields(emailIf.text, passwordIf.text);
        });
        goToRegister.onClick.AddListener(() => {
            screenRegister.GetComponent<Canvas> ().enabled =(true);
            screenLogin.GetComponent<Canvas> ().enabled =(false);
            Debug.Log("presionado link");
        });
    }
    public void ValidateFields(string email, string password) {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) {
            toaster.text = "Por favor completa todos los campos para continuar";
            toaster.PopupToast();
        } else if (emailIf.text.IndexOf('@') <= 0) {
            toaster.text = "El email ingresado no es válido.";
            toaster.PopupToast();
        } else {
            Signing(email, password);
        }
    }


    public void Signing(string email, string password) {
       
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled) {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
        
            goToRegister.onClick.Invoke();
             appManager.Enter();
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
            newUser.DisplayName, newUser.UserId);
        });

    }
    void Update() {

    }
}

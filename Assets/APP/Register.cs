using System.Collections;
using System.Collections.Generic;
using MaterialUI;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour {
    public AppManager appManager;
    public GameObject screenRegister;
    public GameObject screenLogin;
    public Button submit;
    public Button goToLogin;
    public InputField emailIf;
    public InputField passwordIf;
    public InputField confirmPasswordIf;
    public Toaster toaster;
    Firebase.Auth.FirebaseAuth auth;

    void Start() {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        submit.onClick.AddListener(() => {
            ValidateFields(emailIf.text, passwordIf.text, confirmPasswordIf.text);
        });
        goToLogin.onClick.AddListener(() => {
            screenLogin.SetActive(true);
            screenRegister.SetActive(false);
        });
    }

    public void ValidateFields(string email, string password, string confirmPassword) {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword)) {
            toaster.text = "Por favor completa todos los campos para continuar";
            toaster.PopupToast();
        } else if (emailIf.text.IndexOf('@') <= 0) {
            toaster.text = "El email ingresado no es válido.";
            toaster.PopupToast();
        } else if (!string.Equals(password, confirmPassword)) {
            toaster.text = "Los campos de contraseña y confirmación \n deben ser iguales";
            toaster.PopupToast();
        } else {
            CreateAccount(email, password);
        }

    }
    public void CreateAccount(string email, string password) {
        bool sign = false;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled) {
                toaster.text = "Error en el registro, intenta nuevamente.";
                toaster.PopupToast();
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                toaster.text = "Error en el registro, intenta nuevamente.";
                toaster.PopupToast();
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
                sign = true;

        });
        if (sign)
                appManager.CheckLogin();
    }
    void Update() {

    }
}

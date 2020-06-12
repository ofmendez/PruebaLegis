using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Login : MonoBehaviour {
    public Button submit;
    public Button goToRegister;
    public InputField userIf;
    public InputField passwordIf;
    Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

    void Start() {
        submit.onClick.AddListener(()=> {
            ValidateFields(userIf.text,passwordIf.text);
		});
    }
    public void ValidateFields(string user, string password) {
        // if
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

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }
    void Update() {

    }
}

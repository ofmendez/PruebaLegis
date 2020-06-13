using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Auth;
using Firebase.Unity.Editor;
using UnityEngine;

public class AuthManager : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject app;
    public GameObject back;
    public GameObject login;
    public GameObject register;
    Firebase.Auth.FirebaseAuth auth;
    void Start() {
     auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    public void SignOut() {

        auth.SignOut();
        back.GetComponent<Canvas> ().enabled =(true);
        login.GetComponent<Canvas> ().enabled =(true);
        register.GetComponent<Canvas> ().enabled =(false);
        app.GetComponent<Canvas> ().enabled =(false);
    }

  
    // Update is called once per frame
}

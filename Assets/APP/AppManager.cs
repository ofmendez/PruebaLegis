using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour {
    public GameObject app;
    public GameObject background;
    
    public GameObject login;
    public GameObject register;
    Firebase.Auth.FirebaseAuth auth;

    
    void Start() {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        CheckLogin();
    }


    // Update is called once per frame
    public void Enter() {
        Debug.Log("JODER");
            background.GetComponent<Canvas> ().enabled =(false);
            login.GetComponent<Canvas> ().enabled =(true);
            register.GetComponent<Canvas> ().enabled =(false);
            app.GetComponent<Canvas> ().enabled =(true);
    }
    public void GoToLogin() {
            background.GetComponent<Canvas> ().enabled =(true);
            app.GetComponent<Canvas> ().enabled =(false);
            login.GetComponent<Canvas> ().enabled =(true);
            register.GetComponent<Canvas> ().enabled =(false);
    }
    
    public void CheckLogin() {
        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        if (user != null) {
            Enter();
        
            string name = user.DisplayName;
            string email = user.Email;
            System.Uri photo_url = user.PhotoUrl;
            // The user's Id, unique to the Firebase project.
            // Do NOT use this value to authenticate with your backend server, if you
            // have one; use User.TokenAsync() instead.
            string uid = user.UserId;
        } else {
            GoToLogin();
        }
    }
}

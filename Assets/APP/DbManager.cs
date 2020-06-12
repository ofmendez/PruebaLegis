using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DbManager : MonoBehaviour {
    DatabaseReference reference;
    // Start is called before the first frame update
    void Start() {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://pruebalegis.firebaseio.com/");
        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        Initialize();
        WriteNewUser("0001", "fabian", "fabian@hotmail.com");
    }

    public async void Initialize() {
        var result = await FirebaseApp.CheckAndFixDependenciesAsync();
        if (result == DependencyStatus.Available) {

        } else {
            Debug.LogError("ALV");
        }
    }
    // Update is called once per frame
    public void WriteNewUser(string userId, string name, string email) {
        User user = new User(name, email);
        string json = JsonUtility.ToJson(user);

        reference.Child("users").Child(userId).SetRawJsonValueAsync(json);
        //SceneManager.LoadScene("ChooseLogged");
    }
}
public class User {
    public string username;
    public string email;

    public User() {
    }

    public User(string username, string email) {
        this.username = username;
        this.email = email;
    }
}
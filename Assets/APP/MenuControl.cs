using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour {
    Vector2 offPos;
    Vector2 onPos;
    Vector2 tempVec2;
    public Button closeButton;
    int state = 0;
    float animSpeed = 6f;

    void Start() {
        offPos = new Vector2(-Screen.width, 0);
        onPos = new Vector2(-Screen.width / 2, 0);
        transform.localPosition = offPos;
        // Debug.Log(transform.position.x + "  y " + transform.position.y);
        // Debug.Log(transform.localPosition.x + "  y " + transform.localPosition.y);
        closeButton.onClick.AddListener(() =>{
            Toggle();
            closeButton.gameObject.SetActive(false);
        });
    }

    public void Toggle() {
        if (state != 1)
            state = 1;
        else
            state = 2;
    }

    void Update() {
      //  Debug.Log(Time.deltaTime);
        if (state == 1) {
            if (transform.localPosition.x < onPos.x) {
                tempVec2 = transform.localPosition;
                tempVec2.x = Mathf.Lerp(tempVec2.x, onPos.x + 2, Time.deltaTime * animSpeed);
                transform.localPosition = tempVec2;
                closeButton.gameObject.SetActive(true);
            } else {
                transform.localPosition = onPos;
            }
        } else if (state == 2) {
            if (transform.localPosition.x > offPos.x) {
                tempVec2 = transform.localPosition;
                tempVec2.x = Mathf.Lerp(tempVec2.x, offPos.x - 2, Time.deltaTime * animSpeed);
                transform.localPosition = tempVec2;
            } else {
                closeButton.gameObject.SetActive(false);
                // Destroy(gameObject);
            }
        }
    }
}

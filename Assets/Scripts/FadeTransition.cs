using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeTransition : MonoBehaviour
{
    public float fadeInTime;

    private Image panel;

    /*********************************************************************/

    private void Awake()
    {
        this.gameObject.SetActive(true);
    }

    /*********************************************************************/

    // Use this for initialization
    private void Start()
    {        
        this.panel = GetComponent<Image>();
        //this.panel.color = new Color(this.panel.color.r, this.panel.color.g, this.panel.color.b, 1f);
        this.panel.CrossFadeAlpha(0, this.fadeInTime, false);
        Invoke("DeactivateGameObject", this.fadeInTime);
    }

    /*********************************************************************/

    // Simply deactivate the game object
    private void DeactivateGameObject()
    {
        this.gameObject.SetActive(false);
    }

}

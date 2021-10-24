using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject Button;
      public GameObject ControlsPanel;

    public Animator Controls;
    public Animator music;
     public GameObject Button2;
     public GameObject Button3;
     public GameObject CreditsPanel;
public GameObject Title;
     public Animator CreditsPanelAnim;
    public Animator CameraSwitch;
    public Animator VolumeSwitch;
    public GameObject QuitButton;
    public static bool Volume;

  public void Play(){
      QuitButton.SetActive(false);
      Title.SetActive(false);
       CreditsPanel.SetActive(false);
        Button3.SetActive(false);
      CameraFollow.PlayClicked = true;
      Button.SetActive(false);
          Button2.SetActive(false);
          ControlsPanel.SetActive(false);
      CameraSwitch.SetTrigger("Play");
  }
  public void ControlsActive(){
       
      Controls.SetTrigger("Switch");
  }

public void QuitGame(){
    Application.Quit();
}
public void EndMe(){
    SceneManager.LoadScene(0);
}
public void Start(){
    Volume = true;
    }
    
    public void ShowAbout(){
        CreditsPanelAnim.SetTrigger("Switch");
    }
    public void VolumeSwap(){
    
    VolumeSwitch.SetTrigger("Switch");
    music.SetTrigger("Switch");
    if(Volume == true){
        Volume = false;
    } else {
        Volume = true;
    }
}}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource DeathSound;

        public AudioSource WinSound;

  public float moveSpeed;
  public GameObject Player;

  public int scene;
  public bool PlayerAbleToMove;
   public float maxSpeed;
   public float jumpForce;
   public bool isOnGround;
   private Vector3 Input5;
 public float PlayerSpawnX;
  public float PlayerSpawnY;
   public float PlayerSpawnZ;
   private Rigidbody rb;
   public Animator YouWinPanel;

   public void Start(){
     QuestionPanelItself.SetActive(false);
       rb = GetComponent<Rigidbody>();
       PlayerAbleToMove = true;
   }

   public void Update(){
       if(PlayerAbleToMove == true){
     Input5 = new Vector3(Input.GetAxis("Horizontal") * 3 * CameraFollow.CameraSwitch, 0, Input.GetAxis("Vertical") * 3 * CameraFollow.CameraSwitch);
     if(Input.GetKeyDown(KeyCode.Space) && isOnGround){

    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    isOnGround = false;
if(rb.velocity.magnitude < maxSpeed){
  rb.AddForce(Input5 * moveSpeed);


}
}
}

   }
   public GameObject QuestionPanelItself;
   public Animator Timer;
   private void OnCollisionEnter(Collision collisionInfo){
       if(collisionInfo.gameObject.CompareTag("Ground")){
           isOnGround = true;
           
       }
       if(collisionInfo.gameObject.CompareTag("Lava")){
           PlayerAbleToMove = false;
            StartCoroutine(ReloadScene());
               if(UIManager.Volume == true){
            DeathSound.Play();
               }
              
   }
     if(collisionInfo.gameObject.CompareTag("Question")){
           AnsweredYet = false;
                   StartCoroutine(TimerToIncorrect());

       Timer.SetBool("StartTimer", true);
       QuestionPanelItself.SetActive(true);
                  QuestionPanel.SetBool("Switch", true);
                }
     }
     private void OnCollisionStay(Collision collisionInfo){
       if(collisionInfo.gameObject.CompareTag("Ground")){
           isOnGround = true;
       }
   }
   public void WinGame(){
     AnsweredYet = true;
      Timer.SetBool("StartTimer", false);
  QuestionPanel.SetBool("Switch", false);
  WinSound.Play();
  YouWinPanel.SetTrigger("Win");
   }
     IEnumerator ReloadScene(){
         yield return new WaitForSeconds(1);
       Vector3 pos3 = new Vector3(PlayerSpawnX, PlayerSpawnY, PlayerSpawnZ);
       PlayerAbleToMove = true;
         Player.transform.position = pos3;
     }
     public bool AnsweredYet;
public void Incorrect(){
  AnsweredYet = true;
  Timer.SetBool("StartTimer", false);
  QuestionPanel.SetBool("Switch", false);
  StartCoroutine(Matte());
    IncorrectNoise.Play();
            StartCoroutine(ReloadScene());


}
IEnumerator TimerToIncorrect(){
  yield return new WaitForSeconds(5);
  if(AnsweredYet == false){
    AnsweredYet = true;
  Timer.SetBool("StartTimer", false);
  QuestionPanel.SetBool("Switch", false);
  StartCoroutine(Matte());
    IncorrectNoise.Play();
            StartCoroutine(ReloadScene());

  }
}
IEnumerator Matte(){
           yield return new WaitForSeconds(.5f);

    QuestionPanelItself.SetActive(false);
}

public Animator QuestionPanel;
public AudioSource IncorrectNoise;
      public void Pain(){
      
          StartCoroutine(StartTimer());
      } 
   IEnumerator StartTimer(){
          if(CameraFollow.CameraSwitch == 1){
               CameraFollow.CameraSwitch = -1;
           } else{
               CameraFollow.CameraSwitch = 1;
           }
         yield return new WaitForSeconds(.15f);
               CameraFollow.cooldown = false;

     }
   }



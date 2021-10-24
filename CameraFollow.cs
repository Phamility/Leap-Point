using UnityEngine;

public class CameraFollow : MonoBehaviour {
public static bool PlayClicked;
	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;
    public PlayerMovement PlayerReference;

    public static int CameraSwitch;
    public static bool cooldown;
    public void Start(){
        PlayClicked = false;
        CameraSwitch = 1;
        cooldown = false;
    }
    void Update(){
        if(PlayClicked == true){
         if(Input.GetKeyDown(KeyCode.R) && cooldown == false){
                          cooldown = true;

         offset.z = offset.z * -1;
          PlayerReference.Pain();
         
        }}
    }
    
       
	void FixedUpdate ()
	{
       if(PlayClicked == true){
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		transform.LookAt(target);
	}}
    

}
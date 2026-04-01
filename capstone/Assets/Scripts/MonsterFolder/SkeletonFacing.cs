using UnityEngine;

public class SkeletonFacing : MonoBehaviour
{
    [SerializeField] Animator Animator;
    [SerializeField] GameObject Player;
    Vector3 PlayerPosition;
    Vector3 CurrnetPosition;
    float displacementX;
    float displacementY;
    public bool IsAttacking;
    public string facing;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition = Player.transform.position;
        CurrnetPosition = transform.position;
        displacementX = PlayerPosition.x - CurrnetPosition.x; //if +, player on right; if -, player on left
        displacementY = PlayerPosition.y - CurrnetPosition.y; //if +, player on up; if -, player on down
        whichWayToFace();
        if(IsAttacking){

        }
        else{

        }
    }
    public void setIsAttacking(bool IsA){
        IsAttacking = IsA;
    }
    public void setIsAttacking(bool NoA){
        IsAttacking = NoA;
    }
    public void whichWayToFace(){
        if(displacementX < 0 && Math.abs(displacementX) > Math.abs(displacementY)){
            facing = "left";
        }
        if(displacementX > 0 && Math.abs(displacementX) > Math.abs(displacementY)){
            facing = "right";
        }
        if(displacementY > 0 && Math.abs(displacementX) < Math.abs(displacementY)){
            facing = "up";
        }
        if(displacementY < 0 && Math.abs(displacementX) < Math.abs(displacementY)){
            facing = "down";
        }
    }
}

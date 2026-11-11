using UnityEngine;

public class PlayerAnimatoons : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();

    }//start


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _animator.SetBool("PlayerTurnLeft",true);
            _animator.SetBool("PlayerTurnRight", false);
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            _animator.SetBool("PlayerTurnRight",true);
            _animator.SetBool("PlayerTurnLeft", false);
        }
        else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _animator.SetBool("PlayerTurnLeft",false);
            _animator.SetBool("PlayerTurnRight",false);
        }

    }//update
}

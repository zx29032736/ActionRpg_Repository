using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlinchTest : MonoBehaviour {

    public Animator animator;
    public CharacterController chaController;
    bool isFlinch = false;
    public Vector3 flinchDirection = Vector3.back;

    public GameObject teageted;

    private void Update()
    {
        if (isFlinch)
        {
            chaController.SimpleMove(flinchDirection * 6);
            return;
        }
    }

    void Flinch( Vector3 dir)
    {
        //moveController.isControllable = false;
        flinchDirection = dir;
        transform.LookAt(teageted.transform);
        animator.Play("hurt");
        StartCoroutine(KnockBack());
        //moveController.isControllable = true;
    }

    IEnumerator KnockBack()
    {
        isFlinch = true;
        yield return new WaitForSeconds(0.2f);
        isFlinch = false;
    }
}

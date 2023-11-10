using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSet : MonoBehaviour
{
    public Animator animator;
    public bool isMove;
    public Vector3 movePosition;
    public float z;
    public float time;
    public Sprite[] sprites;


    private void Update()
    {
        if (isMove)
        {
            
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, movePosition, 0.05f);
            
            time += 1 * Time.deltaTime;
            if (time>0.25f)
            {
                isMove = false;
                animator.SetBool("Ismove", false);
                time = 0;
            }
        }
    }

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        

    }
    public void MovePosition(Vector3 _position, float _z)
    {
        movePosition = _position;
        z = _z;
        animator.SetBool("Ismove", true);
        isMove = true;
    }

    public void Remove()
    {
    }
    public void SetMotion(int _num)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[_num];
    }
    
}

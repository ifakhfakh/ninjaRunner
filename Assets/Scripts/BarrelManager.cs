using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player ;
    private    Animator animator ;
    void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void  OnCollisionEnter2D(Collision2D col) {
    //   Debug.Log(col.gameObject.name);
      if (col.gameObject.name =="ninja" ) {
          Debug.Log("collider");
          Destroy(gameObject);
      }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//USAGE: put on twitter profiles
//INTENT: make twitter hover up and down and rotate
public class RotateHover : MonoBehaviour
{
    public float hoverSpeed;
    
    public float maxHeight;

    public float minHeight;

    private Vector3 yPosition;

    private bool moveUp = true;
    // Start is called before the first frame update
  
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //rotate profile around Y axis
      transform.Rotate(new Vector3(0f,hoverSpeed,0)*Time.deltaTime);
      float y = transform.position.y;
      if (moveUp)
      {
          transform.Translate(new Vector3(0f, 1f, 0f)*Time.deltaTime);
          if (y > maxHeight)
          {
              moveUp = false;
          }
      }
      else
      {
          transform.Translate(new Vector3(0,-1f,0) *Time.deltaTime);
          if (y < minHeight)
          {
              moveUp = true;
          }
      }

    }
}

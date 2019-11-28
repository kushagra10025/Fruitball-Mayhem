using UnityEngine;
using System.Collections;
 
public class ArmPivot : MonoBehaviour
{

    public Transform player;
 
    void FixedUpdate ()
    {
        faceMouse();
    }


    void faceMouse()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (rotationZ < -90 || rotationZ > 90)
        {
            PlayerMovement.Instance.PlayerBodyRot(180f);
            if(Mathf.Approximately(transform.eulerAngles.y ,0f))
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (Mathf.Approximately(transform.eulerAngles.y,180))
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }
        if (rotationZ < 90 && rotationZ > -90)
        {
            PlayerMovement.Instance.PlayerBodyRot(0f);
        }
    }


    #region Trials

        //Trial Zero
        /*
        void faceMouse()
        {
            
            /*Vector2 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);        //Mouse position
            Vector3 objpos = Camera.main.WorldToViewportPoint (transform.position);        //Object position on screen
            Vector2 relobjpos = new Vector2(objpos.x - 0.5f,objpos.y - 0.5f);            //Set coordinates relative to object
            Vector2 relmousepos = new Vector2 (mouse.x - 0.5f,mouse.y - 0.5f) - relobjpos;
            float angle = Vector2.Angle (Vector2.up, relmousepos);    //Angle calculation
            if (relmousepos.x > 0)
                angle = 360-angle;
            Quaternion quat = Quaternion.identity;
            quat.eulerAngles = new Vector3(0,0,angle); //Changing angle
            transform.rotation = quat;#1#
        }*/
        
        //Trial One
    
    //    void faceMouse()
    //    {
    //        Vector3 mousePos = Input.mousePosition;
    //        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    //        
    //        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
    //
    //        transform.up = direction;
    //
    //    }

    #endregion
}
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour 
{
    #region Variables
    Camera cam;
    public LayerMask movementMask;
    PlayerMotor motor;
    public Interactable focus;
    #endregion

    #region Unity Methods
    
	void Start () 
	{
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}
	
	void Update () 
	{
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //Move player to what raycast hits
                motor.MoveToPoint(hit.point);
                //Stop Focusing any objects
                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //Move player to what raycast hits
                motor.MoveToPoint(hit.point);

                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    SetFocus(interactable);
                }


               //Stop Focusing any objects
            }
        }
    }
    void SetFocus (Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if(focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
    }
    void RemoveFocus()
    {
        if(focus != null)
            focus.OnDefocused();

        focus = null;
        motor.StopFollowingTarget();
    }

#endregion
}
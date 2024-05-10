using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable {
     public void Interact();
}

public class Interactor : MonoBehaviour
{
    //objects being interacted with need public void Interact() inside their function, just before the thing it does

    public Transform InteractorSource;
    public float InteractRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange)) 
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}

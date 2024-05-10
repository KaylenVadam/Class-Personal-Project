using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    public Portal portal;
    public Portal portal2;

    public int numberOfTeleports = 0;
    public bool alreadycounted;

    // Start is called before the first frame update
    void Start()
    {
        alreadycounted = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void counter()
    {
        if(alreadycounted == false)
        {
            alreadycounted = true;
            numberOfTeleports ++;
            Invoke("resetbool", .1f);
        }
    }

    public void resetbool()
    {
        alreadycounted = false;
    }
    
}

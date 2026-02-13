using UnityEngine;

public class ShakePhone : MonoBehaviour
{
    private Vector3 lastAcceleration;
    public float shakeThreshold = 1.2f;   // порог тряски
    private bool ShakeOne;

   void Start()
    {
	   lastAcceleration = Input.acceleration;
    }

    void Update()

    {
        Vector3 delta = Input.acceleration - lastAcceleration;

        if (delta.sqrMagnitude > shakeThreshold * shakeThreshold)
        {
            if(!ShakeOne)
            PlayerPrefs.SetInt("ShakePhone", 1);

            ShakeOne = true;
        }
        else
        {
            if(ShakeOne)
            PlayerPrefs.SetInt("ShakePhone", 0);

            ShakeOne = false;
        }

        lastAcceleration = Input.acceleration;
    }
}

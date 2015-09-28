using UnityEngine;
using System.Collections;

public class TGrav : MonoBehaviour
{
    public float xMax = 6;
    private float zMax = 4;
    private float r;
    public int angle = 50;
    private Vector3 newR = new Vector3(0, 180, 0);
    private Transform mTransform;
    public Vector3 targetP = Vector3.zero;
    private Vector3 curP = Vector3.zero;
    void Start()
    {
        //Debug.LogError(Mathf.Cos(60 / Mathf.Rad2Deg));
        r = xMax / Mathf.Sin(angle / Mathf.Rad2Deg);
        mTransform = transform;
        mTransform.position = Vector3.zero;
    }

    void Update()
    {
        r = xMax / Mathf.Sin(angle / Mathf.Rad2Deg);
        targetP.x += Input.acceleration.x;

        targetP.z += Input.acceleration.y;

        if (Mathf.Abs(targetP.z) > zMax)
            targetP.z = targetP.z > 0 ? zMax : -zMax;
        if (Mathf.Abs(targetP.x) > xMax)
            targetP.x = targetP.x > 0 ? xMax : -xMax;

        curP = Vector3.Lerp(curP, targetP, 10 * Time.deltaTime);
        curP.y = r - Mathf.Sqrt(Mathf.Max(0, (r * r - curP.x * curP.x)));
        mTransform.position = curP;
        newR.z = -Mathf.Asin(mTransform.position.x / r) * Mathf.Rad2Deg;
        mTransform.localEulerAngles = newR;
    }
}

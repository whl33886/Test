using UnityEngine;

using System.Collections;



/**  * 备注：本脚本必须赋予主镜头  */

public class Camera : MonoBehaviour
{



    public Transform target;//主相机要围绕其旋转的物体

    public float distance = 7.0f;//主相机与目标物体之间的距离

    private float eulerAngles_x;

    private float eulerAngles_y;



    //水平滚动相关

    public int distanceMax = 10;//主相机与目标物体之间的最大距离

    public int distanceMin = 3;//主相机与目标物体之间的最小距离

    public float xSpeed = 70.0f;//主相机水平方向旋转速度



    //垂直滚动相关

    public int yMaxLimit = 60;//最大y（单位是角度）

    public int yMinLimit = -10;//最小y（单位是角度）

    public float ySpeed = 70.0f;//主相机纵向旋转速度



    //滚轮相关

    public float MouseScrollWheelSensitivity = 1.0f;//鼠标滚轮灵敏度（备注：鼠标滚轮滚动后将调整相机与目标物体之间的间隔）

    public LayerMask CollisionLayerMask;





    // Use this for initialization

    void Start()
    {

        Vector3 eulerAngles = this.transform.eulerAngles;//当前物体的欧拉角

        this.eulerAngles_x = eulerAngles.y;

        this.eulerAngles_y = eulerAngles.x;

    }

    Quaternion quaternion1 = new Quaternion(0, 0, 0, 0);

    // Update is called once per frame

    void LateUpdate()
    {

        if (this.target != null)
        {

            this.eulerAngles_x += ((Input.GetAxis("Mouse X") * this.xSpeed) * this.distance) * 0.02f;



            this.eulerAngles_y -= (Input.GetAxis("Mouse Y") * this.ySpeed) * 0.02f;

            this.eulerAngles_y = ClampAngle(this.eulerAngles_y, (float)this.yMinLimit, (float)this.yMaxLimit);



            Quaternion quaternion = Quaternion.Euler(this.eulerAngles_y, this.eulerAngles_x, (float)0);





            this.distance = Mathf.Clamp(this.distance - (Input.GetAxis("Mouse ScrollWheel") * MouseScrollWheelSensitivity), (float)this.distanceMin, (float)this.distanceMax);



            //从目标物体处，到当前脚本所依附的对象（主相机）发射一个射线，如果中间有物体阻隔，则更改this.distance（这样做的目的是为了不被挡住）

            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Linecast(this.target.position, this.transform.position, out hitInfo, this.CollisionLayerMask))
            {

                this.distance = hitInfo.distance - 0.05f;

            }

            Vector3 vector = ((Vector3)(quaternion * new Vector3((float)0, (float)0, -this.distance))) + this.target.position;



            //更改主相机的旋转角度和位置
            //             quaternion1.x = Mathf.Lerp(quaternion1.x, quaternion.x, 16 * Time.deltaTime);
            //             quaternion1.y = Mathf.Lerp(quaternion1.y, quaternion.y, 16 * Time.deltaTime);
            //             quaternion1.z = Mathf.Lerp(quaternion1.z, quaternion.z, 16 * Time.deltaTime);
            //             quaternion1.w = Mathf.Lerp(quaternion1.w, quaternion.w, 6 * Time.deltaTime);
            //             quaternion1.w = quaternion.w;
            this.transform.rotation = quaternion;

            this.transform.position = vector;

        }



    }



    //把角度限制到给定范围内

    public float ClampAngle(float angle, float min, float max)
    {

        while (angle < -360)
        {

            angle += 360;

        }



        while (angle > 360)
        {

            angle -= 360;

        }



        return Mathf.Clamp(angle, min, max);

    }



}

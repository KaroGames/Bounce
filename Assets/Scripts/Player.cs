using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject top;

    public float minPower = 1f;
    public float maxPower = 5f;
    public float chargeUpDuration = 2f;
    public float chargeDurationNow = 0f;
    public bool isCharging = false;
    public bool buttonReleased = true;

    Vector3 startDrag;
    Vector3 endDrag;
    Vector3 currentDragPos;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&& buttonReleased)
        {
            chargeDurationNow = 0f;
            isCharging = true;
            buttonReleased = false;
        }

        else if(isCharging && (Input.GetMouseButtonUp(0)|| chargeDurationNow >= chargeUpDuration))
        {
            float throwPower = Mathf.Lerp(minPower, maxPower, chargeDurationNow / chargeUpDuration);

            BallThrow(throwPower);

            Reset();
        }

        if (isCharging)
        {
            chargeDurationNow += Time.deltaTime;
        }

        if (!buttonReleased)
        {
            buttonReleased = Input.GetMouseButtonUp(0);
        }
    }

    public void BallThrow(float throwPower)
    {
        Debug.Log("guc: " + throwPower);
        if( top != null)
        {
            top.GetComponent<Rigidbody>().AddForce(top.transform.up * throwPower, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("top bulunamadı");
        }
    }

    private void Reset()
    {
        chargeDurationNow = 0f;
        isCharging = false;
    }


}

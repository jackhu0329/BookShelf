using RootMotion.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using HTC.UnityPlugin.Vive;
using GameFrame;

public class hand : MonoBehaviour
{
    public SteamVR_Action_Boolean mGrabAction = null;
    private SteamVR_Behaviour_Pose mPose = null;
    private FixedJoint mJoint = null;

    private Interactable mCurrentInteractable = null;
    private List<Interactable> mContactInteractables = new List<Interactable>();

    public int testHand;

    private float timer = 0;
    private bool hasCorrection = false;

    // Start is called before the first frame update
    void Start()
    {
        mPose = GetComponent<SteamVR_Behaviour_Pose>();
        mJoint = GetComponent<FixedJoint>();
        GameEventCenter.AddEvent("ResetHand", ResetHand);
    }

    void Spawn()
    {
        GameEventCenter.DispatchEvent("SpawnBook");
    }
    // Update is called once per frame
    void Update()
    {


        if (mGrabAction.GetStateDown(mPose.inputSource))
        {
            timer += Time.deltaTime;
            if (timer >= 2.0f && !hasCorrection)
            {
                //GameEntityManager.Instance.GetCurrentSceneRes<MainSceneRes>().mainSceneUI.SetUIActive(0, false);
                //GameEventCenter.DispatchEvent<Vector3>(EventName.EnableCameraRig, this.transform.position);
                GameEventCenter.DispatchEvent<Vector3>("CameraCorrection", transform.position);
                GameEventCenter.DispatchEvent("CorrectionUI");
                hasCorrection = true;
                //Correction.hasCorrection = true;
            }

            Debug.Log(mPose.inputSource + " down ");
            //Pickup();
        }
        if (mGrabAction.GetStateUp(mPose.inputSource))
        {
            Debug.Log(mPose.inputSource + " up ");
            //Drop();

        }

        if (mGrabAction.GetStateDown(mPose.inputSource))
        {
            Debug.Log(mPose.inputSource + " down ");
            Pickup();
        }
        if (mGrabAction.GetStateUp(mPose.inputSource))
        {
            Debug.Log(mPose.inputSource + " up ");
            Drop();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touch1");
        if (!other.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("touch2");
            mContactInteractables.Add(other.gameObject.GetComponent<Interactable>());
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Interactable"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("Interactable"))
        {
            mContactInteractables.Remove(other.gameObject.GetComponent<Interactable>());
        }
    }

    private void Pickup()
    {

        mCurrentInteractable = GetNearestInteractable();
        Debug.Log("pick1");
        if (!mCurrentInteractable)
            return;

        if (mCurrentInteractable.mActiveHand)
            mCurrentInteractable.mActiveHand.Drop();
        Debug.Log("pick2");
        //mCurrentInteractable.transform.position =new Vector3(transform.position.x - 0.2f, transform.position.y-0.2f, transform.position.z);
        //mCurrentInteractable.transform.eulerAngles = new Vector3(transform.rotation.x , 0 , -90);

        mCurrentInteractable.transform.position = transform.position;

        GameEventCenter.DispatchEvent("BookNumber", mCurrentInteractable.GetComponent<BookEntity>().n+1); 

        Rigidbody targetBody = mCurrentInteractable.GetComponent<Rigidbody>();
        mJoint.connectedBody = targetBody;

        mCurrentInteractable.mActiveHand = this;
    }

    private void Drop()
    {
        if (!mCurrentInteractable)
            return;

        GameEventCenter.DispatchEvent("BookNumber", 0);

        /*mCurrentInteractable.transform.position = originPosition;
        mCurrentInteractable.transform.rotation = originRotation;*/

        Rigidbody targetBody = mCurrentInteractable.GetComponent<Rigidbody>();
        //targetBody.velocity = mPose.GetVelocity()*10;
        targetBody.velocity = new Vector3(mPose.GetVelocity().z * 10, mPose.GetVelocity().y * 10,- mPose.GetVelocity().x * 10);

        targetBody.angularVelocity = mPose.GetAngularVelocity()*10;


        mContactInteractables = new List<Interactable>();
        mJoint.connectedBody = null;
        mCurrentInteractable.mActiveHand = null;
        mCurrentInteractable = null;


    }

    private Interactable GetNearestInteractable()
    {
        Interactable nearest = null;
        float minDistance = float.MaxValue;
        float distance = 0.0f;
        Debug.Log("GetNearestInteractable1");
        foreach (Interactable interactive in mContactInteractables)
        {
            distance = (interactive.transform.position - transform.position).sqrMagnitude;
            Debug.Log("GetNearestInteractable2:"+ interactive.name);
            /*if (distance < minDistance && distance < 0.1f && interactive.tag == ("Interactable"))//手把真的有碰到物體 且物體還是可以動的狀態
            {
                minDistance = distance;
                nearest = interactive;

            }*/

            if ( interactive.tag == ("Interactable"))//手把真的有碰到物體 且物體還是可以動的狀態
            {
                Debug.Log("GetNearestInteractable3:" + interactive.name);
                nearest = interactive;

            }

        }
        //Debug.Log("GetNearestInteractable:  "+ nearest.gameObject.name);

        return nearest;
    }



    public void ResetHand()
    {
        Drop();
    }
}

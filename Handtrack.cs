using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class Handtrack : MonoBehaviour
{
    //public GameObject sphereMark;
    public GameObject thumbObject;
    public GameObject indexObject;
    public GameObject middleObject;
    public GameObject ringObject;
    //public GameObject pinkyObject;
    ///
    //public GameObject pinkymidObject;
    //public GameObject metacarplalsObject;

    /// 
    /*GameObject thumbObject;
    GameObject indexObject;
    GameObject middleObject;
    GameObject ringObject;
    GameObject pinkyObject;*/
    MixedRealityPose pose;
    // Start is called before the first frame update
    void Start()
    {
        thumbObject = Instantiate(thumbObject, this.transform);
        indexObject = Instantiate(indexObject, this.transform);
        middleObject = Instantiate(middleObject, this.transform);
        ringObject = Instantiate(ringObject, this.transform);
        //pinkyObject = Instantiate(pinkyObject, this.transform);
        //pinkymidObject = Instantiate(pinkymidObject, this.transform);
        //metacarplalsObject = Instantiate(metacarplalsObject, this.transform);


    }

    // Update is called once per frame
    void Update()
    {
        // pong
        thumbObject.GetComponent<Renderer>().enabled = false;
        if(HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out pose))
        {
            thumbObject.GetComponent<Renderer>().enabled = true;
            thumbObject.transform.position = pose.Position;
        }

        // chee
        indexObject.GetComponent<Renderer>().enabled = false;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
        {
            indexObject.GetComponent<Renderer>().enabled = true;
            indexObject.transform.position = pose.Position;
        }
        // krang
        middleObject.GetComponent<Renderer>().enabled = false;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out pose))
        {
            middleObject.GetComponent<Renderer>().enabled = true;
            middleObject.transform.position = pose.Position;
        }
        //nang
        ringObject.GetComponent<Renderer>().enabled = false;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out pose))
        {
            ringObject.GetComponent<Renderer>().enabled = true;
            ringObject.transform.position = pose.Position;
        }
        //goy
        /*pinkyObject.GetComponent<Renderer>().enabled = false;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out pose))
        {
            pinkyObject.GetComponent<Renderer>().enabled = true;
            pinkyObject.transform.position = pose.Position;
        }
        // Under goy
        pinkymidObject.GetComponent<Renderer>().enabled = false;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyKnuckle, Handedness.Right, out pose))
        {
            pinkymidObject.GetComponent<Renderer>().enabled = true;
            pinkymidObject.transform.position = pose.Position;
        }

        //metacarplals
        metacarplalsObject.GetComponent<Renderer>().enabled = false;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingMetacarpal, Handedness.Right, out pose))
        {
            metacarplalsObject.GetComponent<Renderer>().enabled = true;
            metacarplalsObject.transform.position = pose.Position;
        }*/
    }
}

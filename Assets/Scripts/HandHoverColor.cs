using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class HandHoverColor : MonoBehaviour
{
    [Tooltip("The hand entity")]
    public GameObject handController;
    [Tooltip("The base material")]
    public Material baseMaterial;
    [Tooltip("The material to show on hover")]
    public Material hoverMaterial;


    public void HoverRightHand()
    {
        SkinnedMeshRenderer renderer= handController.transform.Find("[Right Controller] Model Parent")?.gameObject.transform.Find("RightHand(Clone)")?.gameObject.transform.Find("hands:hands_geom")?.gameObject.transform.Find("hands:Rhand")?.gameObject.GetComponent<SkinnedMeshRenderer>();
        List<Material> materials = new List<Material>();
        materials.Add(hoverMaterial);
        renderer.SetMaterials(materials);
    }
    public void UnhoverRightHand()
    {
        SkinnedMeshRenderer renderer = handController.transform.Find("[Right Controller] Model Parent")?.gameObject.transform.Find("RightHand(Clone)")?.gameObject.transform.Find("hands:hands_geom")?.gameObject.transform.Find("hands:Rhand")?.gameObject.GetComponent<SkinnedMeshRenderer>();
        List<Material> materials = new List<Material>();
        materials.Add(baseMaterial);
        renderer.SetMaterials(materials);
    }
    public void HoverLeftHand()
    {
        SkinnedMeshRenderer renderer = handController.transform.Find("[Left Controller] Model Parent")?.gameObject.transform.Find("LeftHand(Clone)")?.gameObject.transform.Find("hands:hands_geom")?.gameObject.transform.Find("hands:Lhand")?.gameObject.GetComponent<SkinnedMeshRenderer>();
        List<Material> materials = new List<Material>();
        materials.Add(hoverMaterial);
        renderer.SetMaterials(materials);
    }
    public void UnhoverLeftHand()
    {
        SkinnedMeshRenderer renderer = handController.transform.Find("[Left Controller] Model Parent")?.gameObject.transform.Find("LeftHand(Clone)")?.gameObject.transform.Find("hands:hands_geom")?.gameObject.transform.Find("hands:Lhand")?.gameObject.GetComponent<SkinnedMeshRenderer>();
        List<Material> materials = new List<Material>();
        materials.Add(baseMaterial);
        renderer.SetMaterials(materials);
    }
}

using UnityEngine;
using System.Collections.Generic;

public class CharAppearanceBase : MonoBehaviour {
    public bool hasCustomRig;
    public List<CharAppearanceBoneAttachment> boneAttachments;
    public string objectToRemove = "ExportRig";
    public Texture2D cutout;
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildShape3 : BaseShape
{
    protected override void Interact()
    {
        StartCoroutine(EnableText(1, displayText, clickedColor));
    }
}

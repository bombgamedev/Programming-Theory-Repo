using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using OpenCover.Framework.Model;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseShape : MonoBehaviour
{
    [SerializeField] protected string displayText;
    [SerializeField] protected TextMeshPro text;

    [SerializeField] private Color sColor;
    [SerializeField] private Color cColor;

    // ENCAPSULATION
    protected Color shapeColor
    {
        get
        {
            return sColor;
        }
        set
        {
            sColor = value;
            meshRenderer.material.color = value;
        }
    }

    // ENCAPSULATION
    protected Color clickedColor
    {
        get
        {
            return cColor;
        }
        set
        {
            cColor = value;
        }
    }

    protected MeshRenderer meshRenderer;
     

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        text.gameObject.SetActive(false);
        text.text = "";
    }
    // INHERITANCE
    void OnMouseDown()
    {
        Debug.Log("Клик по объекту: " + name + ", класс: " + 
                  GetType().Name + ", метод: " + MethodBase.GetCurrentMethod().Name);
        Interact();
    }

    protected virtual void Interact()
    {
        StartCoroutine(EnableText(1, displayText, clickedColor));
    }

    // INHERITANCE
    protected virtual IEnumerator EnableText(float time, string newText, Color newShapeColor)
    {
        TransformObject(newText, newShapeColor);
        yield return new WaitForSeconds(time);
        ReturnDefault();
    }

    protected virtual void TransformObject(string newText, Color newColor)
    {
        text.text = newText;
        text.gameObject.SetActive(true);
        meshRenderer.material.color = newColor;
    }
    // ABSTRACTION
    private void ReturnDefault()
    {
        text.gameObject.SetActive(false);
        meshRenderer.material.color = shapeColor;
    }
}

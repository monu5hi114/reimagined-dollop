using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardFlip : MonoBehaviour, IPointerClickHandler
{

    private bool flipped=false;
    private Quaternion targetRotation;
    private float rotationSpeed = 720f;


    private void Start()
    {
        targetRotation = transform.rotation;
    }
    private void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed* Time.deltaTime);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        FlipCard();
    }
    public void FlipCard()
    {
        flipped=!flipped;

        float yRotation = flipped ? 180f : 0f;
        targetRotation=Quaternion.Euler(0f,yRotation,0f);
    }
}

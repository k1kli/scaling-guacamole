using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SightScript : MonoBehaviour
{
    public Transform PlayerCameraTransform;
    public Sprite NormalSight;
    public Sprite RedSight;
    private Image image;

    private void Awake()
    {
        NormalSight = Resources.Load<Sprite>("Sight");
        RedSight = Resources.Load<Sprite>("RedSight");
        image = GetComponent<Image>();
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Ray ray = new Ray(PlayerCameraTransform.position, PlayerCameraTransform.forward);
        if(Physics.Raycast(ray, out RaycastHit hit) && hit.collider.gameObject.CompareTag("Enemy"))
        {
            image.sprite = RedSight;
        }
        else
        {
            image.sprite = NormalSight;
        }
    }
}

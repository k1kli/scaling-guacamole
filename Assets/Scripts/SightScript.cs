using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SightScript : MonoBehaviour
{
    public Transform PlayerCameraTransform;
    public Player player;
    public Sprite NormalSight;
    public Sprite RedSight;
    public Sprite ReloadSight;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        player.ReloadStart += Player_ReloadStart;
        player.ReloadEnd += Player_ReloadEnd;
    }

    private void Player_ReloadEnd()
    {
        this.enabled = true;
    }

    private void Player_ReloadStart()
    {
        image.sprite = ReloadSight;
        this.enabled = false;
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

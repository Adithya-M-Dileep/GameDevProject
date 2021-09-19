using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;
using UnityEngine.UI;

public class playerMovements : MonoBehaviourPunCallbacks, iDamagable
{
    [SerializeField] Image healthBarImage;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject cameraHolder;
    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
    [SerializeField] item[] items;

    int itemIndex;
    int previousItemIndex=-1;

    float verticalLookRotation;
    
    bool grounded;

    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    Rigidbody rb;

    PhotonView pv;
    const float maxHealth = 100f;
    float currentHealth = maxHealth;
    playerManager playerManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pv = GetComponent<PhotonView>();
        playerManager = PhotonView.Find((int)pv.InstantiationData[0]).GetComponent<playerManager>(); 
    }

    private void Start()
    {
        if(pv.IsMine)
        {
            equipItem(0);   
        }
        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
            Destroy(UI);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pv.IsMine)
            return; 
        Look();
        move();
        jump();
        for(int i=0;i<items.Length;i++)
        {
            if(Input.GetKeyDown((i+1).ToString()))
            {
                equipItem(i);
                break;
            }
        }

        if(Input.GetAxisRaw("Mouse ScrollWheel")>0f)
        {
            if( itemIndex>=items.Length-1)
            {
                equipItem(0);
            }
            else
            {
                equipItem(itemIndex + 1);
            }
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            if (itemIndex <=0f)
            {
                equipItem(items.Length-1);
            }
            else
            {
                equipItem(itemIndex -1);
            }
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            items[itemIndex].use();
        }
        if(transform.position.y<-10f)
        {
            Die();
        }
    }

    void move()
    {
        Vector3 movDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, movDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);

        
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Debug.Log("jump");
            rb.AddForce(transform.up * jumpForce);
        }
    }
    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
        verticalLookRotation = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        //cameraHolder.transform.localEulerAngles = Vector3.left* verticalLookRotation ;
        cameraHolder.transform.Rotate(Vector3.left * verticalLookRotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == gameObject)
            return;
        grounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == gameObject)
            return;
        grounded = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject ==gameObject)
            return;
        grounded = true;
    }


    void equipItem(int _index)
    {
        if (_index == previousItemIndex)
            return;
        itemIndex = _index;
        items[itemIndex].itemgameobject.SetActive(true);
        if(previousItemIndex!=-1)
        {
            items[previousItemIndex].itemgameobject.SetActive(false);
        }
        previousItemIndex = itemIndex;
        if(pv.IsMine)
        {
            Hashtable hash = new Hashtable();
            hash.Add("itemIndex", itemIndex);
            PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if(!pv.IsMine && targetPlayer == pv.Owner)
        {
            equipItem((int)changedProps["itemIndex"]);
        }
    }
    private void FixedUpdate()
    {
        if (!pv.IsMine)
            return;
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    public void takeDamage(float damage)
    {
        pv.RPC("RPC_takeDamage", RpcTarget.All, damage);
;    }
    [PunRPC]
    void RPC_takeDamage( float Damage)
    {
        if (!pv.IsMine)
            return;
        currentHealth -= Damage;

        healthBarImage.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0f)
            Die();
    }
    void Die()
    {
        playerManager.Die();
    }
}

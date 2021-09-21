
using UnityEngine;

public class gunSwitch : MonoBehaviour
{
    public int selectedGun = 0;
    // Start is called before the first frame update
    void Start()
    {
        selectGun();
    }

    // Update is called once per frame
    void Update()
    {
        int preGun = selectedGun;
        if(Input.GetAxis("Mouse ScrollWheel")>0f)
        {
            if (selectedGun >= transform.childCount - 1)
                selectedGun = 0;
            else
                selectedGun++;
        }
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedGun <= 0)
                selectedGun = transform.childCount - 1;
            else
                selectedGun--;
        }
        if (preGun != selectedGun)
            selectGun();

    }

    void selectGun()
    {
        int i=0;
        foreach(Transform guns in transform)
        {
            if (i == selectedGun)
                guns.gameObject.SetActive(true);
            else
                guns.gameObject.SetActive(false);
            i++;
        }
    }
}

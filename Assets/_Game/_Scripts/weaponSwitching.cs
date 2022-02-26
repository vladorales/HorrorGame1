using UnityEngine;

public class weaponSwitching : MonoBehaviour
{
	public int selectedWeapon = 0;
    public GameObject KeyUI;
	// Start is called before the first frame update
	void Start()
	{
		SelectWeapon();
        UpdateKeys();
    }

	// Update is called once per frame
	void Update()
	{
       

		int perviousSelectedWeapon = selectedWeapon;
		GetKeypad();
		getMouseScroll();
		if (perviousSelectedWeapon != selectedWeapon)
		{
			SelectWeapon();
		}
        
	}

    public void UpdateKeys()
    {
        //this.gameObject.transform.Find("PF_Key");
        //if("PF_Key" != null)
        //{
        //    KeyUI.SetActive(true);
        //}
        //if("PF_Key" == null)
        //{
        //}
            
    }

	private void GetKeypad()
	{
		if (Input.GetKeyUp(KeyCode.Alpha1))
		{
			selectedWeapon = 0;
		}
		if (Input.GetKeyUp(KeyCode.Alpha2))
		{
			selectedWeapon = 1;
		}
		if (Input.GetKeyUp(KeyCode.Alpha3))
		{
			selectedWeapon = 2;
		}
	}

	private void getMouseScroll()
	{
		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			if (selectedWeapon >= transform.childCount - 1)
				selectedWeapon = 0;
			else
				selectedWeapon++;
		}
		if (Input.GetAxis("Mouse ScrollWheel") < 0f)
		{
			if (selectedWeapon <= 0)
				selectedWeapon = transform.childCount - 1;
			else
				selectedWeapon--;
		}
	}

	void SelectWeapon()
	{
		int i = 0;
		foreach (Transform weapon in transform)
		{
			if (i == selectedWeapon)
				weapon.gameObject.SetActive(true);
			else
				weapon.gameObject.SetActive(false);

			i++;

		}
	}

}

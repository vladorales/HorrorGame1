using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFunction : MonoBehaviour
{
	public int numKey;
	public GameObject Key;
    public GameObject KeyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (numKey >= 1)
		{
			Key.SetActive(true);
            KeyText.SetActive(true);
		}
		else if(numKey <=0)
		{
			Key.SetActive(false);
            KeyText.SetActive(false);
		} 

    }

   public void AddToKey()
    {
		numKey++;
    }
	public void MinusKey()
	{
		numKey--;
	}
}

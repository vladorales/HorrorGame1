using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingLevel : MonoBehaviour
{
	public GameObject winText;

    // Start is called before the first frame update
    
	public void YouWin()
	{
		winText.SetActive(true);
	}
}

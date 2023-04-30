using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Click()
    {
        AkSoundEngine.PostEvent("SFX_ButtonClick", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

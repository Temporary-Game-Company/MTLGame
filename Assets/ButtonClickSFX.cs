using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSFX : MonoBehaviour
{
    public void Click()
    {
        AkSoundEngine.PostEvent("SFX_ButtonClick", gameObject);
    }
}

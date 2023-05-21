using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsAudio : MonoBehaviour
{
    // Start is called before the first frame update

    public void Footstepping()
    {
        AkSoundEngine.PostEvent("Play_Footsteps", gameObject);
    }

    public void MenuClick()
    {
        AkSoundEngine.PostEvent("Play_Footsteps", gameObject);
    }

}

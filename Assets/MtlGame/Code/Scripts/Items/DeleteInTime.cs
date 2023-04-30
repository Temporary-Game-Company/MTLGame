using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteInTime : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeleteObject", 5f);
    }

    private void DeleteObject()
    {
        GameObject.Destroy(this.gameObject);
    }
}

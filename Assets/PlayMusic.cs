using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        SoundManager.Instance.playMenuMusin();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
   private Player player;
    private float footstepTimer;
    private float footstepTimerMax = 0.1f;

    private void Awake()
    {
        player = GetComponent<Player>();    
    }

    private void Update()
    {
        footstepTimer -= Time.deltaTime;

        if(footstepTimer < 0)
        {
            footstepTimer = footstepTimerMax;

            if(player.isMoving())
            {
                float volume = 1f;
                 SoundManage.Instance.PlayFootstepsSound(player.transform.position, volume);
            }            
        } 
    }
}

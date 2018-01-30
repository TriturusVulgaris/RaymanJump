using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Public Members

    public Transform m_player;

	#endregion

	#region Public Function

	#endregion

	#region System

	private void Start() 
	{
		
	}
	
	private void LateUpdate()
	{
        if (transform.position.y < m_player.position.y+10)
        {
            //transform.position = Vector3.Lerp(transform.position, new Vector3(0, m_player.position.y+10, -20), Time.deltaTime);
            
            Vector3 newPosition = new Vector3(0, m_player.position.y +5, -20);
            if (newPosition.y > transform.position.y)
            {
                transform.position = newPosition;
            }
        }
    }

	private void FixedUpdate()
	{
		
	}

	#endregion

	#region Tools Debug And Utility

	#endregion

	#region Private an Protected Members

	#endregion
}

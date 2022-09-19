using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HeadLotate : MonoBehaviour
{
	public GameObject enemy;
	public GameObject controller;

	public float speed;

	// bool catch_Key1 = false;
	public bool is_head_rotation_finish = false;

	public static HeadLotate instance = null;

	private void Awake()
	{

		if (instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
		{
			instance = this; //내자신을 instance로 넣어줍니다.
			DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
		}
		else
		{
			if (instance != this) //instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
				Destroy(this.gameObject); //둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
		}

	}

	public bool isCoroutineFinish = false;
	IEnumerator FollowTarget()
	{
		
		if (enemy != null && !is_head_rotation_finish)
		{
			controller.GetComponent<ContinuousTurnProviderBase>().enabled = false;
			controller.GetComponent<ContinuousMoveProviderBase>().enabled = false;

			Vector3 dir = enemy.transform.position - this.transform.position;
			dir.Normalize();
            while (true)
            {
				this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
				if (isCoroutineFinish)
				{
					break;
				}
				yield return null;
			}
		}

	}

	public void HeadRotate_Finish()
    {
		is_head_rotation_finish = true;
		isCoroutineFinish = true;
		controller.GetComponent<ContinuousTurnProviderBase>().enabled = true;
		controller.GetComponent<ContinuousMoveProviderBase>().enabled = true;
	}

}

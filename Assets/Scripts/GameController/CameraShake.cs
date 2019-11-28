using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CameraShake : MonoBehaviour
{
	public static CameraShake Instance;
	
	public float IdleAmplitude = 0.1f;
	
	public float IdleFrequency = 1f;
	
	public float DefaultShakeAmplitude = .5f;
	
	public float DefaultShakeFrequency = 10f;

	protected Vector3 initialPosition;
	protected Quaternion initialRotation;

	private Cinemachine.CinemachineBasicMultiChannelPerlin _perlin;
	private Cinemachine.CinemachineVirtualCamera _virtualCamera;

	protected virtual void Awake () 
	{
		if (Instance == null)
		{
			Instance = this;
		}
		_virtualCamera = GameObject.FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
		_perlin = _virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin> ();
	}		

	protected virtual void Start()
	{		
		CameraReset ();
	}

	public virtual void ShakeCamera (float duration)
	{
		StartCoroutine (ShakeCameraCo (duration, DefaultShakeAmplitude, DefaultShakeFrequency));
	}

	public virtual void ShakeCamera (float duration, float amplitude, float frequency)
	{
		StartCoroutine (ShakeCameraCo (duration, amplitude, frequency));
	}

	protected virtual IEnumerator ShakeCameraCo(float duration, float amplitude, float frequency)
	{
		_perlin.m_AmplitudeGain = amplitude;
		_perlin.m_FrequencyGain = frequency;
		yield return new WaitForSeconds (duration);
		CameraReset ();
	}

	protected virtual void CameraReset()
	{
		_perlin.m_AmplitudeGain = IdleAmplitude;
		_perlin.m_FrequencyGain = IdleFrequency;
	}

}
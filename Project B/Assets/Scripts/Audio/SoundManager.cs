using UnityEngine;

public class SoundManager : MonoBehaviour
{
	//Instance of sound manager
	public static SoundManager instance { get; private set; }

	//Sound effects
	private AudioSource source;

	//Music
	private AudioSource musicSource;

	private void Awake()
	{
		//Audio source for sounds effects and music
		source = GetComponent<AudioSource>();
		musicSource = transform.GetChild(0).GetComponent<AudioSource>();

		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (instance != null && instance != this)
			Destroy(gameObject);
	}
	public void PlaySound(AudioClip audioSound)
	{
		//Play sound effect once
		source.PlayOneShot(audioSound);
	}

	//Change sound effect volume
	public void ChangeSoundVolume(float changeSound)
	{
		float currentVolume = PlayerPrefs.GetFloat("soundVolume");
		currentVolume += changeSound;

		if (currentVolume > 1)
			currentVolume = 0;
		else if (currentVolume < 0)
			currentVolume = 1;

		source.volume = currentVolume;

		//Save sound effect settings
		PlayerPrefs.SetFloat("soundVolume", currentVolume);
	}

	//Change music volume
	public void ChangeMusicVolume(float changeSound)
	{
		float currentVolume = PlayerPrefs.GetFloat("musicVolume");
		currentVolume += changeSound;

		if (currentVolume > 1)
			currentVolume = 0;
		else if (currentVolume < 0)
			currentVolume = 1;

		musicSource.volume = currentVolume;

		//Save music settings
		PlayerPrefs.SetFloat("musicVolume", currentVolume);
	}

}

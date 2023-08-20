using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] private AudioSource _badDamage;
    [SerializeField] private AudioSource _lightDamage;
    [SerializeField] private AudioSource _gunShot;
    [SerializeField] private AudioSource _PlayerDeath;
    [SerializeField] private AudioSource _lose;
    [SerializeField] private AudioSource _win;
    [Header("Music")]
    [SerializeField] private AudioSource _music;
    [Header("Menu")]
    [SerializeField] private AudioSource _buttonSign;

    private void PlayBadDamage() => PlaySound(_badDamage);
    private void PlayLightDamage() => PlaySound(_lightDamage);
    private void PlayGunShot() => PlaySound(_gunShot);
    private void PlayPlayerDeath()
    {
        PlaySound(_PlayerDeath);
        PlaySound(_lose);
    }
    private void PlayWin() => PlaySound(_win);
    private void PlayButton() => PlaySound(_buttonSign);
    private void PlayMusic() => PlaySound(_music);
    private void StopMusic() => StopSound(_music);

    private void PlaySound(AudioSource source) => source.Play();
    private void StopSound(AudioSource source) => source.Stop();

    private void OnEnable()
    {
        GameSessionManager.OnStartEvent += PlayMusic;
        EnemyHealthSystem.OnDieEvent += PlayBadDamage;
        HealthSystem.OnDamageEvent += PlayLightDamage;
        ShootingWeapon.OnShootEvent += PlayGunShot;
        PlayerHealthSystem.OnDieEvent += PlayPlayerDeath;
        PlayerHealthSystem.OnDieEvent += StopMusic;
        ButtonOnSubmit.OnButtonSubmitEvent += PlayButton;
        GameSessionManager.OnWinEvent += PlayWin;
        ChangeSceneButton.OnSceneChangeEvent += StopMusic;
    }

    private void OnDisable()
    {
        GameSessionManager.OnStartEvent -= PlayMusic;
        EnemyHealthSystem.OnDieEvent -= PlayBadDamage;
        HealthSystem.OnDamageEvent -= PlayLightDamage;
        ShootingWeapon.OnShootEvent -= PlayGunShot;
        PlayerHealthSystem.OnDieEvent -= PlayPlayerDeath;
        PlayerHealthSystem.OnDieEvent -= StopMusic;
        ButtonOnSubmit.OnButtonSubmitEvent -= PlayButton;
        GameSessionManager.OnWinEvent -= PlayWin;
        ChangeSceneButton.OnSceneChangeEvent -= StopMusic;
    }
}

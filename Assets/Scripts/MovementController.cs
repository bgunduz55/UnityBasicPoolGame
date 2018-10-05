using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{

    public GameObject ball;
    public GameObject aSrc;
    private Rigidbody ballRigid;
    public float forceMultiply;
    public int shootCount;
    public int score;
    public float time;
    public bool playable;
    private TimeBody timeBody;
    public bool startRecord;
    public GameObject line;
    public Text scoreText;
    public Button replayBtn;
    public GameObject menu;
	public Slider hitPowerBar;

    // Use this for initialization
    void Start()
    {
		replayBtn.interactable = false;
        time = 0;
        score = 0;
        shootCount = 0;
        startRecord = false;
        playable = true;
        forceMultiply = 0f;
        ballRigid = ball.GetComponent<Rigidbody>();
		hitPowerBar.value = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (!menu.active)
        {
            if (score < 5)
            {
                time += Time.deltaTime;
            } else {
				WinGame();
			}
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetButtonDown("Jump"))
            {
                Stop();
            }
            if (Input.GetButton("Jump") && playable)
            {
				if(forceMultiply<6000) {
					forceMultiply += 1000 * Time.deltaTime;
				} else {
					forceMultiply = 6000;
				}
				
            }
            if (Input.GetButtonUp("Jump") && playable)
            {
                ballRigid.AddForce(Camera.main.transform.forward.x * forceMultiply, transform.position.y, Camera.main.transform.forward.z * forceMultiply);

                shootCount += 1;
                forceMultiply = 0f;
                PlayAudio(0, 0);
                playable = false;
                startRecord = true;
                line.SetActive(false);
                ball.GetComponent<BallController>().changeCanScore(true);
            }
        }
		hitPowerBar.value = forceMultiply;

        scoreText.text = "" + score;
    }
	void FixedUpdate() {
		if (!playable && ballRigid.velocity == Vector3.zero)
        {
            //Debug.Log("Zeroooooo");
            ResetValues();
            ball.GetComponent<BallController>().changeCanScore(true);
        } else if(ballRigid.velocity != Vector3.zero) {
			replayBtn.interactable = false;
			playable = false;
		}
	}
    public void PlayAudio(int clipIndex, float relativeForce)
    {
        aSrc.gameObject.transform.GetChild(clipIndex).GetComponent<VolumeController>().playAudioWithVolume(relativeForce);
    }
    public void Stop()
    {
        line.SetActive(true);
        ball.GetComponent<BallController>().ClearHit();
        forceMultiply = 0f;
        ballRigid.velocity = Vector3.zero;
        ballRigid.angularVelocity = Vector3.zero;
    }
    public void ResetValues()
    {
		Debug.Log("asdasd");
        replayBtn.interactable = true;
        line.SetActive(false);
        playable = true;
        startRecord = false;
    }
	void WinGame() {
		menu.SetActive(true);
		PlayerPrefs.SetInt("ShootCount", shootCount);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetFloat("Time", time);
		Stop();
		ResetValues();
	}
    void OnDestroy()
    {
        PlayerPrefs.SetInt("ShootCount", shootCount);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetFloat("Time", time);
    }
}

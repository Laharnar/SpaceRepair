using System.Collections;
using UnityEngine;

public class EndGame: MonoBehaviour {

    public MoviePlayer player1, player2;
    public Player player;
    public float waitAfterVideoLength = 11;
    public bool expectLose = true;
    public bool done = false;
    public Transform enableAfter;

    private void Start()
    {
        player = Player.PlayerSc;
    }

    private void Update()
    {
        if (done) return;
        if (expectLose)
        {
            if (player == null || player.life.isDead || Input.GetKeyDown(KeyCode.Alpha0))
            {
                EndGameVids();

            }
        }
        else
        {
            if (player != null && (player.won || Input.GetKeyDown(KeyCode.Alpha9)))
            {
                EndGameVids();
            }
        }
    }

    public void EndGameVids()
    {
        done = true;
        StartCoroutine(PlayEndVideos());
    }

    public IEnumerator PlayEndVideos()
    {
        if (player1) player1.externallyTriggerVideo = true;
        yield return new WaitForSeconds(waitAfterVideoLength);
        if(player2)player2.externallyTriggerVideo = true;

    }
}

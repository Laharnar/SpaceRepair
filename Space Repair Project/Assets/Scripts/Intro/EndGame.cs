using System.Collections;
using UnityEngine;

public class EndGame: MonoBehaviour {

    public MoviePlayer player1, player2;
    public Player player;
    public float waitAfterVideoLength = 11;

    private void Start()
    {
        player = Player.PlayerSc;
    }

    private void Update()
    {
        if (player == null || player.life.isDead || Input.GetKeyDown(KeyCode.Alpha0))
        {
            EndGameVids();
        }
    }

    public void EndGameVids()
    {
        StartCoroutine(PlayEndVideos());
    }

    public IEnumerator PlayEndVideos()
    {
        player1.externallyTriggerVideo = true;
        yield return new WaitForSeconds(waitAfterVideoLength);
        player2.externallyTriggerVideo = true;
    }
}

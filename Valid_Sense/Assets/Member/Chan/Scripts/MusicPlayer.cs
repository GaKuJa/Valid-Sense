using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private CriAtomEx.CueInfo[] SongcueInfoList;

    private CriAtomEx.CueInfo[] SEcueInfoList;
    private CriAtomExPlayer SongPlayer;
    private CriAtomExPlayer SEPlayer;
    private CriAtomExAcb SongExAcb;
    private CriAtomExAcb SEExAcb;
    private CriAtomExPlayback Songplayback;
    private CriAtomExPlayback SEplayback;
    public static MusicPlayer instance;
    public long PlayTime;
    public static int SongNum = 0;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    IEnumerator Start()
    {
        /* キューシートファイルのロード待ち */
        while (CriAtom.CueSheetsAreLoading) {
            yield return null;
        }
        /* Cue情報の取得 */
        SongExAcb = CriAtom.GetAcb("tutorialCue");
        SongcueInfoList = SongExAcb.GetCueInfoList();
        SEExAcb = CriAtom.GetAcb("SECue");
        SEcueInfoList = SEExAcb.GetCueInfoList();
        /* AtomExPlayerの生成 */
        SongPlayer = new CriAtomExPlayer(true);
        SEPlayer = new CriAtomExPlayer();    
    }
    private void Update() 
    {
        PlayTime = Songplayback.GetTimeSyncedWithAudio();
        MusicData.Timer = PlayTime;
    }
    public void Music_Play(int num)
    {
        if(SongPlayer.GetStatus() == CriAtomExPlayer.Status.Playing) 
        {
            SongPlayer.Stop();
        }
        SongPlayer.SetCue(SongExAcb,SongcueInfoList[num].name);
        Songplayback = SongPlayer.Start();
    }
    public void Music_Start(int num)
    {
        SongPlayer.SetCue(SongExAcb,SongcueInfoList[num].name);
        Songplayback = SongPlayer.Start();
    }
    public void SE_Tap(int SEtype)
    {
        SEPlayer.SetCue(SEExAcb,SEcueInfoList[SEtype].name);
        SEplayback = SEPlayer.Start();
    }
    public void SE_Tap2()
    {
        SEPlayer.SetCue(SEExAcb,SEcueInfoList[1].name);
        SEplayback = SEPlayer.Start();
    }
    public void SE_Hold()
    {
        SEPlayer.SetCue(SEExAcb,SEcueInfoList[2].name);
        SEplayback = SEPlayer.Start();
    }
}

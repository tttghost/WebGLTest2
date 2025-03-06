//using UnityEngine;
//using Unity.WebRTC;
//using NUnit.Framework;
//using System.Collections.Generic;
//using System;
//using System.Collections;

//public class TestWebRTC : MonoBehaviour
//{

//    RTCPeerConnection _pc1, _pc2;
//    List<RTCRtpSender> pc1Senders;
//    MediaStream videoStream, receiveStream;
//    DelegateOnIceConnectionChange pc1OnIceConnectionChange;
//    DelegateOnIceConnectionChange pc2OnIceConnectionChange;
//    DelegateOnIceCandidate pc1OnIceCandidate;
//    DelegateOnIceCandidate pc2OnIceCandidate;
//    DelegateOnTrack pc2Ontrack;
//    DelegateOnNegotiationNeeded pc1OnNegogationNeeded;
//    bool videoUpdateStarted;

//    private void Awake()
//    {
//        //WebRTC.Initialize(); // 3.0.0-pre.6 부터 제거되었으므로 사용하지 않음
//    }

//    private void Start()
//    {
//        pc1OnIceConnectionChange = state => { OnIceConnectionChange(_pc1, state); };
//        pc2OnIceConnectionChange = state => { OnIceConnectionChange(_pc2, state); };
//        pc1OnIceCandidate = candidate => { OnIceCandidate(_pc1, candidate); };
//        pc2OnIceCandidate = candidate => { OnIceCandidate(_pc2, candidate); };
//        pc2Ontrack = e =>
//        {
//            receiveStream.AddTrack(e.Track);
//        };
//        pc1OnNegogationNeeded = () => { StartCoroutine(PeerNegotiationNeeded(_pc1)); } ;
//    }

//    private IEnumerator PeerNegotiationNeeded(RTCPeerConnection pc1)
//    {
//        yield return null;
//    }

//    private void OnIceCandidate(RTCPeerConnection pc, RTCIceCandidate candidate)
//    {

//    }

//    private void OnIceConnectionChange(RTCPeerConnection pc, RTCIceConnectionState state)
//    {
//        if(state == RTCIceConnectionState.Connected || state == RTCIceConnectionState.Completed)
//        {

//        }
//    }



//    // Update is called once per frame
//    private void Update()
//    {
        
//    }
//}

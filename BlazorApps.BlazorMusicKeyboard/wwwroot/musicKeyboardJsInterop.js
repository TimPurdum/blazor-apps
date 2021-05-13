export function playAudio(barId) {
    const audio = document.getElementById(barId);
    if (audio.paused) {
        audio.play();
    }else{
        audio.volume = 0;
        audio.pause();
        audio.volume = 1;
        audio.currentTime = 0;
        audio.play();
    }
}

export function stopAudio(barId) {
    const audio = document.getElementById(barId);
    lowerAudio(audio);
}

export function getElementWidth(el) {
    return el.clientWidth;
}

export function getElementAtPoint(x, y) {
    return document.elementFromPoint(x, y).id;
}

export function setTopOffset(barId, heightPct, isAccidental) {
    const keybar = document.getElementById(barId);
    const totalHeight = document.getElementsByClassName('music-keyboard')[0].clientHeight;
  
    let offset = (((100 - heightPct) / 2) / 100) * totalHeight;
    if (isAccidental) {
        offset = offset - (totalHeight / 3.5);
    }
    keybar.style.marginTop = offset + 'px';
}

let AudioContext = window.AudioContext || window.webkitAudioContext;
let audioCtx = new AudioContext();
let mediaRecorder;
let audioTracks = [];
let audioChunks = [];
let currentTrack = 0;
let saveMediaRecorder;

export function startRecording(trackNumber) {
    currentTrack = trackNumber;
    console.log('current track is ' + trackNumber);
    if (mediaRecorder === undefined || mediaRecorder === null) {
        console.log('register audio elements');
        let destination = audioCtx.createMediaStreamDestination();
        registerAudioElements(destination);
        mediaRecorder = new MediaRecorder(destination.stream);
        mediaRecorder.addEventListener("dataavailable", dataAvailable);
    }
    console.log('Start recording');
    mediaRecorder.start(1000);
}


export function stopRecording() {
    console.log("stop recording");
    mediaRecorder.stop();
}


export function playback(tracks) {
    stopPlayback();
    for (let i = 0; i < tracks.length; i++) {
        let track = audioTracks[tracks[i]];
        if (track !== null) {
            track.play();
        }
    }
    console.log("Playing back");
}


export function stopPlayback() {
    for (let i = 0; i < audioTracks.length; i++) {
        let track = audioTracks[i];
        if (track !== null) {
            resetAudio(track);
        }
    }
}

export function deleteTrack(track) {
    audioTracks.splice(track, 1);
}


export function save() {
    document.body.style.cursor='wait';
    let recordingChunks = [];
    let saveAudioContext = new AudioContext();
    let recordDestination = saveAudioContext.createMediaStreamDestination();
    for (let i = 0; i < audioTracks.length; i++) {
        let track = audioTracks[i];
        let source = saveAudioContext.createMediaElementSource(track);
        source.connect(recordDestination);
    }
    saveMediaRecorder = new MediaRecorder(recordDestination.stream);
    saveMediaRecorder.addEventListener('dataavailable', (event) => {
        recordingChunks.push(event.data);
        saveMediaRecorder.addEventListener('stop', () =>{
            let blob = new Blob(recordingChunks, {
                type: 'audio/mp4'
            });
            let url = URL.createObjectURL(blob);
            let a = document.createElement('a');
            document.body.appendChild(a);
            a.style = 'display: none';
            a.href = url;
            a.download = 'xylophone_mix.mp4';
            a.click();
            window.URL.revokeObjectURL(url);
            document.body.style.cursor='default';
        });
    });
    saveMediaRecorder.start();
    
    stopPlayback();
    for (let j = 0; j < audioTracks.length; j++) {
        let track = audioTracks[j];
        track.addEventListener('ended', onTrackEnded);
        track.play();
    }
}

let endedTracks = 0;

function onTrackEnded() {
    endedTracks++;
    if (endedTracks >= audioTracks.length) {
        saveMediaRecorder.stop();
        for (let i = 0; i < audioTracks.length; i++) {
            let track = audioTracks[i];
            track.removeEventListener('ended', onTrackEnded);
        }
        
        endedTracks = 0;
    }
}


function lowerAudio(audio) {
    if (audio.volume >= 0.1){
        audio.volume = audio.volume - 0.1;
        setTimeout(() => {lowerAudio(audio)}, 20);
        return;
    }
    resetAudio(audio);
}


function resetAudio(audio) {
    audio.pause();
    audio.currentTime = 0;
    audio.volume = 1;
}


function registerAudioElements(recordDestination) {
    let audioElements = document.getElementsByTagName('audio');
    for (let i = 0; i < audioElements.length; i++) {
        let audioElement = audioElements[i];
        let source = audioCtx.createMediaElementSource(audioElement);
        source.connect(audioCtx.destination);
        source.connect(recordDestination);
    }
}


function dataAvailable (event) {
    console.log("PUSH");
    audioChunks.push(event.data);
    mediaRecorder.addEventListener("stop", recorderStop);
}


function recorderStop() {
    const audioBlob = new Blob(audioChunks);
    const audioUrl = URL.createObjectURL(audioBlob);
    audioTracks[currentTrack] = new Audio(audioUrl);
    audioChunks = [];
}
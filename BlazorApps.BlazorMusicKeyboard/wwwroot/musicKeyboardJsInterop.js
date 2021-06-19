export function registerBar(barId, audioId, heightPct, isAccidental, isPiano) {
    let keyBar = document.getElementById(barId);
    setTopOffset(keyBar, heightPct, isAccidental);
    keyBar.addEventListener('mousedown', (e) => {
        barMouseDown(audioId); 
        e.preventDefault();
    });
    keyBar.addEventListener('mouseup', (e) => {
        barMouseUp(audioId, isPiano);
        e.preventDefault();
    });
    keyBar.addEventListener('mouseout', (e) => {
        barMouseOut(audioId, isPiano);
        e.preventDefault();
    });
    keyBar.addEventListener('mouseover', (e) => {
        barMouseOver(audioId);
        e.preventDefault();
    });
    keyBar.addEventListener('touchstart', (e) => {
        barTouchStart(audioId);
        e.preventDefault();
    });
    keyBar.addEventListener('touchend', (e) => {
        barTouchEnd(audioId, isPiano);
        e.preventDefault();
    });
    keyBar.addEventListener('touchmove', (e) => {
        barTouchMove(e);
        e.preventDefault();
    });
}

function barMouseDown(audioId) {
    if (addBar(audioId)) {
        playAudio(audioId);
    }
    mouseIsDown = true;
    console.log("mouse down");
}

function barMouseUp(audioId, isPiano) {
    if (isPiano) {
        stopAudio(audioId);
    }
    removeBar(audioId);
    mouseIsDown = false;
    console.log("mouse up");
}

function barMouseOver(audioId) {
    if (mouseIsDown && addBar(audioId)) {
        playAudio(audioId);
    }
    console.log("mouse over");
}

function barMouseOut(audioId, isPiano) {
    if (isPiano) {
        stopAudio(audioId);
    }
    removeBar(audioId);
    console.log("mouse out");
}
 
function barTouchStart(audioId) {
    if (addBar(audioId)) {
        playAudio(audioId);
    }
    mouseIsDown = true;
    console.log("touch start");
}


function barTouchEnd(audioId, isPiano) {
    if (isPiano) {
        stopAudio(audioId);
    }
    removeBar(audioId);
    mouseIsDown = false;
    console.log("touch end");
}


function barTouchMove(event) {
    let newBar = document.elementFromPoint(event.touches[0].clientX, event.touches[0].clientY);
    if (newBar.classList.contains('keybar')) {
        var wasDown = null;
        for (let i = 0; i < mouseDownButtons.length; i++) {
            if (mouseDownButtons[i].startsWith(newBar.id)) {
                wasDown = mouseDownButtons[i];
                break;
            }
        }
        mouseDownButtons = [];
        if (wasDown === null) {
            let newTouchEvent = new CustomEvent('touchstart');
            newBar.dispatchEvent(newTouchEvent);    
        }
        else
        {
            mouseDownButtons.push(wasDown)
        }
    }
}

function addBar(audioId) {
    let index = mouseDownButtons.indexOf(audioId);
    if (index < 0) {
        mouseDownButtons.push(audioId);
        return true;
    }
    
    return false;
}

function removeBar(audioId) {
    let index = mouseDownButtons.indexOf(audioId);
    if (index > -1) {
        mouseDownButtons.splice(index, 1);
    }
}

let mouseDownButtons = [];
let mouseIsDown = false;

export function playAudio(audioId) {
    const audio = document.getElementById(audioId);
    console.log('play audio ' + audioId);
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

export function stopAudio(audioId) {
    const audio = document.getElementById(audioId);
    lowerAudio(audio);
}

export function getElementWidth(el) {
    return el.clientWidth;
}

export function getElementAtPoint(x, y) {
    return document.elementFromPoint(x, y).id;
}

export function setTopOffset(keyBar, heightPct, isAccidental) {
    const totalHeight = document.getElementsByClassName('music-keyboard')[0].clientHeight;
  
    let offset = (((100 - heightPct) / 2) / 100) * totalHeight;
    if (isAccidental) {
        offset = offset - (totalHeight / 3.5);
    }
    keyBar.style.marginTop = offset + 'px';
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
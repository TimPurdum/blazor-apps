export function playAudio(barId) {
  const audio = document.getElementById(barId);
  if (audio.paused) {
    audio.play();
  }else{
    audio.currentTime = 0
  }
}

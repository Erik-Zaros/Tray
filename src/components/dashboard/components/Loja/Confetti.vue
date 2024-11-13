<script setup>
import confetti from 'canvas-confetti'; // Certifique-se de instalar com npm ou incluir o CDN

function basic() {
  confetti({
    particleCount: 100,
    spread: 70,
    origin: { y: 0.6 }
  });
}

function randomDirection() {
  confetti({
    angle: randomInRange(55, 125),
    spread: randomInRange(50, 70),
    particleCount: randomInRange(50, 100),
    origin: { y: 0.6 }
  });
}

function makeItRain() {
  const button = document.getElementById("makeItRain");
  button.disabled = true;
  const end = Date.now() + 2 * 1000;
  const colors = ['#bb0000', '#ffffff'];

  function frame() {
    confetti({
      particleCount: 2,
      angle: 60,
      spread: 55,
      origin: { x: 0 },
      colors: colors
    });
    confetti({
      particleCount: 2,
      angle: 120,
      spread: 55,
      origin: { x: 1 },
      colors: colors
    });

    if (Date.now() < end) {
      requestAnimationFrame(frame);
    } else {
      button.disabled = false;
    }
  }
  frame();
}

function randomInRange(min, max) {
  return Math.random() * (max - min) + min;
}
</script>

<template>
  <div class="title">Let's partyyyyyy!</div>
  <div class="emoji-container">
    <span class="emoji">🎉</span>
    <span class="emoji">😎</span>
    <span class="emoji">🎊</span>
  </div>
  <div class="button-container">
    <button @click="basic">Basic</button>
    <button @click="randomDirection">Random direction</button>
    <button id="makeItRain" @click="makeItRain">Make it rain</button>
  </div>
</template>

<style scoped>
body {
  font-family: 'Shojumaru', cursive;
  background-color: #b38867;
}

.title {
  font-size: 100px;
  color: white;
  text-align: center;
}

.emoji-container {
  margin-bottom: 25px;
  margin-top: 25px;
  text-align: center;
}

.emoji {
  font-size: 200px;
}

.button-container {
  text-align: center;
}
</style>

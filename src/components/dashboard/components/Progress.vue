<template>
      <div class="row">
        <div class="col-md-3 col-sm-6">
          <div class="progress blue">
            <span class="progress-left">
              <span class="progress-bar" :style="leftBarStyle"></span>
            </span>
            <span class="progress-right">
              <span class="progress-bar" :style="rightBarStyle"></span>
            </span>
            <div class="progress-value text-primary fw-bold">
              {{ progress }}%
            </div>
          </div>
        </div>
      </div>
  </template>

<script setup>
import { ref, computed } from 'vue';

const progress = ref(45); 

const rightBarStyle = computed(() => {
  const progressAngle = (progress.value > 50 ? 180 : (progress.value / 50) * 180);
  return {
    transform: `rotate(${progressAngle}deg)`
  };
});

const leftBarStyle = computed(() => {
  const progressAngle = (progress.value > 50 ? (progress.value - 50) * 3.6 : 0);
  return {
    transform: `rotate(${progressAngle}deg)`
  };
});

</script>
  
  <style scoped>
  .progress {
    width: 150px;
    height: 150px;
    line-height: 150px;
    background: none;
    margin: 0 auto;
    box-shadow: none;
    position: relative;
  }
  
  .progress:after {
    content: "";
    width: 100%;
    height: 100%;
    border-radius: 50%;
    border: 12px solid #fff;
    position: absolute;
    top: 0;
    left: 0;
  }
  
  .progress>span {
    width: 50%;
    height: 100%;
    overflow: hidden;
    position: absolute;
    top: 0;
    z-index: 1;
  }
  
  .progress .progress-left {
    left: 0;
  }
  
  .progress .progress-bar {
    width: 100%;
    height: 100%;
    background: none;
    border-width: 12px;
    border-style: solid;
    position: absolute;
    top: 0;
    border-color: #e6e6e6;
  }
  
  .progress .progress-left .progress-bar {
    left: 100%;
    border-top-right-radius: 80px;
    border-bottom-right-radius: 80px;
    border-left: 0;
    transform-origin: center left;
  }
  
  .progress .progress-right {
    right: 0;
  }
  
  .progress .progress-right .progress-bar {
    left: -100%;
    border-top-left-radius: 80px;
    border-bottom-left-radius: 80px;
    border-right: 0;
    transform-origin: center right;
  }
  
  .progress-value {
    width: 90%;
    height: 90%;
    border-radius: 50%;
    background: #ffffff;
    font-size: 24px;
    line-height: 135px;
    text-align: center;
    position: absolute;
    top: 5%;
    left: 5%;
  }
  
  .progress.blue .progress-bar {
    border-color: #0d6efd; 
  }
  
  @media only screen and (max-width: 990px) {
    .progress {
      margin-bottom: 20px;
    }
  }
  </style>
  

  
<template>
  <div class="flex-row">
    <div class="box" :style="cssChangeBackground">
      <h1 class="message text-center">{{ message }}</h1>
      <h1 class="text-center">Enter grade</h1>
      <input type="number" v-model="grade" class="text-center"/>
      <button @click="addGrade"> Add </button>
      <div>
          <h1>{{ grades  }}</h1>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      grade: 0,
      message: ""
    }
  },
  computed: {
    cssChangeBackground() {
      console.log(this.message);
      if (this.message == "Passed") {
        return {
          "backgroundColor": "#189e13",
        };
      } 
      else if (this.message == "Failed") {
        return {
          "backgroundColor": "#e91e63",
        };
      } else {
        return {
          "backgroundColor": "#FFFFFF",
        };
      }
    }
  },
  methods: {
    addGrade() {
      if (this.grade >= 75) 
      {
        this.message = "Passed";
      } else if (this.grade >= 30 && this.grade < 75) {
        this.message = "Failed";
      } else {
        this.message = "";
      }
    }
  }
}
</script>


<style>
.flex-row {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  width: 100%;
  height: 100%;
  position: fixed;
  top: 0;
  left: 0;
}
.box {
  width: 280px;
  display: grid;
}
.message {
  color: #189e13;
}
.text-center {
  text-align: center;
}
</style>
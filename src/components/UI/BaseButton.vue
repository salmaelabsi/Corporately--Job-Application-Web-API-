<template>
  <button :class="mode">
    <slot></slot>
  </button>
</template>

<script>
export default {
  props: ['mode']
}
</script>

<style scoped>
button {
  padding: 0.6rem 0.6rem;
  font-family: inherit;
  background-color: #565449;
  border: 1px solid #565449;
  color: #D8CFBC;
  cursor: pointer;
  border-radius: 5px;
  margin-left: 0.5rem;
}

button:hover,
button:active {
  background-color: #6D685D;
  border-color: #6D685D;
}

.flat {
  background-color: #FFFBF4;
  color: #6D685D;
  border: none;
}

.flat:hover,
.flat:active {
  background-color: #d8cfbc;
  color: #6D685D;
}
</style>
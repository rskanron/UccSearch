<template>
  <div>
    
    <h1>Colorado UCC Search</h1>

    <input ref="searchTerm" v-on:keyup.enter="search" type="text">

    <button v-on:click="search">Search</button>

    <ul id="searchResultList" v-model="searchResults">
      <li v-for="(field, result) in searchResults">
        {{ field.debtorname }}
      </li>
    </ul>

    <br><br><br><br>

  </div>
</template>

<script>
import axios from 'axios'

  export default {
    name: 'HelloWorld',
    data () {
      return {
        searchResults: [],
        error: null,
      }
    },
    methods : {
      search (event) {
        var searchTerm = this.$refs.searchTerm.value
        var url = `http://localhost:8081?searchTerm=${searchTerm}`

        axios.get(url).then(
          (response) => { 
            if (!!response.data) {
                this.searchResults = response.data
                console.log(response.data)
              }
          }, 
          (response) => {
            this.error = response
          }
        );

      }
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  h1, h2 {
    font-weight: normal;
  }
  ul {
    list-style-type: none;
    padding: 0;
  }
  li {
    margin: 10px 0px;
  }
  a {
    color: #42b983;
  }
</style>

import Vue from 'vue'
import Router from 'vue-router'
import UccSearch from '@/components/UccSearch'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'UccSearch',
      component: UccSearch
    }
  ]
})

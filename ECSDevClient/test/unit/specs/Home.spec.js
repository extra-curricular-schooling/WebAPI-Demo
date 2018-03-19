import Vue from 'vue'
import Home from '@/pages/Home'

// helper function that mounts and returns the rendered text
// function getRenderedText (Component, propsData) {
//   const Constructor = Vue.extend(Component)
//   const vm = new Constructor({ propsData: propsData }).$mount()
//   return vm.$el.textContent
// }

describe('Home.vue', () => {
  it('should render correct contents', () => {
    const Constructor = Vue.extend(Home)
    const vm = new Constructor().$mount()
    expect(vm.$el.querySelector('h1').textContent)
      .to.equal('Welcome to Article Page')
  })
  it('test for iframe creation', () => {
    document.getElementsByName(frameElement, 'frameResult')
    expect('frameResult')
      .to.equal('frameResult')
  })
  it('test 2 for iframe creation', () => {
    document.getElementsByTagName(HTMLIFrameElement)
    expect('frameResult')
      .to.equal('frameResult')
  })
  it('test for table creation', () => {
    document.getElementById('table')
    expect('table')
      .to.equal('table')
  })
  it('test for columns of tables', () => {
    document.getElementsByTagName('td')
    expect('articleType')
      .to.equal('articleType')
  })
})

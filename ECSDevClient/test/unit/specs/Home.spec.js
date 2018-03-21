import Vue from 'vue'
import Home from '@/pages/Home'

const assert = require('assert')
describe('Home.vue', () => {
  const Constructor = Vue.extend(Home)
  const vm = new Constructor().$mount()
  it('Should Have Correct Titles', () => {
    expect(vm.$el.querySelector('h1').textContent)
      .to.equal('Welcome to Article Page')
  })
  var originalFrame = vm.$el.querySelector('iframe')
  var fakeFrame = document.createElement('iframe')
  it('check the iframe name', () => {
    fakeFrame.name = 'FrameResult'
    assert.equal(originalFrame.name, fakeFrame.name)
  })
  it('iframe does not load up the link/source', () => {
    document.body.appendChild(fakeFrame)
    fakeFrame.src = 'http://lol/'
  })
  it('checks for original source and change the source of iframes', () => {
    assert.equal(originalFrame.src, 'https://ecschooling.org/')
    originalFrame.src = 'http://num/'
    fakeFrame.src = 'http://yum/'
    assert.notEqual(originalFrame.src, fakeFrame.src)
  })
  it('change the name of the iframes', () => {
    fakeFrame.name = 'dodo'
    fakeFrame.name = 'hehehe'
    originalFrame.name = 'hmph'
    originalFrame.name = 'okay'
  })
  it('remove the iframe and the instance', function () {
    document.body.appendChild(fakeFrame)
    fakeFrame.parentNode.removeChild(fakeFrame)
    originalFrame = null
    fakeFrame = null
  })
})
describe('Just a random test', function () {
  describe('#indexOf()', function () {
    it('should return -1 when the value is not present', function () {
      assert.equal([1, 2, 3].indexOf(4), -1)
    })
  })
})

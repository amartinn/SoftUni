function solution() {
    const $elements = {
        addGiftBtn :document.querySelector('.card div button'),
        giftName : document.querySelector('.card input[type=text]'),
        listOfGifts: document.querySelectorAll('.card')[1].querySelector('ul'),
        sendGifts:document.querySelectorAll('.card')[2].querySelector('ul'),
        discardGifts:document.querySelectorAll('.card')[3].querySelector('ul')
    }
    function createHTMLElement(tagName,className,textContent,attributes,event){
        let element = document.createElement(tagName);
        if(className) element.classList.add(className)
        if(textContent) element.textContent=textContent;
        if(attributes) attributes.forEach((a) => element.setAttribute(a.k,a.v));
        if(event) element.addEventListener(event.name,event.func);
        return element;
    }
    function appendChildrenToParent(children,parent){
        children.forEach((c)=>parent.appendChild(c));
        return parent;
    }
    $elements.addGiftBtn.addEventListener('click',addGift);

   function addGift(){
        let giftname = $elements.giftName.value;
        if(!giftname){
            return;
        }
        let li = createHTMLElement('li','gift',giftname);
        let sendButton = createHTMLElement('button',null,'Send',[{k:'id',v:'sendButton'}],{name:'click',func:sendItem});
        let discardButton = createHTMLElement('button',null,'Discard',[{k:'id',v:'discardButton'}],{name:'click',func:discardItem});
        li = appendChildrenToParent([sendButton,discardButton],li);
        $elements.listOfGifts.appendChild(li);
        sortItems($elements.listOfGifts);
        $elements.giftName.value=''
   
    }
    function discardItem(){
        let currentItem = this.parentNode;
        currentItem.removeChild(currentItem.lastChild);
        currentItem.removeChild(currentItem.lastChild);
        $elements.discardGifts.appendChild(currentItem);
    }
    function sendItem(){
      let currentItem = this.parentNode;
      currentItem.removeChild(currentItem.lastChild);
      currentItem.removeChild(currentItem.lastChild);
      $elements.sendGifts.appendChild(currentItem);
    }
    function sortItems(items){
            var  i, switching, b, shouldSwitch;
            switching = true;
            while (switching) {
              switching = false;
              b = items.getElementsByTagName("LI");
              for (i = 0; i < (b.length - 1); i++) {
                shouldSwitch = false;
                if (b[i].textContent.toLowerCase() > b[i + 1].textContent.toLowerCase()) {
                  shouldSwitch = true;
                  break;
                }
              }
              if (shouldSwitch) {
                b[i].parentNode.insertBefore(b[i + 1], b[i]);
                switching = true;
              }
            }
    }
}


function solve(){
   function sortItems( items) {
      let i, switching, b, shouldSwitch;
      switching = true;
      while (switching) {
        switching = false;
        b = items.getElementsByTagName("LI");
        for (i = 0; i < (b.length - 1); i++) {
          shouldSwitch = false;
          if((b[i].innerHTML.localeCompare(b[i+1].innerHTML))===1){
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
     $elements = {
        createForm :document.querySelector('aside section form'),
        createButton : document.querySelector('.create'),
        articles: document.querySelector('.site-content main section'),
        archive: document.querySelector('.archive-section ul')
     }
    $elements.createButton.addEventListener('click',addArticle)

    function addArticle(e){
         e.preventDefault();
         let author = $elements.createForm.querySelector('#creator').value;
         let title = $elements.createForm.querySelector('#title').value;
         let category = $elements.createForm.querySelector('#category').value;
         let content = $elements.createForm.querySelector('#content').value;

      if(!author || !title || !category|| !content) return;

      let article = createHTMLElement('article');
      let h1 = createHTMLElement('h1',null,title);

      let categoryP = createHTMLElement('p',null,'Category: ');
      let categoryStrong = createHTMLElement('strong',null,category);
      categoryP.appendChild(categoryStrong);

      let creatorP = createHTMLElement('p',null,'Creator: ');
      let creatorStrong = createHTMLElement('strong',null,author);
      creatorP.appendChild(creatorStrong);

      let contentP = createHTMLElement('p',null,content);

      let div = createHTMLElement('div','buttons');
      let deleteBtn = createHTMLElement('button','btn','Delete',null,{name:'click',func:deleteArticle});
      deleteBtn.classList.add('delete')
      let archiveBtn = createHTMLElement('button','btn','Archive',null,{name:'click',func:archiveArticle});
      archiveBtn.classList.add('archive')
      div = appendChildrenToParent([deleteBtn,archiveBtn],div);

      article = appendChildrenToParent([h1,categoryP,creatorP,contentP,div],article);

      $elements.articles.appendChild(article);

    }
    function deleteArticle(){
       this.parentNode.parentNode.remove(this.parentNode.parentNode);
    }
    function archiveArticle(){
       let current = this.parentNode.parentNode;
      let title = current.querySelector('h1').textContent;
      current.remove(current);
      let li = createHTMLElement('li',null,title);
      $elements.archive.appendChild(li);
      sortItems($elements.archive);
    }
  }
